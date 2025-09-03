using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // static : 모든 클래스가 접근할 수 있게 해준다.
    // 그러나 ScoreManager가 2개 이상 존재한다면, 하나만 존재하도록 코드를 설정해줘야 한다.
    public static ScoreManager instance;
    public int Score;
    public int BestScore;

    public const string _BESTSCORE = "BestScore";           // 상수로 표현하면 실수 방지를 할 수 있음

    private void Awake()
    {
        // 이 클래스가 단독으로 존재할 수 있도록 조건을 만든다
        // 싱글톤 패턴
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);      // 게임오브젝트를 파괴하지 말라는 함수
    }

    // 어딘 가의 장소에 숨겨진 데이터를 저장해둔다.
    // 만들어진 저장 기능 불러오기
    public void SaveScore(int currentScore)
    {
        if (currentScore < BestScore) { return; }
        PlayerPrefs.SetInt(_BESTSCORE, BestScore);
    }

    // 저장해둔 장소로부터 데이터를 불러온다.
    // 게임을 처음 시작할 때는 BestScore가 존재하지 않는다
    // 존재하지 않는 데이터를 참조하려고 하면 에러가 발생한다.
    public void LoadScore()
    {
        if (PlayerPrefs.HasKey(_BESTSCORE))
        {
            BestScore = PlayerPrefs.GetInt(_BESTSCORE);

        }
        else
        {
            BestScore = 0;
        }
    }
}
