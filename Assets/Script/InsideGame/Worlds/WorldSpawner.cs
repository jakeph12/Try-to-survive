using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WorldSpawner : MonoBehaviour
{
    public static WorldSpawner m_scWorldSpSing;
    [SerializeField]private GameObject[] m_GPr;
    public GameObject m_GPl, m_gBorder,m_gmGroundInWorld, m_gObjInWorld, m_gmDropedItemInWorld;
    [SerializeField]private List<CreatorObjWorld> m_lAllObjWorld = new List<CreatorObjWorld>();
    private Dictionary<CreatorObjWorld, int> m_dRare = new Dictionary<CreatorObjWorld, int>();
    void Start()
    {
        m_scWorldSpSing = this;
        if(!JakePhLib.SaveAndLoad<CurWorld>.CheckSave(PlayerPrefs.GetString("LastGame"), Application.persistentDataPath + "/Worlds")) CrateNewWorld();
        else LoadOldWorld("New World");
    }
    public void CrateNewWorld()
    {
        World.m_stNameWorld = GetComponent<PlayerSettings>().m_stNameWorld;
        foreach (CreatorObjWorld obg in m_lAllObjWorld)
        {
            m_dRare.Add(obg, obg.m_IRare);
        }
        World.m_G2AllPlateWorld = new GameObject[GetComponent<PlayerSettings>().m_V2ISizeWorld.x, GetComponent<PlayerSettings>().m_V2ISizeWorld.y];
        World.m_G2AllObj = new GameObject[GetComponent<PlayerSettings>().m_V2ISizeWorld.x, GetComponent<PlayerSettings>().m_V2ISizeWorld.y];
        m_GPl.transform.position = new Vector3(World.m_G2AllPlateWorld.GetLength(0) / 2, World.m_G2AllPlateWorld.GetLength(1) / 2, 0);
        for (int x = 0; x < World.m_G2AllPlateWorld.GetLength(0); x++)
        {
            for (int y = 0; y < World.m_G2AllPlateWorld.GetLength(1); y++)
            {
                GameObject Gm = Instantiate(m_GPr[0], m_gmGroundInWorld.transform);
                Gm.transform.position = new Vector3(x, y, 0);
                World.m_G2AllPlateWorld[x, y] = Gm;
                for (int i = 0; i < m_dRare.Count; i++)
                {
                    if (x == 0 || y == 0 || x >= GetComponent<PlayerSettings>().m_V2ISizeWorld.x - 1 || y >= GetComponent<PlayerSettings>().m_V2ISizeWorld.y - 1)
                    {
                        GameObject Gms = Instantiate(m_gBorder, m_gmGroundInWorld.transform);
                        Gms.transform.position = new Vector3(x, y, 0);
                        World.m_G2AllObj[x, y] = Gms;
                        break;
                    }
                    int Er = Random.Range(1, 100);
                    int RI = Random.Range(0, m_lAllObjWorld.Count);
                    if (m_dRare[m_lAllObjWorld[RI]] >= Er)
                    {
                        GameObject Gms = Instantiate(m_lAllObjWorld[RI].m_gPrefab, m_gObjInWorld.transform);
                        Gms.transform.position = new Vector3(x, y, 0);
                        m_dRare[m_lAllObjWorld[RI]] = 0;
                        World.m_G2AllObj[x, y] = Gms;
                    }

                    if (m_dRare[m_lAllObjWorld[RI]] == 0)
                    {
                        m_dRare[m_lAllObjWorld[RI]] = m_lAllObjWorld[RI].m_IRare;
                    }
                }
            }
        }
    }
    public void LoadOldWorld(string Name)
    {
        World.m_stNameWorld = Name;
        CurWorld world = SavingWorld.Load();
        World.m_G2AllObj = new GameObject[world.m_intX, world.m_intY];
        World.m_G2AllPlateWorld = new GameObject[world.m_intX, world.m_intY];
        Dictionary<string, GameObject> AllObj = new Dictionary<string, GameObject>();
        GameObject[] bj = Resources.LoadAll<GameObject>("Obj");
        for (int i = 0; i < bj.Length; i++)
        {
            if (bj[i].GetComponent<SaveCh>()) AllObj.Add(bj[i].GetComponent<SaveCh>().m_stNameObjSave, bj[i]);
        }
        for(int x = 0;x < World.m_G2AllPlateWorld.GetLength(0); x++)
        {
            for (int y = 0; y < World.m_G2AllPlateWorld.GetLength(1); y++)
            {
                GameObject Gm = Instantiate(m_GPr[0], m_gmGroundInWorld.transform);
                Gm.transform.position = new Vector3(x, y, 0);
                World.m_G2AllPlateWorld[x, y] = Gm;
                if(world.m_clssPlate[x,y] != null)
                {
                    GameObject Gms = Instantiate(AllObj[world.m_clssPlate[x , y].m_stBlockName], m_gObjInWorld.transform);
                    Gms.transform.position = new Vector3(x, y, 0);
                    World.m_G2AllObj[x, y] = Gms;
                }
            }
        }
        m_GPl.transform.position = new Vector2(world.m_iPlX,world.m_iPlY);
    }
}
