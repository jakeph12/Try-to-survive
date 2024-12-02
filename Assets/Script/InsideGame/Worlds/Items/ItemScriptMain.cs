using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum g_eTypeBlock
{
    Default,
    PlaceblItm
}
[CreateAssetMenu(fileName ="New Item",menuName = "New/For item/Item type/Default")]
public class ItemScriptMain : ScriptableObject
{
    public string m_stName;
    public int m_iMaxAmount;
    public Sprite m_spIco;
    public virtual g_eTypeBlock m_eTypeBlock { get => g_eTypeBlock.Default; set => m_eTypeBlock = value; }
}
