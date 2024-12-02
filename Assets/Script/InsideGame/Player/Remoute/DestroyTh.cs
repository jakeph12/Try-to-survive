using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DestroyTh : MonoBehaviour
{
   [SerializeField] private int _m_iHpBlock;
    public int m_iHpBlock
    {
        get => _m_iHpBlock;
        set
        {
            _m_iHpBlock = value;
            if (_m_iHpBlock <= 0) Death();
        }
    }

    public abstract void Death();
    public abstract void Use(int i);
}
