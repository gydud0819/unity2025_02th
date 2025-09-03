using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreInfoUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI BestScoreText;

    private int currentScore;
   

    private void OnEnable()
    {
        Bus<IScoreUpdateEvent>.OnEvent += HandleScoreUI;
        //Bus<IGameOver>
    }
    private void OnDisable()
    {

        Bus<IScoreUpdateEvent>.OnEvent -= HandleScoreUI;
    }


    private void HandleScoreUI(IScoreUpdateEvent evt)
    {

        currentScore += evt.Score;
        scoreText.SetText($"Score: {currentScore}");
    }

    public void SetScoreInfo()
    {
        currentScore = ScoreManager.instance.Score;
        scoreText.SetText($"score : {currentScore} ");
        ScoreManager.instance.LoadScore();
        BestScoreText.SetText($"BestScore : {ScoreManager.instance.BestScore} ");
    }

    private void Start()
    {
        SetScoreInfo();
    }

    public void SaveBestScore()
    {
        ScoreManager.instance.SaveScore(currentScore);
    }

    // 개선하기 위해 Bus<IScoreUpdateEvent>
    private void Update()
    {
        //SetScoreInfo();
        if(Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log("현재 점수를 저장합니다");
            Debug.Log(Application.persistentDataPath);
            SaveBestScore();
        }
    }
}
