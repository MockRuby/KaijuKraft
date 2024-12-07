using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class KaijuStorage : MonoBehaviour
{
    public static KaijuStorage instance;
    public int eggAmount = 1;
    public GameObject kaiju;
    public List<Transform> spawnLocations;
    public List<bool> spawnFilled;
    public bool inRightScene;
    public int generalFood = 0;
    public int attackFood = 10;
    public int defenceFood = 0;
    public int speedFood = 0;

    public int healthFood = 10;
    public Food food;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Debug.LogError("Mutiple " + instance);
        }

        instance = this;
        DontDestroyOnLoad(this);

        SavingKaiju.instance.LoadFoodAndEgg();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 && !inRightScene)
        {
            LoadSpawns();
            Debug.Log("in habate");

            SavingKaiju.instance.LoadKaiju();
            foreach (GameObject kajus in GameObject.FindGameObjectsWithTag("Kaiju"))
            {
                KaijuStats stats = kajus.GetComponent<KaijuStats>();
                if (stats.inSpawn)
                {
                    spawnFilled[stats.spawn] = true;
                }
            }

            food = FindObjectOfType<Food>();
            food.UpdateFoodUI();
            inRightScene = true;
        }
        else if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            inRightScene = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnEgg();
        }
    }

    public void SpawnEgg()
    {
        if (eggAmount > 0)
        {
            eggAmount--;
            for (int i = 0; i < spawnLocations.Count; i++)
            {
                if (spawnFilled[i] == true) continue;
                else
                {
                    GameObject clone = Instantiate(kaiju, spawnLocations[i]);
                    clone.name = clone.name + Random.Range(1, 1000);
                    clone.GetComponent<KaijuStats>().seed = KaijuTraitLibrary.instance.kaijuSeedList[0];
                    clone.GetComponent<KaijuGeneration>().ParseSeed();
                    KaijuTraitLibrary.instance.kaijuSeedList.Remove(KaijuTraitLibrary.instance.kaijuSeedList[0]);
                    clone.GetComponent<KaijuStats>().inSpawn = true;
                    clone.GetComponent<KaijuStats>().spawn = i;

                    spawnFilled[i] = true;
                    return;
                }
            }
        }
    }

    public void LoadSpawns()
    {
        GameObject[] spawnLocationsTemp = GameObject.FindGameObjectsWithTag("Spawn");
        for (int i = 0; i < spawnLocations.Count; i++)
        {
            spawnLocations[i] = spawnLocationsTemp[i].transform;
        }

        spawnLocations.Sort(Compare);
    }

    int Compare(Transform a, Transform b)
    {
        return a.position.x.CompareTo(b.position.x);
    }
}