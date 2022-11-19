using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCreply : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private TextMesh text;
    private bool cooltime = true;


    private void Update()
    {
        text.gameObject.SetActive(false);
        if (!cooltime)
            text.gameObject.SetActive(true);
    }

    private void OnMouseOver()
    {
        if (cooltime)
            anim.gameObject.SetActive(true);
        else
            anim.gameObject.SetActive(false);
    }

    private void OnMouseExit()
    {
        anim.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        cooltime = false;
        Invoke("CoolTime", 5f);
    }

    private void CoolTime()
    {
        cooltime = true;
    }
}
