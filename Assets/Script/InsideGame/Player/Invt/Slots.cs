using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slots : SlotsDefault
{
    public override void OnDrop(PointerEventData eventData)
    {
        Slots Sl = eventData.pointerDrag.GetComponent<Slots>();
        if (Sl && m_bIsEmpty)
        {
            m_itCurent = Sl.m_itCurent;
            m_iAmount = Sl.m_iAmount;
            m_bIsEmpty = false;
            Sl.m_iAmount = 0;
        }
    }
}
