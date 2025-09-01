using Example;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    // 특정 시점, 특정 이벤트가 발생되고 나서 몬스터를 생성하고 싶음.

    [Header("몬스터 생성 정보")]
    [SerializeField] Transform[] spwanPositions;
    [SerializeField] GameObject[] monsterSpwaners;
    [SerializeField] MonsterInfo[] monsterInfos;

    [SerializeField] int spwanCount = 5;
    [SerializeField] float spwanIntervalTime = 0.75f;

    private Coroutine spwanCoroutine;
    private Monster monster = new();            // monsterInfos를 통해 직접 생성할 몬스터, new()를 붙이면 기본 생성자를 호출한 것과 같다.


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Spawn();
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            monster = ConstructMonster();
            monster.MonsterConstructor();
        }
    }

    /// <summary>
    /// 게임 월드 특정 위치에 몬스터를 생성할 때 몇마리를
    /// 생성할 것인지, 한번에 등장할 것인지 (그냥 반복문 돌리기), 시간에 걸쳐서 서서히 생성할 것인지 (코루틴 사용)
    /// ex). 유니티에서 함수 이름이 spwan이고 위의 두줄의 기능을 하는 함수를 만들어줘
    /// </summary>


    // 비어있는 몬스터의 데이터를 생성해주는 함수
    public Monster ConstructMonster()
    {
        Monster newMonster = new();
       
        int random = UnityEngine.Random.Range(0, monsterInfos.Length);
        newMonster.monsterInfo = monsterInfos[random];         // monsterInfos 배열중에서 하나를 선택하라는 의미
        return newMonster;

    }

    public void Spawn()
    {
        if (spwanCoroutine != null)
        {
            StopCoroutine(SpwanCoroutine());

        }
        spwanCoroutine = StartCoroutine(SpwanCoroutine());

        //StartCoroutine("SpwanCoroutine");       // 이 코드의 문제점 : 오타, 어디에서 문제가 발생했는지 버그를 찾기 어려움.
        //StartCoroutine(nameof(SpwanCoroutine)); // 문자열로 쓰고 싶다면 nameof 사용하기

        // 2가지 방식중에 어떤 코루틴 호출 방식을 사용하면 될까?
        // 두 방식 중에 원하는 방식을 사용하되, 방식을 통일해서 사용하기 

        // ※ 일관성있게 작성하기
        //StopCoroutine(SpwanCoroutine());
        //StopCoroutine(nameof(SpwanCoroutine));
    }

    private IEnumerator SpwanCoroutine()
    {
        for (int i = 0; i < spwanCount; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, spwanPositions.Length);
            int randomMonIndex = UnityEngine.Random.Range(0, monsterSpwaners.Length);
            Instantiate(monsterSpwaners[randomMonIndex], spwanPositions[randomIndex]);

            // interval 시간 후에 위의 코드를 다시 실행하라.
            yield return new WaitForSeconds(spwanIntervalTime);
        }
    }

}
