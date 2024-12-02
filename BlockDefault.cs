using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDefault : DestroyTh, HpScripts
{
    [SerializeField]private ItemScriptMain m_itDropItml;
    [SerializeField] private int m_iAmountDrop;
    public override void Death()
    {
        GameObject NewGameOb = new GameObject();
        NewGameOb.name = $"{m_itDropItml.m_fName} droped";
        NewGameOb.AddComponent<DropItm>().m_iAmount = m_iAmountDrop;
        NewGameOb.GetComponent<DropItm>().m_itmDroped = m_itDropItml;
        NewGameOb.AddComponent<SpriteRenderer>().sprite = m_itDropItml.m_spIco;
        NewGameOb.AddComponent<BoxCollider2D>().isTrigger = true;
        NewGameOb.transform.localScale = new Vector3(6.6f, 6.6f, 1);
        NewGameOb.transform.position = transform.position;
        Destroy(gameObject);
    }

    public override void Use(int i)
    {
        if(m_iHpBlock > 0)
            m_iHpBlock -= i;
    }
}
