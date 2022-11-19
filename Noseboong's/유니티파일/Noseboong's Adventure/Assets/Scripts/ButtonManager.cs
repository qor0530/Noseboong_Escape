using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    public void GoScene()
    {
        SceneManager.LoadScene(1);
    }

    public void GoHelp()
    {
        SceneManager.LoadScene("tutorial");
    }

    public void GoMain()
    {
        SceneManager.LoadScene(0);
    }

    public void Out()
    {
        Application.Quit();
    }
}
