using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using ColorUtility = UnityEngine.ColorUtility;
using Color = UnityEngine.Color;

public class KaijuGeneration : MonoBehaviour
{
    //Color indicates kaiju type
    public SpriteRenderer[] eggColorBase = new SpriteRenderer[2];

    //Color indicates rarity
    public SpriteRenderer[] eggColorShell = new SpriteRenderer[8];

    public int kaijuTypeID = 0; //replace once hatchery script is complete; 0 - mammal, 1 - avian, 2 - aquatic, 3 - reptilian
    public int kaijuRarityID = 0; //replace once hatchery script is complete 0 - common, 1 - uncommon, 2 - rare, 3 - legendary
    public int kaijuRarityPick = 0; //replace once hatchery script is complete

    public int kaiju01GeneID = 0;
    

    public GameObject kaijuJuvieCatGenesTabby;
    public GameObject[] kaijuJuvieCatGenesBicolor = new GameObject[2];
    public GameObject kaijuJuvieCatGenesTicked;
    public GameObject[] kaijuJuvieCatGenesTuxedo = new GameObject[3];
    public GameObject kaijuJuvieCatGenesSpotted;
    public GameObject[] kaijuJuvieCatGenesCalico = new GameObject[2];
    public GameObject[] kaijuJuvieCatGenesPointed = new GameObject[3];
    public GameObject kaijuJuvieCatGenesVan;

    public SpriteRenderer[] baseColor = new SpriteRenderer[26];
    public string baseColorHex;
    public SpriteRenderer[] secondaryColor = new SpriteRenderer[83];
    public string secondaryColorHex;
    public SpriteRenderer[] tertiaryColor = new SpriteRenderer[15];
    public string tertiaryColorHex;
    public SpriteRenderer eyeColorA;
    public SpriteRenderer adultEyeColorA;
    public string eyeColorLeftHex;
    public SpriteRenderer eyeColorB;
    public SpriteRenderer adultEyeColorB;
    public string eyeColorRightHex;

    bool heterochromaticChance = false;

    public GameObject[] kaijuAdultCatGenesTabby = new GameObject[11];
    public GameObject[] kaijuAdultCatGenesBicolor = new GameObject[14];
    public GameObject[] kaijuAdultCatGenesTicked = new GameObject[11];
    public GameObject[] kaijuAdultCatGenesTuxedo = new GameObject[14];
    public GameObject[] kaijuAdultCatGenesSpotted = new GameObject[11];
    public GameObject[] kaijuAdultCatGenesCalico = new GameObject[16];
    public GameObject[] kaijuAdultCatGenesPointed = new GameObject[13];
    public GameObject[] kaijuAdultCatGenesVan = new GameObject[5];

    /// <summary>
    /// Will add more variables for kaiju traits
    /// </summary>

