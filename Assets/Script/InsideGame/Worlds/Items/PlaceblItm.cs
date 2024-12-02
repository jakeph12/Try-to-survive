using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New/For item/Item type/Placebl")]
public class PlaceblItm : ItemScriptMain
{
    public GameObject m_gmPrefab;
    public override g_eTypeBlock m_eTypeBlock { get => g_eTypeBlock.PlaceblItm;  set => base.m_eTypeBlock = value; }
}
