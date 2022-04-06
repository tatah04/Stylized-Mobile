using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderColor : MonoBehaviour
{
    // Start is called before the first frame update
    public MainScript mainScript;
    public Slider hueSlider;
    public Slider satSlider;
    public Slider valSlider;
    public bool activeSlider;

    
    void Update()
    {
        if (activeSlider==true)
        {
            mainScript.selectedSub.myColor = Color.HSVToRGB(hueSlider.value, satSlider.value, valSlider.value);
        }
    }

    public void InitSliders(Color colorToSet)
    {
        activeSlider = false;
        float h;
        float s;
        float v;
        Color.RGBToHSV(colorToSet, out h, out s, out v);
        hueSlider.value = h;
        satSlider.value = s;
        valSlider.value = v;
        activeSlider = true;
    }
}
