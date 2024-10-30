using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class KaijuTraitLibrary
{
    public static Dictionary<string, float> kaijuWeight = new Dictionary<string, float>
    {
        {"Mammal", 25.0f},
        {"Avian", 25.0f},
        {"Aquatic", 25.0f},
        {"Reptile", 25.0f}
    };

    public static Dictionary<string, float> rarityWeight = new Dictionary<string, float>
    {
        {"Common", 50.0f},
        {"Uncommon", 30.0f},
        {"Rare", 15.0f},
        {"Legendary", 5.0f},
    };

    public static List<string> EggShellColorPrimary = new List<string>
    {
        "#FFD09C", //0 - cream: mammal
        "#FFE053", //1 - gold: avian
        "#6EFFF7", //2 - aqua: aquatic
        "#B0FF00" //3 - lime: reptile
    };

    public static List<string> EggShellColorSecondary = new List<string>
    {
        "#00FF5D", //0 - green: common
        "#3998FF", //1 - blue: uncommon
        "#C039FF", //2 - purple: rare
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

    public static List<string> KaijuColorTertiary = new List<string> //exclude white if base is white, exclude black if base is black; i cannot make them anymore black or white without sacrificing details
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

    public static List<string> EyeColor = new List<string>
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

    static string colorHex = "";
    
    public static void GenePick()
    {

    }
}
