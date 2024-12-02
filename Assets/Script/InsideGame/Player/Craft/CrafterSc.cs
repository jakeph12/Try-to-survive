using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrafterSc : MonoBehaviour
{
    public GameObject m_gmPrefaSl,m_gmPrefabPannel;
    private GameObject m_gmPannelOfSlots;

    [SerializeField] private Button m_btCarft;
    [SerializeField] private Text m_txDescription;
    [SerializeField] private Image m_imIco;

    private RecipeScriptMain _m_scCurrentRecipe;

    private bool m_bControl;

    public RecipeScriptMain m_scCurretResipe
    {
        set
        {
            _m_scCurrentRecipe = value;
            if (_m_scCurrentRecipe)
            {
                m_txDescription.text = _m_scCurrentRecipe.m_itmWhatWeGet.m_scItem.m_stName;
                m_imIco.sprite = _m_scCurrentRecipe.m_itmWhatWeGet.m_scItem.m_spIco;
                m_btCarft.interactable = true;
            }
            else
            {
                m_txDescription.text = "";
                m_imIco.sprite = null;
                m_btCarft.interactable = false;
            }
        }
        private get => _m_scCurrentRecipe;
    }

    public void Open(List<RecipeScriptMain> allRecipe,bool RemoveControle)
    {
        gameObject.SetActive(true);
        if (m_bControl) WalkScript.m_bAvailable = false;
        var NewPannel = Instantiate(m_gmPrefabPannel,transform) as GameObject;
        NewPannel.transform.SetAsFirstSibling();
        m_gmPannelOfSlots = NewPannel;
        var container = NewPannel.transform.GetChild(0).gameObject;
        foreach (var r in allRecipe)
        {
            var NewSlot = Instantiate(m_gmPrefaSl, container.transform).GetComponent<CraftSl>();
            if (!MainCraftScript.CanCraft(r)) NewSlot.GetComponent<Button>().interactable = false;
            NewSlot.m_scCraft = this;
            NewSlot.m_scCurentRecipe = r;
        }
    }
    public void Close()
    {
        Destroy(m_gmPannelOfSlots);
        gameObject.SetActive(false);
        m_scCurretResipe = null;
        if(m_bControl) WalkScript.m_bAvailable = true;
    }

    public void Craftcur()
    {
        if (m_scCurretResipe)
        {
            MainCraftScript.Craft(m_scCurretResipe);
            foreach(var r in m_gmPannelOfSlots.GetComponentsInChildren<CraftSl>())
            {
                if (!MainCraftScript.CanCraft(r.m_scCurentRecipe)) r.GetComponent<Button>().interactable = false;
            }
            m_scCurretResipe = null;
        }
    }
}
