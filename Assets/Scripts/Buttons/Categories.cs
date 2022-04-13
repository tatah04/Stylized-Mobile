using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Categories : MonoBehaviour
{
    public MainScript mainScript;
    public RectTransform Content;
    public SubCategory firstSubCateg;
    public ScrollRect subScrollRect;
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

        mainScript.audioManager.playSFX(1);
        subScrollRect.horizontalNormalizedPosition = 0;
    }
    public void DeselectCategory()
    {
        Stat.ColorSelect(this.gameObject, false);
        mainScript.selectedCategory = null;
        if (mainScript.selectedSub!=null)
        {
            mainScript.selectedSub.DeselectSub();
          //  Debug.Log("deselectcateg");
        }
        Content.gameObject.SetActive(false);
    }
}
