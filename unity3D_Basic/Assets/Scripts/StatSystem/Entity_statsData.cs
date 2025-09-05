using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityStats", menuName = "Custom/Stat System/EntityStats")]

public class Entity_statsData : ScriptableObject, ICloneable    // 깊은복사
{
    public Stats MaxSpeed;          // 최고속도
    public Stats Acceleration;      // 가속도
    public Stats Power;             // 힘
    public Stats Control;           // 컨트롤

    public object Clone()
    {
        return Instantiate(this);           // 깊은 복사로 스텟 적용한 스텟 초기화하는 코드
    }
}
