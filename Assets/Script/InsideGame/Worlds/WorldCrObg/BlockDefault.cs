using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDefault : DestroyTh
{
    [SerializeField]private ItemScriptMain m_itDrop;
    [SerializeField] private int m_iAmount;

    public override void Death()
    {
        GameObject Gm = Spawner.ItemObjDrop(m_itDrop, m_iAmount);
        Gm.transform.position = transform.position;
        Gm.name = $"{m_itDrop.m_stName} New";
        Destroy(gameObject);
    }

    public override void Use(int i)
    {
        if (i > 0)
            m_iHpBlock -= i;
    }
}
