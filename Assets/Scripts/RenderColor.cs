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
    public Image SatImage;
    public Image HueImage;
    public SubCategory extra;
    public SubCategory style;
    public Sprite normalHue;
    public Sprite baseHue;
    public HueLock hueLock;
    public SubCategory bg;
   // public Image bgTarget;
    public BGitem bgSelected;
    public BGitem bg1;
    void Update()
    {
        PaintLayers();
        UpdateSliderVisuals();
        if (hueLock.isHairLocked == true && hueLock.toggleBool == false)
        {
            extra.myColor = style.myColor;
            paintExtraLock();
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
    public void PaintLayers()
    {
        if (activeSlider == true && mainScript.selectedSub != null  && mainScript.selectedSub != bg)
        {
            mainScript.selectedSub.myColor = Color.HSVToRGB(hueSlider.value, satSlider.value, valSlider.value);
            if (mainScript.selectedSub.isChar == true && mainScript.selectedSub.selectedChar != null)
            {
                Color H;
                Color S;
                Color O;
                ColorStatic.CalculateHSO(mainScript.selectedSub.myTexture, mainScript.selectedSub.myColor, out O, out S, out H);
                Color H2;
                Color S2;
                Color O2;
                ColorStatic.CalculateHSO(mainScript.baseSub.myTexture, mainScript.baseSub.myColor, out O2, out S2, out H2);
                Color H3;
                Color S3;
                Color O3;
                ColorStatic.CalculateHSO(mainScript.hairSub.myTexture, mainScript.hairSub.myColor, out O3, out S3, out H3);
                switch (mainScript.selectedSub.selectedChar.chartype)
                {
                    case Chartype.Eye:


                        //COLOR
                        Color etc1;
                        etc1 = ColorStatic.ColorLinearLight(mainScript.baseSub.myColor, new Color(255f / 255, 240f / 255, 219f / 255), .9f);
                        mainScript.layers[169].color = etc1;
                        mainScript.layers[170].color = mainScript.selectedSub.myColor;
                        mainScript.layers[171].color = O;
                        mainScript.layers[172].color = etc1;
                        mainScript.layers[173].color = O2;
                        mainScript.layers[175].color = O3;
                        break;


                    case Chartype.Eyebrow:

                        //COLOR
                        mainScript.layers[155].color = S2;
                        mainScript.layers[176].color = mainScript.selectedSub.myColor;

                        break;
                    case Chartype.Nose:

                        //COLOR
                        mainScript.layers[154].color = S;
                        mainScript.layers[157].color = H;
                        mainScript.layers[157].color = O;

                        break;
                    case Chartype.Lips:


                        //COLOR
                        mainScript.layers[160].color = O2;
                        mainScript.layers[164].color = mainScript.selectedSub.myColor;
                        mainScript.layers[165].color = S;
                        mainScript.layers[166].color = H;
                        mainScript.layers[167].color = O;

                        break;
                    case Chartype.Base:


                        //COLOR
                        mainScript.layers[61].color = mainScript.selectedSub.myColor;
                        mainScript.layers[62].color = S2;
                        mainScript.layers[63].color = new Color(1f, 0f, 0f);
                        mainScript.layers[64].color = H2;
                        mainScript.layers[65].color = O2;

                        mainScript.layers[152].color = mainScript.selectedSub.myColor;
                        mainScript.layers[153].color = S;
                        mainScript.layers[156].color = H;
                        mainScript.layers[161].color = O;

                        mainScript.layers[67].color = mainScript.selectedSub.tColor;
                        mainScript.layers[163].color = mainScript.selectedSub.tColor2;

                        break;
                    case Chartype.Blush:
                        mainScript.layers[158].color = mainScript.selectedSub.myColor;
                        break;
                    case Chartype.EyeShadow:
                        mainScript.layers[159].color = mainScript.selectedSub.myColor;
                        break;
                    default:
                        break;
                }
            }
            else if (mainScript.selectedSub.isChar == false && mainScript.selectedSub.selectedItem != null)
            {
                Color H;
                Color S;
                Color O;
                ColorStatic.CalculateHSO(mainScript.selectedSub.myTexture, mainScript.selectedSub.myColor, out O, out S, out H);
                mainScript.layers[mainScript.selectedSub.m1].color = mainScript.selectedSub.myColor;
                mainScript.layers[mainScript.selectedSub.m1 + 1].color = S;
                mainScript.layers[mainScript.selectedSub.m1 + 2].color = H;
                mainScript.layers[mainScript.selectedSub.m1 + 3].color = O;
                if (mainScript.selectedSub.selectedItem.set2bool)
                {
                    mainScript.layers[mainScript.selectedSub.m2].color = mainScript.selectedSub.myColor;
                    mainScript.layers[mainScript.selectedSub.m2 + 1].color = S;
                    mainScript.layers[mainScript.selectedSub.m2 + 2].color = H;
                    mainScript.layers[mainScript.selectedSub.m2 + 3].color = O;
                }
                if (mainScript.selectedSub.selectedItem.set3bool)
                {
                    mainScript.layers[mainScript.selectedSub.m3].color = mainScript.selectedSub.myColor;
                    mainScript.layers[mainScript.selectedSub.m3 + 1].color = S;
                    mainScript.layers[mainScript.selectedSub.m3 + 2].color = H;
                    mainScript.layers[mainScript.selectedSub.m3 + 3].color = O;
                }
                //mainScript.selectedSub.selectedItem
            }
        }
        else if (activeSlider == true && mainScript.selectedSub != null && mainScript.paletteObj.activeInHierarchy == true && mainScript.selectedSub == bg)
        {
            if (bgSelected==bg1)
            {
                mainScript.selectedSub.myColor = Color.HSVToRGB(hueSlider.value, satSlider.value, valSlider.value);
                bgSelected.target.color = bg.myColor;
            }

        }
    }
    public void paintExtraLock()
    {
        if (extra.selectedItem!=null)
        {

        Color H;
        Color S;
        Color O;
        //Debug.Log("active");
        ColorStatic.CalculateHSO(extra.myTexture, extra.myColor, out O, out S, out H);
        mainScript.layers[extra.m1].color = extra.myColor;
        mainScript.layers[extra.m1 + 1].color = S;
        mainScript.layers[extra.m1 + 2].color = H;
        mainScript.layers[extra.m1 + 3].color = O;
        if (extra.selectedItem.set2bool)
        {
            mainScript.layers[extra.m2].color = extra.myColor;
            mainScript.layers[extra.m2 + 1].color = S;
            mainScript.layers[extra.m2 + 2].color = H;
            mainScript.layers[extra.m2 + 3].color = O;
        }
        if (extra.selectedItem.set3bool)
        {
            mainScript.layers[extra.m3].color = extra.myColor;
            mainScript.layers[extra.m3 + 1].color = S;
            mainScript.layers[extra.m3 + 2].color = H;
            mainScript.layers[extra.m3 + 3].color = O;
        }
            //mainScript.selectedSub.selectedItem
        }

    }

    public void UpdateSliderVisuals()
    {
        if (activeSlider == true && mainScript.selectedSub != null && mainScript.paletteObj.activeInHierarchy == true)
        {
            float H;
            float S;
            float V;
            Color.RGBToHSV(mainScript.selectedSub.myColor, out H, out S, out V);
            SatImage.color = Color.HSVToRGB(H, .8f, .8f);
        }
        //else 
    }
    
}
