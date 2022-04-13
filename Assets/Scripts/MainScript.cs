using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    public List<Image> layers = new List<Image>();
    public StoreScript selectedStore;
    public Categories selectedCategory;
    public SubCategory selectedSub;
    public RenderColor renderColor;

    [Header("SelectionInits")]
    public GameObject categContent;
    public int SelectedStoreInt;
    public ScrollRect subScrollView;
    public ScrollRect itemScrollView;

    [Header("CharInits")]
    public SubCategory baseSub;
    public SubCategory hairSub;
    public List<CharItem> charInit = new List<CharItem>();
    public List<ItemScript> itemInit = new List<ItemScript>();
    public bool inits;

    [Header("Switches")]
    public GameObject paletteObj;
    public GameObject selectionObj;
    public GameObject actualPalette;
    public GameObject switchButton;

    [Header("Textures")]
    public List<HeartsColor> Textures = new List<HeartsColor>();

    [Header("Detail Button")]
    public GameObject detailParent;
    public List<Image> detailFills;
    public List<Image> detailOutlines;

    [Header("Remove Base")]
    public GameObject baseTop;
    public GameObject baseBot;

    [Header("Hue Lock")]
    public HueLock hueLock;

    [Header("ColorPick")]
    public GameObject ActiveItemCanvas;
    public List<ActiveItem> activeItemsScript = new List<ActiveItem>();

    [Header("Store Special Select")]
    public List<StoreScript> allStores = new List<StoreScript>();
    public List<Categories> allCategs = new List<Categories>();

    [Header("UI CHECKLIST")]
    public List<GameObject> allChecklist = new List<GameObject>();

    [Header("Sound")]
    public AudioManager audioManager;
    #region INIT


    private void Start()
    {
        for (int i = 0; i < charInit.Count; i++)
        {
            charInit[i].RenderChar();
        }

        for (int i = 0; i < itemInit.Count; i++)
        {
            inits = true;
            itemInit[i].RenderItem();
            inits = false;
        }
        TempInit();
    }



    private void TempInit()
    {
        paletteObj.SetActive(false);
        switchButton.SetActive(false);
        actualPalette.SetActive(false);
        selectionObj.SetActive(true);
        renderColor.bg1.isInit = true;
        renderColor.bg1.changeBG();
        renderColor.bg1.isInit = false;

    }
    #endregion
    #region SwitchUI
    public void switchUI()
    {
        paletteObj.SetActive(!paletteObj.activeInHierarchy);
        selectionObj.SetActive(!paletteObj.activeInHierarchy);
        //renderColor.bg1.updatebg1();
        if (paletteObj.activeInHierarchy == true && selectedSub != null)
        {
            renderColor.InitSliders(selectedSub.myColor);
            Textures[1].updateTextureSprite(false);
            hueLock.UpdateLock();
        }
        else
        {
            Textures[1].updateTextureSprite(true);
        }
    }
    public void UpdateSwitchable(bool isSwitchable)
    {
        if (isSwitchable)
        {
            actualPalette.SetActive(true);
            switchButton.SetActive(true);
        }
        else
        {
            actualPalette.SetActive(false);
            switchButton.SetActive(false);
        }
    }


    #endregion
    #region DetailButton

    public void CheckFlats()
    {
        if (selectedSub==null || selectedSub.selectedItem==null || selectedSub.selectedChar)
        {
            detailParent.SetActive(false);

        }
        else  if (selectedSub != null && selectedSub.selectedItem != null && selectedSub.isChar == false)
        {
            if (selectedSub.selectedItem.flat1[0] != null || selectedSub.selectedItem.flat2[0] != null || selectedSub.selectedItem.flat3[0] != null)
            {
                detailParent.SetActive(true);
                UpdateDetailButton(selectedSub.selectedItem.flatNumber);

            }
            else if (selectedSub.selectedItem.flat1[0] == null && selectedSub.selectedItem.flat2[0] == null && selectedSub.selectedItem.flat3[0] == null)
            {
                detailParent.SetActive(false);
            }
        }
        else if (selectedSub != null && selectedSub.selectedChar != null && selectedSub.isChar == true)
        {
            Debug.Log("hasflats");

            if (selectedSub.selectedChar.flats1[0] != null || selectedSub.selectedChar.flats2[0] != null)
            {
                detailParent.SetActive(true);
                Debug.Log("hasflats");
                UpdateDetailButton(selectedSub.selectedItem.flatNumber);

            }
            else if (selectedSub.selectedChar.flats1[0] == null && selectedSub.selectedChar.flats2[0] == null)
            {
                detailParent.SetActive(false);
            }
        }
        
    }
    public void CycleFlats()
    {
        if (detailParent.activeInHierarchy==true)
        {
            if (selectedSub != null && selectedSub.selectedItem != null && selectedSub.isChar == false)
            {
                selectedSub.selectedItem.ScrollFlats();
                UpdateDetailButton(selectedSub.selectedItem.flatNumber);
            }
            else if (selectedSub != null && selectedSub.selectedChar != null && selectedSub.isChar == true)
            {
                selectedSub.selectedChar.ScrollFlats();
                UpdateDetailButton(selectedSub.selectedChar.flatNumber);
            }


        }
    }
    public void UpdateDetailButton(int FlatSelected)
    {
        for (int i = 1; i < detailFills.Count; i++)
        {
            detailFills[i].gameObject.SetActive(false);
            detailOutlines[i].gameObject.SetActive(false);
        }
        int x=0;
        for (int i = 0; i < 5; i++)
        {
            if (selectedSub.isChar==true && selectedSub.selectedChar!=null)
            {
                if (selectedSub.selectedChar.flats1[i]!=null|| selectedSub.selectedChar.flats2[i] != null)
                {
                    x++;
                }
            }
            else if(selectedSub.isChar==false && selectedSub.selectedItem!=null)
            {
                if (selectedSub.selectedItem.flat1[i] != null || selectedSub.selectedItem.flat2[i] != null|| selectedSub.selectedItem.flat3[i] != null)
                {
                    x++;
                }
            }
        }
        for (int i = 1; i < x+1; i++)
        {
            detailOutlines[i].gameObject.SetActive(true);
        }
        detailFills[FlatSelected].gameObject.SetActive(true);
    }


    #endregion
    #region ColorPick
    public void activeItem(bool open)
    {
            ActiveItemCanvas.SetActive(open);
        if (open==true)
        {
            for (int i = 1; i < activeItemsScript.Count; i++)
            {
                activeItemsScript[i].CheckMyDependency();
            }
        }
        //audioManager.playSFX(3);
    }

    #endregion

    #region CheckList
    public void TriggerChecklist(List<bool> boolList)
    {
        for (int i = 1; i < allChecklist.Count; i++)
        {
            allChecklist[i].SetActive(boolList[i]);
        }
    }



    #endregion
}
