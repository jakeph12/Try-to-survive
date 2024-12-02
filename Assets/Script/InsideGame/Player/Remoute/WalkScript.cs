using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkScript : MonoBehaviour
{
    [SerializeField] private float m_flSpeed;
    [SerializeField] private GameObject m_gCrossHair;
    private Vector2 m_vecMove;
    public static bool m_bAvailable = true;
    private void FixedUpdate()
    {
        if (m_bAvailable)
            transform.position = new Vector3( transform.position.x + m_vecMove.x, transform.position.y + m_vecMove.y,transform.position.z);
    }
    private void Update()
    {
        if (m_bAvailable) Cheack();
        else if (GetComponent<Animator>().GetBool("Walk")) GetComponent<Animator>().SetBool("Walk", false);
    }
    private void Cheack()
    {
        float X = Input.GetAxis("Horizontal");
        float Y = Input.GetAxis("Vertical");
        if(X != 0 || Y != 0)
        {
            GetComponent<Animator>().SetBool("Walk", true);
                if(X > 0)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                    m_gCrossHair.transform.localPosition = new Vector2(0.16f,0);
                    m_gCrossHair.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
                else if(X < 0)
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                    m_gCrossHair.transform.localPosition = new Vector2(-0.16f, 0);
                    m_gCrossHair.transform.rotation = Quaternion.Euler(0,0,0);
                }
                else if (Y > 0)
                {
                m_gCrossHair.transform.rotation = Quaternion.Euler(0, 0, -90);
                m_gCrossHair.transform.localPosition = new Vector2(0, 0.16f);
                }
                else if (Y < 0)
                {                   
                m_gCrossHair.transform.rotation = Quaternion.Euler(0,0,90);
                m_gCrossHair.transform.localPosition = new Vector2(0, -0.18f);
                }

        }
        else
        {
            GetComponent<Animator>().SetBool("Walk", false);
        }   
        m_vecMove = new Vector2(X,Y).normalized * m_flSpeed;
    }
}
