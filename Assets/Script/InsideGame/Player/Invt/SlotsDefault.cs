using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class SlotsDefault : MonoBehaviour ,IDropHandler
{
    [SerializeField] private Text m_tAmount;
    [SerializeField] private Image m_imIco;
    public int m_iIdSlot;


    public bool m_bIsEmpty = true;
    [SerializeField] private ItemScriptMain _m_itCurent;

    public ItemScriptMain m_itCurent
    {
        get => _m_itCurent;
        set
        {
            _m_itCurent = value;
            if (_m_itCurent)
            {
                m_imIco.color = new Color(255, 255, 255, 255);
                m_imIco.sprite = _m_itCurent.m_spIco;
            }

        }
    }
    [SerializeField] private int _m_iAmount;
    public int m_iAmount
    {
        get => _m_iAmount;
        set
        {
            _m_iAmount = value;
            if (_m_iAmount < 0) _m_iAmount = 0;
            if (m_tAmount)
                m_tAmount.text = _m_iAmount.ToString();
            if (_m_iAmount == 0)
            {
                _m_itCurent = null;
                m_bIsEmpty = true;
                if (m_imIco)
                {
                    m_imIco.sprite = null;
                    m_imIco.color = new Color(255, 255, 255, 0);
                }
                if(m_tAmount)
                    m_tAmount.text = "";
            }
        }
    }



    public abstract void OnDrop(PointerEventData eventData);
}
