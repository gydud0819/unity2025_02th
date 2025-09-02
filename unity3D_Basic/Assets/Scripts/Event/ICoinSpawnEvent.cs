using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// 이 이벤트가 언제 실행되는지, 실행되었을 때 무엇을 하는지 OnEvent 등록하기
public class ICoinSpawnEvent : IEvent
{
    public Coin Coin;

    public ICoinSpawnEvent(Coin coin)
    {
        Coin = coin;
    }
}
