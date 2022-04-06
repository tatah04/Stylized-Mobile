using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCategory : MonoBehaviour
{
    // Start is called before the first frame update
    public MainScript mainScript;
    public Color myColor;
    public Color defaultColor;
    public Color tColor;
    public Color tColor2;
    public int myTexture;
    public ItemScript selectedItem;
    public int m1;
    public int m2;
    public int m3;
    public bool isChar;
    public CharItem selectedChar;
    public List<RectTransform> storeContents = new List<RectTransform>();
    public void SelectSub()
    {
        if (mainScript.selectedSub != null)
        {
            mainScript.selectedSub.DeselectSub();
        }
        mainScript.selectedSub = this;
        Stat.SetContent(mainScript.itemScrollView, storeContents[mainScript.SelectedStoreInt]);
        Stat.ColorSelect(this.gameObject, true);
    }
    public void DeselectSub()
    {
        Stat.ColorSelect(this.gameObject, false);
        mainScript.selectedSub = null;
        for (int i = 1; i < storeContents.Count; i++)
        {
            storeContents[i].gameObject.SetActive(false);
        }
    }
}
