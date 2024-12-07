using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SavingKaiju : MonoBehaviour
{
    public static SavingKaiju instance;
    
    public KaijuListData listData = new KaijuListData();
    public FoodAndEgg foodAndEggData = new FoodAndEgg();
    public SeedData seedData = new SeedData();

    public GameObject kaijuPrefab;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Mutiple " + instance);
        }

        instance = this;
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
        if (System.IO.File.Exists(filepath))
        {
            string jsonString = System.IO.File.ReadAllText(filepath);
            listData = JsonUtility.FromJson<KaijuListData>(jsonString);
            LoadingAllKaijuData();
            Debug.Log("KaijuLoaded");
        }
  
    }

    public void LoadingAllKaijuData()
    {
        foreach (GameObject kaiju in GameObject.FindGameObjectsWithTag("Kaiju"))
        {
            Destroy(kaiju);
        }
        foreach (KaijuData kaijuData in listData.kaijuListData)
        {
            GameObject clone =  Instantiate(kaijuPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            kaijuData.LoadData(clone.GetComponent<KaijuStats>(), clone);
            clone.GetComponent<KaijuStats>().selectedForBattle = false;
        }
    }

    public void BattleLoad()
    {
        string filepath = Application.persistentDataPath + "/KaijuData.json";
        string jsonString = System.IO.File.ReadAllText(filepath);
        listData = JsonUtility.FromJson<KaijuListData>(jsonString);
        Debug.Log("KaijuLoaded");
        foreach (KaijuData kaijuData in listData.kaijuListData)
        {
            if(!kaijuData.selectedForBattleLocal) continue;
            GameObject kaiju = GameObject.FindWithTag("Kaiju");
            kaijuData.BattleLoadData(kaiju.GetComponent<KaijuStats>(), kaiju);
        }
    }

    public void SaveFoodAndEgg()
    {
        foodAndEggData.SetData();
        string filepath = Application.persistentDataPath + "/FoodAndEggData.json";
        Debug.Log(filepath);
        string jsonString = JsonUtility.ToJson(foodAndEggData, true);
        System.IO.File.WriteAllText(filepath, jsonString);
        Debug.Log("foodSaved");
    }
    public void LoadFoodAndEgg()
    {
        string filepath = Application.persistentDataPath + "/FoodAndEggData.json";
        if (System.IO.File.Exists(filepath))
        {
            string jsonString = System.IO.File.ReadAllText(filepath);
            foodAndEggData = JsonUtility.FromJson<FoodAndEgg>(jsonString);
            foodAndEggData.LoadData();
            Debug.Log("foodLoaded");
        }
    }

    public void SaveSeedData()
    {
        seedData.SetData();
        string filepath = Application.persistentDataPath + "/SeedData.json";
        Debug.Log(filepath);
        string jsonString = JsonUtility.ToJson(seedData, true);
        System.IO.File.WriteAllText(filepath, jsonString);
        Debug.Log("seedSaved");
    }

    public void LoadSeedData()
    {
        string filepath = Application.persistentDataPath + "/SeedData.json";
        if (System.IO.File.Exists(filepath))
        {
            string jsonString = System.IO.File.ReadAllText(filepath);
            seedData = JsonUtility.FromJson<SeedData>(jsonString);
            seedData.LoadData();
            Debug.Log("seedLoaded");
        }
    }
}

[System.Serializable]
public class KaijuData
{
    public int localHealth; // Health points of the Kaiju
    public int localAttack; // Attack points of the Kaiju
    public int localDefence; // Defence points of the Kaiju
    public int localSpeed; // Speed of the Kaiju
    public float localGrowth; // Growth progress of the Kaiju
    public string kaijuName;
    public bool selectedForBattleLocal;
    public Vector3 pos;
    public bool inSpawnLocal;
    public int spawnLocal;
    public string localSeed;

    public float localPrevSystemTime; // Previous system time for growth calculation

    // Food stats for the Kaiju
    public int localGeneralFood; // General food collected
    public int localFoodAttack; // Food for increasing attack
    public int localFoodDefence; // Food for increasing defence
    public int localFoodHealth; // Food for increasing health
    public int localFoodSpeed; // Food for increasing speed
    public KaijuStats.StagesOfLife stageOfLifeForSave;


    public void SetData(KaijuStats stats, GameObject kaiju)
    {
        kaijuName = kaiju.name;
        inSpawnLocal = stats.inSpawn;
        spawnLocal = stats.spawn;
        selectedForBattleLocal = stats.selectedForBattle;
        pos = kaiju.transform.position;
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
        localSeed = stats.seed;
        stageOfLifeForSave = stats.stageOfLife;
    }

    public void LoadData(KaijuStats stats, GameObject kaiju)
    {
        KaijuGeneration gen = kaiju.GetComponent<KaijuGeneration>();
        stats.seed = localSeed;
        gen.ParseSeed();
        stats.spawn = spawnLocal;
        stats.inSpawn = inSpawnLocal;
        stats.health = localHealth;
        stats.selectedForBattle = selectedForBattleLocal;
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
        kaiju.name = kaijuName;
        kaiju.transform.position = pos;
    }

    public void BattleLoadData(KaijuStats stats, GameObject kaiju)
    {
        KaijuGeneration gen = kaiju.GetComponent<KaijuGeneration>();
        stats.seed = localSeed;
        gen.ParseSeed();
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
        kaiju.name = kaijuName;
    }
}

[System.Serializable]
public class KaijuListData
{
    public List<KaijuData> kaijuListData = new List<KaijuData>();

    public void SavingAllKaijuData()
    {
        kaijuListData.Clear();
        foreach (GameObject kaiju in GameObject.FindGameObjectsWithTag("Kaiju"))
        {
            KaijuData kaijuData = new KaijuData();
            kaijuData.SetData(kaiju.GetComponent<KaijuStats>(), kaiju);
            kaijuListData.Add(kaijuData);
        }
    }
}

[System.Serializable]
public class FoodAndEgg
{
    public int localGeneralFood; // General food collected
    public int localFoodAttack; // Food for increasing attack
    public int localFoodDefence; // Food for increasing defence
    public int localFoodHealth; // Food for increasing health
    public int localFoodSpeed; // Food for increasing speed
    public int localEggAmount;
    public void SetData()
    {
       
        localGeneralFood =  KaijuStorage.instance.generalFood;;
        localFoodAttack = KaijuStorage.instance.attackFood;
        localFoodDefence = KaijuStorage.instance.defenceFood;
        localFoodHealth = KaijuStorage.instance.healthFood;
        localFoodSpeed = KaijuStorage.instance.speedFood;
        localEggAmount = KaijuStorage.instance.eggAmount;
    }

    public void LoadData()
    {
        KaijuStorage.instance.generalFood = localGeneralFood;
        KaijuStorage.instance.attackFood = localFoodAttack;
        KaijuStorage.instance.defenceFood = localFoodDefence;
        KaijuStorage.instance.healthFood = localFoodHealth;
        KaijuStorage.instance.speedFood = localFoodSpeed;
        KaijuStorage.instance.eggAmount = localEggAmount;
    }
}
[System.Serializable]
public class SeedData
{
    public List<string> localSeeds;

    public void SetData()
    {
        localSeeds = KaijuTraitLibrary.instance.kaijuSeedList;
    }

    public void LoadData()
    {
        KaijuTraitLibrary.instance.kaijuSeedList.Clear();
        KaijuTraitLibrary.instance.kaijuSeedList = localSeeds;
    }
}