using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Battling : MonoBehaviour
{
    public KaijuStats kaiju1;
    public KaijuStats kaiju2;
    public bool startBattle = false;

    private float kaiju1AttackTime;
    private float kaiju2AttackTime;

    private bool attack1;
    private bool attack2;

    public Image kaiju1DesplayHealth;
    public Image kaiju2DesplayHealth;

    public GameObject attackTextKaiju1;
    public GameObject attackTextKaiju2;

    public TextMeshProUGUI playerWin;


    private void Start()
    {
        kaiju1AttackTime = 1 - (float)kaiju1.speed / 500;
        kaiju2AttackTime = 1 - (float)kaiju2.speed / 500;

        attack1 = true;
        attack2 = true;
    }

    void Update()
    {
        if (startBattle)
        {
            // Perform battle actions for kaiju1 and kaiju2
            BattleRound();


            // Display the winner based on the final stats
            DisplayWinner();
        }

        kaiju1DesplayHealth.fillAmount = kaiju1.currentHealth / kaiju1.health;
        kaiju2DesplayHealth.fillAmount = kaiju2.currentHealth / kaiju2.health;
    }

    // Function to simulate a single round of battle between two kaiju
    void BattleRound()
    {
        if (attack1 == true)
        {
            Debug.Log("Kaiju 1 attacktime:" + kaiju1AttackTime);
            attack1 = false;
            StartCoroutine(Kaiju1Attack());
        }

        if (attack2 == true)
        {
            attack2 = false;
            StartCoroutine(Kaiju2Attack());
        }
    }

    // Function to display the winner of the battle based on the final stats
    void DisplayWinner()
    {
        if (0 >= kaiju2.currentHealth)
        {
            Debug.Log("Kaiju 1 wins the battle!");
            playerWin.gameObject.SetActive(true);
            playerWin.text = "You Win";
            startBattle = false;
        }
        else if (0 >= kaiju1.currentHealth)
        {
            Debug.Log("Kaiju 2 wins the battle!");
            playerWin.gameObject.SetActive(true);
            playerWin.text = "You Loose";
            startBattle = false;
        }
        else if (kaiju1.currentHealth <= 0 && kaiju2.currentHealth <= 0)
        {
            Debug.Log("It's a tie!");
            playerWin.gameObject.SetActive(true);
            playerWin.text = "You Tie";
            startBattle = false;
        }
    }

    public void StartBattle()
    {
        kaiju1.currentHealth = kaiju1.health;
        kaiju2.currentHealth = kaiju2.health;
        startBattle = true;
    }

    private IEnumerator Kaiju1Attack()
    {
        yield return new WaitForSeconds(kaiju1AttackTime);
        attackTextKaiju1.SetActive(true);
        float kaijuADamage = (1 - (float)kaiju2.defence / 1000) * kaiju1.attack;
        kaiju2.currentHealth -= kaijuADamage;
        attack1 = true;
        StartCoroutine(KaijuAttack1());
    }

    IEnumerator Kaiju2Attack()
    {
        yield return new WaitForSeconds(kaiju2AttackTime);
        attackTextKaiju2.SetActive(true);
        float kaijuBDamage = (1 - (float)kaiju1.defence / 1000) * kaiju2.attack;
        kaiju1.currentHealth -= kaijuBDamage;
        attack2 = true;
        StartCoroutine(KaijuAttack2());
    }

    IEnumerator KaijuAttack1()
    {
        yield return new WaitForSeconds(0.2f);
        attackTextKaiju1.SetActive(false);
    }

    IEnumerator KaijuAttack2()
    {
        yield return new WaitForSeconds(0.2f);
        attackTextKaiju2.SetActive(false);
    }
}