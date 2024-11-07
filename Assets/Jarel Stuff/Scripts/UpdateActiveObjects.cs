using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateActiveObjects : MonoBehaviour
{
    KaijuStats stats;

    public List<GameObject> kaiju = new List<GameObject>();
    [SerializeField] private GameObject eggObject;
    [SerializeField] private GameObject juvObject;

    [SerializeField] private Animator eggAnimator;
    [SerializeField] private Animator juvAnimator;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject kaijuGameObjects in GameObject.FindGameObjectsWithTag("Kaiju"))
        {
            kaiju.Add(kaijuGameObjects);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
