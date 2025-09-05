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
        StatsData.MaxSpeed.AddModifier(4, "Item");      // 아이템으로 인해 속도가 4 증가함

        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

        }
    }
}
