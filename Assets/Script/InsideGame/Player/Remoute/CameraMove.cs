using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float m_flLerPower;
    [SerializeField] private Camera m_CMain;
    private void Start()
    {
        if(!m_CMain)
            m_CMain = Camera.main;
    }
    private void FixedUpdate()
    {
        float X = Mathf.Lerp(m_CMain.transform.position.x, transform.position.x, m_flLerPower);
        float Y = Mathf.Lerp(m_CMain.transform.position.y, transform.position.y, m_flLerPower);
        X = Mathf.Clamp(X,10, World.m_G2AllPlateWorld.GetLength(0) - 10);
        Y = Mathf.Clamp(Y,4.5f, World.m_G2AllPlateWorld.GetLength(1) - 7);
        m_CMain.transform.position = new Vector3(
            X,
            Y,
            m_CMain.transform.position.z);
    }
}
