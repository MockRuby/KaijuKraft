using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MotherManager : MonoBehaviour
{
    public GameObject foodCanvasObj;
    public GameObject mineralCanvasObj;
    public GameObject feedPanelObj;
    public GameObject eggObj;
    public GameObject eggBaseObj;
    public GameObject eggShellObj;
    public GameObject getEggButtonObj;
    public GameObject continueButtonObj;

    public Button feedButton;
    public Button habitatButton;

    public Slider mammalSlider;
    public Slider avianSlider;
    public Slider aquaticSlider;
    public Slider reptileSlider;

    public Slider commonSlider;
    public Slider uncommonSlider;
    public Slider rareSlider;
    public Slider legendarySlider;

    public Slider bellyHungerSlider;

    public Image bellySliderImage;

    public SpriteRenderer eggShellSprite;
    public SpriteRenderer eggBaseSprite;

    public EggTimeManager eggClock;

    int feedPage = 0;
    float rarityWeightMin = 10.0f;
    float rarityWeightMax = 75.0f;
    float typeWeightMin = 5.0f;
    float typeWeightMax = 85.0f;

    bool readyToFeed;
    bool feedPanelActive = false;

    float prevSystemTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        feedPage = 0;
        if (BroodMotherData.motherBellySaturation < 65.0f)
        {
            readyToFeed = true;
        }
        else
        {
            readyToFeed = false;
        }

        if (BroodMotherData.eggTimer > 0)
        {
            feedButton.interactable = true;
        }
        else
        {
            feedButton.interactable = false;
        }

        UpdateSliders();
    }

    // Update is called once per frame
    void Update()
    {
        float currentSystemTime = (float)DateTime.Now.TimeOfDay.TotalSeconds;
        if (!BroodMotherData.motherBellyFull && BroodMotherData.eggTimer > 0)
        {
            if (prevSystemTime == 0)
            {
                BroodMotherData.motherBellySaturation -= 0.1f * Time.deltaTime;
            }
            else
            {
                BroodMotherData.motherBellySaturation -= (0.1f * (currentSystemTime - prevSystemTime));
            }
            BroodMotherData.motherBellySaturation = Mathf.Clamp(BroodMotherData.motherBellySaturation, 0, 100);
        }
        prevSystemTime = currentSystemTime;
        bellyHungerSlider.value = BroodMotherData.motherBellySaturation;

        if (BroodMotherData.motherBellySaturation < 100.0f)
        {
            readyToFeed = true;
        }

        if (!feedPanelActive && BroodMotherData.eggTimer > 0 && !BroodMotherData.motherBellyFull)
        {
            feedButton.interactable = true;
        }
        else
        {
            feedButton.interactable = false;
        }

        if (BroodMotherData.motherBellySaturation < 35.0f)
        {
            bellySliderImage.GetComponent<Image>().color = Color.red;
        }
        else if (BroodMotherData.motherBellySaturation < 65.0f)
        {
            bellySliderImage.GetComponent<Image>().color = Color.yellow;
        }
        else if (BroodMotherData.motherBellySaturation < 100.0f)
        {
            bellySliderImage.GetComponent<Image>().color = Color.green;
        }
        else if (BroodMotherData.motherBellySaturation <= 0.0f)
        {
            ResetWeights();
        }
        else
        {
            bellySliderImage.GetComponent<Image>().color = Color.cyan;
        }

        if (BroodMotherData.eggTimer == 0 && !BroodMotherData.getEgg)
        {
            feedButton.interactable = false;
            readyToFeed = false;
            getEggButtonObj.SetActive(true);
        }
    }

    public void EggRoll()
    {
        BroodMotherData.getEgg = true;
        getEggButtonObj.SetActive(false);
        continueButtonObj.SetActive(true);
        Color newColor;
        KaijuTraitLibrary.KaijuGatcha();

        eggObj.SetActive(false);
        eggBaseObj.SetActive(true);
        eggShellObj.SetActive(true);

        if (ColorUtility.TryParseHtmlString(KaijuTraitLibrary.eggShellColorPrimary[KaijuTraitLibrary.newKaijuTypeID], out newColor))
        {
            eggBaseSprite.color = newColor;
        }
        if (ColorUtility.TryParseHtmlString(KaijuTraitLibrary.eggShellColorSecondary[KaijuTraitLibrary.newKaijuRarityID], out newColor))
        {
            eggShellSprite.color = newColor;
        }

        KaijuTraitLibrary.BuildAndStoreSeed(KaijuTraitLibrary.newKaijuTypeID, KaijuTraitLibrary.newKaijuRarityID, KaijuTraitLibrary.newKaijuGeneID, KaijuTraitLibrary.newKaijuBaseColorID, KaijuTraitLibrary.newKaijuSecondaryColorID, KaijuTraitLibrary.newKaijuTertiaryColorID, KaijuTraitLibrary.newKaijuEyeLeftColorID, KaijuTraitLibrary.newKaijuEyeRightColorID, KaijuTraitLibrary.newKaijuAttackPts, KaijuTraitLibrary.newKaijuDefencePts, KaijuTraitLibrary.newKaijuHealthPts, KaijuTraitLibrary.newKaijuSpeedPts);
    }

    public void ResumeBreed()
    {
        BroodMotherData.eggTimer = 30f;
        BroodMotherData.getEgg = false;
        ResetWeights();
        readyToFeed = true;
        continueButtonObj.SetActive(false);
        eggBaseObj.SetActive(false);
        eggShellObj.SetActive(false);
        eggObj.SetActive(true);
    }

    public void CloseFeedPanel()
    {
        feedPanelObj.SetActive(false);

        feedPanelActive = false;
        habitatButton.interactable = true;
    }

    public void ReturnToHabitat()
    {
        SceneManager.LoadScene("Habitate");
    }

    public void OpenFeedPanel()
    {
        feedPanelObj.SetActive(true);

        if (feedPage != 0)
        {
            feedPage = 0;
            mineralCanvasObj.SetActive(false);
            foodCanvasObj.SetActive(true);
        }

        feedPanelActive = true;
        habitatButton.interactable = false;
    }

    public void SwitchFeedPage()
    {
        if (feedPage == 0)
        {
            feedPage = 1;
            foodCanvasObj.SetActive(false);
            mineralCanvasObj.SetActive(true);
        }
        else
        {
            feedPage = 0;
            mineralCanvasObj.SetActive(false);
            foodCanvasObj.SetActive(true);
        }
    }

    void ResetWeights()
    {
        BroodMotherData.mammalWeight = 25.0f;
        mammalSlider.value = BroodMotherData.mammalWeight;
        BroodMotherData.avianWeight = 25.0f;
        avianSlider.value = BroodMotherData.avianWeight;
        BroodMotherData.aquaticWeight = 25.0f;
        aquaticSlider.value = BroodMotherData.aquaticWeight;
        BroodMotherData.reptileWeight = 25.0f;
        reptileSlider.value = BroodMotherData.reptileWeight;

        BroodMotherData.commonWeight = 50.0f;
        commonSlider.value = BroodMotherData.commonWeight;
        BroodMotherData.uncommonWeight = 30.0f;
        uncommonSlider.value = BroodMotherData.uncommonWeight;
        BroodMotherData.rareWeight = 15.0f;
        rareSlider.value = BroodMotherData.rareWeight;
        BroodMotherData.legendaryWeight = 5.0f;
        legendarySlider.value = BroodMotherData.legendaryWeight;
    }

    void UpdateSliders()
    {
        mammalSlider.value = BroodMotherData.mammalWeight;
        avianSlider.value = BroodMotherData.avianWeight;
        aquaticSlider.value = BroodMotherData.aquaticWeight;
        reptileSlider.value = BroodMotherData.reptileWeight;

        commonSlider.value = BroodMotherData.commonWeight;
        uncommonSlider.value = BroodMotherData.uncommonWeight;
        rareSlider.value = BroodMotherData.rareWeight;
        legendarySlider.value = BroodMotherData.legendaryWeight;

        bellyHungerSlider.value = BroodMotherData.motherBellySaturation;
    }

    //delay before player can feed the broodmother again
    IEnumerator BellyDigest()
    {
        yield return new WaitForSeconds(30.0f);
        BroodMotherData.motherBellyFull = false;
    }

    void CapMinMaxWeights()
    {
        //kaiju type
        if (BroodMotherData.mammalWeight < typeWeightMin) //prevent weight from going below min threshold
        {
            BroodMotherData.mammalWeight = typeWeightMin;
        }
        else if (BroodMotherData.mammalWeight > typeWeightMax) //prevent weight from going beyond max threshold
        {
            BroodMotherData.mammalWeight = typeWeightMax;
        }

        if (BroodMotherData.avianWeight < typeWeightMin)
        {
            BroodMotherData.avianWeight = typeWeightMin;
        }
        else if (BroodMotherData.avianWeight > typeWeightMax)
        {
            BroodMotherData.avianWeight = typeWeightMax;
        }

        if (BroodMotherData.aquaticWeight < typeWeightMin)
        {
            BroodMotherData.aquaticWeight = typeWeightMin;
        }
        else if (BroodMotherData.aquaticWeight > typeWeightMax)
        {
            BroodMotherData.aquaticWeight = typeWeightMax;
        }

        if (BroodMotherData.reptileWeight < typeWeightMin)
        {
            BroodMotherData.reptileWeight = typeWeightMin;
        }
        else if (BroodMotherData.reptileWeight > typeWeightMax)
        {
            BroodMotherData.reptileWeight = typeWeightMax;
        }

        //rarity
        if (BroodMotherData.commonWeight < rarityWeightMin)
        {
            BroodMotherData.commonWeight = rarityWeightMin;
        }
        else if (BroodMotherData.commonWeight > rarityWeightMax)
        {
            BroodMotherData.commonWeight = rarityWeightMax;
        }

        if (BroodMotherData.uncommonWeight < rarityWeightMin)
        {
            BroodMotherData.uncommonWeight = rarityWeightMin;
        }
        else if (BroodMotherData.uncommonWeight > rarityWeightMax)
        {
            BroodMotherData.uncommonWeight = rarityWeightMax;
        }

        if (BroodMotherData.rareWeight < rarityWeightMin)
        {
            BroodMotherData.rareWeight = rarityWeightMin;
        }
        else if (BroodMotherData.rareWeight > rarityWeightMax)
        {
            BroodMotherData.rareWeight = rarityWeightMax;
        }

        if (BroodMotherData.legendaryWeight < rarityWeightMin)
        {
            BroodMotherData.legendaryWeight = rarityWeightMin;
        }
        else if (BroodMotherData.legendaryWeight > rarityWeightMax)
        {
            BroodMotherData.legendaryWeight = rarityWeightMax;
        }

        if (BroodMotherData.motherBellySaturation >= 100.0f)
        {
            BroodMotherData.motherBellySaturation = 100.0f;
            BroodMotherData.motherBellyFull = true;
            readyToFeed = false;
            StartCoroutine(BellyDigest());
        }

        UpdateSliders();
    }

    //mammal food stuff
    public void GiveFood01()
    {
        if (readyToFeed)
        {
            BroodMotherData.motherBellySaturation += 0.5f;
            BroodMotherData.mammalWeight += 0.3f;
            BroodMotherData.avianWeight -= 0.1f;
            BroodMotherData.aquaticWeight -= 0.1f;
            BroodMotherData.reptileWeight -= 0.1f;

            CapMinMaxWeights();
        }
    }

    public void GiveFood02()
    {
        if (readyToFeed)
        {
            BroodMotherData.motherBellySaturation += 1.0f;
            BroodMotherData.mammalWeight += 0.6f;
            BroodMotherData.avianWeight -= 0.2f;
            BroodMotherData.aquaticWeight -= 0.2f;
            BroodMotherData.reptileWeight -= 0.2f;

            BroodMotherData.commonWeight -= 0.22f;
            BroodMotherData.uncommonWeight += 0.5f;
            BroodMotherData.rareWeight -= 0.12f;
            BroodMotherData.legendaryWeight -= 0.16f;

            CapMinMaxWeights();
        }
    }

    public void GiveFood03()
    {
        if (readyToFeed)
        {
            BroodMotherData.motherBellySaturation += 1.5f;
            BroodMotherData.mammalWeight += 0.9f;
            BroodMotherData.avianWeight -= 0.3f;
            BroodMotherData.aquaticWeight -= 0.3f;
            BroodMotherData.reptileWeight -= 0.3f;

            BroodMotherData.commonWeight -= 0.32f;
            BroodMotherData.uncommonWeight += 0.75f;
            BroodMotherData.rareWeight -= 0.22f;
            BroodMotherData.legendaryWeight -= 0.21f;

            CapMinMaxWeights();
        }
    }

    public void GiveFood04()
    {
        if (readyToFeed)
        {
            BroodMotherData.motherBellySaturation += 2.0f;
            BroodMotherData.mammalWeight += 1.2f;
            BroodMotherData.avianWeight -= 0.4f;
            BroodMotherData.aquaticWeight -= 0.4f;
            BroodMotherData.reptileWeight -= 0.4f;

            BroodMotherData.commonWeight -= 0.3f;
            BroodMotherData.uncommonWeight += 0.3f;

            CapMinMaxWeights();
        }
    }

    //avian food stuff
    public void GiveFood05()
    {
        if (readyToFeed)
        {
            BroodMotherData.motherBellySaturation += 0.5f;
            BroodMotherData.mammalWeight -= 0.1f;
            BroodMotherData.avianWeight += 0.3f;
            BroodMotherData.aquaticWeight -= 0.1f;
            BroodMotherData.reptileWeight -= 0.1f;

            CapMinMaxWeights();
        }
    }

    public void GiveFood06()
    {
        if (readyToFeed)
        {
            BroodMotherData.motherBellySaturation += 1.0f;
            BroodMotherData.mammalWeight -= 0.2f;
            BroodMotherData.avianWeight += 0.6f;
            BroodMotherData.aquaticWeight -= 0.2f;
            BroodMotherData.reptileWeight -= 0.2f;

            BroodMotherData.commonWeight -= 0.22f;
            BroodMotherData.uncommonWeight += 0.5f;
            BroodMotherData.rareWeight -= 0.12f;
            BroodMotherData.legendaryWeight -= 0.16f;

            CapMinMaxWeights();
        }
    }

    public void GiveFood07()
    {
        if (readyToFeed)
        {
            BroodMotherData.motherBellySaturation += 1.5f;
            BroodMotherData.mammalWeight -= 0.3f;
            BroodMotherData.avianWeight += 0.9f;
            BroodMotherData.aquaticWeight -= 0.3f;
            BroodMotherData.reptileWeight -= 0.3f;

            BroodMotherData.commonWeight -= 0.32f;
            BroodMotherData.uncommonWeight += 0.75f;
            BroodMotherData.rareWeight -= 0.22f;
            BroodMotherData.legendaryWeight -= 0.21f;

            CapMinMaxWeights();
        }
    }

    public void GiveFood08()
    {
        if (readyToFeed)
        {
            BroodMotherData.motherBellySaturation += 2.0f;
            BroodMotherData.mammalWeight -= 0.4f;
            BroodMotherData.avianWeight += 1.2f;
            BroodMotherData.aquaticWeight -= 0.4f;
            BroodMotherData.reptileWeight -= 0.4f;

            BroodMotherData.commonWeight -= 0.3f;
            BroodMotherData.uncommonWeight += 0.3f;

            CapMinMaxWeights();
        }
    }

    //aquatic food stuff
    public void GiveFood09()
    {
        if (readyToFeed)
        {
            BroodMotherData.motherBellySaturation += 0.5f;
            BroodMotherData.mammalWeight -= 0.1f;
            BroodMotherData.avianWeight -= 0.1f;
            BroodMotherData.aquaticWeight += 0.3f;
            BroodMotherData.reptileWeight -= 0.1f;

            CapMinMaxWeights();
        }
    }

    public void GiveFood10()
    {
        if (readyToFeed)
        {
            BroodMotherData.motherBellySaturation += 1.0f;
            BroodMotherData.mammalWeight -= 0.2f;
            BroodMotherData.avianWeight -= 0.2f;
            BroodMotherData.aquaticWeight += 0.6f;
            BroodMotherData.reptileWeight -= 0.2f;

            BroodMotherData.commonWeight -= 0.22f;
            BroodMotherData.uncommonWeight += 0.5f;
            BroodMotherData.rareWeight -= 0.12f;
            BroodMotherData.legendaryWeight -= 0.16f;

            CapMinMaxWeights();
        }
    }

    public void GiveFood11()
    {
        if (readyToFeed)
        {
            BroodMotherData.motherBellySaturation += 1.5f;
            BroodMotherData.mammalWeight -= 0.3f;
            BroodMotherData.avianWeight -= 0.3f;
            BroodMotherData.aquaticWeight += 0.9f;
            BroodMotherData.reptileWeight -= 0.3f;

            BroodMotherData.commonWeight -= 0.32f;
            BroodMotherData.uncommonWeight += 0.75f;
            BroodMotherData.rareWeight -= 0.22f;
            BroodMotherData.legendaryWeight -= 0.21f;

            CapMinMaxWeights();
        }
    }

    public void GiveFood12()
    {
        if (readyToFeed)
        {
            BroodMotherData.motherBellySaturation += 2.0f;
            BroodMotherData.mammalWeight -= 0.4f;
            BroodMotherData.avianWeight -= 0.4f;
            BroodMotherData.aquaticWeight += 1.2f;
            BroodMotherData.reptileWeight -= 0.4f;

            BroodMotherData.commonWeight -= 0.3f;
            BroodMotherData.uncommonWeight += 0.3f;

            CapMinMaxWeights();
        }
    }

    //reptile food stuff
    public void GiveFood13()
    {
        if (readyToFeed)
        {
            BroodMotherData.motherBellySaturation += 0.5f;
            BroodMotherData.mammalWeight -= 0.1f;
            BroodMotherData.avianWeight -= 0.1f;
            BroodMotherData.aquaticWeight -= 0.1f;
            BroodMotherData.reptileWeight += 0.3f;

            CapMinMaxWeights();
        }
    }

    public void GiveFood14()
    {
        if (readyToFeed)
        {
            BroodMotherData.motherBellySaturation += 1.0f;
            BroodMotherData.mammalWeight -= 0.2f;
            BroodMotherData.avianWeight -= 0.2f;
            BroodMotherData.aquaticWeight -= 0.2f;
            BroodMotherData.reptileWeight -= 0.6f;

            BroodMotherData.commonWeight -= 0.22f;
            BroodMotherData.uncommonWeight += 0.5f;
            BroodMotherData.rareWeight -= 0.12f;
            BroodMotherData.legendaryWeight -= 0.16f;

            CapMinMaxWeights();
        }
    }

    public void GiveFood15()
    {
        if (readyToFeed)
        {
            BroodMotherData.motherBellySaturation += 1.5f;
            BroodMotherData.mammalWeight -= 0.3f;
            BroodMotherData.avianWeight -= 0.3f;
            BroodMotherData.aquaticWeight -= 0.3f;
            BroodMotherData.reptileWeight += 0.9f;

            BroodMotherData.commonWeight -= 0.32f;
            BroodMotherData.uncommonWeight += 0.75f;
            BroodMotherData.rareWeight -= 0.22f;
            BroodMotherData.legendaryWeight -= 0.21f;

            CapMinMaxWeights();
        }
    }
    public void GiveFood16()
    {
        if (readyToFeed)
        {
            BroodMotherData.motherBellySaturation += 2.0f;
            BroodMotherData.mammalWeight -= 0.4f;
            BroodMotherData.avianWeight -= 0.4f;
            BroodMotherData.aquaticWeight -= 0.4f;
            BroodMotherData.reptileWeight += 1.2f;

            BroodMotherData.commonWeight -= 0.3f;
            BroodMotherData.uncommonWeight += 0.3f;

            CapMinMaxWeights();
        }
    }

    //////////////////////////////////////////
    //////////////////////////////////////////
    //mammal mineral stuff
    public void GiveMineral01()
    {
        if (readyToFeed)
        {
            BroodMotherData.motherBellySaturation += 0.3f;
            BroodMotherData.mammalWeight += 5.55f;
            BroodMotherData.avianWeight -= 1.85f;
            BroodMotherData.aquaticWeight -= 1.85f;
            BroodMotherData.reptileWeight -= 1.85f;

            CapMinMaxWeights();
        }
    }

    public void GiveMineral02()
    {
        if (readyToFeed)
        {
            BroodMotherData.motherBellySaturation += 0.6f;
            BroodMotherData.mammalWeight += 3.0f;
            BroodMotherData.avianWeight += 0.5f;
            BroodMotherData.aquaticWeight -= 1.5f;
            BroodMotherData.reptileWeight -= 2.0f;

            BroodMotherData.commonWeight -= 2.25f;
            BroodMotherData.uncommonWeight += 1.5f;
            BroodMotherData.rareWeight += 0.5f;
            BroodMotherData.legendaryWeight += 0.25f;

            CapMinMaxWeights();
        }
    }

    public void GiveMineral03()
    {
        if (readyToFeed)
        {
            BroodMotherData.motherBellySaturation += 0.9f;
            BroodMotherData.mammalWeight += 5.0f;
            BroodMotherData.avianWeight += 1.5f;
            BroodMotherData.aquaticWeight += 0.5f;
            BroodMotherData.reptileWeight -= 7.0f;

            BroodMotherData.commonWeight -= 1.5f;
            BroodMotherData.uncommonWeight -= 0.5f;
            BroodMotherData.rareWeight += 1.5f;
            BroodMotherData.legendaryWeight += 0.5f;

            CapMinMaxWeights();
        }
    }

    //avian minerals
    public void GiveMineral04()
    {
        if (readyToFeed)
        {
            BroodMotherData.motherBellySaturation += 0.3f;
            BroodMotherData.avianWeight += 5.55f;
            BroodMotherData.mammalWeight -= 1.85f;
            BroodMotherData.aquaticWeight -= 1.85f;
            BroodMotherData.reptileWeight -= 1.85f;

            CapMinMaxWeights();
        }
    }
    
    public void GiveMineral05()
    {
        if (readyToFeed)
        {
            BroodMotherData.motherBellySaturation += 0.6f;
            BroodMotherData.avianWeight += 3.0f;
            BroodMotherData.mammalWeight += 0.5f;
            BroodMotherData.reptileWeight -= 1.5f;
            BroodMotherData.aquaticWeight -= 2.0f;

            BroodMotherData.commonWeight -= 2.25f;
            BroodMotherData.uncommonWeight += 1.5f;
            BroodMotherData.rareWeight += 0.5f;
            BroodMotherData.legendaryWeight += 0.25f;

            CapMinMaxWeights();
        }
    }

    public void GiveMineral06()
    {
        if (readyToFeed)
        {
            BroodMotherData.motherBellySaturation += 0.9f;
            BroodMotherData.avianWeight += 5.0f;
            BroodMotherData.mammalWeight += 1.5f;
            BroodMotherData.reptileWeight += 0.5f;
            BroodMotherData.aquaticWeight -= 7.0f;

            BroodMotherData.commonWeight -= 1.5f;
            BroodMotherData.uncommonWeight -= 0.5f;
            BroodMotherData.rareWeight += 1.5f;
            BroodMotherData.legendaryWeight += 0.5f;

            CapMinMaxWeights();
        }
    }

    //aquatic minerals
    public void GiveMineral07()
    {
        if (readyToFeed)
        {
            BroodMotherData.motherBellySaturation += 0.3f;
            BroodMotherData.aquaticWeight += 5.55f;
            BroodMotherData.avianWeight -= 1.85f;
            BroodMotherData.mammalWeight -= 1.85f;
            BroodMotherData.reptileWeight -= 1.85f;

            CapMinMaxWeights();
        }
    }

    public void GiveMineral08()
    {
        if (readyToFeed)
        {
            BroodMotherData.motherBellySaturation += 0.6f;
            BroodMotherData.aquaticWeight += 3.0f;
            BroodMotherData.reptileWeight += 0.5f;
            BroodMotherData.mammalWeight -= 1.5f;
            BroodMotherData.avianWeight -= 2.0f;

            BroodMotherData.commonWeight -= 2.25f;
            BroodMotherData.uncommonWeight += 1.5f;
            BroodMotherData.rareWeight += 0.5f;
            BroodMotherData.legendaryWeight += 0.25f;

            CapMinMaxWeights();
        }
    }
    
    public void GiveMineral09()
    {
        if (readyToFeed)
        {
            BroodMotherData.motherBellySaturation += 0.9f;
            BroodMotherData.aquaticWeight += 5.0f;
            BroodMotherData.reptileWeight += 1.5f;
            BroodMotherData.mammalWeight += 0.5f;
            BroodMotherData.avianWeight -= 7.0f;

            BroodMotherData.commonWeight -= 1.5f;
            BroodMotherData.uncommonWeight -= 0.5f;
            BroodMotherData.rareWeight += 1.5f;
            BroodMotherData.legendaryWeight += 0.5f;

            CapMinMaxWeights();
        }
    }
    //reptilian mineral stuff
    public void GiveMineral10()
    {
        if (readyToFeed)
        {
            BroodMotherData.motherBellySaturation += 0.3f;
            BroodMotherData.reptileWeight += 5.55f;
            BroodMotherData.avianWeight -= 1.85f;
            BroodMotherData.aquaticWeight -= 1.85f;
            BroodMotherData.mammalWeight -= 1.85f;

            CapMinMaxWeights();
        }
    }

    public void GiveMineral11()
    {
        if (readyToFeed)
        {
            BroodMotherData.motherBellySaturation += 0.6f;
            BroodMotherData.reptileWeight += 3.0f;
            BroodMotherData.aquaticWeight += 0.5f;
            BroodMotherData.avianWeight -= 1.5f;
            BroodMotherData.mammalWeight -= 2.0f;

            BroodMotherData.commonWeight -= 2.25f;
            BroodMotherData.uncommonWeight += 1.5f;
            BroodMotherData.rareWeight += 0.5f;
            BroodMotherData.legendaryWeight += 0.25f;

            CapMinMaxWeights();
        }
    }

    public void GiveMineral12()
    {
        if (readyToFeed)
        {
            BroodMotherData.motherBellySaturation += 0.9f;
            BroodMotherData.reptileWeight += 5.0f;
            BroodMotherData.aquaticWeight += 1.5f;
            BroodMotherData.avianWeight += 0.5f;
            BroodMotherData.mammalWeight -= 7.0f;

            BroodMotherData.commonWeight -= 1.5f;
            BroodMotherData.uncommonWeight -= 0.5f;
            BroodMotherData.rareWeight += 1.5f;
            BroodMotherData.legendaryWeight += 0.5f;

            CapMinMaxWeights();
        }
    }

    //rarity chance modifiers
    public void GiveMineral13()
    {
        if (readyToFeed)
        {
            BroodMotherData.motherBellySaturation += 0.3f;
            BroodMotherData.commonWeight -= 6.5f;
            BroodMotherData.uncommonWeight += 4.0f;
            BroodMotherData.rareWeight += 2.0f;
            BroodMotherData.legendaryWeight += 0.5f;

            CapMinMaxWeights();
        }
    }

    public void GiveMineral14()
    {
        if (readyToFeed)
        {
            BroodMotherData.motherBellySaturation += 0.6f;
            BroodMotherData.commonWeight -= 10.5f;
            BroodMotherData.uncommonWeight += 8.0f;
            BroodMotherData.rareWeight += 2.5f;

            CapMinMaxWeights();
        }
    }

    public void GiveMineral15()
    {
        if (readyToFeed)
        {
            BroodMotherData.motherBellySaturation += 1.0f;
            BroodMotherData.commonWeight -= 8.0f;
            BroodMotherData.uncommonWeight += 3.0f;
            BroodMotherData.rareWeight += 5.0f;
            BroodMotherData.legendaryWeight += 2.0f;

            CapMinMaxWeights();
        }
    }
    public void GiveMineral16()
    {
        if (readyToFeed)
        {
            BroodMotherData.motherBellySaturation += 8.0f;
            BroodMotherData.commonWeight -= 7.5f;
            BroodMotherData.uncommonWeight -= 2.0f;
            BroodMotherData.rareWeight += 3.0f;
            BroodMotherData.legendaryWeight += 6.5f;

            CapMinMaxWeights();
        }
    }
}
