using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpwaner : MonoBehaviour
{
    //[SerializeField] Transform[] spwanPositions;
    //[SerializeField] GameObject[] coinSpwaner;

    public int CoinSpwanCount;
    //[SerializeField] float spwanIntervalTime = 0.75f;


    //private Coroutine spwanCoinCoroutine;
    //private Coin coin = new();

    public GameObject CoinPrefab;
    private void OnEnable()
    {
        Bus<IGetCoin>.OnEvent += HandleGetCoin;
    }


    private void OnDisable()
    {
        Bus<IGetCoin>.OnEvent -= HandleGetCoin;
    }
    private void HandleGetCoin(IGetCoin evt)
    {
        // 게임에 플레이어가 코인을 획득한 경우에 코인을 생성하고 싶을 때
        // 랜덤으로 호출하기

        for (int i = 0; i < CoinSpwanCount; i++)
        {
            Vector2 randomSpwanPos = UnityEngine.Random.insideUnitCircle * 10;
            Instantiate(CoinPrefab, Vector3.zero + (Vector3)randomSpwanPos, Quaternion.identity);

        }

    }

    //public void Spwan()
    //{
    //    if (spwanCoinCoroutine != null)
    //    {
    //        StopCoroutine(CoinCorutine());

    //    }
    //    spwanCoinCoroutine = StartCoroutine(CoinCorutine());
    //}

    //private IEnumerator CoinCorutine()
    //{
    //    for (int i = 0; i < CoinSpwanCount; i++)
    //    {
    //        int randomIndex = UnityEngine.Random.Range(0, spwanPositions.Length);
    //        int randomMonIndex = UnityEngine.Random.Range(0, coinSpwaner.Length);
    //        Instantiate(coinSpwaner[randomMonIndex], spwanPositions[randomIndex]);

    //    }
    //    yield return new WaitForSeconds(spwanIntervalTime);
    //}

}



