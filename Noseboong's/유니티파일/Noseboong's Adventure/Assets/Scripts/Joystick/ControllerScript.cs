using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControllerScript : MonoBehaviour
{
    public JoyStick joystick;   //조이스틱 스크립트

    [Header("이동속도 조절")]
    [SerializeField] [Range(1f, 20f)] public float MoveSpeed; //플레이어 이동속도
    [Header("대쉬속도 조절")]
    [SerializeField] [Range(1f, 20f)] public float DashSpeed; //플레이어 대쉬속도


    private Vector3 _moveVector;    //플레이어 이동벡터
    private Transform _transform;

    void Start()
    {
        _transform = transform;     //트렌스폼 캐싱
        _moveVector = Vector3.zero; //플레이어 이동벡터 초기화
    }

    void Update()
    {
        HandleInput();  //터치패드 입력받기
    }

    public void FixedUpdate()
    {
        Move();         //플레이어 이동
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

    public void Move()
    {
        float xMove, yMove;
        if (Input.GetKey(KeyCode.Space) && HealthGauge.health > 0.5f)
        {
            xMove = joystick.GetHorizontalValue() * DashSpeed * Time.deltaTime; //x축으로 이동할 양
            yMove = joystick.GetVerticalValue() * DashSpeed * Time.deltaTime; //y축으로 이동할양
            HealthGauge.health -= 0.5f;

        }
        else
        {
            xMove = joystick.GetHorizontalValue() * MoveSpeed * Time.deltaTime; //x축으로 이동할 양
            yMove = joystick.GetVerticalValue() * MoveSpeed * Time.deltaTime; //y축으로 이동할양
            if (HealthGauge.health <= 99)
                HealthGauge.health += 0.1f;
        }

        _transform.Translate(new Vector3(xMove, yMove, 0));  //이동
    }
}
