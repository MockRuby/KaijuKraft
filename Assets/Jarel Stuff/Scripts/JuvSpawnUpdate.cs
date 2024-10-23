using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuvSpawnUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;

    string boolEggOpen = "inEgg";

    public void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void HasSpawnedUpdate()
    {
        animator.SetBool(boolEggOpen, false);
    }
}
