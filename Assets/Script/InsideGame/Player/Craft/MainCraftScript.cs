using UnityEngine;

public class MainCraftScript
{
    public static bool CanCraft(RecipeScriptMain Recipe)
    {
        uint AmItm = (uint)Recipe.m_scItemWhatWeNeed.Length;
        for (int i = 0;i < Recipe.m_scItemWhatWeNeed.Length; i++)
        {
            int AmAm = Recipe.m_scItemWhatWeNeed[i].m_iAmount;
            foreach (Slots Sl in InventoryMenager.m_singInvt.m_lAllSlots)
            {
                if (Sl.m_itCurent == Recipe.m_scItemWhatWeNeed[i].m_scItem)
                {
                    if (Sl.m_iAmount >= AmAm)
                    {
                        AmAm = 0;
                    }
                    else
                    {
                        AmAm -= Sl.m_iAmount;
                    }
                    if (AmAm == 0)
                    {
                        AmItm--;
                        break;
                    }
                }
            }
            if (AmItm == 0) break;
        }
        if (AmItm == 0) return true;
        else
        return false;
    }
    public static void Craft(RecipeScriptMain Recipe)
    {
        if (CanCraft(Recipe))
        {
            uint AmItm = (uint)Recipe.m_scItemWhatWeNeed.Length;
            for (int i = 0; i < Recipe.m_scItemWhatWeNeed.Length; i++)
            {
                int AmAm = Recipe.m_scItemWhatWeNeed[i].m_iAmount;
                ItemScriptMain Itm = Recipe.m_scItemWhatWeNeed[i].m_scItem;
                foreach (Slots Sl in InventoryMenager.m_singInvt.m_lAllSlots)
                {
                    if (Sl.m_itCurent == Itm)
                    {
                        if (Sl.m_iAmount >= AmAm)
                        {
                            Sl.m_iAmount -= AmAm;
                            AmAm = 0;
                        }
                        else
                        {
                            AmAm -= Sl.m_iAmount;
                            Sl.m_iAmount = 0;
                        }
                        if (AmAm == 0)
                        {
                            AmItm--;
                            break;
                        }
                    }
                }
                if (AmItm == 0) break;
            }
            InventoryMenager.m_singInvt.AddOnInvt(Recipe.m_itmWhatWeGet.m_scItem, Recipe.m_itmWhatWeGet.m_iAmount);
        }
    }
}
