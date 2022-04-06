using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Categories : MonoBehaviour
{
    public MainScript mainScript;
    public RectTransform Content;
    public SubCategory firstSubCateg;
    public void SelectCategory()
    {
        if (mainScript.selectedCategory != null)
        {
            mainScript.selectedCategory.DeselectCategory();
        }
        mainScript.selectedCategory = this;

        Stat.SetContent(mainScript.subScrollView, Content);
        firstSubCateg.SelectSub();
        Stat.ColorSelect(this.gameObject, true);
    }
    public void DeselectCategory()
    {
        Stat.ColorSelect(this.gameObject, false);
        mainScript.selectedCategory = null;
        if (mainScript.selectedSub!=null)
        {
            mainScript.selectedSub.DeselectSub();
        }
        Content.gameObject.SetActive(false);
    }
}
