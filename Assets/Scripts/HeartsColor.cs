using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsColor : MonoBehaviour
{
    public Color myColor;
    public Sprite original;
    public Sprite selected;
    public MainScript mainScript;
    public void pickColor()
    {
        if (mainScript.selectedSub!=null)
        {
            mainScript.renderColor.activeSlider = false;
            mainScript.selectedSub.myColor = myColor;
            mainScript.renderColor.InitSliders(mainScript.selectedSub.myColor);
            mainScript.audioManager.playSFX(2);

            mainScript.renderColor.activeSlider = true;
            mainScript.renderColor.PaintLayers();
            mainScript.renderColor.activeSlider = true;
        }
    }
    public void pickTexture()
    {
        if (mainScript.selectedSub!=null)
        {
            mainScript.Textures[mainScript.selectedSub.myTexture].gameObject.GetComponent<Image>().sprite = mainScript.Textures[mainScript.selectedSub.myTexture].original;
            mainScript.selectedSub.myTexture = this.gameObject.transform.GetSiblingIndex()+1;
            this.gameObject.GetComponent<Image>().sprite = selected;
            // Debug.Log(this.gameObject.transform.GetSiblingIndex().ToString());
            mainScript.audioManager.playSFX(2);
        }
    }
    public void updateTextureSprite(bool orig)
    {
        if (orig==true)
        {
            mainScript.Textures[mainScript.selectedSub.myTexture].gameObject.GetComponent<Image>().sprite = mainScript.Textures[mainScript.selectedSub.myTexture].original;

        }
        else
        {
            mainScript.Textures[mainScript.selectedSub.myTexture].gameObject.GetComponent<Image>().sprite = mainScript.Textures[mainScript.selectedSub.myTexture].selected;

        }
    }
  
}
