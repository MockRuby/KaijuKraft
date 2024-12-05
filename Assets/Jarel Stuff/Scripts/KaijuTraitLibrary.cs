using System;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

public class KaijuTraitLibrary : MonoBehaviour
{
    public static KaijuTraitLibrary instance;
    public List<string> kaijuSeedList = new List<string>();

    static StringBuilder newSeed = new StringBuilder();

    public int newKaijuTypeID = 0;
    public int newKaijuRarityID = 0;
    public int newKaijuGeneID = 0;
    public int newKaijuAttackPts = 0;
    public int newKaijuHealthPts = 0;
    public int newKaijuDefencePts = 0;
    public int newKaijuSpeedPts = 0;
    public int newKaijuBaseColorID = 0;
    public string newKaijuBaseColor = "";
    public int newKaijuSecondaryColorID = 0;
    public string newKaijuSecondaryColor = "";
    public int newKaijuTertiaryColorID = 0;
    public string newKaijuTertiaryColor = "";
    public int newKaijuEyeLeftColorID = 0;
    public string newKaijuEyeLeftColor = "";
    public int newKaijuEyeRightColorID = 0;
    public string newKaijuEyeRightColor = "";
    public string newKaijuEggBaseColor = ""; //use typeID for color int ID
    public string newKaijuEggSecondaryColor = ""; //use rarityID for color int ID


    public List<string> kaijuTypeName = new List<string>
    {
        "Mammalian",
        "Avian",
        "Aquatic",
        "Reptilian"
    };

    public List<string> kaijuRarityName = new List<string>
    {
        "Common",
        "Uncommon",
        "Rare",
        "Legendary"
    };

    public List<string> eggShellColorPrimary = new List<string>
    {
        "#FFE8CC", //0 - cream: mammal
        "#FFF788", //1 - gold: avian
        "#5DDCFF", //2 - aqua: aquatic
        "#AAF600" //3 - lime: reptile
    };

    public List<string> eggShellColorSecondary = new List<string>
    {
        "#00EF31", //0 - green: common
        "#1C76FF", //1 - blue: uncommon
        "#B42DFD", //2 - purple: rare
        "#FF6900" //3 - orange: legendary
    };

    public List<string> kaijuColorBase = new List<string>
    {
        "#FFFFFF", //0 -----white-----bright/soft colors
        "#FFBA5B", //1 ginger
        "#FFE9C0", //2 cream
        "#F3B9D8", //3 berry
        "#B4E7FF", //4 ice
        "#DFFF94", //5 lime
        "#CBA8FF", //6 lilac
        "#3A3E44", //7 -----black-----dark/deep colors
        "#FF7400", //8 fire
        "#8E7057", //9 choco
        "#FF0009", //10 scarlet
        "#005CFF", //11 ocean
        "#00AE0F", //12 moss
        "#6536A2" //13 purple
    };

    public List<string> kaijuColorSecondary = new List<string> //exclude black if base is black
    {
        "#3A3E44", //0 black
        "#743318", //1 autumn
        "#E6A040", //2 ginger
        "#C8B187", //3 cream
        "#D894B8", //4 berry
        "#7EBFDE", //5 ice
        "#AAC767", //6 lime
        "#AA81E7", //7 lilac
        "#BF5700", //8 fire
        "#775335", //9 choco
        "#BF0007", //10 scarlet
        "#003CA6", //11 ocean
        "#007A0B", //12 moss
        "#491092" //13 purple
    };

    public List<string> kaijuColorTertiary =
        new
            List<string> //exclude white if base is white, exclude black if base/secondary is black; i cannot make them anymore black or white without sacrificing details
            {
                "#FFFFFF", //0 white
                "#FFC52A", //1 ginger
                "#FFCF8F", //2 cream
                "#FF79C8", //3 berry
                "#52DAFF", //4 ice
                "#BFFF4C", //5 lime
                "#B877FF", //6 lilac
                "#FFB900", //7 fire
                "#A77641", //8 choco
                "#FF4844", //9 scarlet
                "#427CFF", //10 ocean
                "#2EC64B", //11 moss
                "#7C55D0", //12 purple
                "#3A3E44" //13 black
            };

