using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGetCoin : IEvent
{
    public int Value;

    public IGetCoin(int value)
    {
        Value = value;
    }
}
