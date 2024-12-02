using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : SlotsDefault
{
    public override void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.GetComponent<Slots>().m_itCurent)
        {
            Slots Sl = eventData.pointerDrag.GetComponent<Slots>();
            GameObject NewGameOb = Spawner.ItemObjDrop(Sl.m_itCurent,Sl.m_iAmount);
            Vector2 pos = (Vector2)Player.m_singPl.m_gmCrossHair.transform.position;
            NewGameOb.transform.position = new Vector3((int)pos.x,(int)pos.y , -1);
            eventData.pointerDrag.GetComponent<Slots>().m_iAmount = 0;
        }
    }
}
