using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreScript : MonoBehaviour
{
    // Start is called before the first frame update
    public MainScript mainScript;
    public int storeNumber;
    public void SelectStore()
    {
        if (mainScript.selectedStore!=null)
        {
            mainScript.selectedStore.DeselectStore();
        }
        mainScript.selectedStore = this;
        mainScript.SelectedStoreInt = storeNumber;
        mainScript.categContent.SetActive(true);
        Stat.ColorSelect(this.gameObject, true);
    }
    public void DeselectStore()
    {
        Stat.ColorSelect(this.gameObject, false);
        if (mainScript.selectedCategory!=null)
        {
            mainScript.selectedCategory.DeselectCategory();
        }

    }
}
