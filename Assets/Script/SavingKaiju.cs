using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class SavingKaiju : MonoBehaviour
{
    public KaijuData kaijuData = new KaijuData();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveKaiju();
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            LoadKaiju();
        }
    }

    public void SaveKaiju()
    {
        kaijuData.SetData();
        string jsonString = JsonUtility.ToJson(kaijuData);
        string filepath = Application.persistentDataPath + "/KaijuData.json";
        Debug.Log(filepath);
        System.IO.File.WriteAllText(filepath, jsonString);
        Debug.Log("KaijuSaved");
    }

    public void LoadKaiju()
    {
        string filepath = Application.persistentDataPath + "/KaijuData.json";
        string jsonString = System.IO.File.ReadAllText(filepath);
        kaijuData = JsonUtility.FromJson<KaijuData>(jsonString);
        kaijuData.LoadData();
        Debug.Log("KaijuLoaded");
    }
}
[System.Serializable]
public class KaijuData
{
    public List<GameObject> kaijuList = new List<GameObject>();
    public KaijuStats stats;
    public int localHealth; // Health points of the Kaiju
    public int localAttack; // Attack points of the Kaiju
    public int localDefence; // Defence points of the Kaiju
    public int localSpeed; // Speed of the Kaiju
    public float localGrowth; // Growth progress of the Kaiju

    public float localPrevSystemTime = 0; // Previous system time for growth calculation

    // Food stats for the Kaiju
    public int localGeneralFood = 0; // General food collected
    public int localFoodAttack = 0; // Food for increasing attack
    public int localFoodDefence = 0; // Food for increasing defence
    public int localFoodHealth = 0; // Food for increasing health
    public int localFoodSpeed = 0; // Food for increasing speed
    public KaijuStats.StagesOfLife stageOfLifeForSave;
    
    public void SetData()
    {
        localHealth = stats.health;
        localAttack = stats.attack;
        localDefence = stats.defence;
        localSpeed = stats.speed;
        localGrowth = stats.growth;
        localPrevSystemTime = stats.prevSystemTime;
        localGeneralFood = stats.generalFood;
        localFoodAttack = stats.foodAttack;
        localFoodDefence = stats.foodDefence;
        localFoodHealth = stats.foodHealth;
        localFoodSpeed = stats.foodSpeed;
        stageOfLifeForSave = stats.stageOfLife;
        
    }

    public void LoadData()
    {
        stats.health = localHealth;
        stats.attack = localAttack;
        stats.defence = localDefence;
        stats.speed = localSpeed;
        stats.growth = localGrowth;
        stats.prevSystemTime = localPrevSystemTime;
        stats.generalFood = localGeneralFood;
        stats.foodAttack = localFoodAttack;
        stats.foodDefence = localFoodDefence;
        stats.foodHealth = localFoodHealth;
        stats.foodSpeed = localFoodSpeed;
        stats.stageOfLife = stageOfLifeForSave;
    }
}
