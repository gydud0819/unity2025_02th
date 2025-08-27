using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Example;

public class MonsterMove : MonoBehaviour
{
    // 2d 월드에서 랜덤한 위치로 이동하는 코드를 작성해줘
    // 이동 속도는 얼마인지, 이동하는 방식은 무엇인지 rigidbody 2D를 이용한 물리엔진 방식
    // 서로 충돌했을 때 어떻게 되는지 = 서로 충돌하면 사라지게 해보기 
    // 함수이름 : Move
    // Start is called before the first frame update

    [Header("몬스터 움직이기")]
    [SerializeField] float moveSpeed = 3.0f;
    [SerializeField] Rigidbody2D rigidbody2D;

    private Vector2 monsterPosition;

    void Start()
    {
        if (rigidbody2D == null)
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        RandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        if(Vector2.Distance(transform.position, monsterPosition) < 1.0f)
        {
            RandomPosition();
        }

        Vector2 dir = (monsterPosition - (Vector2)transform.position).normalized;
        rigidbody2D.velocity = dir * moveSpeed;
    }

    public void RandomPosition()
    {
        Camera mainCamera = Camera.main;

        if(mainCamera == null)
        {
            return;
        }

        float randX = mainCamera.transform.position.x;
        float randY = mainCamera.transform.position.y;

        float screenAspect = (float) Screen.width / (float)Screen.height;   // 해상도는 정수니까 float으로 명시적 형변환 해주기
        float cameraHeight = mainCamera.orthographicSize * 2f;   // 카메라 화면 넓이 구하는 코드
        float cameraWidth = cameraHeight * screenAspect;

        float randomX = Random.Range(randX - cameraWidth / 2, randX + cameraWidth / 2);
        float randomY = Random.Range(randY - cameraWidth / 2, randY + cameraWidth / 2);

        monsterPosition=  new Vector2(randomX, randomY);
    }

}
