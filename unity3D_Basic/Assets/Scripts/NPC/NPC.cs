using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;      // Random을 사용하면  UnityEngine.Random를 사용한다는 의미로 간주한다.

public enum CollisionEvent
{
    Friendly, hostile, Undefined
}

public class NPC : MonoBehaviour
{
    [SerializeField] public NPCInfo npcInfo;
    [SerializeField] CollisionEvent collisionEvent = CollisionEvent.Undefined;


    // 클래스가 부착되어 있는 오브젝트의 다른 컴포넌트를 참조해서 사용할 수 있다.
    SpriteRenderer spriteRenderer;
    CircleCollider2D circleCollider;
    Rigidbody2D rigidbody2D;


    [SerializeField] private Vector2 currentTargetPos;       // 언제 멈춰야할지 
    [SerializeField] private bool isMoving;                 // 목적지에 도착 후 한번만 위치를 재설정 하기위한 변수

    private Transform playerPos;


    // 정찰, 추적 기능


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
        SetRandomPos();

    }

    private void Update()
    {
        // 목적지까지 이동 후 멈추기

        // 언제 정찰을 할 것인지, 현재 플레이어와의 거리에 따라 정찰할지 추적할지 정하기
        if (isPatrol())
            Patrol();
        //else if(/*공격 최소 거리*/)
        // 스턴 걸기
        else
            Chase();
        // 언제 추적할 것인지
    }

    // 현재 상태를 체크해주는 함수
    bool isPatrol()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        if (Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < npcInfo.PatrolDistance)
            return false;
        else
            return true;

    }



    public void Patrol()    // Patrol : 정찰하다
    {
        // 이동해라 = MoveTargetPoint
        MoveTargetPoint();

        // 특정 장소에 도착 후 일정 시간 대기

    }

    public void Chase()
    {
        // 플레이어를 받아와야 한다.
        // 어떻게 받아올 것인지, 게임오브젝트의 이름이 player, tag가 player오브젝트를 전달해준다.

        SetPostion(playerPos.position);
        MoveTargetPoint();
    }

    public void WaitTime(float time)
    {
        // 대기 시간이면 스턴같은거 해도될려나 
        // 몹이 플레이어와의 거리가 2이하면 몹을 2초 동안 스턴걸고 플레이어는 도망가고
    }

    private void MoveTargetPoint()
    {
        // 속도의 랜덤값 구현
        int moveSpeed = UnityEngine.Random.Range(npcInfo.MinSpeed, npcInfo.MaxSpeed);
        // 위치의 랜덤값 구현

        // 이동 속도, 이동해야할 위치, 현재 위치 (이동해야할 방향)
        // 방향 * 속도 = 이동

        // 목적지까지 도착했다면 멈추기
        if (Vector2.Distance(transform.position, currentTargetPos) < npcInfo.StopDistance)      // 0.1 : 대상과의 멈추기 위한 거리 StopDistance
        {
            rigidbody2D.velocity = Vector2.zero;
            isMoving = true;
            // 잠시 기다리는 시간 부여하기
            //if (isMoving)    // 한번만 실행하게 하기 위해서
            //{
            //    StartCoroutine(SetRandomPosCoroutine());
            //
            //}
            SetRandomPos();
            //Invoke(nameof(SetRandomPos), 1f);       // 단순한 지연 함수를 사용할때 좋음
        }
        else
        {
            // 그렇지 않으면 계속 이동하기
            rigidbody2D.velocity = (currentTargetPos - (Vector2)transform.position).normalized * moveSpeed;   // 두 벡터 위치 값과 속도를 사용해서 코드 구현하기 

        }


    }

    private void SetRandomPos()     // 이동해야할 랜덤 위치 함수 
    {
        currentTargetPos = (Vector2)transform.position + Random.insideUnitCircle * npcInfo.PatrolRadius;        // 반지름이 1일 때 랜덤값을 반환하는 코드
    }

    public void SetPostion(Vector2 position)
    {
        currentTargetPos = position;
    }

    private IEnumerator SetRandomPosCoroutine()
    {
        // 1초가 되기 전에 
        isMoving = false;
        yield return new WaitForSeconds(1f);
        SetRandomPos();
    }

    private void OnDrawGizmos()
    {
        //DrawChaseCircle();
    }

    // 기즈모를 그리는 특수한 함수
    private void OnDrawGizmosSelected()     // selected가 붙은 기즈모 함수를 사용하는 게 좋음
    {
        DrawChaseCircle();
    }

    private void DrawChaseCircle()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, npcInfo.PatrolRadius);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collisionEvent == CollisionEvent.Friendly)
            {
                Debug.Log("친화적인 이벤트 발생");
                Bus<ICollsionPlayerEvent>.Raise(new ICollsionPlayerEvent(this));
                gameObject.SetActive(false);
            }
            else if(collisionEvent == CollisionEvent.hostile)
            {
                Debug.Log("적대적인 이벤트 발생");
                Bus<ICollsionPlayerEvent>.Raise(new ICollsionPlayerEvent(this));
                gameObject.SetActive(false);
            }
            else
            {
                Debug.LogWarning("정의되지 않은 이벤트가 발생했습니다");
            }
        }
    }
}
