using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMenu : MonoBehaviour
{
    public Animator anim;
    public SavingKaiju save;

    public void Clicked()
    {
        anim.SetBool("clicked", true);
    }

    public void UnClicked()
    {
        anim.SetBool("clicked", false);
    }

    public void QuitGame()
    {
        save.SaveKaiju();
        Application.Quit();
    }
}