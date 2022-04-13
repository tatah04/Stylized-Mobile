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
        if (mainScript.selectedStore!=null )
        {
            mainScript.selectedStore.DeselectStore();
            if (mainScript.selectedCategory != null &&( mainScript.allStores.IndexOf(mainScript.selectedStore) == 1 || mainScript.allStores.IndexOf(mainScript.selectedStore) == 7))
            {
               // Debug.Log("notnull Categ");
                mainScript.selectedCategory.DeselectCategory();
                mainScript.UpdateSwitchable(false);
            }
            mainScript.selectedStore = this;
            mainScript.SelectedStoreInt = storeNumber;
            if ( mainScript.selectedSub != null
            &&( mainScript.allStores.IndexOf(mainScript.selectedStore) != 1 && mainScript.allStores.IndexOf(mainScript.selectedStore) != 7))
            {
               // mainScript.selectedCategory.DeselectCategory();
                mainScript.selectedSub.ChangeStore();
            }
            else if (mainScript.selectedSub != null
            && (mainScript.allStores.IndexOf(mainScript.selectedStore) == 1 || mainScript.allStores.IndexOf(mainScript.selectedStore) == 7))
            {
                mainScript.selectedCategory.DeselectCategory();
                mainScript.UpdateSwitchable(false);
            }
        }
        else
        {
            mainScript.selectedStore = this;
            mainScript.SelectedStoreInt = storeNumber;
        }



        mainScript.categContent.SetActive(true);
        storeSelectSpecial();
        Stat.ColorSelect(this.gameObject, true);

        mainScript.audioManager.playSFX(1);

    }
    public void DeselectStore()
    {
        Stat.ColorSelect(this.gameObject, false);
        //if (mainScript.selectedCategory != null)
        //{
        //    mainScript.selectedCategory.DeselectCategory();
        //}

    }

    public void storeSelectSpecial()
    {
        if (mainScript.allStores.IndexOf(mainScript.selectedStore)==1)
        {
            mainScript.allCategs[1].gameObject.SetActive(true);
            mainScript.allCategs[2].gameObject.SetActive(false);
            mainScript.allCategs[3].gameObject.SetActive(false);
            mainScript.allCategs[4].gameObject.SetActive(false);
            mainScript.allCategs[5].gameObject.SetActive(false);
        }
        else if(mainScript.allStores.IndexOf(mainScript.selectedStore) == 7)
        {
            mainScript.allCategs[1].gameObject.SetActive(false);
            mainScript.allCategs[2].gameObject.SetActive(false);
            mainScript.allCategs[3].gameObject.SetActive(false);
            mainScript.allCategs[4].gameObject.SetActive(false);
            mainScript.allCategs[5].gameObject.SetActive(true);
        }
        else
        {
            mainScript.allCategs[1].gameObject.SetActive(false);
            mainScript.allCategs[2].gameObject.SetActive(true);
            mainScript.allCategs[3].gameObject.SetActive(true);
            mainScript.allCategs[4].gameObject.SetActive(true);
            mainScript.allCategs[5].gameObject.SetActive(false);
        }
    }
}
