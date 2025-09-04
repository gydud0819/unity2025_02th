using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 싱글톤 사용하기

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }

    public void GameClear()
    {
      
        if(isGameClear())
        {
            Bus<IGameClearEvent>.Raise(new IGameClearEvent());
        }
    }
    public bool isGameClear()
    {
        // 특정 조건을 달성하면 클리어
        //if ()
        //{
        //    return false;
        //}
        return true;
    }

    public void GameOver()
    {
        // 게임오버 멘트
        // Bus<I~Event>.Raise(new~());
        Bus<IGameOverEvent>.Raise(new IGameOverEvent());
    }
}
