using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum Chartype
{
    Eye,
    Eyebrow,
    Nose,
    Lips,
    Base,
    Blush,
    EyeShadow,
}
public class CharItem : MonoBehaviour
{
    public MainScript mainScript;
    public Chartype chartype;
    public SubCategory mySub;
    public Sprite s1;
    public Sprite s2;
    public Sprite s3;
    public Sprite s4;
    public Sprite s5;
    public Sprite s6;
    public Sprite s7;
    public Sprite s8;
    public Sprite s9;
    public Sprite s10;
    public Sprite s11;
    public Sprite s12;
    public Sprite s13;
    public List<Sprite> flats1 = new List<Sprite>();
    public List<Sprite> flats2 = new List<Sprite>();
    //
    //public List<Sprite> flats3 = new List<Sprite>();

    public void RenderChar()
    {
        Color H1;
        Color S1;
        Color O1;
        Color H2;
        Color S2;
        Color O2;
        Color etc1;
        Color etc2;
        Color etc3;
        switch (chartype)
        {
            case Chartype.Eye:
                check(s1, 169);
                check(s2, 170);
                check(s3, 171);
                check(s4, 172);
                check(s5, 173);
                check(flats1[0], 174);
                check(s6, 175);

                //COLOR
                etc1 = ColorStatic.ColorLinearLight(mainScript.baseSub.myColor, new Color(255f / 255, 240f / 255, 219f / 255), .9f);
                mainScript.layers[169].color = etc1;
                ColorStatic.CalculateHSO(mySub.myTexture, mySub.myColor, out O1, out S1, out H1);
                mainScript.layers[170].color = mySub.myColor;
                mainScript.layers[171].color = O1;
                mainScript.layers[172].color = etc1;
                ColorStatic.CalculateHSO(mainScript.baseSub.myTexture, mainScript.baseSub.myColor, out O2, out S2, out H2);
                mainScript.layers[173].color = O2;
                ColorStatic.CalculateHSO(mainScript.hairSub.myTexture, mainScript.hairSub.myColor, out O1, out S1, out H1);
                mainScript.layers[175].color = O1;
                break;


            case Chartype.Eyebrow:
                check(s1, 155);
                check(s2, 176);

                //COLOR
                ColorStatic.CalculateHSO(mainScript.baseSub.myTexture, mainScript.baseSub.myColor, out O1, out S1, out H1);
                mainScript.layers[155].color = S1;
                mainScript.layers[176].color = mySub.myColor;

                break;
            case Chartype.Nose:
                check(s1, 154);
                check(s2, 157);
                check(s3, 177);

                //COLOR
                ColorStatic.CalculateHSO(mainScript.baseSub.myTexture, mainScript.baseSub.myColor, out O1, out S1, out H1);
                mainScript.layers[154].color = S1;
                mainScript.layers[157].color = H1;
                mainScript.layers[157].color = O1;

                break;
            case Chartype.Lips:
                check(s1, 160);
                check(s2, 164);
                check(s3, 165);
                check(s4, 166);
                check(s5, 167);
                check(flats1[0], 168);

                //COLOR
                ColorStatic.CalculateHSO(mainScript.baseSub.myTexture, mainScript.baseSub.myColor, out O1, out S1, out H1);
                mainScript.layers[160].color = O1;
                mainScript.layers[164].color = mySub.myColor;
                ColorStatic.CalculateHSO(mySub.myTexture, mySub.myColor, out O2, out S2, out H2);
                mainScript.layers[165].color = S2;
                mainScript.layers[166].color = H2;
                mainScript.layers[167].color = O2;

                break;
            case Chartype.Base:
                check(s1, 61);
                check(s2, 62);
                check(s3, 63);
                check(s4, 64);
                check(s5, 65);
                check(flats1[0], 66);
          
                check(s8, 152);
                check(s9, 153);
                check(s10, 156);
                check(s11, 161);
                check(flats2[0], 162);

                check(s7, 67);
                check(s13, 163);

                //COLOR
                mainScript.layers[61].color = mySub.myColor;
                ColorStatic.CalculateHSO(mainScript.baseSub.myTexture, mainScript.baseSub.myColor, out O1, out S1, out H1);
                mainScript.layers[62].color = S1;
                mainScript.layers[63].color = new Color(1f, 0f, 0f);
                mainScript.layers[64].color = H1;
                mainScript.layers[65].color = O1;

                mainScript.layers[152].color = mySub.myColor;
                mainScript.layers[153].color = S1;
                mainScript.layers[156].color = H1;
                mainScript.layers[161].color = O1;

                mainScript.layers[67].color = mySub.tColor;
                mainScript.layers[163].color = mySub.tColor2;

                break;
            case Chartype.Blush:
                SingleRender(s1, mainScript.layers[158]);
                mainScript.layers[158].color = mySub.myColor;
                break;
            case Chartype.EyeShadow:
                SingleRender(s1, mainScript.layers[159]);
                mainScript.layers[159].color = mySub.myColor;
                break;
            default:
                break;
        }
        if (chartype == Chartype.Blush || chartype == Chartype.EyeShadow)
        {
           // Debug.Log("wtf0");
            if (mySub.selectedChar == null)
            {
                Stat.SetAct(this.gameObject, true);
                mySub.selectedChar = this;
                //Debug.Log("wtf3");

            }
            else if(mySub.selectedChar != null && mySub.selectedChar != this)
            {
                Stat.SetAct(mySub.selectedChar.gameObject, false);
                mySub.selectedChar = this;
                Stat.SetAct(this.gameObject, true);
                //  Debug.Log("wtf1");
            }
            else if (mySub.selectedChar != null && mySub.selectedChar == this)
            {
                Stat.SetAct(mySub.selectedChar.gameObject, false);
                mySub.selectedChar = null;

               // Debug.Log("wtf2");
            }
          

        }
        else if (chartype != Chartype.Blush || chartype != Chartype.EyeShadow)
        {
            if (mySub.selectedChar != null)
            {
                Stat.SetAct(mySub.selectedChar.gameObject, false);
            }
            mySub.selectedChar = this;
            Stat.SetAct(this.gameObject, true);
          //  Debug.Log(this.chartype);

        }
        


    }
    public void SingleRender(Sprite input, Image image)
    {
        if (image.sprite != input || image.gameObject.activeInHierarchy == false)
        {
            image.sprite = input;
            image.gameObject.SetActive(true);
        }
        else if (image.sprite == input)
        {
            image.gameObject.SetActive(false);
        }

    }
    public void check(Sprite sprite, int layer)
    {
        if (sprite != null)
        {
            mainScript.layers[layer].sprite = sprite;
            mainScript.layers[layer].gameObject.SetActive(true);
            //Debug.Log("wtf");
        }
        else
        {
            mainScript.layers[layer].gameObject.SetActive(false);
        }
    }
    public void checkChar()
    {
        switch (chartype)
        {
            case Chartype.Eye:
                break;
            case Chartype.Eyebrow:
                break;
            case Chartype.Nose:
                break;
            case Chartype.Lips:
                break;
            case Chartype.Base:
                break;
            case Chartype.Blush:
                break;
            case Chartype.EyeShadow:
                break;
            default:
                break;
        }
    }
}
