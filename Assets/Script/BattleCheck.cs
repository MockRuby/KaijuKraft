using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCheck : MonoBehaviour
{
    public GameObject battle;

    // Update is called once per frame
    void Update()
    {
        if (!battle.activeInHierarchy)
        {
            foreach (GameObject kaiju in GameObject.FindGameObjectsWithTag("Kaiju"))
            {
                if (kaiju.GetComponent<KaijuStats>().stageOfLife == KaijuStats.StagesOfLife.Adult)
                {
                    battle.SetActive(true);
                }
            }
        }
    }
}
