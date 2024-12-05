using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public void Scene(int scene)
    {
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

    public void GetEgg()
    {
        KaijuStorage.instance.SpawnEgg();
    }
}
