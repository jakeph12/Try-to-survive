using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenager : MonoBehaviour
{
    public   List<Slots> m_lAllSlots = new List<Slots>();
    [SerializeField] private GameObject PannelOfSlot;


    public static InventoryMenager m_singInvt;

    private void Awake()
    {
        for(int i = 0;i < PannelOfSlot.transform.childCount;i++)
        {
            if (PannelOfSlot.transform.GetChild(i).GetComponent<Slots>())
            {
                m_lAllSlots.Add(PannelOfSlot.transform.GetChild(i).GetComponent<Slots>());
                PannelOfSlot.transform.GetChild(i).GetComponent<Slots>().m_iIdSlot = i + 1;
            }
        }
        m_singInvt = this;
    }
    public void AddOnInvt(ItemScriptMain ItemAdd, int Amount)
    {
        int Am = Amount;
        foreach (Slots Sl in m_lAllSlots)
        {
            if (Sl.m_itCurent == ItemAdd && Sl.m_iAmount != Sl.m_itCurent.m_iMaxAmount)
            {
                if (Sl.m_iAmount + Am <= Sl.m_itCurent.m_iMaxAmount)
                {
                    Sl.m_iAmount += Am;
                    Am = 0;
                    return;
                }
                else
                {
                    int En = Sl.m_itCurent.m_iMaxAmount - Sl.m_iAmount;
                    Sl.m_iAmount += En;
                    Am -= En;
                    if (Am == 0) return;
                }
            }


        }
        if (Am == 0) return;

        foreach (Slots Sl in m_lAllSlots)
        {
            if (Sl.m_bIsEmpty)
            {
                if (Am <= ItemAdd.m_iMaxAmount)
                {
                    Sl.m_iAmount = Am;
                    Sl.m_itCurent = ItemAdd;
                    Sl.m_bIsEmpty = false;
                    Am = 0;
                    return;
                }
                else
                {
                    int En = Am - ItemAdd.m_iMaxAmount;
                    En = Am - En;
                    Sl.m_iAmount = En;
                    Sl.m_itCurent = ItemAdd;
                    Sl.m_bIsEmpty = false;
                    Am -= En;
                    if (Am == 0) return;
                }
            }
        }
    }
}
