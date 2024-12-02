using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class DragSlot : MonoBehaviour, IEndDragHandler, IDragHandler, IBeginDragHandler
{
    [SerializeField]private Canvas m_cnCanvas;
    private CanvasGroup m_cngCnvasG;

    private RectTransform m_rkRect;

    private Vector3 m_vk3StartPos;
    private bool m_bDrag;
    private void Awake()
    {
        m_cngCnvasG = GetComponent<CanvasGroup>();
        m_rkRect = GetComponent<RectTransform>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (GetComponent<Slots>().m_itCurent && !WalkScript.m_bAvailable)
            m_rkRect.anchoredPosition += eventData.delta / m_cnCanvas.scaleFactor;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (GetComponent<Slots>().m_itCurent && !WalkScript.m_bAvailable)
        {
            m_vk3StartPos = transform.position;
            m_cngCnvasG.alpha = 0.6f;
            m_cngCnvasG.blocksRaycasts = false;
            m_bDrag = true;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (m_bDrag && !WalkScript.m_bAvailable)
        {
            m_cngCnvasG.alpha = 1f;
            m_cngCnvasG.blocksRaycasts = true;
            transform.position = m_vk3StartPos;
            m_bDrag = false;
        }
    }
}
