using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlaceRemove : MonoBehaviour
{
    public PlaceRemoveKaiju kaijuList;
    public TMP_Text KaijuName;
    public GameObject inScene;
    public TextMeshProUGUI placeRemove;

    public KaijuStats kaiju;
    // Start is called before the first frame update
    void Start()
    {
        kaijuList = FindObjectOfType<PlaceRemoveKaiju>();
        for (int i = 0; i < kaijuList.kaijus.Count; i++)
        {
            if (KaijuName.text == kaijuList.kaijus[i].name)
            {
                kaiju = kaijuList.kaijus[i];
            }
        }

        if (kaiju.inSpawn)
        {
            placeRemove.text = "Remove";
        }
        else
        {
            placeRemove.text = "Place";
        }
    }

    public void RemovePlace()
    {
        if (kaiju.inSpawn == true)
        {
            Remove();
            placeRemove.text = "Place";
            inScene.SetActive(false);
        }
        else
        {
            Place();
            placeRemove.text = "Remove";
            inScene.SetActive(true);
        }
    }

    void Remove()
    {
        KaijuStorage.instance.spawnFilled[kaiju.spawn] = false;
        kaiju.spawn = 4;
        kaiju.inSpawn = false;
        kaiju.transform.position = new Vector3(0, 0, 20);
    }

    void Place()
    {
        for (int i = 0; i < KaijuStorage.instance.spawnFilled.Count; i++)
        {
            if (KaijuStorage.instance.spawnFilled[i] == false)
            {
                kaiju.spawn = i;
                kaiju.inSpawn = true;
                kaiju.transform.position = KaijuStorage.instance.spawnLocations[i].position;
                KaijuStorage.instance.spawnFilled[i] = true;
                return;
            }
        }
   
    }
    
}
