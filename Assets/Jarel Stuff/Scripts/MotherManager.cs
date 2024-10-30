using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MotherManager : MonoBehaviour
{
    public GameObject foodCanvasObj;
    public GameObject mineralCanvasObj;
    public GameObject feedPanelObj;

    public Button feedButton;
    public Button habitatButton;
    public Button getEggButton;

    public Slider mammalSlider;
    public Slider avianSlider;
    public Slider aquaticSlider;
    public Slider reptileSlider;

    public Slider commonSlider;
    public Slider uncommonSlider;
    public Slider rareSlider;
    public Slider legendarySlider;

    public Slider bellyHungerSlider;

    int feedPage = 0;
    float weightMin = 5.0f;
    float weightMax = 85.0f;

    float mammalWeight = 25.0f;
    float avianWeight = 25.0f;
    float aquaticWeight = 25.0f;
    float reptileWeight = 25.0f;

    float commonWeight = 50.0f;
    float uncommonWeight = 30.0f;
    float rareWeight = 15.0f;
    float legendaryWeight = 5.0f;

    float bellySaturation = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        feedPage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseFeedPanel()
    {
        feedPanelObj.SetActive(false);

        feedButton.interactable = true;
        habitatButton.interactable = true;
        getEggButton.interactable = true;
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
        getEggButton.interactable = false;
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
        mammalWeight = 25.0f;
        mammalSlider.value = mammalWeight;
        avianWeight = 25.0f;
        avianSlider.value = avianWeight;
        aquaticWeight = 25.0f;
        aquaticSlider.value = aquaticWeight;
        reptileWeight = 25.0f;
        reptileSlider.value = reptileWeight;

        commonWeight = 50.0f;
        commonSlider.value = commonWeight;
        uncommonWeight = 30.0f;
        uncommonSlider.value = uncommonWeight;
        rareWeight = 15.0f;
        rareSlider.value = rareWeight;
        legendaryWeight = 5.0f;
        legendarySlider.value = legendaryWeight;
    }

    void UpdateSliders()
    {
        mammalSlider.value = mammalWeight;
        avianSlider.value = avianWeight;
        aquaticSlider.value = aquaticWeight;
        reptileSlider.value = reptileWeight;

        commonSlider.value = commonWeight;
        uncommonSlider.value = uncommonWeight;
        rareSlider.value = rareWeight;
        legendarySlider.value = legendaryWeight;

        bellyHungerSlider.value = bellySaturation;
    }

    void CapMinMaxWeights()
    {
        //kaiju type
        if (mammalWeight < weightMin) //prevent weight from going below min threshold
        {
            mammalWeight = weightMin;
        }
        else if (mammalWeight > weightMax) //prevent weight from going beyond max threshold
        {
            mammalWeight = weightMax;
        }

        if (avianWeight < weightMin)
        {
            avianWeight = weightMin;
        }
        else if (avianWeight > weightMax)
        {
            avianWeight = weightMax;
        }

        if (aquaticWeight < weightMin)
        {
            aquaticWeight = weightMin;
        }
        else if (aquaticWeight > weightMax)
        {
            aquaticWeight = weightMax;
        }

        if (reptileWeight < weightMin)
        {
            reptileWeight = weightMin;
        }
        else if (reptileWeight > weightMax)
        {
            reptileWeight = weightMax;
        }

        //rarity
        if (commonWeight < weightMin)
        {
            commonWeight = weightMin;
        }
        else if (commonWeight > weightMax)
        {
            commonWeight = weightMax;
        }

        if (uncommonWeight < weightMin)
        {
            uncommonWeight = weightMin;
        }
        else if (uncommonWeight > weightMax)
        {
            uncommonWeight = weightMax;
        }

        if (rareWeight < weightMin)
        {
            rareWeight = weightMin;
        }
        else if (rareWeight > weightMax)
        {
            rareWeight = weightMax;
        }

        if (legendaryWeight < weightMin)
        {
            legendaryWeight = weightMin;
        }
        else if (legendaryWeight > weightMax)
        {
            legendaryWeight = weightMax;
        }

        if (bellySaturation > 100.0f)
        {
            bellySaturation = 100.0f;
        }

        UpdateSliders();
    }

    //mammal food stuff
    public void GiveFood01()
    {
        if (bellySaturation < 100.0f)
        {
            bellySaturation += 0.3f;
            mammalWeight += 0.3f;
            avianWeight -= 0.1f;
            aquaticWeight -= 0.1f;
            reptileWeight -= 0.1f;

            CapMinMaxWeights();
        }
    }

    public void GiveFood02()
    {
        if (bellySaturation < 100.0f)
        {
            bellySaturation += 0.6f;
            mammalWeight += 0.6f;
            avianWeight -= 0.2f;
            aquaticWeight -= 0.2f;
            reptileWeight -= 0.2f;

            commonWeight -= 0.2f;
            uncommonWeight += 0.5f;
            rareWeight -= 0.1f;
            legendaryWeight -= 0.1f;

            CapMinMaxWeights();
        }
    }

    public void GiveFood03()
    {
        if (bellySaturation < 100.0f)
        {
            bellySaturation += 0.9f;
            mammalWeight += 0.9f;
            avianWeight -= 0.3f;
            aquaticWeight -= 0.3f;
            reptileWeight -= 0.3f;

            commonWeight -= 0.3f;
            uncommonWeight += 0.7f;
            rareWeight -= 0.2f;
            legendaryWeight -= 0.2f;

            CapMinMaxWeights();
        }
    }

    public void GiveFood04()
    {
        if (bellySaturation < 100.0f)
        {
            bellySaturation += 1.2f;
            mammalWeight += 1.2f;
            avianWeight -= 0.4f;
            aquaticWeight -= 0.4f;
            reptileWeight -= 0.4f;

            commonWeight -= 0.4f;
            uncommonWeight += 0.3f;
            rareWeight += 0.3f;
            legendaryWeight -= 0.2f;

            CapMinMaxWeights();
        }
    }

    //avian food stuff
    public void GiveFood05()
    {
        if (bellySaturation < 100.0f)
        {
            bellySaturation += 0.3f;
            mammalWeight -= 0.1f;
            avianWeight += 0.3f;
            aquaticWeight -= 0.1f;
            reptileWeight -= 0.1f;

            CapMinMaxWeights();
        }
    }

    public void GiveFood06()
    {
        if (bellySaturation < 100.0f)
        {
            bellySaturation += 0.6f;
            mammalWeight -= 0.2f;
            avianWeight += 0.6f;
            aquaticWeight -= 0.2f;
            reptileWeight -= 0.2f;

            commonWeight -= 0.2f;
            uncommonWeight += 0.5f;
            rareWeight -= 0.1f;
            legendaryWeight -= 0.1f;

            CapMinMaxWeights();
        }
    }

    public void GiveFood07()
    {
        if (bellySaturation < 100.0f)
        {
            bellySaturation += 0.9f;
            mammalWeight -= 0.3f;
            avianWeight += 0.9f;
            aquaticWeight -= 0.3f;
            reptileWeight -= 0.3f;

            commonWeight -= 0.3f;
            uncommonWeight += 0.7f;
            rareWeight -= 0.2f;
            legendaryWeight -= 0.2f;

            CapMinMaxWeights();
        }
    }

    public void GiveFood08()
    {
        if (bellySaturation < 100.0f)
        {
            bellySaturation += 1.2f;
            mammalWeight -= 0.4f;
            avianWeight += 1.2f;
            aquaticWeight -= 0.4f;
            reptileWeight -= 0.4f;

            commonWeight -= 0.4f;
            uncommonWeight += 0.3f;
            rareWeight += 0.3f;
            legendaryWeight -= 0.2f;

            CapMinMaxWeights();
        }
    }

    //aquatic food stuff
    public void GiveFood09()
    {
        if (bellySaturation < 100.0f)
        {
            bellySaturation += 0.3f;
            mammalWeight -= 0.1f;
            avianWeight -= 0.1f;
            aquaticWeight += 0.3f;
            reptileWeight -= 0.1f;

            CapMinMaxWeights();
        }
    }

    public void GiveFood10()
    {
        if (bellySaturation < 100.0f)
        {
            bellySaturation += 0.6f;
            mammalWeight -= 0.2f;
            avianWeight -= 0.2f;
            aquaticWeight += 0.6f;
            reptileWeight -= 0.2f;

            commonWeight -= 0.2f;
            uncommonWeight += 0.5f;
            rareWeight -= 0.1f;
            legendaryWeight -= 0.1f;

            CapMinMaxWeights();
        }
    }

    public void GiveFood11()
    {
        if (bellySaturation < 100.0f)
        {
            bellySaturation += 0.9f;
            mammalWeight -= 0.3f;
            avianWeight -= 0.3f;
            aquaticWeight += 0.9f;
            reptileWeight -= 0.3f;

            commonWeight -= 0.3f;
            uncommonWeight += 0.7f;
            rareWeight -= 0.2f;
            legendaryWeight -= 0.2f;

            CapMinMaxWeights();
        }
    }

    public void GiveFood12()
    {
        if (bellySaturation < 100.0f)
        {
            bellySaturation += 1.2f;
            mammalWeight -= 0.4f;
            avianWeight -= 0.4f;
            aquaticWeight += 1.2f;
            reptileWeight -= 0.4f;

            commonWeight -= 0.4f;
            uncommonWeight += 0.3f;
            rareWeight += 0.3f;
            legendaryWeight -= 0.2f;

            CapMinMaxWeights();
        }
    }

    //reptile food stuff
    public void GiveFood13()
    {
        if (bellySaturation < 100.0f)
        {
            bellySaturation += 0.3f;
            mammalWeight -= 0.1f;
            avianWeight -= 0.1f;
            aquaticWeight -= 0.1f;
            reptileWeight += 0.3f;

            CapMinMaxWeights();
        }
    }

    public void GiveFood14()
    {
        if (bellySaturation < 100.0f)
        {
            bellySaturation += 0.6f;
            mammalWeight -= 0.2f;
            avianWeight -= 0.2f;
            aquaticWeight -= 0.2f;
            reptileWeight -= 0.6f;

            commonWeight -= 0.2f;
            uncommonWeight += 0.5f;
            rareWeight -= 0.1f;
            legendaryWeight -= 0.1f;

            CapMinMaxWeights();
        }
    }

    public void GiveFood15()
    {
        if (bellySaturation < 100.0f)
        {
            bellySaturation += 0.9f;
            mammalWeight -= 0.3f;
            avianWeight -= 0.3f;
            aquaticWeight -= 0.3f;
            reptileWeight += 0.9f;

            commonWeight -= 0.3f;
            uncommonWeight += 0.7f;
            rareWeight -= 0.2f;
            legendaryWeight -= 0.2f;

            CapMinMaxWeights();
        }
    }
    public void GiveFood16()
    {
        if (bellySaturation < 100.0f)
        {
            bellySaturation += 1.2f;
            mammalWeight -= 0.4f;
            avianWeight -= 0.4f;
            aquaticWeight -= 0.4f;
            reptileWeight += 1.2f;

            commonWeight -= 0.4f;
            uncommonWeight += 0.3f;
            rareWeight += 0.3f;
            legendaryWeight -= 0.2f;

            CapMinMaxWeights();
        }
    }
}
