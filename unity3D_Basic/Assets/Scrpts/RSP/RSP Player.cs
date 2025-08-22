using BattleExam;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSPPlayer : RSPBattle
{
    public override void Attack(RSPBattle other)
    {
        other.TakeDamage(this);

        
    }
}
