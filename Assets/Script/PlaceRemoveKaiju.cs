using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlaceRemoveKaiju : MonoBehaviour
{
    public GameObject prefab;

    public Transform kaijuContent;

    public List<KaijuStats> kaijus = new List<KaijuStats>();
    public void UpdateList()
    {
        kaijus.Clear();
        foreach (GameObject kaiju in GameObject.FindGameObjectsWithTag("Kaiju"))
        {
            kaijus.Add(kaiju.GetComponent<KaijuStats>());
        }
        kaijus.Sort(CompareByName);
        ListItems();
    }
    int CompareByName(KaijuStats a, KaijuStats b)
    {
        return string.Compare(a.name, b.name, StringComparison.Ordinal);
    }
    public void ListItems()
    {
        foreach (Transform item in kaijuContent)
        {
            Destroy(item.gameObject);
        }

        for (int i = 0; i < kaijus.Count; i++)
        {
            GameObject obj = Instantiate(prefab, kaijuContent);
            TMP_Text kaijuName = obj.transform.Find("KaijuName").GetComponent<TMP_Text>();
            GameObject inSceneObj = obj.transform.Find("InScene").gameObject;
            if (kaijus[i].inSpawn)
            {
                inSceneObj.SetActive(true);
            }
            else
            {
                inSceneObj.SetActive(false);
            }
            kaijuName.text = kaijus[i].name;
        }
    }
}
