using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnFocus : MonoBehaviour
{

    public KaijuFocus focus;

    private void OnMouseDown()
    {
        focus.focusedKaiju = null;
    }
}
