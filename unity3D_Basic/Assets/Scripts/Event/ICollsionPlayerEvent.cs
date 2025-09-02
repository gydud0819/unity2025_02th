using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ICollsionPlayerEvent : IEvent
{
    public NPC NPC;
    public ICollsionPlayerEvent(NPC npc)
    {
        NPC = npc;
    }
}

/*
 * NPC 클래스
 * 제일 아래에 NPC와 충돌하는 이벤트 만들기
 * 플레이어와 발생하는 이벤트 생성하기
 * (Raise)
 * UI - NPC Player 충돌, Image Panel 활성화하고 Text 대화하기
 * NPC 충돌 이후에 NPC게임에서 사라지게 하기
 * NPC 일정 수가 이하일 때 생성되도록 만들기
 */ 