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

    //public override void Attack()
    //{
    //    // battleManager에서 playerTurn이라면 실행하지 말기
    //    if (battleManager.playerTurn) return;
    //
    //    //base.Attack();      // 몬스터의 공격 로직 실행 후
    //
    //    Debug.Log("Monster Attack");
    //
    //    // battleManager에서 턴을 종료한다. - 몬스터는 할 필요 없음 
    //}

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
