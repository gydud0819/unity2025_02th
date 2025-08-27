using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSPEnemy : RSPBattle
{
    public override void Attack(RSPBattle other)
    {
        other.TakeDamage(this);
    }
}
