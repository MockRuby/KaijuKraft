using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// THIS IS JUST FOR OBSERVATION PURPOSES
/// </summary>
/*public class RNGManager : MonoBehaviour
{
    int common = 0;
    int uncommon = 0;
    int rare = 0;
    int legendary = 0;

    int commonWeight = 30;
    int uncommonWeight = 50;
    int rareWeight = 65;
    int legendaryWeight = 99;

    int modWeight = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("20 Random Rolls from 0 to 99:");
        for (int i = 0; i < 20; i++)
        {
            int randomRoll = Random.Range(0, 100);
            if (randomRoll < commonWeight)
            {
                common++;
            }
            else if (randomRoll < uncommonWeight)
            {
                uncommon++;
            }
            else if (randomRoll < rareWeight)
            {
                rare++;
            }
            else
            {
                legendary++;
            }
            //Debug.Log(randomRoll);
        }
        Debug.Log("Common: " + common + "\nUncommon: " + uncommon + "\nRare: " + rare + "\nLegendary: " + legendary);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SimRNG()
    {
        common = 0;
        uncommon = 0;
        rare = 0;
        legendary = 0;

        for (int i = 0; i < 20; i++)
        {
            int randomRoll = Random.Range(0, 100);
            if (randomRoll < 5)
            {
                legendary++;
            }
            else if (randomRoll < 15)
            {
                rare++;
            }
            else if (randomRoll < 30)
            {
                uncommon++;
            }
            else
            {
                common++;
            }
            //Debug.Log(randomRoll);
        }
        Debug.Log("Common: " + common + "\nUncommon: " + uncommon + "\nRare: " + rare + "\nLegendary: " + legendary);
    }
}
*/