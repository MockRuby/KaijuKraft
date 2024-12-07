using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectKaiju : MonoBehaviour
{
    public List<KaijuStats> kaijus = new List<KaijuStats>();
    public Transform kaijuContent;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        UpdateList();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void UpdateList()
    {
        kaijus.Clear();
        foreach (GameObject kaiju in GameObject.FindGameObjectsWithTag("Kaiju"))
        {
            kaijus.Add(kaiju.GetComponent<KaijuStats>());
        }
        kaijus.Sort(CompareByName);
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
            kaijuName.text = kaijus[i].name;
        }
    }

    public void SellectKaijuOnPress()
    {
        TMP_Text kaijuName = gameObject.transform.Find("KaijuName").GetComponent<TMP_Text>();
        for (int i = 0; i < kaijus.Count; i++)
        {
            if (kaijuName.text == kaijus[i].name)
            {
                kaijus[i].selectedForBattle = true;
            }
        }
        
    }
}
