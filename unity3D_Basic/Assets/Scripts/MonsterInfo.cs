using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*ScriptableObject 정리
 * 
 * ScriptableObject를 사용하는 이유
 * 데이터의 메모리가 어떻게 사용되는지
 * GameObject 객체를 생성해서 컴포넌트를 부착한다. (모든 객체가 그 클래스의 데이터 타입만큼의 메모리를 컴퓨터에 할당한다.)
 * 공통적으로 사용하는 데이터를 한번만 사용할 수 있게 할 수는 없을까?
 * - 같은 데이터를 모든 오브젝트가 개별로 생성하고 있다. -> 이 데이터를 사용하는 모든 오브젝트가 참조하도록 하면된다. 
 * ※ 디자인 패턴 : flyweight 패턴
 * 단점 : 참조하고 있는 데이터를 수정하면, 다른 오브젝트들도 모두 변경된다. (ex. 몬스터 수정을 하나하면 모두가 바뀐다.)
 * 해결방법 : 깊은 복사를 통해 해결할 수 있다. 
 */

namespace Example
{
    [CreateAssetMenu(fileName = "Defalut Monster", menuName = "ScriptableObject/MonsterData", order = 100)]   // Attribute, 같은 폴더위치에서 만들 때 누가 위에 있고 밑에 있는지 구분하기 위해서 저렇게 함
    public class MonsterInfo : ScriptableObject
    {
        public float speed;
        public Sprite sprite;
        public float Size;
        public string monsterName;
        public Color color;
        public Collider2D collider;
    }
}


