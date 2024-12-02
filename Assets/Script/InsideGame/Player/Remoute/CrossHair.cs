using UnityEngine;
using UnityEngine.UI;

public class CrossHair : MonoBehaviour
{
    public GameObject m_gmCrossHair;
    [SerializeField] private SlotsDefault m_scSl;
    private GameObject Curentpr;

    private void Update()
    {
        if (m_scSl && m_scSl.m_itCurent && m_scSl.m_itCurent.m_eTypeBlock == g_eTypeBlock.PlaceblItm)
        {
            if (Curentpr)
            {
                Curentpr.transform.position = (Vector2)Vector2Int.CeilToInt(m_gmCrossHair.transform.position);
                Curentpr.GetComponent<SpriteRenderer>().sprite = m_scSl.m_itCurent.m_spIco;
            }
            else
            {
                Curentpr = new GameObject();
                Curentpr.AddComponent<SpriteRenderer>().sortingOrder = 1;
                Curentpr.transform.localScale = (Vector2.one * 6.66f);
            }
        }
        else
        {
            if (Curentpr)
            {
                Destroy(Curentpr);
            }
        }
    }
    public void Fire()
    {
        Collider2D m_gBlock = Physics2D.OverlapBox(m_gmCrossHair.transform.position, Vector2.one / 2, 0);
        if (m_gBlock && WalkScript.m_bAvailable)
        {
            if(m_gBlock.GetComponent<DestroyTh>())
                m_gBlock.GetComponent<DestroyTh>().Use(Player.m_singPl.m_iDamege);
        }
    }
    public void Use()
    {
        Collider2D m_gBlock = Physics2D.OverlapBox(m_gmCrossHair.transform.position, Vector2.one / 2, 0);
        if (WalkScript.m_bAvailable)
        {
            if (m_gBlock)
            {
                if (m_gBlock.GetComponent<UseTh>())
                    m_gBlock.GetComponent<UseTh>().Use();
            }
            else
            {
                if(m_scSl && m_scSl.m_itCurent && m_scSl.m_itCurent.m_eTypeBlock == g_eTypeBlock.PlaceblItm)
                {
                    if (m_scSl.m_itCurent is PlaceblItm pl)
                    {
                        Vector2Int vk = Vector2Int.CeilToInt(m_gmCrossHair.transform.position);
                        if (!World.m_G2AllObj[vk.x, vk.y])
                        {
                            var NewObg = Instantiate(pl.m_gmPrefab, WorldSpawner.m_scWorldSpSing.m_gObjInWorld.transform);
                            NewObg.transform.position = (Vector2)vk;
                            m_scSl.m_iAmount--;
                            World.m_G2AllObj[vk.x, vk.y] = NewObg;
                            Destroy(Curentpr);
                        }
                       
                    }
                }
            }

        }
    }
}