    void Start()
    {
        //create reference to hatchery script for IDs
        //kaijuTypeID = Random.Range(0,4); 
        kaijuTypeID = 0; //only 1 kaiju type available right now; remove/replace after hatchery script is complete
        kaijuRarityPick = Random.Range(0,21); //remove/replace after hatchery script is complete

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


        if (kaijuRarityPick >= 0 && kaijuRarityPick <= 8)
        {
            foreach (SpriteRenderer srColor in eggColorShell)
            {
                kaijuRarityID = 0;
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

        else if (kaijuRarityPick >= 9 && kaijuRarityPick <= 14)
        {
            foreach (SpriteRenderer srColor in eggColorShell)
            {
                kaijuRarityID = 1;
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

        else if (kaijuRarityPick >= 15 && kaijuRarityPick <= 18)
        {
            foreach (SpriteRenderer srColor in eggColorShell)
            {
                kaijuRarityID = 2;
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

        else if (kaijuRarityPick >= 19 && kaijuRarityPick <= 20)
        {
            foreach (SpriteRenderer srColor in eggColorShell)
            {
                kaijuRarityID = 3;
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

        switch (kaijuRarityID) //for first kaiju type
        {
            case 0:
                kaiju01GeneID = Random.Range(0, 3);
                break;
            case 1:
                kaiju01GeneID = Random.Range(3, 5);
                break;
            case 2:
                kaiju01GeneID = Random.Range(5, 7);
                break;
            case 3:
                kaiju01GeneID = Random.Range(7, 9);
                break;
            default:
                break;
        }
    }
    void Update()
    {
        
    }

    public void KaijuGenePick()
    {
        KaijuBaseColorPick();
        switch (kaiju01GeneID) //default gene is 0; if 0, no additional code necessary
        {
            case 1:
                kaijuJuvieCatGenesTabby.SetActive(true);
                KaijuSecondaryColorPick();
                break;
            case 2:
                foreach (GameObject geneObject in kaijuJuvieCatGenesBicolor)
                {
                    geneObject.SetActive(true);
                }
                break;
            case 3:
                kaijuJuvieCatGenesTicked.SetActive(true);
                break;
            case 4:
                foreach (GameObject geneObject in kaijuJuvieCatGenesTuxedo)
                {
                    geneObject.SetActive(true);
                }
                KaijuSecondaryColorPick();
                break;
            case 5:
                kaijuJuvieCatGenesSpotted.SetActive(true);
                KaijuSecondaryColorPick();
                break;
            case 6:
                foreach (GameObject geneObject in kaijuJuvieCatGenesCalico)
                {
                    geneObject.SetActive(true);
                }
                KaijuSecondaryColorPick();
                KaijuTertiaryColorPick();
                break;
            case 7:
                foreach (GameObject geneObject in kaijuJuvieCatGenesPointed)
                {
                    geneObject.SetActive(true);
                }
                KaijuSecondaryColorPick();
                break;
            case 8:
                kaijuJuvieCatGenesVan.SetActive(true);
                KaijuSecondaryColorPick();
                heterochromaticChance = true;
                break;
            default:
                break;
        }

        KaijuEyeColorPick();
    }

    public void KaijuBaseColorPick()
    {
        int baseColorID;
        baseColorID = Random.Range(0, 5);
        Color newBaseColor;

        switch (baseColorID)
        {
            case 0:
                baseColorHex = "#444444";
                foreach (SpriteRenderer srBaseColor in baseColor)
                {
                    if (ColorUtility.TryParseHtmlString(baseColorHex, out newBaseColor))
                    {

                        srBaseColor.color = newBaseColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                }
                break;
            case 1:
                baseColorHex = "#FFA500";
                foreach (SpriteRenderer srBaseColor in baseColor)
                {
                    if (ColorUtility.TryParseHtmlString(baseColorHex, out newBaseColor))
                    {

                        srBaseColor.color = newBaseColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                }
                break;
            case 2:
                baseColorHex = "#808080";
                foreach (SpriteRenderer srBaseColor in baseColor)
                {
                    if (ColorUtility.TryParseHtmlString(baseColorHex, out newBaseColor))
                    {

                        srBaseColor.color = newBaseColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                }
                break;
            case 3:
                baseColorHex = "#FFA500";
                foreach (SpriteRenderer srBaseColor in baseColor)
                {
                    if (ColorUtility.TryParseHtmlString(baseColorHex, out newBaseColor))
                    {

                        srBaseColor.color = newBaseColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                }
                break;
            case 4:
                baseColorHex = "#654321";
                foreach (SpriteRenderer srBaseColor in baseColor)
                {
                    if (ColorUtility.TryParseHtmlString(baseColorHex, out newBaseColor))
                    {

                        srBaseColor.color = newBaseColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                }
                break;
            default:
                break;
        }
    }

    public void KaijuSecondaryColorPick()
    {
        int secondColorID;
        secondColorID = Random.Range(0, 5);
        Color newSecondColor;

        switch (secondColorID)
        {
            case 0:
                secondaryColorHex = "#C60000";
                foreach (SpriteRenderer srSecondColor in secondaryColor)
                {
                    if (ColorUtility.TryParseHtmlString(secondaryColorHex, out newSecondColor))
                    {

                        srSecondColor.color = newSecondColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                }
                break;
            case 1:
                secondaryColorHex = "#767676";
                foreach (SpriteRenderer srSecondColor in secondaryColor)
                {
                    if (ColorUtility.TryParseHtmlString(secondaryColorHex, out newSecondColor))
                    {

                        srSecondColor.color = newSecondColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                }
                break;
            case 2:
                secondaryColorHex = "#D75A00";
                foreach (SpriteRenderer srSecondColor in secondaryColor)
                {
                    if (ColorUtility.TryParseHtmlString(secondaryColorHex, out newSecondColor))
                    {

                        srSecondColor.color = newSecondColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                }
                break;
            case 3:
                secondaryColorHex = "#6A4F2F";
                foreach (SpriteRenderer srSecondColor in secondaryColor)
                {
                    if (ColorUtility.TryParseHtmlString(secondaryColorHex, out newSecondColor))
                    {

                        srSecondColor.color = newSecondColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                }
                break;
            case 4:
                secondaryColorHex = "#E3AF75";
                foreach (SpriteRenderer srSecondColor in secondaryColor)
                {
                    if (ColorUtility.TryParseHtmlString(secondaryColorHex, out newSecondColor))
                    {

                        srSecondColor.color = newSecondColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                }
                break;
            default:
                break;
        }
    }

    public void KaijuTertiaryColorPick()
    {
        int thirdColorID;
        thirdColorID = Random.Range(0, 5);
        Color newThirdColor;

        switch (thirdColorID)
        {
            case 0:
                tertiaryColorHex = "#FFAFD2";
                foreach (SpriteRenderer srThirdColor in tertiaryColor)
                {
                    if (ColorUtility.TryParseHtmlString(tertiaryColorHex, out newThirdColor))
                    {

                        srThirdColor.color = newThirdColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                }
                break;
            case 1:
                tertiaryColorHex = "#FFD775";
                foreach (SpriteRenderer srThirdColor in tertiaryColor)
                {
                    if (ColorUtility.TryParseHtmlString(tertiaryColorHex, out newThirdColor))
                    {

                        srThirdColor.color = newThirdColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                }
                break;
            case 2:
                tertiaryColorHex = "#A0E2FF";
                foreach (SpriteRenderer srThirdColor in tertiaryColor)
                {
                    if (ColorUtility.TryParseHtmlString(tertiaryColorHex, out newThirdColor))
                    {

                        srThirdColor.color = newThirdColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                }
                break;
            case 3:
                tertiaryColorHex = "#FF8470";
                foreach (SpriteRenderer srThirdColor in tertiaryColor)
                {
                    if (ColorUtility.TryParseHtmlString(tertiaryColorHex, out newThirdColor))
                    {

                        srThirdColor.color = newThirdColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                }
                break;
            case 4:
                tertiaryColorHex = "#AB977D";
                foreach (SpriteRenderer srThirdColor in tertiaryColor)
                {
                    if (ColorUtility.TryParseHtmlString(tertiaryColorHex, out newThirdColor))
                    {

                        srThirdColor.color = newThirdColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                }
                break;
            default:
                break;
        }
    }

    public void KaijuEyeColorPick()
    {
        if (!heterochromaticChance)
        {
            int eyeColors;
            eyeColors = Random.Range(0, 8);
            Color newEyeColor;

            switch (eyeColors)
            {
                case 0: //emerald
                    eyeColorLeftHex = "#50C878";
                    eyeColorRightHex = "#50C878";

                    if (ColorUtility.TryParseHtmlString(eyeColorLeftHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                        eyeColorB.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 1: //gold
                    eyeColorLeftHex = "#FFD700";
                    eyeColorRightHex = "#FFD700";

                    if (ColorUtility.TryParseHtmlString(eyeColorLeftHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                        eyeColorB.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 2: //blue
                    eyeColorLeftHex = "#4682B4";
                    eyeColorRightHex = "#4682B4";

                    if (ColorUtility.TryParseHtmlString(eyeColorLeftHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                        eyeColorB.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 3: //hazel
                    eyeColorLeftHex = "#8E7618";
                    eyeColorRightHex = "#8E7618";

                    if (ColorUtility.TryParseHtmlString(eyeColorLeftHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                        eyeColorB.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 4: //copper
                    eyeColorLeftHex = "#B87333";
                    eyeColorRightHex = "#B87333";

                    if (ColorUtility.TryParseHtmlString(eyeColorLeftHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                        eyeColorB.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 5: //orange
                    eyeColorLeftHex = "#FFA500";
                    eyeColorRightHex = "#FFA500";

                    if (ColorUtility.TryParseHtmlString(eyeColorLeftHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                        eyeColorB.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 6: //gray
                    eyeColorLeftHex = "#BEBEBE";
                    eyeColorRightHex = "#BEBEBE";

                    if (ColorUtility.TryParseHtmlString(eyeColorLeftHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                        eyeColorB.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 7: //aqua
                    eyeColorLeftHex = "#00FFFF";
                    eyeColorRightHex = "#00FFFF";

                    if (ColorUtility.TryParseHtmlString(eyeColorLeftHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                        eyeColorB.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                default:
                    break;
            }
        }
        else
        {
            int eyeColorLeft;
            int eyeColorRight;
            eyeColorLeft = Random.Range(0, 8);
            eyeColorRight = Random.Range(0, 8);
            Color newEyeColor;

            switch (eyeColorLeft)
            {
                case 0: //emerald
                    eyeColorLeftHex = "#50C878";

                    if (ColorUtility.TryParseHtmlString(eyeColorLeftHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 1: //gold
                    eyeColorLeftHex = "#FFD700";

                    if (ColorUtility.TryParseHtmlString(eyeColorLeftHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 2: //blue
                    eyeColorLeftHex = "#4682B4";

                    if (ColorUtility.TryParseHtmlString(eyeColorLeftHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 3: //hazel
                    eyeColorLeftHex = "#8E7618";

                    if (ColorUtility.TryParseHtmlString(eyeColorLeftHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 4: //copper
                    eyeColorLeftHex = "#B87333";

                    if (ColorUtility.TryParseHtmlString(eyeColorLeftHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 5: //orange
                    eyeColorLeftHex = "#FFA500";

                    if (ColorUtility.TryParseHtmlString(eyeColorLeftHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 6: //gray
                    eyeColorLeftHex = "#BEBEBE";

                    if (ColorUtility.TryParseHtmlString(eyeColorLeftHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 7: //aqua
                    eyeColorLeftHex = "#00FFFF";

                    if (ColorUtility.TryParseHtmlString(eyeColorLeftHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                default:
                    break;
            }

            switch (eyeColorRight)
            {
                case 0: //emerald
                    eyeColorRightHex = "#50C878";

                    if (ColorUtility.TryParseHtmlString(eyeColorRightHex, out newEyeColor))
                    {
                        eyeColorB.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 1: //gold
                    eyeColorRightHex = "#FFD700";

                    if (ColorUtility.TryParseHtmlString(eyeColorRightHex, out newEyeColor))
                    {
                        eyeColorB.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 2: //blue
                    eyeColorRightHex = "#4682B4";

                    if (ColorUtility.TryParseHtmlString(eyeColorRightHex, out newEyeColor))
                    {
                        eyeColorB.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 3: //hazel
                    eyeColorRightHex = "#8E7618";

                    if (ColorUtility.TryParseHtmlString(eyeColorRightHex, out newEyeColor))
                    {
                        eyeColorB.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 4: //copper
                    eyeColorRightHex = "#B87333";

                    if (ColorUtility.TryParseHtmlString(eyeColorRightHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                        eyeColorB.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 5: //orange
                    eyeColorRightHex = "#FFA500";

                    if (ColorUtility.TryParseHtmlString(eyeColorRightHex, out newEyeColor))
                    {
                        eyeColorB.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 6: //gray
                    eyeColorRightHex = "#BEBEBE";

                    if (ColorUtility.TryParseHtmlString(eyeColorRightHex, out newEyeColor))
                    {
                        eyeColorB.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 7: //aqua
                    eyeColorRightHex = "#00FFFF";

                    if (ColorUtility.TryParseHtmlString(eyeColorRightHex, out newEyeColor))
                    {
                        eyeColorB.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                default:
                    break;
            }
        }
    }


    public void UpdateColour()
    {
          if (!heterochromaticChance)
        {
            int eyeColors;
            eyeColors = Random.Range(0, 8);
            Color newEyeColor;

            switch (eyeColors)
            {
                case 0: //emerald
                    eyeColorLeftHex = "#50C878";
                    eyeColorRightHex = "#50C878";

                    if (ColorUtility.TryParseHtmlString(eyeColorLeftHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                        eyeColorB.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 1: //gold
                    eyeColorLeftHex = "#FFD700";
                    eyeColorRightHex = "#FFD700";

                    if (ColorUtility.TryParseHtmlString(eyeColorLeftHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                        eyeColorB.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 2: //blue
                    eyeColorLeftHex = "#4682B4";
                    eyeColorRightHex = "#4682B4";

                    if (ColorUtility.TryParseHtmlString(eyeColorLeftHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                        eyeColorB.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 3: //hazel
                    eyeColorLeftHex = "#8E7618";
                    eyeColorRightHex = "#8E7618";

                    if (ColorUtility.TryParseHtmlString(eyeColorLeftHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                        eyeColorB.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 4: //copper
                    eyeColorLeftHex = "#B87333";
                    eyeColorRightHex = "#B87333";

                    if (ColorUtility.TryParseHtmlString(eyeColorLeftHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                        eyeColorB.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 5: //orange
                    eyeColorLeftHex = "#FFA500";
                    eyeColorRightHex = "#FFA500";

                    if (ColorUtility.TryParseHtmlString(eyeColorLeftHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                        eyeColorB.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 6: //gray
                    eyeColorLeftHex = "#BEBEBE";
                    eyeColorRightHex = "#BEBEBE";

                    if (ColorUtility.TryParseHtmlString(eyeColorLeftHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                        eyeColorB.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 7: //aqua
                    eyeColorLeftHex = "#00FFFF";
                    eyeColorRightHex = "#00FFFF";

                    if (ColorUtility.TryParseHtmlString(eyeColorLeftHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                        eyeColorB.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                default:
                    break;
            }
        }
        else
        {
            int eyeColorLeft;
            int eyeColorRight;
            eyeColorLeft = Random.Range(0, 8);
            eyeColorRight = Random.Range(0, 8);
            Color newEyeColor;

            switch (eyeColorLeft)
            {
                case 0: //emerald
                    eyeColorLeftHex = "#50C878";

                    if (ColorUtility.TryParseHtmlString(eyeColorLeftHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 1: //gold
                    eyeColorLeftHex = "#FFD700";

                    if (ColorUtility.TryParseHtmlString(eyeColorLeftHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 2: //blue
                    eyeColorLeftHex = "#4682B4";

                    if (ColorUtility.TryParseHtmlString(eyeColorLeftHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 3: //hazel
                    eyeColorLeftHex = "#8E7618";

                    if (ColorUtility.TryParseHtmlString(eyeColorLeftHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 4: //copper
                    eyeColorLeftHex = "#B87333";

                    if (ColorUtility.TryParseHtmlString(eyeColorLeftHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 5: //orange
                    eyeColorLeftHex = "#FFA500";

                    if (ColorUtility.TryParseHtmlString(eyeColorLeftHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 6: //gray
                    eyeColorLeftHex = "#BEBEBE";

                    if (ColorUtility.TryParseHtmlString(eyeColorLeftHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 7: //aqua
                    eyeColorLeftHex = "#00FFFF";

                    if (ColorUtility.TryParseHtmlString(eyeColorLeftHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                default:
                    break;
            }

            switch (eyeColorRight)
            {
                case 0: //emerald
                    eyeColorRightHex = "#50C878";

                    if (ColorUtility.TryParseHtmlString(eyeColorRightHex, out newEyeColor))
                    {
                        eyeColorB.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 1: //gold
                    eyeColorRightHex = "#FFD700";

                    if (ColorUtility.TryParseHtmlString(eyeColorRightHex, out newEyeColor))
                    {
                        eyeColorB.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 2: //blue
                    eyeColorRightHex = "#4682B4";

                    if (ColorUtility.TryParseHtmlString(eyeColorRightHex, out newEyeColor))
                    {
                        eyeColorB.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 3: //hazel
                    eyeColorRightHex = "#8E7618";

                    if (ColorUtility.TryParseHtmlString(eyeColorRightHex, out newEyeColor))
                    {
                        eyeColorB.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 4: //copper
                    eyeColorRightHex = "#B87333";

                    if (ColorUtility.TryParseHtmlString(eyeColorRightHex, out newEyeColor))
                    {
                        eyeColorA.color = newEyeColor;
                        eyeColorB.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 5: //orange
                    eyeColorRightHex = "#FFA500";

                    if (ColorUtility.TryParseHtmlString(eyeColorRightHex, out newEyeColor))
                    {
                        eyeColorB.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 6: //gray
                    eyeColorRightHex = "#BEBEBE";

                    if (ColorUtility.TryParseHtmlString(eyeColorRightHex, out newEyeColor))
                    {
                        eyeColorB.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                case 7: //aqua
                    eyeColorRightHex = "#00FFFF";

                    if (ColorUtility.TryParseHtmlString(eyeColorRightHex, out newEyeColor))
                    {
                        eyeColorB.color = newEyeColor;
                    }
                    else
                    {
                        Debug.LogError("Invalid hexcode");
                    }
                    break;
                default:
                    break;
            }
        }
    }

    public void MaturizeKaiju()
    {
        switch (kaiju01GeneID) //default gene is 0; if 0, no additional code necessary
        {
            case 1:
                foreach (GameObject geneObject in kaijuAdultCatGenesTabby)
                {
                    geneObject.SetActive(true);
                }
                break;
            case 2:
                foreach (GameObject geneObject in kaijuAdultCatGenesBicolor)
                {
                    geneObject.SetActive(true);
                }
                break;
            case 3:
                foreach (GameObject geneObject in kaijuAdultCatGenesTicked)
                {
                    geneObject.SetActive(true);
                }
                break;
            case 4:
                foreach (GameObject geneObject in kaijuAdultCatGenesTuxedo)
                {
                    geneObject.SetActive(true);
                }
                break;
            case 5:
                foreach (GameObject geneObject in kaijuAdultCatGenesSpotted)
                {
                    geneObject.SetActive(true);
                }
                break;
            case 6:
                foreach (GameObject geneObject in kaijuAdultCatGenesCalico)
                {
                    geneObject.SetActive(true);
                }
                break;
            case 7:
                foreach (GameObject geneObject in kaijuAdultCatGenesPointed)
                {
                    geneObject.SetActive(true);
                }
                break;
            case 8:
                foreach (GameObject geneObject in kaijuAdultCatGenesVan)
                {
                    geneObject.SetActive(true);
                }
                break;
            default:
                break;
        }
    }
}
