using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_Stats : MonoBehaviour
{
    [SerializeField] private Entity_statsData statsData;
    public Entity_statsData StatsData { get; set; }

    public float GetMaxSpeed()
    {
        float baseSpeed = statsData.MaxSpeed.GetValue();
        float bonusSpeed = statsData.Acceleration.GetValue();
        return baseSpeed + bonusSpeed;
    }

    private void Awake()
    {
        StatsData = (Entity_statsData)statsData.Clone();

    }

    public Stats GetStatType(StatType type)
    {
        switch (type)
        {
            case StatType.MaxSpeed: return StatsData.MaxSpeed;
            case StatType.Acceleration: return StatsData.Acceleration;
            case StatType.Power: return StatsData.Power;
            case StatType.Control: return StatsData.Control;
            

            case StatType.Undefined:
                {
                    Debug.LogError("지정된 StatType이 존재하지 않음");
                    return null;
                }

               
            default: return null;
        }
    }

}