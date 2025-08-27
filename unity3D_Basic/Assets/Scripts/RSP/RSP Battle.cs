using BattleExam;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]   // 유니티가 읽을 수 있도록 해준다. 
public class BattleEntity
{
    public int maxHP;      // 체력
    public int ATK;        // 데미지


    // 생성자 자동으로 만들어주는 단축키 : 드래그하고 ctrl+.
    public BattleEntity(int hP, int aTK)
    {
        maxHP = hP;
        ATK = aTK;
    }
}

[System.Serializable]
public class BattleUI
{
    public Image hpBar;
    public TextMeshProUGUI AttackText;
  
    public void SetBatteUI(BattleEntity battleEntity)
    {
        AttackText.SetText($"ATK : {battleEntity.ATK}");
    }

    public void SetHpBar(int current, int max)
    {
        hpBar.fillAmount = (float)current / max;
    }
}

public abstract class RSPBattle : MonoBehaviour
{
    public BattleEntity battleEntity;
    public BattleUI battleUI;

    public int CurrentHP 
    {
        get
        {
            if (currentHP <= 0) 
            {
                currentHP = 0;

            }
            return currentHP;
        }

        private set
        {
            if (value > battleEntity.maxHP) value = battleEntity.maxHP;

            currentHP = value;
        }
    }

    [SerializeField] private int currentHP;

    void Start()
    {
        // 0으로 초기화 된다.
        Debug.Log($"HP : {battleEntity.maxHP}, ATK : {battleEntity.ATK}");
        battleUI.SetBatteUI(battleEntity);
        CurrentHP = battleEntity.maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        battleUI.SetHpBar(CurrentHP, battleEntity.maxHP);
    }

    // 상대에게 데미지를 입힌다 (TakeDamage 이 함수로 지면 무조건 피 까이기)
    public void TakeDamage(RSPBattle other)
    {
        int finalDamge = (other.battleEntity.ATK);
        if (finalDamge <= 0) finalDamge = 10;

        CurrentHP -= finalDamge;    // 상대의 공격력

        Debug.Log($"최종 데미지 : {finalDamge}, 공격자의 공격력 : {other.battleEntity.ATK} ");
    }

    public void Death()
    {
        // 혹시 모를 대비 코드
        if(currentHP <=0)
            Debug.Log($"You Lose : {currentHP}");
            return;
        // 후에 화면으로 띄우기
    }

    public abstract void Attack(RSPBattle other);
}