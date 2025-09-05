using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpeed : MonoBehaviour
{
    private Entity_Stats stats;

    [SerializeField] protected float currentSpeed;

    private void Start()
    {
        stats = GetComponent<Entity_Stats>();
        currentSpeed = stats.GetMaxSpeed();
    }
}
