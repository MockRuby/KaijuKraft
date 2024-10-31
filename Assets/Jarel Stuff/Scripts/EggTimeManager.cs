using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EggTimeManager : MonoBehaviour
{
    public Button feedButton;

    public GameObject getEggButton;
    
    public TextMeshProUGUI timerUpdate;

    public float eggTimer = 4900.0f;

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
        if (eggTimer > 0)
        {
            if (prevSystemTime == 0)
            {
                eggTimer -= 1f * Time.deltaTime;
            }
            else
            {
                eggTimer -= (currentSystemTime - prevSystemTime);
            }
            eggTimer = Mathf.Clamp(eggTimer, 0, 7200);
        }
        prevSystemTime = currentSystemTime;

        hourNum = Mathf.FloorToInt(eggTimer / 3600);
        minNum = Mathf.FloorToInt((eggTimer % 3600) / 60);
        secNum = Mathf.FloorToInt(eggTimer % 60);
        
        if (hourNum > 0)
        {
            timerUpdate.text = "New egg in: " + hourNum.ToString() + "h " + minNum.ToString() + "m " + secNum.ToString() + "s";
        }
        else if (minNum > 0)
        {
            timerUpdate.text = "New egg in: " + minNum.ToString() + "m " + secNum.ToString() + "s";
        }
        else if (secNum > 0)
        {
            timerUpdate.text = "New egg in: " + secNum.ToString() + "s";
        }
        else
        {
            timerUpdate.text = "Ready!";
            feedButton.interactable = false;
            getEggButton.SetActive(true);
        }
    }
}
