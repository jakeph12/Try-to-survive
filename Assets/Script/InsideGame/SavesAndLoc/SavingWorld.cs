using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingWorld
{  
    public static void Save()
    {
        CurWorld Plate = new CurWorld();
        Func<int> SetWorld = () =>
        {
            Plate.m_stNameWorld = World.m_stNameWorld;
            Plate.m_intX = World.m_G2AllPlateWorld.GetLength(0);
            Plate.m_intY = World.m_G2AllPlateWorld.GetLength(1);
            Plate.m_iPlX = WorldSpawner.m_scWorldSpSing.m_GPl.transform.position.x;
            Plate.m_iPlY = WorldSpawner.m_scWorldSpSing.m_GPl.transform.position.y;
            Plate.m_clssPlate = new WorldPlate[World.m_G2AllPlateWorld.GetLength(0), World.m_G2AllPlateWorld.GetLength(1)];
            for (int x = 0; x < World.m_G2AllObj.GetLength(0); x++)
            {
                for (int y = 0; y < World.m_G2AllObj.GetLength(1); y++)
                {
                    if (!World.m_G2AllObj[x, y]) continue;
                    if (!World.m_G2AllObj[x, y].GetComponent<SaveCh>()) continue;
                    Plate.m_clssPlate[x, y] = new WorldPlate();
                    Plate.m_clssPlate[x, y].m_stBlockName = World.m_G2AllObj[x, y].GetComponent<SaveCh>().m_stNameObjSave;
                }
            }
            return 1;
        };
        Func<int> SetInventory = () =>
        {
            foreach(var sl in InventoryMenager.m_singInvt.m_lAllSlots)
                if (!sl.m_bIsEmpty) Plate.m_lsAllItem.Add(new InventorySlot(sl.m_itCurent.m_stName, sl.m_iAmount));
            return 1;
        };
        SetWorld();
        SetInventory();

        JakePhLib.SaveAndLoad<CurWorld>.SaveData(Plate, $"{World.m_stNameWorld}", Application.persistentDataPath + "/Worlds");
    }
    public static CurWorld Load()
    {
        JakePhLib.SaveAndLoad<CurWorld>.LoadData(out CurWorld LoadedData,$"{World.m_stNameWorld}",Application.persistentDataPath + "/Worlds");
        {
            if(LoadedData != null)
            {
                Dictionary<string, ItemScriptMain> items = new Dictionary<string, ItemScriptMain>();
                var t = Resources.LoadAll<ItemScriptMain>("Item");
                foreach (var r in t)
                {
                    var s = r;
                    items.Add(s.m_stName, s);
                }
                foreach (var sl in LoadedData.m_lsAllItem)
                {
                    var s = sl;
                    InventoryMenager.m_singInvt.AddOnInvt(items[s.m_stNameItem], s.m_iAmount);
                }
                return LoadedData;
            }
            return null;
        }
    }
}
[Serializable]
public class CurWorld
{
    public string m_stNameWorld;
    public int m_intX;
    public int m_intY;
    public float m_iPlX;
    public float m_iPlY;
    public WorldPlate[,] m_clssPlate = new WorldPlate[World.m_G2AllObj.GetLength(0) , World.m_G2AllObj.GetLength(1)];
    public List<InventorySlot> m_lsAllItem = new List<InventorySlot>();
}
[Serializable]
public class WorldPlate
{
    public string m_stBlockName = "";
}
[Serializable]
public class InventorySlot
{
    public string m_stNameItem;
    public int m_iAmount;
    public InventorySlot(string Name,int Amount)
    {
        m_iAmount = Amount;
        m_stNameItem = Name;
    } 
}