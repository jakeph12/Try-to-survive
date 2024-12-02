using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBlocks : MonoBehaviour
{
    public List<CreatorObjWorld> m_lCRAllWB = new List<CreatorObjWorld>();
    public static Dictionary<string, CreatorObjWorld> m_dCRAllWB = new Dictionary<string, CreatorObjWorld>();

    public void Awake()
    {
        foreach(CreatorObjWorld Obg in m_lCRAllWB)
            m_dCRAllWB.Add(Obg.m_sName,Obg);
    }
}
