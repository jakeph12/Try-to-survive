using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CraftSl : MonoBehaviour
{
    [SerializeField] private Image m_imIco;
    public CrafterSc m_scCraft;

    public RecipeScriptMain _m_scCurentRecipe;
    public RecipeScriptMain m_scCurentRecipe
    {
        get => _m_scCurentRecipe;
        set
        {
            _m_scCurentRecipe = value;
            if (_m_scCurentRecipe && m_imIco) m_imIco.sprite = _m_scCurentRecipe.m_itmWhatWeGet.m_scItem.m_spIco;
        }
    }

    public void SetRecipe()
    {
        m_scCraft.m_scCurretResipe = m_scCurentRecipe;
    }
}
