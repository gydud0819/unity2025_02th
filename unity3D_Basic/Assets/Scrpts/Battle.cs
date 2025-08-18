using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]   // 유니티가 읽을 수 있도록 해준다. 
public class BattleEntity
{
    public int maxHP;      // 체력
    public int ATK;   // 데미지
    public int Def;     // 방어력
    public string AttackType;
    public int Critical;

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

    public int currentHP;

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

    // 죽었을 때 로직 처리하기 (Die)
}
