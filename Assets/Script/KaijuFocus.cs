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
    public TextMeshProUGUI kaijuAmount;

    public UiManager ui;

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
        KaijuStats stats = focusedKaiju.GetComponent<KaijuStats>();

        KaijuStorage.instance.spawnFilled[stats.spawn] = false;
        stats.spawn = 4;
        stats.inSpawn = false;
        focusedKaiju.transform.position = new Vector3(0, 0, 20);
        focusedKaiju = null;
    }

    // Update is called once per frame
    void Update()
    {
        ui.UpdateKaijuAmount(kaijuAmount);
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
                for (int i = 0; i < buttons.Count; i++)
                {
                    buttons[i].SetActive(true);
                }

                kaijuNameInputField.text = focusedKaiju.name;
            }
        }

        if (focusedKaiju == null && previousKaiju != null)
        {
            for (int i = 0; i < buttons.Count; i++)
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