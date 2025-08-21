using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    // Enemy가 행동한다.
    public Battle Player;
    public Battle Enemy;

    // Turn 만들기 

    int turnValue;

    public bool playerTurn = true;

    public void TurnChange()
    {
        playerTurn = !playerTurn;
        EnemyTurn();
    }

    public void EnemyTurn()
    {
        EnemyAI();
        playerTurn = true;
    }

  

    public void EnemyAI()
    {
        // 랜덤으로 0~2 숫자를 받아온다. 
        int RandomValue = UnityEngine.Random.Range(0, 3);
       // Debug.Log($"랜덤 값의 정확성 확인  {RandomValue}");

        switch (RandomValue)
        {
            case 0:
                Enemy.Attack(Player);
                break;
            case 1:
                Enemy.Recover(10);
                break;
            case 2:
                Enemy.ShieldDef(5);
                break;


        }
    }
}
