using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Camera mainCamera; // 메인 카메라
    private GameObject player;
    private GameObject finish;
    private Vector2 MousePosition;
    private bool IsMouse;
    private bool IsKeyBoard;

    public int sceneNum;

    private void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        player = GameObject.Find("Player");
        finish = GameObject.Find("Finish");
        DontDestroyOnLoad(gameObject);
    }

    public void NextScene()
    {
        sceneNum++;
        Debug.Log("NextScene ON");
        SceneManager.LoadScene("Scene" + sceneNum);
    }

    public void StartScene()
    {
        sceneNum = 0;
        Debug.Log("StartScene ON");
        SceneManager.LoadScene("Scene" + sceneNum);
    }
}