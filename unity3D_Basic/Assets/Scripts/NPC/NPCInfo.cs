using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Defalut NPC", menuName = "ScriptableObject/NPCData", order = 101)]
public class NPCInfo : ScriptableObject
{
    public int MinSpeed;
    public int MaxSpeed;
    public int PatrolRadius;    // 랜덤으로 최소 거리 
    public float StopDistance = 0.1f;
    public float PatrolDistance = 5f;   // 이건 직접 계산한 최소 거리
    public string NpcName;
    public Sprite Sprite;
  
}
