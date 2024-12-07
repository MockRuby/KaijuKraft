using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public SpriteRenderer eggBaseSprite;
    public SpriteRenderer eggShellSprite;
    public Transform moveCam;
    public Camera mainCam;
    public TextMeshProUGUI general;
    public TextMeshProUGUI attack;
    public TextMeshProUGUI defence;
    public TextMeshProUGUI speed;
    public TextMeshProUGUI health;

    public void Scene(int scene)
    {
        KaijuStorage.instance.previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene);
    }

    public void SaveAllKaiju()
    {
        SavingKaiju.instance.SaveKaiju();
    }

    public void LoadAllKaiju()
    {
        SavingKaiju.instance.LoadKaiju();
    }

    public void BattleLoadKaiju()
    {
        SavingKaiju.instance.BattleLoad();
    }

    public void SpawnAEgg()
    {
        KaijuStorage.instance.SpawnEgg();
    }
    
    public void EggRoll(TextMeshProUGUI eggName)
    {
        KaijuStorage.instance.eggAmount++;
        mainCam.transform.position = moveCam.position;
        Color newColor;
        KaijuTraitLibrary.instance.KaijuGatcha();

        if (ColorUtility.TryParseHtmlString(KaijuTraitLibrary.instance.eggShellColorPrimary[KaijuTraitLibrary.instance.newKaijuTypeID], out newColor))
        {
            eggBaseSprite.color = newColor;
        }
        if (ColorUtility.TryParseHtmlString(KaijuTraitLibrary.instance.eggShellColorSecondary[KaijuTraitLibrary.instance.newKaijuRarityID], out newColor))
        {
            eggShellSprite.color = newColor;
        }

        KaijuTraitLibrary.instance.BuildAndStoreSeed(KaijuTraitLibrary.instance.newKaijuTypeID, KaijuTraitLibrary.instance.newKaijuRarityID, KaijuTraitLibrary.instance.newKaijuGeneID, KaijuTraitLibrary.instance.newKaijuBaseColorID, KaijuTraitLibrary.instance.newKaijuSecondaryColorID, KaijuTraitLibrary.instance.newKaijuTertiaryColorID, KaijuTraitLibrary.instance.newKaijuEyeLeftColorID, KaijuTraitLibrary.instance.newKaijuEyeRightColorID, KaijuTraitLibrary.instance.newKaijuAttackPts, KaijuTraitLibrary.instance.newKaijuDefencePts, KaijuTraitLibrary.instance.newKaijuHealthPts, KaijuTraitLibrary.instance.newKaijuSpeedPts);
        eggName.text = KaijuTraitLibrary.instance.kaijuRarityName[KaijuTraitLibrary.instance.newKaijuRarityID] + " " + KaijuTraitLibrary.instance.kaijuTypeName[KaijuTraitLibrary.instance.newKaijuTypeID] + " Egg";
    }

    public void FoodRoll()
    {
        int generalRange =  Random.Range(1, 11);
        int attackRange =  Random.Range(1, 11);
        int defenceRange =  Random.Range(1, 11);
        int speedRange =  Random.Range(1, 11);
        int healthRange =  Random.Range(1, 11);
        
        KaijuStorage.instance.generalFood += generalRange;
        general.text = "x" + generalRange;

        KaijuStorage.instance.attackFood += attackRange;
        attack.text = "x" + attackRange;

        KaijuStorage.instance.defenceFood += defenceRange;
        defence.text = "x" + defenceRange;

        KaijuStorage.instance.speedFood += speedRange;
        speed.text = "x" + speedRange;

        KaijuStorage.instance.healthFood += healthRange;
        health.text = "x" + healthRange;

    }
}
