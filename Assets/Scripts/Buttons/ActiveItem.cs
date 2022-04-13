using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveItem : MonoBehaviour
{
    public MainScript mainScript;
    public SubCategory myDependencySub;
    public bool isCharActiveItem;
    public Image target;
    public bool isBG;

    
    public void CheckMyDependency()
    {
        if (isCharActiveItem==true && isBG == false)
        {
            this.gameObject.SetActive(true);
            target.color = myDependencySub.myColor;
        }
        else if(isCharActiveItem==false && myDependencySub.selectedItem!=null && isBG == false)
        {
            this.gameObject.SetActive(true);
            target.color = myDependencySub.myColor;
        }
        else if (isCharActiveItem == false && myDependencySub.selectedItem == null &&isBG==false)
        {
            this.gameObject.SetActive(false);
        }
        else if(isBG==true && mainScript.renderColor.bgSelected==mainScript.renderColor.bg1)
        {
            this.gameObject.SetActive(true);
            target.color = myDependencySub.myColor;
        }
        else if(isBG == true && mainScript.renderColor.bgSelected != mainScript.renderColor.bg1)
        {
            this.gameObject.SetActive(false);
        }
    }
    public void SelectColor()
    {
        if (mainScript.selectedSub!=null)
        {
            mainScript.renderColor.activeSlider = false;
            mainScript.selectedSub.myColor = target.color;
            mainScript.renderColor.InitSliders(target.color);
        }

        mainScript.audioManager.playSFX(2);
        mainScript.activeItem(false);
    }
}
