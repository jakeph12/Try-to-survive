using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScr : MonoBehaviour
{
    [SerializeField] private float m_flSpeed = 1;
    [SerializeField] private Vector2Int m_vk2EndPos = new Vector2Int(1,1);


    private void Start()
    {
       m_vk2EndPos = ChEndPos(10);
    }
    void Update()
    {
        Vector2 vk;
        int index = 1000;
        if((int)transform.position.x != m_vk2EndPos.x)
        {
            if((int)transform.position.x < m_vk2EndPos.x)
                vk = new Vector2(transform.position.x + (m_flSpeed / index) ,transform.position.y);
            else
                vk = new Vector2(transform.position.x - (m_flSpeed / index),transform.position.y);
        }
        else
        {
            if ((int)transform.position.y < m_vk2EndPos.y)
                vk = new Vector2(transform.position.x, transform.position.y + (m_flSpeed / index));
            else
                vk = new Vector2(transform.position.x, transform.position.y - (m_flSpeed / index));
        }

        GetComponent<Rigidbody2D>().MovePosition(vk);
    }
    private Vector2Int ChEndPos(int maxd)
    {
        Vector2Int m;
        m = new Vector2Int((int)transform.position.x + Random.Range(0, maxd), (int)transform.position.y + Random.Range(0 ,maxd));
        return m;
    }
}
