using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]   // 유니티가 읽을 수 있도록 해준다. 
public class BattleEntity
{
    public int maxHP;      // 체력
    public int ATK;   // 데미지
    public int Def;     // 방어력
    public string AttackType;

    // 생성자 자동으로 만들어주는 단축키 : 드래그하고 ctrl+.
    public BattleEntity(int hP, int aTK, int def)
    {
        maxHP = hP;
        ATK = aTK;
        Def = def;
    }
}

[System.Serializable]
public class BattleUI
{
    public Image hpBar;
    public TextMeshProUGUI AttackText;
    public TextMeshProUGUI DefText;
    public void SetBatte(BattleEntity battleEntity)
    {
        AttackText.SetText($"ATK : {battleEntity.ATK}");
        DefText.SetText($"Def :{battleEntity.Def}");
    }

    public void SetHpBar(int current, int max)
    {
        hpBar.fillAmount = (float)current / max;
    }
}

public class Battle : MonoBehaviour
{
    public BattleEntity battleEntity;
    public BattleUI battleUI;
    public BattleManager battleManager;

    public bool IsPlayer;
    public int CurrentHP
    {   // 배틀 클래스에서만 현재 체력을 수정할 수 있다. 
        get
        {
            if (currentHP <= 0)
            {
                currentHP = 0;
                Death();
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

   // [SerializeField] private int Something;
    //[field: SerializeField] public int SomeThing { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        // 0으로 초기화 된다.
        Debug.Log($"HP : {battleEntity.maxHP}, ATK : {battleEntity.ATK}, Def :{battleEntity.Def}");
        battleUI.SetBatte(battleEntity);
        currentHP = battleEntity.maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        battleUI.SetHpBar(currentHP, battleEntity.maxHP);
    }

    // 상대에게 데미지를 입힌다 (takeDamage) :: currentHP (atk, def에 따라서 감소)
    public void TakeDamage(Battle other)
    {
        int finalDamge = (other.battleEntity.ATK - battleEntity.Def);
        if (finalDamge <= 0) finalDamge = 1;

        currentHP -= (other.battleEntity.ATK - battleEntity.Def);    // 상대의 공격력

        Debug.Log($"최종 데미지 : {finalDamge}, 공격자의 공격력 : {other.battleEntity}, 방어력 : {other.battleEntity.Def} ");
    }

    public void Death()
    {
        Debug.Log($"사망했습니다 : { currentHP}");
    }

    public void Recover(int amount)
    {
        if (IsPlayer&& !battleManager.playerTurn) return;
       currentHP += amount;     // amount 수치만큼 회복
       
    }

    public void ShieldDef(int amount)
    {
        if (IsPlayer && !battleManager.playerTurn) return;
       
        battleEntity.Def += amount;
        battleUI.SetBatte(battleEntity);
        
    }
    // 죽었을 때 로직 처리하기 (Die)
}
