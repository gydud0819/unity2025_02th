using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;      // Random을 사용하면  UnityEngine.Random를 사용한다는 의미로 간주한다.

public class NPC : MonoBehaviour
{
    [SerializeField] NPCInfo npcInfo;


    // 클래스가 부착되어 있는 오브젝트의 다른 컴포넌트를 참조해서 사용할 수 있다.
    SpriteRenderer spriteRenderer;
    CircleCollider2D circleCollider;
    Rigidbody2D rigidbody2D;
    private Vector2 currentTargetPos;       // 언제 멈춰야할지 


    public void Awake()
    {
        // NPC 클래스와 같은 오브젝트에 부착되어 있는 컴포넌트를 GetComponent로 가져오기
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();

        // 컴포넌트에 데이터를 연결했다면 실제 데이터로 설정하기
        spriteRenderer.sprite = npcInfo.Sprite;

        rigidbody2D.gravityScale = 0;
    }

    private void Start()
    {
        Patrol();
    }

    private void Update()
    {
        // 목적지까지 이동 후 멈추기
        Stop();
    }

    public void Patrol()    // Patrol : 정찰하다
    {
        // 이동해라 = MoveTargetPoint
        MoveTargetPoint();

        // 특정 장소에 도착 후 일정 시간 대기
        WaitTime(3);

    }

    public void Stop()
    {
        // 특정 범위를 벗어나면? 또는 특정 위치에 도착을 했다면
        //if ()
        //{
        //    // vector 클래스 안에 distance 함수가 존재한다 
        //    // distance함수를 이용해서 특정 위치에 도달하면 멈추는 코드 만들기
        //    rigidbody2D.velocity = Vector2.zero;
        //}
    }

    public void WaitTime(float time)
    {

    }

    private void MoveTargetPoint()
    {
        // 속도의 랜덤값 구현
        int moveSpeed = UnityEngine.Random.Range(npcInfo.MinSpeed, npcInfo.MaxSpeed);
        // 위치의 랜덤값 구현
        Vector2 randomPos = (Vector2)transform.position + Random.insideUnitCircle * npcInfo.PatrolRadius;        // 반지름이 1일 때 랜덤값을 반환하는 코드
        currentTargetPos = randomPos;
        //Debug.Log(randomPos);

        // 이동 속도, 이동해야할 위치, 현재 위치 (이동해야할 방향)
        // 방향 * 속도 = 이동
        rigidbody2D.velocity = (randomPos - (Vector2)transform.position).normalized * moveSpeed;   // 두 벡터 위치 값과 속도를 사용해서 코드 구현하기 
    }
}
