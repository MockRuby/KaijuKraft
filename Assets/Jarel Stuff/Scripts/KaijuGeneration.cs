using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using ColorUtility = UnityEngine.ColorUtility;

public class KaijuGeneration : MonoBehaviour
{
    //Color indicates kaiju type
    public SpriteRenderer[] eggColorBase = new SpriteRenderer[2];

    //Color indicates rarity
    public SpriteRenderer[] eggColorShell = new SpriteRenderer[8];

    public int kaijuTypeID = 0; //replace once hatchery script is complete; 0 - mammal, 1 - avian, 2 - aquatic, 3 - reptilian
    public int kaijuRarityID = 0; //replace once hatchery script is complete

    /// <summary>
    /// Will add more variables for kaiju traits
    /// </summary>

    void Start()
    {
        //create reference to hatchery script for IDs
        kaijuTypeID = Random.Range(0,4); //remove/replace after hatchery script is complete
        kaijuRarityID = Random.Range(0,21); //remove/replace after hatchery script is complete

        switch (kaijuTypeID)
        {
            case 0:
                foreach(SpriteRenderer srColor in eggColorBase)
                {
                    string colorHex = "#FFF6DA";
                    Color newColor;

                    if (ColorUtility.TryParseHtmlString(colorHex, out newColor))
                    {
                        srColor.color = newColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                }
                break;
            case 1:
                foreach (SpriteRenderer srColor in eggColorBase)
                {
                    srColor.color = Color.yellow;
                }
                break;
            case 2:
                foreach (SpriteRenderer srColor in eggColorBase)
                {
                    srColor.color = Color.cyan;
                }
                break;
            case 3:
                foreach (SpriteRenderer srColor in eggColorBase)
                {
                    srColor.color = Color.green;
                }
                break;
            default:
                break;
        }

        if (kaijuRarityID >= 0 && kaijuRarityID <= 8)
        {
            foreach (SpriteRenderer srColor in eggColorShell)
            {
                string colorHex = "#805146";
                Color newColor;

                if (ColorUtility.TryParseHtmlString(colorHex, out newColor))
                {
                    srColor.color = newColor;
                }
                else
                {
                    Debug.LogError("Invalid hexcode");
                }
            }
        }

        else if (kaijuRarityID >= 9 && kaijuRarityID <= 14)
        {
            foreach (SpriteRenderer srColor in eggColorShell)
            {
                string colorHex = "#5D7BFF";
                Color newColor;

                if (ColorUtility.TryParseHtmlString(colorHex, out newColor))
                {
                    srColor.color = newColor;
                }
                else
                {
                    Debug.LogError("Invalid hexcode");
                }
            }
        }

        else if (kaijuRarityID >= 15 && kaijuRarityID <= 18)
        {
            foreach (SpriteRenderer srColor in eggColorShell)
            {
                string colorHex = "#98BA71";
                Color newColor;

                if (ColorUtility.TryParseHtmlString(colorHex, out newColor))
                {
                    srColor.color = newColor;
                }
                else
                {
                    Debug.LogError("Invalid hexcode");
                }
            }
        }

        else if (kaijuRarityID >= 19 && kaijuRarityID <= 20)
        {
            foreach (SpriteRenderer srColor in eggColorShell)
            {
                string colorHex = "#C540FF";
                Color newColor;

                if (ColorUtility.TryParseHtmlString(colorHex, out newColor))
                {
                    srColor.color = newColor;
                }
                else
                {
                    Debug.LogError("Invalid hexcode");
                }
            }
        }
    }
    void Update()
    {
        
    }
}
