using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class KaijuStats : MonoBehaviour
{
    public int health;
    public int attack;
    public int defence;
    public int speed;
    public enum StagesOfLife
    {
        Egg,
        Juvenile,
        Adult
    }

    public StagesOfLife stageOfLife;
    public float growth;
     
    float prevSystemTime = 0;

    public int generalFood = 0;
    public int foodAttack = 0;
    public int foodDefence = 0;
    public int foodHealth = 0;
    public int foodSpeed = 0;

    public GameObject egg;

    public GameObject juv;

    public GameObject adult;
    // Start is called before the first frame update
    void Start()
    {
        stageOfLife = StagesOfLife.Egg;
        health = 10;
        attack = 10;
        defence = 10;
        speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (stageOfLife == StagesOfLife.Egg)
        {
            EggGrowing();
        }
        else if (stageOfLife == StagesOfLife.Juvenile)
        {
            JuvenileGrowing();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            growth += 5;
            generalFood += 1;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            growth += 5;
            foodHealth += 1;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            growth += 5;
            foodAttack += 1;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            growth += 5;
            foodDefence += 1;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            growth += 5;
            foodSpeed += 1;
        }
    }

    void EggGrowing()
    {
        float currentSystemTime  = (float)DateTime.Now.TimeOfDay.TotalSeconds;
        if (prevSystemTime == 0)
        {
            growth += 1 * Time.deltaTime;
        }
        else
        {
            growth += (currentSystemTime - prevSystemTime);
        }
        growth = Mathf.Clamp(growth, 0, 100);

        if (growth >= 100)
        {
            stageOfLife = StagesOfLife.Juvenile;
            growth = 0;
            health += 10 + generalFood + foodHealth * 5;
            attack += 10 + generalFood + foodHealth * 5 ;
            defence += 10 + generalFood + foodDefence * 5;
            speed += 10 + generalFood + foodSpeed * 5;

            generalFood = 0;
            foodAttack = 0;
            foodHealth = 0;
            foodDefence = 0;
            foodSpeed = 0;
            
            egg.SetActive(false);
            juv.SetActive(true);
        }

        prevSystemTime = currentSystemTime;
    }
    
    void JuvenileGrowing()
    {
        float currentSystemTime  = (float)DateTime.Now.TimeOfDay.TotalSeconds;
        if (prevSystemTime == 0)
        {
            growth += 1 * Time.deltaTime;
        }
        else
        {
            growth += (currentSystemTime - prevSystemTime);
        }
        growth = Mathf.Clamp(growth, 0, 100);

        if (growth >= 100)
        {
            stageOfLife = StagesOfLife.Adult;
            growth = 0;
            health += 10 + generalFood + foodHealth * 5;
            attack += 10 + generalFood + foodHealth * 5 ;
            defence += 10 + generalFood + foodDefence * 5;
            speed += 10 + generalFood + foodSpeed * 5;

            generalFood = 0;
            foodAttack = 0;
            foodHealth = 0;
            foodDefence = 0;
            foodSpeed = 0;
            
            juv.SetActive(false);
            adult.SetActive(true);
        }

        prevSystemTime = currentSystemTime;
    }
}
