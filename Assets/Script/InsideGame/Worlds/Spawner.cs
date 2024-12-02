using UnityEngine;

public static class Spawner
{
    public static GameObject ItemObjDrop(ItemScriptMain Itm,int Amount)
    {
        GameObject This = new GameObject($"new droped {Itm.m_stName}");
        This.transform.localScale = new Vector3(5.5f, 5.5f, 0);
        This.transform.parent = WorldSpawner.m_scWorldSpSing.m_gmDropedItemInWorld.transform;
        This.AddComponent<SpriteRenderer>().sprite = Itm.m_spIco;
        This.AddComponent<BoxCollider2D>().isTrigger = true;
        This.AddComponent<DropItm>().m_iAmount = Amount;
        This.GetComponent<DropItm>().m_itmDroped = Itm;
        This.GetComponent<SpriteRenderer>().sortingOrder = 1;
        return This;
    }    
}
