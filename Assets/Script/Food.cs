using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Food : MonoBehaviour
{
    public KaijuStats stats;

    public KaijuFocus focused;
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
        stats.growth += 5;
        stats.generalFood += 1;
    }
    public void GiveHealthFood()
    {
        stats.growth += 5;
        stats.foodHealth += 1;
    }

    public void GiveAttackFood()
    {
        stats.growth += 5;
        stats.foodAttack += 1;
    }

    public void GiveDefenceFood()
    {
        stats.growth += 5;
        stats.foodDefence += 1;
    }

    public void GiveSpeedFood()
    {
        stats.growth += 5;
        stats.foodSpeed += 1;
    }
    
}
