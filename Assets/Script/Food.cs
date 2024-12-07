using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Food : MonoBehaviour
{
    public KaijuStats stats;

    public KaijuFocus focused;

    public List<TextMeshProUGUI> foods = new List<TextMeshProUGUI>();
    // Start is called before the first frame update
    void Start()
    {
        if (focused.focusedKaiju != null)
        {
            stats = focused.focusedKaiju.GetComponent<KaijuStats>();
        }
    }

    public void GiveGeneralFood()
    {
        if (KaijuStorage.instance.generalFood > 0)
        {
            stats.growth += 5;
            stats.generalFood += 1;
            KaijuStorage.instance.generalFood--;
        }
        UpdateFoodUI();
    }
    public void GiveHealthFood()
    {
        if (KaijuStorage.instance.healthFood > 0)
        {
            stats.growth += 5;
            stats.foodHealth += 1;
            KaijuStorage.instance.healthFood--;
        }
        UpdateFoodUI();
    }

    public void GiveAttackFood()
    {
        if (KaijuStorage.instance.attackFood > 0)
        {
            stats.growth += 5;
            stats.foodAttack += 1;
            KaijuStorage.instance.attackFood--;
        }
        UpdateFoodUI();
    }

    public void GiveDefenceFood()
    {
        if (KaijuStorage.instance.defenceFood > 0)
        {
            stats.growth += 5;
            stats.foodDefence += 1;
            KaijuStorage.instance.defenceFood--;
        }
        UpdateFoodUI();
    }

    public void GiveSpeedFood()
    {
        if (KaijuStorage.instance.speedFood > 0)
        {
            stats.growth += 5;
            stats.foodSpeed += 1;
            KaijuStorage.instance.speedFood--;
        }
        UpdateFoodUI();
    }

    public void UpdateFoodUI()
    {
        for (int i = 0; i < foods.Count; i++)
        {
            if (foods[i].name == "GAmount")
            {
                foods[i].text = "x" + KaijuStorage.instance.generalFood;
            }
            else if(foods[i].name == "AAmount")
            {
                foods[i].text = "x" + KaijuStorage.instance.attackFood;
            }
            else if(foods[i].name == "SAmount")
            {
                foods[i].text = "x" + KaijuStorage.instance.speedFood;
            }
            else if(foods[i].name == "DAmount")
            {
                foods[i].text = "x" + KaijuStorage.instance.defenceFood;
            }
            else if(foods[i].name == "HAmount")
            {
                foods[i].text = "x" + KaijuStorage.instance.healthFood;
            }
            
   
        }
    }
    
}
