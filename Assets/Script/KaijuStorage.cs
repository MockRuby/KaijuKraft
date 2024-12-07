using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KaijuStorage : MonoBehaviour
{
    public static KaijuStorage instance;
    public int eggAmount;
    public GameObject kaiju;
    public List<Transform> spawnLocations;
    public List<bool> spawnFilled;
    public bool inRightScene;
    public int generalFood = 0;
    public int attackFood = 10;
    public int defenceFood = 0;
    public int speedFood = 0;
    public int healthFood = 10;
    public int previousSceneIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Debug.LogError("Mutiple " + instance);
        }

        instance = this;
        DontDestroyOnLoad(this);

        eggAmount = 1;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 && !inRightScene)
        {
            LoadSpawns();
            Debug.Log("in habate");
            if (previousSceneIndex == 2 )
            {
                SavingKaiju.instance.LoadKaiju();
                previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
            }
            inRightScene = true;
        }
        else if(SceneManager.GetActiveScene().buildIndex != 1)
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
                if(spawnFilled[i] == true) continue;
                else
                {
                    GameObject clone = Instantiate(kaiju, spawnLocations[i]);
                    clone.GetComponent<KaijuStats>().seed = KaijuTraitLibrary.instance.kaijuSeedList[0];
                    clone.GetComponent<KaijuGeneration>().ParseSeed();
                    KaijuTraitLibrary.instance.kaijuSeedList.Remove(KaijuTraitLibrary.instance.kaijuSeedList[0]);

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