    public List<string> kaijuEyeColor = new List<string>
    {
        //common
        "#FFC23B", //0 amber
        "#00FF00", //1 green
        "#FFD700", //2 yellow
        "#00A4FF", //3 blue
        "#D26700", //4 hazel
        "#D7126C", //5 rose
        "#FFE2AF", //6 cream

        //uncommon
        "#B87333", //7 oxidized copper
        "#41CD66", //8 emerald green
        "#FF4500", //9 fiery orange
        "#C89EFF", //10 violet
        "#40E0D0", //11 turquoise

        //rare
        "#934421", //12 deep brown
        "#97D935", //13 lime green
        "#FF90D2", //14 berry pink
        "#FFD470", //15 metallic gold
        "#AADDFF", //16 frost blue

        //legendary
        "#9645FF", //17 amethyst purple
        "#FF0600", //18 scarlet red
        "#09D700" //19 neon green
    };

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one:" );
        }

        instance = this;
        DontDestroyOnLoad(this);
    }

    public void KaijuGenePick()
    {
        switch (newKaijuRarityID)
        {
            case 0:
                newKaijuGeneID = Random.Range(0, 3);
                break;
            case 1:
                newKaijuGeneID = Random.Range(3, 5);
                break;
            case 2:
                newKaijuGeneID = Random.Range(5, 7);
                break;
            case 3:
                newKaijuGeneID = Random.Range(7, 9);
                break;
            default:
                newKaijuGeneID = 0;
                break;
        }

        KaijuColorPicks();
        KaijuStatsRoll();
    }

    public void KaijuGatcha()
    {
        float mammalCap;
        float avianCap;
        float aquaticCap;
        float reptileCap;
        float commonCap;
        float uncommonCap;
        float rareCap;
        float kaijuRoll;
        float rarityRoll;
        //sets up the ranges
        mammalCap = BroodMotherData.mammalWeight;
        avianCap = mammalCap + BroodMotherData.avianWeight;
        aquaticCap = avianCap + BroodMotherData.aquaticWeight;
        reptileCap = aquaticCap + BroodMotherData.reptileWeight;
        commonCap = BroodMotherData.commonWeight;
        uncommonCap = commonCap + BroodMotherData.uncommonWeight;
        rareCap = uncommonCap + BroodMotherData.rareWeight;

        kaijuRoll = Random.Range(0.0f, 100.0f);
        rarityRoll = Random.Range(0.0f, 100.0f);

        if (kaijuRoll < mammalCap)
        {
            newKaijuTypeID = 0;
        }
        else if (kaijuRoll < avianCap)
        {
            newKaijuTypeID = 1;
        }
        else if (kaijuRoll < aquaticCap)
        {
            newKaijuTypeID = 2;
        }
        else
        {
            newKaijuTypeID = 3;
        }

        newKaijuEggBaseColor = eggShellColorPrimary[newKaijuTypeID];

        if (rarityRoll < commonCap)
        {
            newKaijuRarityID = 0;
        }
        else if (rarityRoll < uncommonCap)
        {
            newKaijuRarityID = 1;
        }
        else if (rarityRoll < rareCap)
        {
            newKaijuRarityID = 2;
        }
        else
        {
            newKaijuRarityID = 3;
        }

        newKaijuEggSecondaryColor = eggShellColorSecondary[newKaijuRarityID];

        KaijuGenePick();
    }

    public void KaijuColorPicks()
    {
        newKaijuBaseColorID = Random.Range(0, 14);
        newKaijuBaseColor = kaijuColorBase[newKaijuBaseColorID];

        if (newKaijuBaseColorID == 7)
        {
            newKaijuSecondaryColorID = Random.Range(1, 14);
            newKaijuSecondaryColor = kaijuColorSecondary[newKaijuSecondaryColorID];
        }
        else
        {
            newKaijuSecondaryColorID = Random.Range(0, 14);
            newKaijuSecondaryColor = kaijuColorSecondary[newKaijuSecondaryColorID];
        }

        if (newKaijuBaseColorID == 0)
        {
            newKaijuTertiaryColorID = Random.Range(1, 14);
            newKaijuTertiaryColor = kaijuColorTertiary[newKaijuTertiaryColorID];
        }
        else if (newKaijuBaseColorID == 7 || newKaijuSecondaryColorID == 0)
        {
            newKaijuTertiaryColorID = Random.Range(0, 13);
            newKaijuTertiaryColor = kaijuColorTertiary[newKaijuTertiaryColorID];
        }
        else
        {
            newKaijuTertiaryColorID = Random.Range(0, 14);
            newKaijuTertiaryColor = kaijuColorTertiary[newKaijuTertiaryColorID];
        }

        KaijuEyeColorPicks();
    }

    public void KaijuEyeColorPicks()
    {
        switch (newKaijuRarityID)
        {
            case 0:
                newKaijuEyeLeftColorID = Random.Range(0, 7);
                break;
            case 1:
                newKaijuEyeLeftColorID = Random.Range(0, 12);
                break;
            case 2:
                newKaijuEyeLeftColorID = Random.Range(0, 17);
                break;
            case 3:
                newKaijuEyeLeftColorID = Random.Range(0, 20);
                break;
            default:
                newKaijuEyeLeftColorID = Random.Range(0, 7);
                break;
        }

        if (newKaijuRarityID == 3)
        {
            newKaijuEyeRightColorID = Random.Range(0, 20);
            newKaijuEyeLeftColor = kaijuEyeColor[newKaijuEyeLeftColorID];
            newKaijuEyeRightColor = kaijuEyeColor[newKaijuEyeRightColorID];
        }
        else
        {
            newKaijuEyeRightColorID = newKaijuEyeLeftColorID;
            newKaijuEyeLeftColor = kaijuEyeColor[newKaijuEyeLeftColorID];
            newKaijuEyeRightColor = kaijuEyeColor[newKaijuEyeRightColorID];
        }
    }

    public void KaijuStatsRoll()
    {
        switch (newKaijuTypeID)
        {
            case 0: //mammal
                newKaijuAttackPts = 18;
                newKaijuDefencePts = 18;
                newKaijuHealthPts = 24;
                newKaijuSpeedPts = 15;

                if (newKaijuRarityID == 1)
                {
                    newKaijuAttackPts = newKaijuAttackPts * 2;
                    newKaijuDefencePts = newKaijuDefencePts * 2;
                    newKaijuHealthPts = Mathf.RoundToInt(newKaijuHealthPts * 2.5f);
                    newKaijuSpeedPts = Mathf.RoundToInt(newKaijuSpeedPts * 1.5f);
                }
                else if (newKaijuRarityID == 2)
                {
                    newKaijuAttackPts = newKaijuAttackPts * 4;
                    newKaijuDefencePts = newKaijuDefencePts * 4;
                    newKaijuHealthPts = Mathf.RoundToInt(newKaijuHealthPts * 4.5f);
                    newKaijuSpeedPts = Mathf.RoundToInt(newKaijuSpeedPts * 3.5f);
                }
                else if (newKaijuRarityID == 3)
                {
                    newKaijuAttackPts = newKaijuAttackPts * 7;
                    newKaijuDefencePts = newKaijuDefencePts * 7;
                    newKaijuHealthPts = Mathf.RoundToInt(newKaijuHealthPts * 7.5f);
                    newKaijuSpeedPts = Mathf.RoundToInt(newKaijuSpeedPts * 6.5f);
                }

                break;
            case 1: //avian
                newKaijuAttackPts = 14;
                newKaijuDefencePts = 12;
                newKaijuHealthPts = 14;
                newKaijuSpeedPts = 24;

                if (newKaijuRarityID == 1)
                {
                    newKaijuAttackPts = newKaijuAttackPts * 2;
                    newKaijuDefencePts = Mathf.RoundToInt(newKaijuDefencePts * 1.5f);
                    newKaijuHealthPts = newKaijuHealthPts * 2;
                    newKaijuSpeedPts = Mathf.RoundToInt(newKaijuSpeedPts * 2.5f);
                }
                else if (newKaijuRarityID == 2)
                {
                    newKaijuAttackPts = newKaijuAttackPts * 4;
                    newKaijuDefencePts = Mathf.RoundToInt(newKaijuDefencePts * 3.5f);
                    newKaijuHealthPts = newKaijuHealthPts * 4;
                    newKaijuSpeedPts = Mathf.RoundToInt(newKaijuSpeedPts * 4.5f);
                }
                else if (newKaijuRarityID == 3)
                {
                    newKaijuAttackPts = newKaijuAttackPts * 7;
                    newKaijuDefencePts = Mathf.RoundToInt(newKaijuDefencePts * 6.5f);
                    newKaijuHealthPts = newKaijuHealthPts * 7;
                    newKaijuSpeedPts = Mathf.RoundToInt(newKaijuSpeedPts * 7.5f);
                }

                break;
            case 2: //aquatic
                newKaijuAttackPts = 12;
                newKaijuDefencePts = 24;
                newKaijuHealthPts = 20;
                newKaijuSpeedPts = 18;

                if (newKaijuRarityID == 1)
                {
                    newKaijuAttackPts = Mathf.RoundToInt(newKaijuAttackPts * 1.5f);
                    newKaijuDefencePts = Mathf.RoundToInt(newKaijuDefencePts * 2.5f);
                    newKaijuHealthPts = newKaijuHealthPts * 2;
                    newKaijuSpeedPts = newKaijuSpeedPts * 2;
                }
                else if (newKaijuRarityID == 2)
                {
                    newKaijuAttackPts = Mathf.RoundToInt(newKaijuAttackPts * 3.5f);
                    newKaijuDefencePts = Mathf.RoundToInt(newKaijuDefencePts * 4.5f);
                    newKaijuHealthPts = newKaijuHealthPts * 4;
                    newKaijuSpeedPts = newKaijuSpeedPts * 4;
                }
                else if (newKaijuRarityID == 3)
                {
                    newKaijuAttackPts = Mathf.RoundToInt(newKaijuAttackPts * 6.5f);
                    newKaijuDefencePts = Mathf.RoundToInt(newKaijuDefencePts * 7.5f);
                    newKaijuHealthPts = newKaijuHealthPts * 7;
                    newKaijuSpeedPts = newKaijuSpeedPts * 7;
                }

                break;
            case 3: //reptilian
                newKaijuAttackPts = 24;
                newKaijuDefencePts = 15;
                newKaijuHealthPts = 14;
                newKaijuSpeedPts = 11;

                if (newKaijuRarityID == 1)
                {
                    newKaijuAttackPts = Mathf.RoundToInt(newKaijuAttackPts * 2.5f);
                    newKaijuDefencePts = newKaijuDefencePts * 2;
                    newKaijuHealthPts = newKaijuHealthPts * 2;
                    newKaijuSpeedPts = Mathf.RoundToInt(newKaijuSpeedPts * 1.5f);
                }
                else if (newKaijuRarityID == 2)
                {
                    newKaijuAttackPts = Mathf.RoundToInt(newKaijuAttackPts * 4.5f);
                    newKaijuDefencePts = newKaijuDefencePts * 4;
                    newKaijuHealthPts = newKaijuHealthPts * 4;
                    newKaijuSpeedPts = Mathf.RoundToInt(newKaijuSpeedPts * 3.5f);
                }
                else if (newKaijuRarityID == 3)
                {
                    newKaijuAttackPts = Mathf.RoundToInt(newKaijuAttackPts * 7.5f);
                    newKaijuDefencePts = newKaijuDefencePts * 7;
                    newKaijuHealthPts = newKaijuHealthPts * 7;
                    newKaijuSpeedPts = Mathf.RoundToInt(newKaijuSpeedPts * 6.5f);
                }

                break;
            default:
                break;
        }
    }

    public void BuildAndStoreSeed(int typeID, int rarityID, int geneID, int baseColorID, int secondaryColorID,
        int tertiaryColorID, int eyeLeftColorID, int eyeRightColorID, int attackValue, int defenceValue,
        int healthValue, int speedValue)
    {
        newSeed.Append(typeID.ToString());
        newSeed.Append(rarityID.ToString());
        newSeed.Append(geneID.ToString());
        newSeed.Append(baseColorID.ToString("D2"));
        newSeed.Append(secondaryColorID.ToString("D2"));
        newSeed.Append(tertiaryColorID.ToString("D2"));
        newSeed.Append(eyeLeftColorID.ToString("D2"));
        newSeed.Append(eyeRightColorID.ToString("D2"));

        newSeed.Append(attackValue.ToString("D3"));
        newSeed.Append(defenceValue.ToString("D3"));
        newSeed.Append(healthValue.ToString("D3"));
        newSeed.Append(speedValue.ToString("D3"));

        string fullSeed = newSeed.ToString();
        kaijuSeedList.Add(fullSeed);
        newSeed.Clear();
        Debug.Log(fullSeed);
    }
}