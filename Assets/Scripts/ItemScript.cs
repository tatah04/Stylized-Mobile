using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{

    public MainScript mainScript;
    public List<Sprite> set1 = new List<Sprite>();
    public List<Sprite> flat1 = new List<Sprite>();
    public List<Sprite> set2 = new List<Sprite>();
    public List<Sprite> flat2 = new List<Sprite>();
    public List<Sprite> set3 = new List<Sprite>();
    public List<Sprite> flat3 = new List<Sprite>();
    public SubCategory mySub;
    public bool set2bool;
    public bool set3bool;
    public int flatNumber;
    public bool removeTop;
    public bool removeBot;
    #region Basic Render
    public void RenderItem()
    {
        
        if (mySub.selectedItem == null)
        {
            Stat.SetAct(this.gameObject, true);
            mySub.selectedItem = this;
            wholeRender(true);
            CheckAndUpdateBase(true);
        }
        else if (mySub.selectedItem != null && mySub.selectedItem != this)
        {
            Stat.SetAct(mySub.selectedItem.gameObject, false);
            mySub.selectedItem.wholeRender(false);
            mySub.selectedItem = this;
            wholeRender(true);
            Stat.SetAct(this.gameObject, true);
            CheckAndUpdateBase(true);
        }
        else if (mySub.selectedItem != null && mySub.selectedItem == this)
        {
            Stat.SetAct(this.gameObject, false);
            wholeRender(false);
            mySub.selectedItem = null;
            CheckAndUpdateBase(false);
        }
        //if (mainScript.inits==false)
        //{
        //    mainScript.renderColor.InitSliders(mainScript.selectedSub.myColor);
        //}
        mainScript.audioManager.playSFX(1);
    }

    public void wholeRender(bool render)
    {
        if (render==true)
        {
            RenderSet(set1, mySub.m1, flat1);
            if (set2bool == true)
            {
                RenderSet(set2, mySub.m2, flat2);
            }
            if (set3bool == true)
            {
                RenderSet(set3, mySub.m3, flat3);
            }
            UpdateFlatNumber();
            mainScript.CheckFlats();
        }
        else
        {
            deRender(mySub.m1);
            if (set2bool == true)
            {
                deRender(mySub.m2);
            }
            if (set3bool == true)
            {
                deRender(mySub.m3);
            }
        }
    
    }
   
    private void RenderSet(List<Sprite> setSprites, int Mlayer, List<Sprite> flat)
    {
        for (int i = 0; i < setSprites.Count; i++)
        {
            if (setSprites[i] != null)
            {
                mainScript.layers[Mlayer + i].sprite = setSprites[i];
                mainScript.layers[Mlayer + i].gameObject.SetActive(true);
            }
            else
            {
                mainScript.layers[Mlayer + i].gameObject.SetActive(false);
            }
        }
        if (flat[0] != null)
        {
            mainScript.layers[Mlayer + 4].sprite = flat[0];
            mainScript.layers[Mlayer + 4].preserveAspect = true;
            mainScript.layers[Mlayer + 4].gameObject.SetActive(true);
        }
        else
        {
            mainScript.layers[Mlayer + 4].gameObject.SetActive(false);
        }
        //Insert Set Image Color Script Here
        Color m = mySub.myColor;
        Color s;
        Color h;
        Color o;
        ColorStatic.CalculateHSO(mySub.myTexture, m, out o, out s, out h);
        mainScript.layers[Mlayer].color = m;
        mainScript.layers[Mlayer + 1].color = s;
        mainScript.layers[Mlayer + 2].color = h;
        mainScript.layers[Mlayer + 3].color = o;
        mainScript.layers[Mlayer].preserveAspect = true;
        mainScript.layers[Mlayer + 1].preserveAspect = true;
        mainScript.layers[Mlayer + 2].preserveAspect = true;
        mainScript.layers[Mlayer + 3].preserveAspect = true;

    }
    public void deRender(int Mlayer)
    {
        for (int i = 0; i < 5; i++)
        {
            mainScript.layers[Mlayer + i].gameObject.SetActive(false);
            mainScript.layers[Mlayer + 4].gameObject.SetActive(false);
        }
    }
    #endregion
    #region Flats
    public void ScrollFlats()
    {
        int CurrentFlat = flatNumber - 1;
        int m1 = mainScript.selectedSub.m1;
        int m2 = mainScript.selectedSub.m2;
        int m3 = mainScript.selectedSub.m3;
        if (CurrentFlat == 4|| (flat1[CurrentFlat+1]==null && flat2[CurrentFlat + 1] == null && flat3[CurrentFlat + 1] == null))
        {
            UpdateFlatNumber();
            checkAndActivateFlat(m1, flat1, 0);
            checkAndActivateFlat(m2, flat2, 0);
            checkAndActivateFlat(m3, flat3, 0);
        }
        else if(flat1[CurrentFlat + 1] != null || flat2[CurrentFlat + 1] != null || flat3[CurrentFlat + 1] != null)
        {
            checkAndActivateFlat(m1, flat1, CurrentFlat + 1);
            checkAndActivateFlat(m2, flat2, CurrentFlat + 1);
            checkAndActivateFlat(m3, flat3, CurrentFlat + 1);
            flatNumber = CurrentFlat + 2;
        }
        

    }
    public void checkAndActivateFlat(int Mlayer, List<Sprite> flat, int flatNum)
    {
        if (flat[flatNum] != null)
        {
            mainScript.layers[Mlayer + 4].sprite = flat[flatNum];
            mainScript.layers[Mlayer + 4].preserveAspect = true;
            mainScript.layers[Mlayer + 4].gameObject.SetActive(true);
        }
        else
        {
            mainScript.layers[Mlayer + 4].gameObject.SetActive(false);
        }
    }
    public void UpdateFlatNumber()
    {
        if (flat1[0]!=null|| flat2[0] != null|| flat3[0] != null)
        {
            flatNumber = 1;
        }
    }
    #endregion

    public void CheckAndUpdateBase(bool isRemove)
    {
        if (isRemove==true)
        {
            if (removeTop==true)
            {
                mainScript.baseTop.SetActive(false);
            }
            if (removeBot==true)
            {
                mainScript.baseBot.SetActive(false);
            }
        }
        else
        {
            if (removeTop == true)
            {
                mainScript.baseTop.SetActive(true);
            }
            if (removeBot == true)
            {
                mainScript.baseBot.SetActive(true);
            }
        }
    }
}
