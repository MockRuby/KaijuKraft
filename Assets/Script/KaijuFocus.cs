using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaijuFocus : MonoBehaviour
{
    public GameObject focusedKaiju;
    private GameObject previousKaiju;

    public List<GameObject> buttons = new List<GameObject>();

    public BottomMenu bMenu;
    public Food food;
    
    // Update is called once per frame
    void Update()
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
        }

        if (focusedKaiju == null)
        {
            for (int i = 0; i < buttons.Count; i ++)
            {
                buttons[i].SetActive(false);
            }
        }
    }
}