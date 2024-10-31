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

    float prevSystemTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        feedPage = 0;
        if (KaijuTraitLibrary.motherBellySaturation < 65.0f)
        {
            readyToFeed = true;
        }
        else
        {
            readyToFeed = false;
        }

        if (eggClock.eggTimer > 0)
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
        if (!KaijuTraitLibrary.motherBellyFull || eggClock.eggTimer > 0)
        {
            if (prevSystemTime == 0)
            {
                KaijuTraitLibrary.motherBellySaturation -= 0.01f * Time.deltaTime;
            }
            else
            {
                KaijuTraitLibrary.motherBellySaturation -= (currentSystemTime - prevSystemTime);
            }
            KaijuTraitLibrary.motherBellySaturation = Mathf.Clamp(KaijuTraitLibrary.motherBellySaturation, 0, 100);
        }
        prevSystemTime = currentSystemTime;
        bellyHungerSlider.value = KaijuTraitLibrary.motherBellySaturation;

        if (KaijuTraitLibrary.motherBellySaturation < 65.0f)
        {
            readyToFeed = true;
        }

        if (KaijuTraitLibrary.motherBellySaturation < 35.0f)
        {
            bellySliderImage.GetComponent<Image>().color = Color.red;
        }
        else if (KaijuTraitLibrary.motherBellySaturation < 65.0f)
        {
            bellySliderImage.GetComponent<Image>().color = Color.yellow;
        }
        else if (KaijuTraitLibrary.motherBellySaturation < 100.0f)
        {
            bellySliderImage.GetComponent<Image>().color = Color.green;
        }
        else if (KaijuTraitLibrary.motherBellySaturation <= 0.0f)
        {
            ResetWeights();
        }
        else
        {
            bellySliderImage.GetComponent<Image>().color = Color.cyan;
        }
    }

    public void EggRoll()
    {
        getEggButtonObj.SetActive(false);
        Color newColor;
        KaijuTraitLibrary.KaijuGatcha();

        eggObj.SetActive(false);
        eggBaseObj.SetActive(true);
        eggShellObj.SetActive(true);

        if (ColorUtility.TryParseHtmlString(KaijuTraitLibrary.EggShellColorPrimary[KaijuTraitLibrary.newKaijuTypeID], out newColor))
        {
            eggBaseSprite.color = newColor;
        }
        if (ColorUtility.TryParseHtmlString(KaijuTraitLibrary.EggShellColorSecondary[KaijuTraitLibrary.newKaijuRarityID], out newColor))
        {
            eggShellSprite.color = newColor;
        }
    }

    public void CloseFeedPanel()
    {
        feedPanelObj.SetActive(false);

        feedButton.interactable = true;
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

        feedButton.interactable = false;
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
        KaijuTraitLibrary.mammalWeight = 25.0f;
        mammalSlider.value = KaijuTraitLibrary.mammalWeight;
        KaijuTraitLibrary.avianWeight = 25.0f;
        avianSlider.value = KaijuTraitLibrary.avianWeight;
        KaijuTraitLibrary.aquaticWeight = 25.0f;
        aquaticSlider.value = KaijuTraitLibrary.aquaticWeight;
        KaijuTraitLibrary.reptileWeight = 25.0f;
        reptileSlider.value = KaijuTraitLibrary.reptileWeight;

        KaijuTraitLibrary.commonWeight = 50.0f;
        commonSlider.value = KaijuTraitLibrary.commonWeight;
        KaijuTraitLibrary.uncommonWeight = 30.0f;
        uncommonSlider.value = KaijuTraitLibrary.uncommonWeight;
        KaijuTraitLibrary.rareWeight = 15.0f;
        rareSlider.value = KaijuTraitLibrary.rareWeight;
        KaijuTraitLibrary.legendaryWeight = 5.0f;
        legendarySlider.value = KaijuTraitLibrary.legendaryWeight;
    }

    void UpdateSliders()
    {
        mammalSlider.value = KaijuTraitLibrary.mammalWeight;
        avianSlider.value = KaijuTraitLibrary.avianWeight;
        aquaticSlider.value = KaijuTraitLibrary.aquaticWeight;
        reptileSlider.value = KaijuTraitLibrary.reptileWeight;

        commonSlider.value = KaijuTraitLibrary.commonWeight;
        uncommonSlider.value = KaijuTraitLibrary.uncommonWeight;
        rareSlider.value = KaijuTraitLibrary.rareWeight;
        legendarySlider.value = KaijuTraitLibrary.legendaryWeight;

        bellyHungerSlider.value = KaijuTraitLibrary.motherBellySaturation;
    }

    //delay before player can feed the broodmother again
    IEnumerator BellyDigest()
    {
        yield return new WaitForSeconds(30.0f);
        KaijuTraitLibrary.motherBellyFull = false;
    }

    void CapMinMaxWeights()
    {
        //kaiju type
        if (KaijuTraitLibrary.mammalWeight < typeWeightMin) //prevent weight from going below min threshold
        {
            KaijuTraitLibrary.mammalWeight = typeWeightMin;
        }
        else if (KaijuTraitLibrary.mammalWeight > typeWeightMax) //prevent weight from going beyond max threshold
        {
            KaijuTraitLibrary.mammalWeight = typeWeightMax;
        }

        if (KaijuTraitLibrary.avianWeight < typeWeightMin)
        {
            KaijuTraitLibrary.avianWeight = typeWeightMin;
        }
        else if (KaijuTraitLibrary.avianWeight > typeWeightMax)
        {
            KaijuTraitLibrary.avianWeight = typeWeightMax;
        }

        if (KaijuTraitLibrary.aquaticWeight < typeWeightMin)
        {
            KaijuTraitLibrary.aquaticWeight = typeWeightMin;
        }
        else if (KaijuTraitLibrary.aquaticWeight > typeWeightMax)
        {
            KaijuTraitLibrary.aquaticWeight = typeWeightMax;
        }

        if (KaijuTraitLibrary.reptileWeight < typeWeightMin)
        {
            KaijuTraitLibrary.reptileWeight = typeWeightMin;
        }
        else if (KaijuTraitLibrary.reptileWeight > typeWeightMax)
        {
            KaijuTraitLibrary.reptileWeight = typeWeightMax;
        }

        //rarity
        if (KaijuTraitLibrary.commonWeight < rarityWeightMin)
        {
            KaijuTraitLibrary.commonWeight = rarityWeightMin;
        }
        else if (KaijuTraitLibrary.commonWeight > rarityWeightMax)
        {
            KaijuTraitLibrary.commonWeight = rarityWeightMax;
        }

        if (KaijuTraitLibrary.uncommonWeight < rarityWeightMin)
        {
            KaijuTraitLibrary.uncommonWeight = rarityWeightMin;
        }
        else if (KaijuTraitLibrary.uncommonWeight > rarityWeightMax)
        {
            KaijuTraitLibrary.uncommonWeight = rarityWeightMax;
        }

        if (KaijuTraitLibrary.rareWeight < rarityWeightMin)
        {
            KaijuTraitLibrary.rareWeight = rarityWeightMin;
        }
        else if (KaijuTraitLibrary.rareWeight > rarityWeightMax)
        {
            KaijuTraitLibrary.rareWeight = rarityWeightMax;
        }

        if (KaijuTraitLibrary.legendaryWeight < rarityWeightMin)
        {
            KaijuTraitLibrary.legendaryWeight = rarityWeightMin;
        }
        else if (KaijuTraitLibrary.legendaryWeight > rarityWeightMax)
        {
            KaijuTraitLibrary.legendaryWeight = rarityWeightMax;
        }

        if (KaijuTraitLibrary.motherBellySaturation >= 100.0f)
        {
            KaijuTraitLibrary.motherBellySaturation = 100.0f;
            KaijuTraitLibrary.motherBellyFull = true;
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
            KaijuTraitLibrary.motherBellySaturation += 0.5f;
            KaijuTraitLibrary.mammalWeight += 0.3f;
            KaijuTraitLibrary.avianWeight -= 0.1f;
            KaijuTraitLibrary.aquaticWeight -= 0.1f;
            KaijuTraitLibrary.reptileWeight -= 0.1f;

            CapMinMaxWeights();
        }
    }

    public void GiveFood02()
    {
        if (readyToFeed)
        {
            KaijuTraitLibrary.motherBellySaturation += 1.0f;
            KaijuTraitLibrary.mammalWeight += 0.6f;
            KaijuTraitLibrary.avianWeight -= 0.2f;
            KaijuTraitLibrary.aquaticWeight -= 0.2f;
            KaijuTraitLibrary.reptileWeight -= 0.2f;

            KaijuTraitLibrary.commonWeight -= 0.22f;
            KaijuTraitLibrary.uncommonWeight += 0.5f;
            KaijuTraitLibrary.rareWeight -= 0.12f;
            KaijuTraitLibrary.legendaryWeight -= 0.16f;

            CapMinMaxWeights();
        }
    }

    public void GiveFood03()
    {
        if (readyToFeed)
        {
            KaijuTraitLibrary.motherBellySaturation += 1.5f;
            KaijuTraitLibrary.mammalWeight += 0.9f;
            KaijuTraitLibrary.avianWeight -= 0.3f;
            KaijuTraitLibrary.aquaticWeight -= 0.3f;
            KaijuTraitLibrary.reptileWeight -= 0.3f;

            KaijuTraitLibrary.commonWeight -= 0.32f;
            KaijuTraitLibrary.uncommonWeight += 0.75f;
            KaijuTraitLibrary.rareWeight -= 0.22f;
            KaijuTraitLibrary.legendaryWeight -= 0.21f;

            CapMinMaxWeights();
        }
    }

    public void GiveFood04()
    {
        if (readyToFeed)
        {
            KaijuTraitLibrary.motherBellySaturation += 2.0f;
            KaijuTraitLibrary.mammalWeight += 1.2f;
            KaijuTraitLibrary.avianWeight -= 0.4f;
            KaijuTraitLibrary.aquaticWeight -= 0.4f;
            KaijuTraitLibrary.reptileWeight -= 0.4f;

            KaijuTraitLibrary.commonWeight -= 0.3f;
            KaijuTraitLibrary.uncommonWeight += 0.3f;

            CapMinMaxWeights();
        }
    }

    //avian food stuff
    public void GiveFood05()
    {
        if (readyToFeed)
        {
            KaijuTraitLibrary.motherBellySaturation += 0.5f;
            KaijuTraitLibrary.mammalWeight -= 0.1f;
            KaijuTraitLibrary.avianWeight += 0.3f;
            KaijuTraitLibrary.aquaticWeight -= 0.1f;
            KaijuTraitLibrary.reptileWeight -= 0.1f;

            CapMinMaxWeights();
        }
    }

    public void GiveFood06()
    {
        if (readyToFeed)
        {
            KaijuTraitLibrary.motherBellySaturation += 1.0f;
            KaijuTraitLibrary.mammalWeight -= 0.2f;
            KaijuTraitLibrary.avianWeight += 0.6f;
            KaijuTraitLibrary.aquaticWeight -= 0.2f;
            KaijuTraitLibrary.reptileWeight -= 0.2f;

            KaijuTraitLibrary.commonWeight -= 0.22f;
            KaijuTraitLibrary.uncommonWeight += 0.5f;
            KaijuTraitLibrary.rareWeight -= 0.12f;
            KaijuTraitLibrary.legendaryWeight -= 0.16f;

            CapMinMaxWeights();
        }
    }

    public void GiveFood07()
    {
        if (readyToFeed)
        {
            KaijuTraitLibrary.motherBellySaturation += 1.5f;
            KaijuTraitLibrary.mammalWeight -= 0.3f;
            KaijuTraitLibrary.avianWeight += 0.9f;
            KaijuTraitLibrary.aquaticWeight -= 0.3f;
            KaijuTraitLibrary.reptileWeight -= 0.3f;

            KaijuTraitLibrary.commonWeight -= 0.32f;
            KaijuTraitLibrary.uncommonWeight += 0.75f;
            KaijuTraitLibrary.rareWeight -= 0.22f;
            KaijuTraitLibrary.legendaryWeight -= 0.21f;

            CapMinMaxWeights();
        }
    }

    public void GiveFood08()
    {
        if (readyToFeed)
        {
            KaijuTraitLibrary.motherBellySaturation += 2.0f;
            KaijuTraitLibrary.mammalWeight -= 0.4f;
            KaijuTraitLibrary.avianWeight += 1.2f;
            KaijuTraitLibrary.aquaticWeight -= 0.4f;
            KaijuTraitLibrary.reptileWeight -= 0.4f;

            KaijuTraitLibrary.commonWeight -= 0.3f;
            KaijuTraitLibrary.uncommonWeight += 0.3f;

            CapMinMaxWeights();
        }
    }

    //aquatic food stuff
    public void GiveFood09()
    {
        if (readyToFeed)
        {
            KaijuTraitLibrary.motherBellySaturation += 0.5f;
            KaijuTraitLibrary.mammalWeight -= 0.1f;
            KaijuTraitLibrary.avianWeight -= 0.1f;
            KaijuTraitLibrary.aquaticWeight += 0.3f;
            KaijuTraitLibrary.reptileWeight -= 0.1f;

            CapMinMaxWeights();
        }
    }

    public void GiveFood10()
    {
        if (readyToFeed)
        {
            KaijuTraitLibrary.motherBellySaturation += 1.0f;
            KaijuTraitLibrary.mammalWeight -= 0.2f;
            KaijuTraitLibrary.avianWeight -= 0.2f;
            KaijuTraitLibrary.aquaticWeight += 0.6f;
            KaijuTraitLibrary.reptileWeight -= 0.2f;

            KaijuTraitLibrary.commonWeight -= 0.22f;
            KaijuTraitLibrary.uncommonWeight += 0.5f;
            KaijuTraitLibrary.rareWeight -= 0.12f;
            KaijuTraitLibrary.legendaryWeight -= 0.16f;

            CapMinMaxWeights();
        }
    }

    public void GiveFood11()
    {
        if (readyToFeed)
        {
            KaijuTraitLibrary.motherBellySaturation += 1.5f;
            KaijuTraitLibrary.mammalWeight -= 0.3f;
            KaijuTraitLibrary.avianWeight -= 0.3f;
            KaijuTraitLibrary.aquaticWeight += 0.9f;
            KaijuTraitLibrary.reptileWeight -= 0.3f;

            KaijuTraitLibrary.commonWeight -= 0.32f;
            KaijuTraitLibrary.uncommonWeight += 0.75f;
            KaijuTraitLibrary.rareWeight -= 0.22f;
            KaijuTraitLibrary.legendaryWeight -= 0.21f;

            CapMinMaxWeights();
        }
    }

    public void GiveFood12()
    {
        if (readyToFeed)
        {
            KaijuTraitLibrary.motherBellySaturation += 2.0f;
            KaijuTraitLibrary.mammalWeight -= 0.4f;
            KaijuTraitLibrary.avianWeight -= 0.4f;
            KaijuTraitLibrary.aquaticWeight += 1.2f;
            KaijuTraitLibrary.reptileWeight -= 0.4f;

            KaijuTraitLibrary.commonWeight -= 0.3f;
            KaijuTraitLibrary.uncommonWeight += 0.3f;

            CapMinMaxWeights();
        }
    }

    //reptile food stuff
    public void GiveFood13()
    {
        if (readyToFeed)
        {
            KaijuTraitLibrary.motherBellySaturation += 0.5f;
            KaijuTraitLibrary.mammalWeight -= 0.1f;
            KaijuTraitLibrary.avianWeight -= 0.1f;
            KaijuTraitLibrary.aquaticWeight -= 0.1f;
            KaijuTraitLibrary.reptileWeight += 0.3f;

            CapMinMaxWeights();
        }
    }

    public void GiveFood14()
    {
        if (readyToFeed)
        {
            KaijuTraitLibrary.motherBellySaturation += 1.0f;
            KaijuTraitLibrary.mammalWeight -= 0.2f;
            KaijuTraitLibrary.avianWeight -= 0.2f;
            KaijuTraitLibrary.aquaticWeight -= 0.2f;
            KaijuTraitLibrary.reptileWeight -= 0.6f;

            KaijuTraitLibrary.commonWeight -= 0.22f;
            KaijuTraitLibrary.uncommonWeight += 0.5f;
            KaijuTraitLibrary.rareWeight -= 0.12f;
            KaijuTraitLibrary.legendaryWeight -= 0.16f;

            CapMinMaxWeights();
        }
    }

    public void GiveFood15()
    {
        if (readyToFeed)
        {
            KaijuTraitLibrary.motherBellySaturation += 1.5f;
            KaijuTraitLibrary.mammalWeight -= 0.3f;
            KaijuTraitLibrary.avianWeight -= 0.3f;
            KaijuTraitLibrary.aquaticWeight -= 0.3f;
            KaijuTraitLibrary.reptileWeight += 0.9f;

            KaijuTraitLibrary.commonWeight -= 0.32f;
            KaijuTraitLibrary.uncommonWeight += 0.75f;
            KaijuTraitLibrary.rareWeight -= 0.22f;
            KaijuTraitLibrary.legendaryWeight -= 0.21f;

            CapMinMaxWeights();
        }
    }
    public void GiveFood16()
    {
        if (readyToFeed)
        {
            KaijuTraitLibrary.motherBellySaturation += 2.0f;
            KaijuTraitLibrary.mammalWeight -= 0.4f;
            KaijuTraitLibrary.avianWeight -= 0.4f;
            KaijuTraitLibrary.aquaticWeight -= 0.4f;
            KaijuTraitLibrary.reptileWeight += 1.2f;

            KaijuTraitLibrary.commonWeight -= 0.3f;
            KaijuTraitLibrary.uncommonWeight += 0.3f;

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
            KaijuTraitLibrary.motherBellySaturation += 0.3f;
            KaijuTraitLibrary.mammalWeight += 5.55f;
            KaijuTraitLibrary.avianWeight -= 1.85f;
            KaijuTraitLibrary.aquaticWeight -= 1.85f;
            KaijuTraitLibrary.reptileWeight -= 1.85f;

            CapMinMaxWeights();
        }
    }

    public void GiveMineral02()
    {
        if (readyToFeed)
        {
            KaijuTraitLibrary.motherBellySaturation += 0.6f;
            KaijuTraitLibrary.mammalWeight += 3.0f;
            KaijuTraitLibrary.avianWeight += 0.5f;
            KaijuTraitLibrary.aquaticWeight -= 1.5f;
            KaijuTraitLibrary.reptileWeight -= 2.0f;

            KaijuTraitLibrary.commonWeight -= 2.25f;
            KaijuTraitLibrary.uncommonWeight += 1.5f;
            KaijuTraitLibrary.rareWeight += 0.5f;
            KaijuTraitLibrary.legendaryWeight += 0.25f;

            CapMinMaxWeights();
        }
    }

    public void GiveMineral03()
    {
        if (readyToFeed)
        {
            KaijuTraitLibrary.motherBellySaturation += 0.9f;
            KaijuTraitLibrary.mammalWeight += 5.0f;
            KaijuTraitLibrary.avianWeight += 1.5f;
            KaijuTraitLibrary.aquaticWeight += 0.5f;
            KaijuTraitLibrary.reptileWeight -= 7.0f;

            KaijuTraitLibrary.commonWeight -= 1.5f;
            KaijuTraitLibrary.uncommonWeight -= 0.5f;
            KaijuTraitLibrary.rareWeight += 1.5f;
            KaijuTraitLibrary.legendaryWeight += 0.5f;

            CapMinMaxWeights();
        }
    }

    //avian minerals
    public void GiveMineral04()
    {
        if (readyToFeed)
        {
            KaijuTraitLibrary.motherBellySaturation += 0.3f;
            KaijuTraitLibrary.avianWeight += 5.55f;
            KaijuTraitLibrary.mammalWeight -= 1.85f;
            KaijuTraitLibrary.aquaticWeight -= 1.85f;
            KaijuTraitLibrary.reptileWeight -= 1.85f;

            CapMinMaxWeights();
        }
    }
    
    public void GiveMineral05()
    {
        if (readyToFeed)
        {
            KaijuTraitLibrary.motherBellySaturation += 0.6f;
            KaijuTraitLibrary.avianWeight += 3.0f;
            KaijuTraitLibrary.mammalWeight += 0.5f;
            KaijuTraitLibrary.reptileWeight -= 1.5f;
            KaijuTraitLibrary.aquaticWeight -= 2.0f;

            KaijuTraitLibrary.commonWeight -= 2.25f;
            KaijuTraitLibrary.uncommonWeight += 1.5f;
            KaijuTraitLibrary.rareWeight += 0.5f;
            KaijuTraitLibrary.legendaryWeight += 0.25f;

            CapMinMaxWeights();
        }
    }

    public void GiveMineral06()
    {
        if (readyToFeed)
        {
            KaijuTraitLibrary.motherBellySaturation += 0.9f;
            KaijuTraitLibrary.avianWeight += 5.0f;
            KaijuTraitLibrary.mammalWeight += 1.5f;
            KaijuTraitLibrary.reptileWeight += 0.5f;
            KaijuTraitLibrary.aquaticWeight -= 7.0f;

            KaijuTraitLibrary.commonWeight -= 1.5f;
            KaijuTraitLibrary.uncommonWeight -= 0.5f;
            KaijuTraitLibrary.rareWeight += 1.5f;
            KaijuTraitLibrary.legendaryWeight += 0.5f;

            CapMinMaxWeights();
        }
    }

    //aquatic minerals
    public void GiveMineral07()
    {
        if (readyToFeed)
        {
            KaijuTraitLibrary.motherBellySaturation += 0.3f;
            KaijuTraitLibrary.aquaticWeight += 5.55f;
            KaijuTraitLibrary.avianWeight -= 1.85f;
            KaijuTraitLibrary.mammalWeight -= 1.85f;
            KaijuTraitLibrary.reptileWeight -= 1.85f;

            CapMinMaxWeights();
        }
    }

    public void GiveMineral08()
    {
        if (readyToFeed)
        {
            KaijuTraitLibrary.motherBellySaturation += 0.6f;
            KaijuTraitLibrary.aquaticWeight += 3.0f;
            KaijuTraitLibrary.reptileWeight += 0.5f;
            KaijuTraitLibrary.mammalWeight -= 1.5f;
            KaijuTraitLibrary.avianWeight -= 2.0f;

            KaijuTraitLibrary.commonWeight -= 2.25f;
            KaijuTraitLibrary.uncommonWeight += 1.5f;
            KaijuTraitLibrary.rareWeight += 0.5f;
            KaijuTraitLibrary.legendaryWeight += 0.25f;

            CapMinMaxWeights();
        }
    }
    
    public void GiveMineral09()
    {
        if (readyToFeed)
        {
            KaijuTraitLibrary.motherBellySaturation += 0.9f;
            KaijuTraitLibrary.aquaticWeight += 5.0f;
            KaijuTraitLibrary.reptileWeight += 1.5f;
            KaijuTraitLibrary.mammalWeight += 0.5f;
            KaijuTraitLibrary.avianWeight -= 7.0f;

            KaijuTraitLibrary.commonWeight -= 1.5f;
            KaijuTraitLibrary.uncommonWeight -= 0.5f;
            KaijuTraitLibrary.rareWeight += 1.5f;
            KaijuTraitLibrary.legendaryWeight += 0.5f;

            CapMinMaxWeights();
        }
    }
    //reptilian mineral stuff
    public void GiveMineral10()
    {
        if (readyToFeed)
        {
            KaijuTraitLibrary.motherBellySaturation += 0.3f;
            KaijuTraitLibrary.reptileWeight += 5.55f;
            KaijuTraitLibrary.avianWeight -= 1.85f;
            KaijuTraitLibrary.aquaticWeight -= 1.85f;
            KaijuTraitLibrary.mammalWeight -= 1.85f;

            CapMinMaxWeights();
        }
    }

    public void GiveMineral11()
    {
        if (readyToFeed)
        {
            KaijuTraitLibrary.motherBellySaturation += 0.6f;
            KaijuTraitLibrary.reptileWeight += 3.0f;
            KaijuTraitLibrary.aquaticWeight += 0.5f;
            KaijuTraitLibrary.avianWeight -= 1.5f;
            KaijuTraitLibrary.mammalWeight -= 2.0f;

            KaijuTraitLibrary.commonWeight -= 2.25f;
            KaijuTraitLibrary.uncommonWeight += 1.5f;
            KaijuTraitLibrary.rareWeight += 0.5f;
            KaijuTraitLibrary.legendaryWeight += 0.25f;

            CapMinMaxWeights();
        }
    }

    public void GiveMineral12()
    {
        if (readyToFeed)
        {
            KaijuTraitLibrary.motherBellySaturation += 0.9f;
            KaijuTraitLibrary.reptileWeight += 5.0f;
            KaijuTraitLibrary.aquaticWeight += 1.5f;
            KaijuTraitLibrary.avianWeight += 0.5f;
            KaijuTraitLibrary.mammalWeight -= 7.0f;

            KaijuTraitLibrary.commonWeight -= 1.5f;
            KaijuTraitLibrary.uncommonWeight -= 0.5f;
            KaijuTraitLibrary.rareWeight += 1.5f;
            KaijuTraitLibrary.legendaryWeight += 0.5f;

            CapMinMaxWeights();
        }
    }

    //rarity chance modifiers
    public void GiveMineral13()
    {
        if (readyToFeed)
        {
            KaijuTraitLibrary.motherBellySaturation += 0.3f;
            KaijuTraitLibrary.commonWeight -= 6.5f;
            KaijuTraitLibrary.uncommonWeight += 4.0f;
            KaijuTraitLibrary.rareWeight += 2.0f;
            KaijuTraitLibrary.legendaryWeight += 0.5f;

            CapMinMaxWeights();
        }
    }

    public void GiveMineral14()
    {
        if (readyToFeed)
        {
            KaijuTraitLibrary.motherBellySaturation += 0.6f;
            KaijuTraitLibrary.commonWeight -= 10.5f;
            KaijuTraitLibrary.uncommonWeight += 8.0f;
            KaijuTraitLibrary.rareWeight += 2.5f;

            CapMinMaxWeights();
        }
    }

    public void GiveMineral15()
    {
        if (readyToFeed)
        {
            KaijuTraitLibrary.motherBellySaturation += 1.0f;
            KaijuTraitLibrary.commonWeight -= 8.0f;
            KaijuTraitLibrary.uncommonWeight += 3.0f;
            KaijuTraitLibrary.rareWeight += 5.0f;
            KaijuTraitLibrary.legendaryWeight += 2.0f;

            CapMinMaxWeights();
        }
    }
    public void GiveMineral16()
    {
        if (readyToFeed)
        {
            KaijuTraitLibrary.motherBellySaturation += 8.0f;
            KaijuTraitLibrary.commonWeight -= 7.5f;
            KaijuTraitLibrary.uncommonWeight -= 2.0f;
            KaijuTraitLibrary.rareWeight += 3.0f;
            KaijuTraitLibrary.legendaryWeight += 6.5f;

            CapMinMaxWeights();
        }
    }
}
