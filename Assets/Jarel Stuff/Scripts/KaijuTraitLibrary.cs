using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaijuTraitLibrary
{
    string colorHex = "";
    public void KaijuEggColorList(int typeID, int rarityID)
    {
        switch (typeID)
        {
            case 0: //cream
                colorHex = "#FFF7A8";
                break;
            case 1: //yellow
                colorHex = "#FFFE6C";
                break;
            case 2: //cyan
                colorHex = "#56FFF7";
                break;
            case 3: //green
                colorHex = "#00FF34";
                break;
            default:
                break;
        }

        switch (rarityID)
        {
            case 0: //cream
                colorHex = "#FFF7A8";
                break;
            case 1: //yellow
                colorHex = "#FFFE6C";
                break;
            case 2: //cyan
                colorHex = "#56FFF7";
                break;
            case 3: //green
                colorHex = "#00FF34";
                break;
            default:
                break;
        }
    }

    public void KaijuBaseColorList()
    {

    }

    public void KaijuSecondaryColorList()
    {

    }

    public void KaijuTertiaryColorList()
    {

    }

    public void KaijuEyeColorList()
    {

    }
}
