using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "New/For item/Recipe")]
public class RecipeScriptMain : ScriptableObject
{
    public string m_stName;
    public ItemBase[] m_scItemWhatWeNeed;
    public ItemBase m_itmWhatWeGet;
}
[System.Serializable]
public class ItemBase
{
    public ItemScriptMain m_scItem;
    public int m_iAmount;
}