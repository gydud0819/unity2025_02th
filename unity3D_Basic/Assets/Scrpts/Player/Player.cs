using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 오늘 할 일 : 플레이어 기능 구현하기
// 전투와 관련된 요소 정의하기 

// 직렬화 (Serialized)
// 우리가 직접 정의한 클래스 정보를 유니티에서 읽어올 수 없기 때문에, 유니티 인스펙터창에서 노출할 수 없다.
// 유니티가 우리가 정의한 정보를 읽을 수 있도록 조치를 취하면 된다. (이진수로 바꿔서 읽을 수 있도록 한다)

public class Player : Battle
{
    public override void Attack(Battle other)
    {
        //throw new System.NotImplementedException();
        if (!battleManager.playerTurn) return;      // 예외코드
        other.TakeDamage(this);     // 
        battleManager.TurnChange();

    }


    public override void Recover(int amount)
    {
        if (!battleManager.playerTurn) return;
        base.Recover(amount);
        battleManager.TurnChange();
    }

    public override void ShieldDef(int amount)
    {
        if (!battleManager.playerTurn) return;
        base.ShieldDef(amount);
        battleManager.TurnChange();
    }
}
