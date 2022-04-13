using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGitem : MonoBehaviour
{
    public Sprite myBG;
    public Image target;
    public Image myImage;
    public MainScript mainScript;
    public bool is1;
    public List<bool> boolForChecklist = new List<bool>();
    public bool isInit;
    public void changeBG()
    {
        if (mainScript.renderColor.bgSelected==null)
        {
            mainScript.renderColor.bgSelected = this;
            Stat.SetAct(this.gameObject, true);
        }
        else
        {
            Stat.SetAct(mainScript.renderColor.bgSelected.gameObject, false);
            mainScript.renderColor.bgSelected = this;
            Stat.SetAct(this.gameObject, true);
        }
        if (is1==false)
        {
            target.color = Color.white;
        }
        else
        {
            //updatebg1();
        }

       // mainScript.renderColor.bg1.myImage.color = mainScript.renderColor.bg.myColor;
       
        target.sprite = myBG;
        target.preserveAspect = true;

        if (isInit==false)
        {
            mainScript.TriggerChecklist(boolForChecklist);
        }
    }
    //public void updatebg1()
    //{
    //    if (is1 == true)
    //    {
    //        if (mainScript.paletteObj.activeInHierarchy==true)
    //        {
    //            mainScript.renderColor.activeSlider = false;
    //            mainScript.renderColor.InitSliders(mainScript.renderColor.bg.myColor);
    //        }
    //        myImage.color = mainScript.renderColor.bg.myColor;
    //    }
    //}
}
