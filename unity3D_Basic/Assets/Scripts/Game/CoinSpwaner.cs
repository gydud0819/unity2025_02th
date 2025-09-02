using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. 동전 먹었을 때 작동하기

// 2. 동전이 생성되었으면 얼마 만큼의 동전이 현재 게임 씬에 존재하는지 파악하는 코드 만들기
public class CoinSpwaner : MonoBehaviour
{

    public int CoinSpwanCount;  // 전체적인 코인의 개수
    public GameObject CoinPrefab;
    public List<Coin> spawnedList = new();
    public int SpawnCount;      // 씬에 생성된 코인의 수



    private void OnEnable()
    {
        Bus<IGetCoinEvent>.OnEvent += HandleGetCoin;
        Bus<ICoinSpawnEvent>.OnEvent += HandleSpawnCoin;
    }


    private void OnDisable()
    {
        Bus<IGetCoinEvent>.OnEvent -= HandleGetCoin;
        Bus<ICoinSpawnEvent>.OnEvent -= HandleSpawnCoin;
    }
    private void HandleSpawnCoin(ICoinSpawnEvent evt)
    {
        // Coin 객체가 얼마만큼 저장되어 있는지 자료구조로 저장하기
        // ICoinSpawnEvent가 Coin 정보를 저장하도록 Coin 변수 선언하기
        // Raise 함수 실행할 때 Coin 정보를 전달할 수 있도록 수정하기
        spawnedList.Add(evt.Coin);
        SpawnCount++;
    }
    private void HandleGetCoin(IGetCoinEvent evt)
    {
        // 게임에 플레이어가 코인을 획득한 경우에 코인을 생성하고 싶을 때
        // 랜덤으로 호출하기

        // 코인을 생성하고 싶을 때

        // 획득한 코인은 리스트에서 제거하기

        // 동전이 생성된 개수가 일정 개수 이하일때만 생성하기 
        spawnedList.Remove(evt.Coin);
        SpawnCount++;

        if (SpawnCount > 2) { return; }


        for (int i = 0; i < CoinSpwanCount; i++)
        {
            Vector2 randomSpwanPos = UnityEngine.Random.insideUnitCircle * 10;
            Instantiate(CoinPrefab, Vector3.zero + (Vector3)randomSpwanPos, Quaternion.identity);

        }

    }



}



