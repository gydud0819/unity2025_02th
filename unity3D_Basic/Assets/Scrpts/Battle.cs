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
    public void SetBatteUI(BattleEntity battleEntity)
    {
        AttackText.SetText($"ATK : {battleEntity.ATK}");
        DefText.SetText($"Def :{battleEntity.Def}");
    }

    public void SetHpBar(int current, int max)
    {
        hpBar.fillAmount = (float)current / max;
    }
}


// 추상 클래스 : abstract를 붙인 클래스를 인스턴스 할 수 없다.
// 이 클래스를 오브젝트의 컴포넌트로 사용하지 말라는 의미이다.
// Player, Enemy를 사용해서 클래스를 구현해라
// abstract : 메소드에 abstract 키워드를 추가할 수 있다. 

/*
 * abstract vs virtual
 * abstract 가상 함수 : 본문을 가질 수 없다. - 자식 클래스에서 구현을 해야한다.
 * virtual 가상 함수 : 본문을 가질 수 있다. - 자식 클래스에서 코드를 사용 안할 수도 있고, base 키워드를 이용해 사용할 수 있다.
 */
public abstract class Battle : MonoBehaviour
{
    public BattleEntity battleEntity;
    public BattleUI battleUI;
    public BattleManager battleManager;

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
        battleUI.SetBatteUI(battleEntity);
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
        Debug.Log($"사망했습니다 : {currentHP}");
    }

    public abstract void Attack(Battle other);
   
    public virtual void Recover(int amount)
    {
        CurrentHP += amount;     // amount 수치만큼 회복

    }

    public virtual void ShieldDef(int amount)
    {
        battleEntity.Def += amount;
        battleUI.SetBatteUI(battleEntity);

    }
    // 죽었을 때 로직 처리하기 (Die)
}
