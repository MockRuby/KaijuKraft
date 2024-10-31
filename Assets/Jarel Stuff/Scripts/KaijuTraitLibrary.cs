using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class KaijuTraitLibrary
{

    public static float mammalWeight = 25.0f;
    public static float avianWeight = 25.0f;
    public static float aquaticWeight = 25.0f;
    public static float reptileWeight = 25.0f;

    public static float commonWeight = 50.0f;
    public static float uncommonWeight = 30.0f;
    public static float rareWeight = 15.0f;
    public static float legendaryWeight = 5.0f;

    public static float motherBellySaturation = 50.0f;
    public static bool motherBellyFull = false;

    public static int newKaijuTypeID = 0;
    public static int newKaijuRarityID = 0;
    public static int newKaijuGeneID = 0;
    public static string newKaijuBaseColor = "";
    public static string newKaijuSecondaryColor = "";
    public static string newKaijuTertiaryColor = "";
    public static string newKaijuEyeLeftColor = "";
    public static string newKaijuEyeRightColor = "";
    public static string newKaijuEggBaseColor = "";
    public static string newKaijuEggSecondaryColor = "";

    public static List<string> EggShellColorPrimary = new List<string>
    {
        "#FFE8CC", //0 - cream: mammal
        "#FFF788", //1 - gold: avian
        "#5DDCFF", //2 - aqua: aquatic
        "#AAF600" //3 - lime: reptile
    };

    public static List<string> EggShellColorSecondary = new List<string>
    {
        "#00EF31", //0 - green: common
        "#1C76FF", //1 - blue: uncommon
        "#B42DFD", //2 - purple: rare
        "#FF6900" //3 - orange: legendary
    };

    public static List<string> KaijuColorBase = new List<string>
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

    public static List<string> KaijuColorSecondary = new List<string> //exclude black if base is black
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

    public static List<string> KaijuColorTertiary = new List<string> //exclude white if base is white, exclude black if base/secondary is black; i cannot make them anymore black or white without sacrificing details
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

    public static List<string> KaijuEyeColor = new List<string>
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
        "#09D700"  //19 neon green
    };

    public static void KaijuGenePick()
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
    }

    public static void KaijuGatcha()
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
        mammalCap = mammalWeight;
        avianCap = mammalCap + avianWeight;
        aquaticCap = avianCap + aquaticWeight;
        reptileCap = aquaticCap + reptileWeight;
        commonCap = commonWeight;
        uncommonCap = commonCap + uncommonWeight;
        rareCap = uncommonCap + rareWeight;

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
        newKaijuEggBaseColor = EggShellColorPrimary[newKaijuTypeID];

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
        newKaijuEggSecondaryColor = EggShellColorSecondary[newKaijuRarityID];

        KaijuGenePick();
    }

    public static void KaijuColorPicks()
    {
        int baseColorID;
        int secondaryColorID;
        int tertiaryColorID;
        int eyeColorCount = KaijuEyeColor.Count;

        baseColorID = Random.Range(0, 14);
        newKaijuBaseColor = KaijuColorBase[baseColorID];

        if (baseColorID == 7)
        {
            secondaryColorID = Random.Range(1, 14);
            newKaijuSecondaryColor = KaijuColorSecondary[secondaryColorID];
        }
        else
        {
            secondaryColorID = Random.Range(0, 14);
            newKaijuSecondaryColor = KaijuColorSecondary[secondaryColorID];
        }

        if (baseColorID == 0)
        {
            tertiaryColorID = Random.Range(1, 14);
            newKaijuTertiaryColor = KaijuColorTertiary[tertiaryColorID];
        }
        else if (baseColorID == 7 || secondaryColorID == 0)
        {
            tertiaryColorID = Random.Range(0, 13);
            newKaijuTertiaryColor = KaijuColorTertiary[tertiaryColorID];
        }
        else
        {
            tertiaryColorID = Random.Range(0, 14);
            newKaijuTertiaryColor = KaijuColorTertiary[tertiaryColorID];
        }

        KaijuEyeColorPicks();
    }

    public static void KaijuEyeColorPicks()
    {
        int eyeColorID;
        int eyeColorHeteroID;

        switch (newKaijuRarityID)
        {
            case 0:
                eyeColorID = Random.Range(0,7);
                break;
            case 1:
                eyeColorID = Random.Range(0, 12);
                break;
            case 2:
                eyeColorID = Random.Range(0, 17);
                break;
            case 3:
                eyeColorID = Random.Range(0, 20);
                break;
            default:
                eyeColorID = Random.Range(0, 7);
                break;
        }

        if (newKaijuRarityID == 3)
        {
            eyeColorHeteroID = Random.Range(0, 20);
            newKaijuEyeLeftColor = KaijuEyeColor[eyeColorID];
            newKaijuEyeRightColor = KaijuEyeColor[eyeColorHeteroID];
        }
        else
        {
            newKaijuEyeLeftColor = KaijuEyeColor[eyeColorID];
            newKaijuEyeRightColor = KaijuEyeColor[eyeColorID];
        }
    }
}
