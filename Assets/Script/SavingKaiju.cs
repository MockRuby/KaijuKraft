using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SavingKaiju : MonoBehaviour
{
    public KaijuListData listData = new KaijuListData();
    // Update is called once per411 frame
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
        else if (Input.GetKeyDown(KeyCode.A))
        {
          BattleLoad();
        }
    }

    public void SaveKaiju()
    {
        listData.SavingAllKaijuData();
        string filepath = Application.persistentDataPath + "/KaijuData.json";
        Debug.Log(filepath);
        string jsonString = JsonUtility.ToJson(listData, true);
        System.IO.File.WriteAllText(filepath, jsonString);
        Debug.Log("KaijuSaved");
    }

    public void LoadKaiju()
    {
        string filepath = Application.persistentDataPath + "/KaijuData.json";
        string jsonString = System.IO.File.ReadAllText(filepath);
        listData = JsonUtility.FromJson<KaijuListData>(jsonString);
        listData.LoadingAllKaijuData();
        Debug.Log("KaijuLoaded");
    }

    public void BattleLoad()
    {
        foreach (KaijuData kaijuData in listData.kaijuListData)
        {
            GameObject newKaiju = GameObject.FindGameObjectWithTag("Kaiju");
            KaijuStats newKaijuStats = newKaiju.GetComponent<KaijuStats>();

            // Apply saved data to the new Kaiju
            newKaijuStats.health = kaijuData.localHealth;
            newKaijuStats.attack = kaijuData.localAttack;
            newKaijuStats.defence = kaijuData.localDefence;
            newKaijuStats.speed = kaijuData.localSpeed;
            newKaijuStats.growth = kaijuData.localGrowth;
            newKaijuStats.prevSystemTime = kaijuData.localPrevSystemTime;
            newKaijuStats.generalFood = kaijuData.localGeneralFood;
            newKaijuStats.foodAttack = kaijuData.localFoodAttack;
            newKaijuStats.foodDefence = kaijuData.localFoodDefence;
            newKaijuStats.foodHealth = kaijuData.localFoodHealth;
            newKaijuStats.foodSpeed = kaijuData.localFoodSpeed;
            newKaijuStats.stageOfLife = kaijuData.stageOfLifeForSave;
        }
    }
}

[System.Serializable]
public class KaijuData
{
    public GameObject kaiju;
    public KaijuStats stats;
    public int localHealth; // Health points of the Kaiju
    public int localAttack; // Attack points of the Kaiju
    public int localDefence; // Defence points of the Kaiju
    public int localSpeed; // Speed of the Kaiju
    public float localGrowth; // Growth progress of the Kaiju

    public float localPrevSystemTime; // Previous system time for growth calculation

    // Food stats for the Kaiju
    public int localGeneralFood; // General food collected
    public int localFoodAttack ; // Food for increasing attack
    public int localFoodDefence; // Food for increasing defence
    public int localFoodHealth; // Food for increasing health
    public int localFoodSpeed; // Food for increasing speed
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

[System.Serializable]
public class KaijuListData
{
    public List<KaijuData> kaijuListData = new List<KaijuData>();

    public void SavingAllKaijuData()
    {
        foreach (GameObject kaiju in GameObject.FindGameObjectsWithTag("Kaiju"))
        {
            KaijuData kaijuData = new KaijuData();
            kaijuData.kaiju = kaiju;
            kaijuData.stats = kaiju.GetComponent<KaijuStats>();
            kaijuData.SetData();
            kaijuListData.Add(kaijuData);
        }
    }

    public void LoadingAllKaijuData()
    {
        foreach (KaijuData kaijuData in kaijuListData)
        {
            kaijuData.LoadData();
        }
    }
}