using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player m_singPl;
    public int m_iDamege;
    public CrossHair m_srCrosshair;
    public GameObject m_gmCrossHair
    {
        private set { }
        get => m_srCrosshair.m_gmCrossHair;
    }
    public void Awake()
    {
        m_singPl = this;
    }
}
