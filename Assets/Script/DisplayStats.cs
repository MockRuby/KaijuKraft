using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayStats : MonoBehaviour
{
    public KaijuStats kaijuStats; // Reference to the KaijuStats script
    public TextMeshPro statsText; // Reference to the TextMeshPro Text component
    public TextMeshPro foodText; // Referance to the text for food

    private void Start()
    {
        kaijuStats = gameObject.GetComponent<KaijuStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (kaijuStats != null)
        {
            string statsInfo = $"Name: {gameObject.name}\n" +
                               $"Stage: {kaijuStats.stageOfLife}\n" +
                               $"Health: {kaijuStats.health}\n" +
                               $"Attack: {kaijuStats.attack}\n" +
                               $"Defence: {kaijuStats.defence}\n" +
                               $"Speed: {kaijuStats.speed}";

            statsText.text = statsInfo;

            string foodInfo = $"General Food: {kaijuStats.generalFood}\n" +
                              $"Food for Health: {kaijuStats.foodHealth}\n" +
                              $"Food for Attack: {kaijuStats.foodAttack}\n" +
                              $"Food for Defence: {kaijuStats.foodDefence}\n" +
                              $"Food for Speed: {kaijuStats.foodSpeed}";
            foodText.text = foodInfo;
        }
    }
}