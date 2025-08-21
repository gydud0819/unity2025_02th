using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

// 부모의 함수를 가져와서 사용하는 방법 익히기
// 부모의 함수를 다시 정의한다 (재정의) override

public class Enemy : Battle
{
    public override void Attack(Battle other)
    {
        //throw new System.NotImplementedException();     // 예외처리 코드 
        if (battleManager.playerTurn) return;

        // Battle 컴포넌트를 가지고 있는 상대가 TakeDamage(this.BattleEntity);
        other.TakeDamage(this);
    }

    public override void Recover(int amount)
    {
        if (battleManager.playerTurn) return;
        base.Recover(amount);
    }

    public override void ShieldDef(int amount)
    {
        if (battleManager.playerTurn) return;
        base.ShieldDef(amount);
    }
}
