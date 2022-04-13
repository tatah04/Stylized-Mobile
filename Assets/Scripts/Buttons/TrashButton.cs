using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashButton : MonoBehaviour
{
    public MainScript mainScript;
    public List<SubCategory> charSubs = new List<SubCategory>();
    public SubCategory hair;
    public ItemScript hairItem;
    public void Trash()
    {
        if (mainScript.selectedSub != null)
        {
            if (mainScript.selectedSub.isChar == false && mainScript.selectedSub.selectedItem != null)
            {
                if (mainScript.selectedSub == hair && mainScript.selectedSub.selectedItem != hairItem)
                {
                    hairItem.RenderItem();
                }
                else if(mainScript.selectedSub!=hair)
                {
                    mainScript.selectedSub.selectedItem.RenderItem();
                }else if(mainScript.selectedSub == hair && mainScript.selectedSub.selectedItem == hairItem)
                {

                }
            }
            else if (mainScript.selectedSub.isChar == true && charSubs.Contains(mainScript.selectedSub) == true)
            {
                mainScript.charInit[charSubs.IndexOf(mainScript.selectedSub)].RenderChar();
            }
            else if (mainScript.selectedSub.isChar == true && charSubs.Contains(mainScript.selectedSub) == false)
            {
                mainScript.selectedSub.selectedChar.RenderChar();
            }
            mainScript.renderColor.activeSlider = false;
            mainScript.selectedSub.myColor = mainScript.selectedSub.defaultColor;
            mainScript.renderColor.InitSliders(mainScript.selectedSub.defaultColor);

        }
    }
}
