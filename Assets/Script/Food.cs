using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public enum foodType
    {
        General,
        Health,
        Attack,
        Defence,
        Speed
        
    }

    public foodType type;
    public KaijuStats stats;
    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Kaiju").GetComponent<KaijuStats>();
    }

    private void OnMouseUpAsButton()
    {
        if (type == foodType.General)
        {
            GiveGeneralFood();
        }
        else if (type == foodType.Health)
        {
            GiveHealthFood();
        }
        else if (type == foodType.Attack)
        {
            GiveAttackFood();
        }
        else if (type == foodType.Defence)
        {
            GiveDefenceFood();
        }
        else if (type == foodType.Speed)
        {
            GiveSpeedFood();
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
