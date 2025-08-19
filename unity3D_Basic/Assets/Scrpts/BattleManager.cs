using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    // Turn 만들기 

    int turnValue;

    public bool playerTurn = true;

    public void TurnChange()
    {
        playerTurn = !playerTurn;
    }

    // Enemy가 행동한다.

    public Battle Enemy;

    public void EnemyAI()
    {
        // 랜덤으로 0~2 숫자를 받아온다. 
        int RandomValue = UnityEngine.Random.Range(0, 3);

        switch (RandomValue)
        {
            case 0:
                //Enemy.Attak();
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
