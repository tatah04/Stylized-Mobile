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
    [Header("Switches")]
    public GameObject paletteObj;
    public GameObject selectionObj;

    private void Start()
    {
        for (int i = 0; i < charInit.Count; i++)
        {
            charInit[i].RenderChar();
        }
        for (int i = 0; i < itemInit.Count; i++)
        {
            itemInit[i].RenderItem();
        }
    }
    public void switchUI()
    {
        paletteObj.SetActive(!paletteObj.activeInHierarchy);
        selectionObj.SetActive(!paletteObj.activeInHierarchy);
    }

}
