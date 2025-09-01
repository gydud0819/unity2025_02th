using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이벤트를 총괄적으로 관리하는 특별한 클래스
// Generic Coding (T) 어떤 클래스든 올 수 있고
// where 클래스가 IEvent를 상속한 경우에만 <> 들어올 수 있다.
public class Bus<T> where T : IEvent          // 어떤 타입의 클래스 모두를 가져와서 사용할 수 있음
{
    public delegate void Event(T evt);
    public static event Event OnEvent;
    public static void Raise(T evt) => OnEvent?.Invoke(evt);
  
}

public interface IEvent
{

}
