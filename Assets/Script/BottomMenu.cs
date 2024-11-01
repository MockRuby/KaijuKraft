using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomMenu : MonoBehaviour
{
    public Animator anim;
    public GameObject buttonFlip;

    public void Clicked()
    {
        if (anim.GetBool("clickedBottom") == false)
        {
            anim.SetBool("clickedBottom", true);
        }
        else if (anim.GetBool("clickedBottom") == true)
        {
            anim.SetBool("clickedBottom", false);
        }
    }
    
    public void Flip()
    {
        buttonFlip.transform.Rotate(new Vector3(0, 0, 180));
    }
}