using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KaijuFocus : MonoBehaviour
{
    public GameObject focusedKaiju;
    public GameObject previousKaiju;

    public List<GameObject> buttons = new List<GameObject>();

    public BottomMenu bMenu;
    public Food food;
    [SerializeField] private TMP_InputField kaijuNameInputField;
    
    private void Start()
    {
        if (kaijuNameInputField != null)
        {
            kaijuNameInputField.onValueChanged.AddListener(OnKaijuNameChanged);
        }
    }
    private void OnKaijuNameChanged(string newText)
    {
        Debug.Log("User is typing: " + newText);
        focusedKaiju.name = newText;
    }

    public void KaijuStore()
    {
        for (int i = 0; i < KaijuStorage.instance.spawnLocations.Count; i++)
        {
            if (focusedKaiju.transform.position == KaijuStorage.instance.spawnLocations[i].transform.position)
            {
                KaijuStorage.instance.spawnFilled[i] = false;
            }
        }
        focusedKaiju.transform.position = new Vector3(0, 0, -20);
        focusedKaiju = null;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (focusedKaiju != null)
        {
            if (focusedKaiju != previousKaiju)
            {
                food.stats = focusedKaiju.GetComponent<KaijuStats>();
                if (!bMenu.anim.GetBool("clickedBottom"))
                {
                    bMenu.Clicked();
                    bMenu.Flip();
                }
                previousKaiju = focusedKaiju;
                for (int i = 0; i < buttons.Count; i ++)
                {
                    buttons[i].SetActive(true);
                }

                kaijuNameInputField.text = focusedKaiju.name;
            }
        }
       
        if (focusedKaiju == null && previousKaiju != null)
        {
            for (int i = 0; i < buttons.Count; i ++)
            {
                buttons[i].SetActive(false);
            }
            if (bMenu.anim.GetBool("clickedBottom"))
            {
                bMenu.Clicked();
                bMenu.Flip();
            }
            previousKaiju = null;
        }
        
    }
}