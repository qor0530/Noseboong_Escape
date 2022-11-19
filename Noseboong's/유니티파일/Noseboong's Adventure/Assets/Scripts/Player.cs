using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{      
    public JoyStick joystick;   //조이스틱 스크립트
    //Rigidbody2D rb;
    private Vector3 _moveVector;    //플레이어 이동벡터
    public AudioSource audioSource;
    [SerializeField] private GameObject[] coins;
    private bool GoNextScene;
    [SerializeField] private GameManager GM;
    private float Speed = 3f;
    private float dashSpeed = 7f;
    private bool dashOn = true;
    private bool isBtnDown = false;
    Animator animator;
    private void Start()
    {
        _moveVector = Vector3.zero; //플레이어 이동벡터 초기화
        //rb.gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        coins = GameObject.FindGameObjectsWithTag("Coin");
        GM = FindObjectOfType<GameManager>();
        GoNextScene = false;
    }
    public void Update()
    {
        HandleInput();  //터치패드 입력받기
        Move();
        coins = GameObject.FindGameObjectsWithTag("Coin");

    }

    public void Clear()
    {
        coins = GameObject.FindGameObjectsWithTag("Coin");
        GM = FindObjectOfType<GameManager>();
        GoNextScene = false;
    }

    public void HandleInput()
    {
        _moveVector = poolInput();
    }

    public Vector3 poolInput()
    {
        float h = joystick.GetHorizontalValue();    //수펑
        float v = joystick.GetVerticalValue();      //수직
        Vector3 moveDir = new Vector3(h, v, 0).normalized;

        return moveDir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("충돌 :" + collision.gameObject.name);
        if (collision.gameObject.tag == "Coin")
        {
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("GameOver ON");
            GameOver();
        }
        if (collision.gameObject.tag == "Finish")
        {
            if (coins.Length > 0)
            {
                GoNextScene = false;
            }
            else if (coins.Length == 0)
            {
                GoNextScene = true;
            }
            else
            {
                GoNextScene = false;
            }
            
        }
        if (GoNextScene)
        {
            GM.NextScene();
            Invoke("Clear", 0.1f);
        }
    }

    void Move()
    {
        float xMove, yMove;
        float xMovej, yMovej;
        if (Input.GetKey(KeyCode.Space) && HealthGauge.health > 0.5f && dashOn || isBtnDown && dashOn) 
        {
            xMove = Input.GetAxis("Horizontal") * dashSpeed * Time.deltaTime; //x축으로 이동할 양
            xMovej = joystick.GetHorizontalValue() * dashSpeed * Time.deltaTime; //조이스틱 x축 이동 값
            yMove = Input.GetAxis("Vertical") * dashSpeed * Time.deltaTime; //y축으로 이동할양
            yMovej = joystick.GetVerticalValue() * dashSpeed * Time.deltaTime; //조이스틱 y축 이동 값
     
            HealthGauge.health -= 0.5f;
            if (HealthGauge.health <= 1)
            {
                dashOn = false;
                Invoke("DashOn", 3f);
            }
        }
        else
        {
            xMove = Input.GetAxis("Horizontal") * Speed * Time.deltaTime; //x축으로 이동할 양
            xMovej = joystick.GetHorizontalValue() * Speed * Time.deltaTime; //조이스틱 x축 이동 값
            yMove = Input.GetAxis("Vertical") * Speed * Time.deltaTime; //y축으로 이동할양
            yMovej = joystick.GetVerticalValue() * Speed * Time.deltaTime; //조이스틱 y축 이동 값

            if (HealthGauge.health <= 99)
                HealthGauge.health += 0.1f;
        }
        if (xMove < 0 || xMovej < 0)
        {
            transform.localScale = new Vector3(-2, 2, 1);
        }
        else
        {
            transform.localScale = new Vector3(2, 2, 1);
        }
        transform.Translate(new Vector3(xMove, yMove, 0));  //이동 (키보드)
        transform.Translate(new Vector3(xMovej, yMovej, 0));  //이동 (조이스틱)
        if (xMove == 0 && yMove == 0 && xMovej == 0 && yMovej == 0)
        {
            animator.SetBool("Isrun", false);
            audioSource.Stop();
        }
        else
        {
            animator.SetBool("Isrun", true);
            if(!audioSource.isPlaying)
                audioSource.Play();
        }   
    }

    public void DashOn()
    {
        dashOn = true;
    }

    public void PointerUp()
    {
        isBtnDown = false;
    }

    public void PointerDown()
    {
        isBtnDown = true;
    }
    public void GameOver()
    {
        Debug.Log("GameOver ON");
        SceneManager.LoadScene("GameOver" + Random.Range(1,3));
    }

}