using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;

public class PropertyExample
{
    // 멤버 변수, 멤버 함수

    private int hp;     //

    // 프로퍼티 사용법 1
    public int HP { get; set; }

    public int ATK { get; set; }

    // 프로퍼티 사용법 2
    public int HP2 
    { 
        get
        {
            if (hp <= 0)
            {
                hp = 0;
            }

            return hp; 
        } 
        set 
        { 
            hp = value; 
        } 
    }

    // 프로퍼티 사용법 3
    public int DEF { get; set; }        // 중괄호 안 private set : 외부에서 값을 변경하지 말라는 뜻

    public int MaxLevel { get; private set; }   // 게임 시작할 때 최대 레벨을 설정. 다른 클래스에서 변경할 수 없도록 설정한다.

    /*
     * 프로퍼티
     * 사용법 : 변수 선언 public (타입) (변수이름) 첫글자를 대문자로 작성하는 것이 이름 규칙이다.
     * public int HP {get; set;}
     */


    /// <summary>
    /// hp를 절반으로 변경해주는 코드이다. 반드시 이 함수를 사용해서 조절해주세요
    /// </summary>
    public void UseThisFunction()
    {
        // hp가 어떤 시스템에 의해 변경된다.
        hp /= 2;
    }
}

