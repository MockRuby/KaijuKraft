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
    
    
    // Update is called once per frame
    void Update()
    {
        if (focusedKaiju != null)
        {
            if (focusedKaiju != previousKaiju)
            {
                food.stats = focusedKaiju.GetComponent<KaijuStats>(); 
                bMenu.Clicked();
                bMenu.Flip();
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
            bMenu.Clicked();
            bMenu.Flip();
            previousKaiju = null;
        }
        
    }
}