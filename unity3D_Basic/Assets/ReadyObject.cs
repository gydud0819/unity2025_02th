using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyObject : MonoBehaviour
{
    // Ready Script가 Start 텍스트가 작성 되면 Square 오브젝트의 색상을 기존 색상과 다른 색으로 변경해보기

    // void Start -> IEnumerator Start로 바꾸기

    [SerializeField] SpriteRenderer spr;
    [SerializeField] SpriteRenderer spr2;
    [SerializeField] SpriteRenderer spr3;

    IEnumerator Start()
    {

        yield return new WaitForSeconds(6f);      // IEnumerator를 사용할 땐 yeild return 쓰기
        spr.color = Color.green;
        spr2.color = Color.yellow;
        spr3.color = Color.red;
    }


}