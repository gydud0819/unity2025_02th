using BattleExam;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RSP
{
    Rock, Scissors, Paper
}

public class RSPBattleManager : MonoBehaviour
{
    public RSPBattle rspPlayer;
    public RSPBattle rspEnemy;

    // 필요한 문법 : enum, string, ...
    
    // 플레이어가 낼 수 있는 거 먼저 만들기 -> 버튼이랑 연결되야함
    public void GetRSP(string choiceRSP)
    {
        RSP rPlayer = (RSP)System.Enum.Parse(typeof(RSP), choiceRSP);
        RSP rEnemy = (RSP)Random.Range(0, 3);

        string result = GetResult(rPlayer, rEnemy);

        Debug.Log($"플레이어: {rPlayer}, 적: {rEnemy} → 결과: {result}");


        if (result == "Win")
            rspPlayer.Attack(rspEnemy);
        else if (result == "Lose")
            rspEnemy.Attack(rspPlayer);
        else
            Debug.Log("Draw");
            return;


    }

    private string GetResult(RSP rPlayer, RSP rEnemy)
    {
        if (rPlayer == rEnemy) return "Draw";

        if ((rPlayer == RSP.Rock && rEnemy == RSP.Scissors) ||
            (rPlayer == RSP.Scissors && rEnemy == RSP.Paper) ||
            (rPlayer == RSP.Paper && rEnemy == RSP.Rock))
            return "Win";

        return "Lose";
    }

  }
