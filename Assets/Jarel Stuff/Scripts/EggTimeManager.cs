using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EggTimeManager : MonoBehaviour
{    
    public TextMeshProUGUI timerUpdate;

    public GameObject getEggButtonObj;

    public Button feedButton;

    float prevSystemTime = 0;
    int hourNum;
    int minNum;
    int secNum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float currentSystemTime = (float)DateTime.Now.TimeOfDay.TotalSeconds;
        if (BroodMotherData.eggTimer > 0)
        {
            if (prevSystemTime == 0)
            {
                BroodMotherData.eggTimer -= 1f * Time.deltaTime;
            }
            else
            {
                BroodMotherData.eggTimer -= (currentSystemTime - prevSystemTime);
            }
            BroodMotherData.eggTimer = Mathf.Clamp(BroodMotherData.eggTimer, 0, 5400);
        }
        prevSystemTime = currentSystemTime;

        hourNum = Mathf.FloorToInt(BroodMotherData.eggTimer / 3600);
        minNum = Mathf.FloorToInt((BroodMotherData.eggTimer % 3600) / 60);
        secNum = Mathf.FloorToInt(BroodMotherData.eggTimer % 60);
        
        if (hourNum > 0)
        {
            timerUpdate.text = "New egg in:\n" + hourNum.ToString() + "h " + minNum.ToString() + "m " + secNum.ToString() + "s";
        }
        else if (minNum > 0)
        {
            timerUpdate.text = "New egg in:\n" + minNum.ToString() + "m " + secNum.ToString() + "s";
        }
        else if (secNum > 0)
        {
            timerUpdate.text = "New egg in:\n" + secNum.ToString() + "s";
        }
        else
        {
            if (!BroodMotherData.getEgg)
            {
                timerUpdate.text = "Ready!";
            }
            else
            {
                timerUpdate.text = KaijuTraitLibrary.instance.kaijuRarityName[KaijuTraitLibrary.instance.newKaijuRarityID] + " " + KaijuTraitLibrary.instance.kaijuTypeName[KaijuTraitLibrary.instance.newKaijuTypeID] + " Egg";
            }
        }

        if (BroodMotherData.eggTimer == 0 && !BroodMotherData.getEgg)
        {
            feedButton.interactable = false;
            getEggButtonObj.SetActive(true);
        }
    }
}
