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
    /*public int kaijuRarityID = 0; //replace once hatchery script is complete 0 - common, 1 - uncommon, 2 - rare, 3 - legendary
    public int kaijuRarityPick = 0; //replace once hatchery script is complete*/
    

    //store game objects to turn active/inactive
    public GameObject kaijuJuvieCatGenesTabby;
    public GameObject[] kaijuJuvieCatGenesBicolor = new GameObject[2];
    public GameObject kaijuJuvieCatGenesTicked;
    public GameObject[] kaijuJuvieCatGenesTuxedo = new GameObject[3];
    public GameObject kaijuJuvieCatGenesSpotted;
    public GameObject[] kaijuJuvieCatGenesCalico = new GameObject[2];
    public GameObject[] kaijuJuvieCatGenesPointed = new GameObject[3];
    public GameObject kaijuJuvieCatGenesVan;

    public SpriteRenderer[] baseColor = new SpriteRenderer[26];
    public SpriteRenderer[] secondaryColor = new SpriteRenderer[83];
    public SpriteRenderer[] tertiaryColor = new SpriteRenderer[14];
    public SpriteRenderer[] eyeColorLeft = new SpriteRenderer[2];
    public SpriteRenderer[] eyeColorRight = new SpriteRenderer[2];

    public GameObject[] kaijuAdultCatGenesTabby = new GameObject[11];
    public GameObject[] kaijuAdultCatGenesBicolor = new GameObject[14];
    public GameObject[] kaijuAdultCatGenesTicked = new GameObject[11];
    public GameObject[] kaijuAdultCatGenesTuxedo = new GameObject[14];
    public GameObject[] kaijuAdultCatGenesSpotted = new GameObject[11];
    public GameObject[] kaijuAdultCatGenesCalico = new GameObject[16];
    public GameObject[] kaijuAdultCatGenesPointed = new GameObject[13];
    public GameObject[] kaijuAdultCatGenesVan = new GameObject[5];

    int x;
    public string seed;
    private int seedNum;

    KaijuStats stats;


    //data to store
    int kaijuTypeID;
    int kaijuRarityID;
    int kaijuGeneID;
    int kaijuBaseColorID;
    int kaijuSecondaryColorID;
    int kaijuTertiaryColorID;
    int kaijuEyeLeftColorID;
    int kaijuEyeRightColorID;

    /// <summary>
    /// Will add more variables for kaiju traits
    /// </summary>

    public void ParseSeed()
    {
        stats = gameObject.GetComponent<KaijuStats>();
        //create reference to hatchery script for IDs
        //kaijuTypeID = Random.Range(0,4);
        seed = stats.seed;
        stats = gameObject.GetComponent<KaijuStats>();
        for (int i = 0; i < KaijuTraitLibrary.instance.kaijuSeedList.Count; i++)
        {
            if (seed == KaijuTraitLibrary.instance.kaijuSeedList[i])
            {
                seedNum = i;
                return;
            }
        }

        seed = KaijuTraitLibrary.instance.kaijuSeedList[seedNum];
        stats.seed = KaijuTraitLibrary.instance.kaijuSeedList[seedNum];

        kaijuTypeID = int.Parse(seed.Substring(0,1));
        kaijuRarityID = int.Parse(seed.Substring(1,1));
        kaijuGeneID = int.Parse(seed.Substring(2,1));
        kaijuBaseColorID = int.Parse(seed.Substring(3,2));
        kaijuSecondaryColorID = int.Parse(seed.Substring(5,2));
        kaijuTertiaryColorID = int.Parse(seed.Substring(7,2));
        kaijuEyeLeftColorID = int.Parse(seed.Substring(9,2));
        kaijuEyeRightColorID = int.Parse(seed.Substring(11,2));
        stats.attack = int.Parse(seed.Substring(13, 3));
        stats.defence = int.Parse(seed.Substring(16, 3));
        stats.health = int.Parse(seed.Substring(19, 3));
        stats.speed = int.Parse(seed.Substring(22, 3));

        KaijuUpdateAppearance();
    }
    void Update()
    {
        
    }

    public void KaijuUpdateAppearance()
    {
        foreach (SpriteRenderer srColor in eggColorBase)
        {
            Color newColor;
            if (ColorUtility.TryParseHtmlString(KaijuTraitLibrary.instance.eggShellColorPrimary[kaijuTypeID], out newColor))
            {
                srColor.color = newColor;
            }
            else
            {
                Debug.LogError("Invalid hexcode");
            }
        }

        foreach (SpriteRenderer srColor in eggColorShell)
        {
            Color newColor;
            if (ColorUtility.TryParseHtmlString(KaijuTraitLibrary.instance.eggShellColorSecondary[kaijuRarityID], out newColor))
            {
                srColor.color = newColor;
            }
            else
            {
                Debug.LogError("Invalid hexcode");
            }
        }

        foreach (SpriteRenderer srColor in baseColor)
        {
            Color newColor;
            if (ColorUtility.TryParseHtmlString(KaijuTraitLibrary.instance.kaijuColorBase[kaijuBaseColorID], out newColor))
            {
                srColor.color = newColor;
            }
            else
            {
                Debug.LogError("Invalid hexcode");
            }
        }

        foreach (SpriteRenderer srColor in secondaryColor)
        {
            Color newColor;
            if (ColorUtility.TryParseHtmlString(KaijuTraitLibrary.instance.kaijuColorSecondary[kaijuSecondaryColorID], out newColor))
            {
                srColor.color = newColor;
            }
            else
            {
                Debug.LogError("Invalid hexcode");
            }
        }

        foreach (SpriteRenderer srColor in tertiaryColor)
        {
            Color newColor;
            if (ColorUtility.TryParseHtmlString(KaijuTraitLibrary.instance.kaijuColorTertiary[kaijuTertiaryColorID], out newColor))
            {
                srColor.color = newColor;
            }
            else
            {
                Debug.LogError("Invalid hexcode");
            }
        }

        foreach (SpriteRenderer srColor in eyeColorLeft)
        {
            Color newColor;
            if (ColorUtility.TryParseHtmlString(KaijuTraitLibrary.instance.kaijuEyeColor[kaijuEyeLeftColorID], out newColor))
            {
                srColor.color = newColor;
            }
            else
            {
                Debug.LogError("Invalid hexcode");
            }
        }

        foreach (SpriteRenderer srColor in eyeColorRight)
        {
            Color newColor;
            if (ColorUtility.TryParseHtmlString(KaijuTraitLibrary.instance.kaijuEyeColor[kaijuEyeRightColorID], out newColor))
            {
                srColor.color = newColor;
            }
            else
            {
                Debug.LogError("Invalid hexcode");
            }
        }

        switch (kaijuGeneID) //default gene is 0; if 0, no additional code necessary
        {
            case 1:
                kaijuJuvieCatGenesTabby.SetActive(true);
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
                break;
            case 5:
                kaijuJuvieCatGenesSpotted.SetActive(true);
                break;
            case 6:
                foreach (GameObject geneObject in kaijuJuvieCatGenesCalico)
                {
                    geneObject.SetActive(true);
                }
                break;
            case 7:
                foreach (GameObject geneObject in kaijuJuvieCatGenesPointed)
                {
                    geneObject.SetActive(true);
                }
                break;
            case 8:
                kaijuJuvieCatGenesVan.SetActive(true);
                break;
            default:
                break;
        }
    }


    public void MaturizeKaiju()
    {
        switch (kaijuGeneID) //default gene is 0; if 0, no additional code necessary
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
