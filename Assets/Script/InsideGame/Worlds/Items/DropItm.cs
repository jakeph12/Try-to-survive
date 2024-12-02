using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItm : UseTh
{
    public  ItemScriptMain m_itmDroped;
    public  int m_iAmount;
    public override void Use()
    {
        if(m_itmDroped && m_iAmount > 0)
        {
            InventoryMenager.m_singInvt.AddOnInvt(m_itmDroped, m_iAmount);
            Destroy(gameObject);
        }
    }
}
