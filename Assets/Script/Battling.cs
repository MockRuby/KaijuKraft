using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battling : MonoBehaviour
{
    public KaijuStats kaiju1;
    public KaijuStats kaiju2;
    public bool startBattle = false;

    void Update()
    {
        if (startBattle)
        {
            // Simulate battle rounds
            for (int i = 0; i < 5; i++) // Simulating 5 rounds of battle
            {
                // Perform battle actions for kaiju1 and kaiju2
                BattleRound(kaiju1, kaiju2);
            }

            // Display the winner based on the final stats
            DisplayWinner();
            startBattle = false;
        }
    }

    // Function to simulate a single round of battle between two kaiju
    void BattleRound(KaijuStats kaijuA, KaijuStats kaijuB)
    {
        kaijuA.health -= kaijuB.attack - kaijuA.defence;
        kaijuB.health -= kaijuA.attack - kaijuB.defence;
    }

    // Function to display the winner of the battle based on the final stats
    void DisplayWinner()
    {
        if (0 >= kaiju2.health)
        {
            Debug.Log("Kaiju 1 wins the battle!");
        }
        else if (0 >= kaiju1.health)
        {
            Debug.Log("Kaiju 2 wins the battle!");
        }
        else
        {
            Debug.Log("It's a tie!");
        }
    }

    public void StartBattle()
    {
        startBattle = true;
    }
}