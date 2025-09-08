using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Buff
{
    public StatType type = StatType.Undefined;
    public float Value = 3.0f;

}


public class ObjectBuff : MonoBehaviour
{
    private SpriteRenderer sr;

    [Header("Buff Detail")]
    [SerializeField] Buff[] buffs;
    [SerializeField] private float buffTime = 4.0f;
    [SerializeField] private string buffName;


    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Tag가 Player인 객체와 충돌했을 때
    Entity_Stats statsToMod;       // 수정하기 위한 스텟
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            statsToMod = collision.GetComponent<Entity_Stats>();        // collision으로부터 컴포너트에 Get해서 statsToMod 저장하기
            StartCoroutine(BuffCo());

        }
    }

    IEnumerator BuffCo()
    {
        // spriteRenderer 변수 추가하고 sr.color를 안보이게 하기
        sr.color = Color.clear;

        foreach (Buff buff in buffs)
        {
            statsToMod.GetStatType(buff.type).AddModifier(buff.Value, buffName);

        }
        // 안전 코드 = if(Entity_Stats)가 있을 때만 넣을 수 잇도록

        Bus<IStatUpdateEvent>.Raise(new IStatUpdateEvent());


        // n초간의 딜레이 후에 증가되었던 임시 스탯을 없애고, 이 오브젝트를 파괴하기 
        yield return new WaitForSeconds(buffTime);

        foreach (Buff buff in buffs)
        {
            statsToMod.GetStatType(buff.type).ReMoveModifier(buffName);

        }

       
        Bus<IStatUpdateEvent>.Raise(new IStatUpdateEvent());
        Destroy(gameObject);

    }
}
