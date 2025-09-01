using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [field:SerializeField] public int Value { get; private set; } = 5;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // 동전을 획득했습니다 라는 이벤트 실행하기

            // 이벤트
            Bus<IGetCoin>.Raise(new IGetCoin(Value));
            Destroy(gameObject);

            //Bus<T>.Raise(new T());
        }
    }
}
