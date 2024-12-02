using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workbench : UseTh
{
    [SerializeField] private List<RecipeScriptMain> AllRecipe = new List<RecipeScriptMain>();
    [SerializeField] private bool m_RemoveControle = true;
    public override void Use()
    {
        UiController.mst_gAllPannels[1].GetComponent<CrafterSc>().Open(AllRecipe, m_RemoveControle);
    }
}
