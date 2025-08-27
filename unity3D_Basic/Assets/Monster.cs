using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

namespace Example
{
    // Todo 목표 : 코드로 게임에 등장하는 오브젝트를 조립한다. 
    // 컴퓨터와 대화를 (C#) 해서 몬스터가 필요한 정보를 전달한다.

    // 이속(MonsterMove), Sprite정보, 
    public class Monster : MonoBehaviour
    {
        // MonsterMove.cs에 있는 코드로 움직인다. (몬스터가 움직이는 코드를 생성한다.)
        // 움직이는 속도 필요, 몬스터가 어떻게 생겼는지 Sprite도 필요
        // 위치, 회전, 크기 설정도 필요

        public MonsterInfo monsterInfo;

        public float moveSpeed;

        // 몬스터가 움직일 수 있도록 MonsterMove 클래스 만들기 
        // Start 함수에 AddComponnent를 사용해서 오브젝트에 부착하기
        // MonsterMove 이동속도를 monsterInfo를 이용하여 변경하기 
        private void Start()
        {
            MonsterConstructor();
            //Instantiate(instance, Vector3.zero, Quaternion.identity);
        }

        [ContextMenu("캐릭터 객체 생성")]
        private void MonsterConstructor()
        {
            GameObject instance = new GameObject();
            instance.transform.localScale = Vector3.one * monsterInfo.Size;
            SpriteRenderer sr = instance.AddComponent<SpriteRenderer>();
            sr.sprite = monsterInfo.sprite;
            
            MonsterMove move = instance.AddComponent<MonsterMove>();
            moveSpeed = monsterInfo.speed;
            Rigidbody2D rigid = instance.AddComponent<Rigidbody2D>();
            rigid.gravityScale = 0;
            BoxCollider2D boxCollider2D = instance.AddComponent<BoxCollider2D>();
            boxCollider2D.offset = new Vector2(0, 0);
            boxCollider2D.size = new Vector2(1, 1);
            CapsuleCollider2D capsuleCollider2D = instance.AddComponent <CapsuleCollider2D>();
            capsuleCollider2D.offset = new Vector2(0, 0);
            capsuleCollider2D.size = new Vector2(1, 1);
            //Collider2D collider2D = instance.GetComponent<Collider2D>();
            


            instance.name = monsterInfo.monsterName;
        }
    }




}
