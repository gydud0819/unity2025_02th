using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatUIContainer : MonoBehaviour
{
    [SerializeField] Entity_Stats playerStat;

    public StatUIElement[] stats;

    private void Start()
    {
        // MaxSpeed = 2, Acceleration = 5, Power = 3, Control = 5
        stats[0].SetUI(playerStat.StatsData.MaxSpeed.GetValue());
        stats[1].SetUI(playerStat.StatsData.Acceleration.GetValue());
        stats[2].SetUI(playerStat.StatsData.Power.GetValue());
        stats[3].SetUI(playerStat.StatsData.Control.GetValue());
    }
}
