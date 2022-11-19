using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public GameObject btnCanvas;

    public void AnimDone()
    {
        BtnOn();
    }

    public void BtnOn()
    {
        btnCanvas.gameObject.SetActive(true);
    }
}
