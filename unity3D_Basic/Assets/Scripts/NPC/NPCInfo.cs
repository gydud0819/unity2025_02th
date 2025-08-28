using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Defalut NPC", menuName = "ScriptableObject/NPCData", order = 101)]
public class NPCInfo : ScriptableObject
{
    public int MinSpeed;
    public int MaxSpeed;
    public int PatrolRadius;
    public string NpcName;
    public Sprite Sprite;
  
}
