using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggUpdate : MonoBehaviour
{
    public KaijuGeneration kaiGen;
    // Start is called before the first frame update
    public void DestroyOnHatch()
    {
        kaiGen.KaijuGenePick();
        gameObject.SetActive(false);
    }
}
