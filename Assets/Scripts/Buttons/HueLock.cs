using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HueLock : MonoBehaviour
{
    public MainScript mainScript;
    public RenderColor renderColor;
    public GameObject hueLockObj;
    public Image myImage;
    public Sprite baseLocked;
    public Sprite baseUnLocked;
    public Sprite hairLocked;
    public Sprite hairunLocked;
    public Color hair;
    public bool isHairLocked;
    public bool isBaseLocked;
    public SubCategory extraSub;
    public SubCategory styleSub;
    public SubCategory baseSub;
    public bool toggleBool=false;
    public List<bool> boolForLocked = new List<bool>();
    public void ToggleHueLock()
    {
        if (mainScript.selectedSub != null && (mainScript.selectedSub == extraSub || mainScript.selectedSub == styleSub))
        {
            isHairLocked = !isHairLocked;
            if (isHairLocked==true)
            {
                toggleBool = true;
            }
            TriggerHair();
        }
        else if (mainScript.selectedSub != null && mainScript.selectedSub == baseSub)
        {
            isBaseLocked = !isBaseLocked;
       
        }

        UpdateLock();
    }
    public void UpdateLock()
    {
        Debug.Log("wtf1");
        if (mainScript.selectedSub != null && (mainScript.selectedSub == extraSub || mainScript.selectedSub == styleSub))
        {
            hueLockObj.SetActive(true);
            if (isHairLocked == true)
            {
                Debug.Log("wtf2");
                myImage.sprite = hairLocked;
                if (mainScript.selectedSub==extraSub)
                {
                    mainScript.TriggerChecklist(boolForLocked);
                    Debug.Log("wtf3");
                }
            }
            else
            {
                Debug.Log("wtf4");
                if (mainScript.selectedSub == extraSub)
                {
                    mainScript.TriggerChecklist(extraSub.boolCheckList);
                    Debug.Log("wtf5");
                }
                myImage.sprite = hairunLocked;
            }
            myImage.color = hair;
        }
        else if (mainScript.selectedSub != null && mainScript.selectedSub == baseSub)
        {
            hueLockObj.SetActive(true);

            if (isBaseLocked == true)
            {
                myImage.sprite = baseLocked;
            }
            else
            {
                myImage.sprite = baseUnLocked;
            }
            myImage.color = Color.white;
        }
        else
        {
            hueLockObj.SetActive(false);
        }
        if (mainScript.selectedSub != null && mainScript.selectedSub == mainScript.baseSub &&isBaseLocked)
        {
            renderColor.HueImage.sprite = renderColor.baseHue;
            renderColor.activeSlider = false;
            renderColor.hueSlider.minValue = 14f / 360;
            renderColor.hueSlider.maxValue = 29f / 360;
            renderColor.activeSlider = true;
        }
        else 
        {
            renderColor.HueImage.sprite = renderColor.normalHue;
            renderColor.activeSlider = false;
            renderColor.hueSlider.minValue = 0;
            renderColor.hueSlider.maxValue = 1;
            renderColor.activeSlider = true;
        }
    }
 
    public void TriggerHair()
    {
        if (toggleBool == true)
        {
            renderColor.activeSlider = false;
            extraSub.myColor = styleSub.myColor;
            renderColor.paintExtraLock();
            renderColor.InitSliders(extraSub.myColor);
            toggleBool = false;
        }
    }
}
