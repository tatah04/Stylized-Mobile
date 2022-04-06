using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

public class RiggingScript : MonoBehaviour
{
    public List<CharItem> charItemsToRig = new List<CharItem>();
    public List<ItemScript> itemsToRig = new List<ItemScript>();
    public string storeNumber;
    public string categ;
    public string subCateg;

}
#if UNITY_EDITOR
public class RiggingClass
{
    [MenuItem("System/RigChar")]
    public static void RigChars()
    {
        RiggingScript rigging = GameObject.FindGameObjectWithTag("GameManager").GetComponent<RiggingScript>();
        for (int i = 1; i < rigging.charItemsToRig.Count; i++)
        {
            EditorUtility.SetDirty(rigging.charItemsToRig[i]);
            rigging.charItemsToRig[i].flats1.Clear();
            rigging.charItemsToRig[i].flats2.Clear();
            rigging.charItemsToRig[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + "icons/" + rigging.categ + "/" + rigging.subCateg + "/" + i);
            rigging.charItemsToRig[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (rigging.charItemsToRig[i].transform.GetSiblingIndex() + 1).ToString();
            rigging.charItemsToRig[i].transform.GetChild(0).gameObject.SetActive(false);
            switch (rigging.charItemsToRig[i].chartype)
            {

                case Chartype.Eye:
                    rigging.charItemsToRig[i].s1 = Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/W");
                    rigging.charItemsToRig[i].s2 = Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/CM");
                    rigging.charItemsToRig[i].s3 = Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/CO");
                    rigging.charItemsToRig[i].s4 = Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/CW");
                    rigging.charItemsToRig[i].s5 = Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/O");
                    rigging.charItemsToRig[i].s6 = Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/L");
                    for (int j = 1; j < 6; j++)
                    {
                        rigging.charItemsToRig[i].flats1.Add(Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/" + j));
                        rigging.charItemsToRig[i].flats2.Add(Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/F" + j));
                        // rigging.charItemsToRig[i].flats3.Add(Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/" + j));

                    }
                    break;
                case Chartype.Eyebrow:
                    rigging.charItemsToRig[i].s1 = Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/S");
                    rigging.charItemsToRig[i].s2 = Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/M");
                    break;
                case Chartype.Nose:
                    rigging.charItemsToRig[i].s1 = Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/S");
                    rigging.charItemsToRig[i].s2 = Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/H");
                    rigging.charItemsToRig[i].s3 = Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/O");
                    break;
                case Chartype.Lips:
                    rigging.charItemsToRig[i].s1 = Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/FO");
                    rigging.charItemsToRig[i].s2 = Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/M");
                    rigging.charItemsToRig[i].s3 = Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/S");
                    rigging.charItemsToRig[i].s4 = Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/H");
                    rigging.charItemsToRig[i].s5 = Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/O");
                    //rigging.charItemsToRig[i].s6 = Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/S");
                    for (int j = 1; j < 6; j++)
                    {
                        rigging.charItemsToRig[i].flats1.Add(Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/" + j));
                        rigging.charItemsToRig[i].flats2.Add(Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/F" + j));
                        // rigging.charItemsToRig[i].flats3.Add(Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/" + j));

                    }
                    break;
                case Chartype.Base:
                    rigging.charItemsToRig[i].s1 = Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/M");
                    rigging.charItemsToRig[i].s2 = Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/S");
                    rigging.charItemsToRig[i].s3 = Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/R");
                    rigging.charItemsToRig[i].s4 = Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/H");
                    rigging.charItemsToRig[i].s5 = Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/O");

                    rigging.charItemsToRig[i].s8 = Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/FM");
                    rigging.charItemsToRig[i].s9 = Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/FS");
                    rigging.charItemsToRig[i].s10 = Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/FH");
                    rigging.charItemsToRig[i].s11 = Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/FO");

                    rigging.charItemsToRig[i].s7 = Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/T");
                    rigging.charItemsToRig[i].s13 = Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/FT");
                    for (int j = 1; j < 6; j++)
                    {
                        rigging.charItemsToRig[i].flats1.Add(Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/" + j));
                        rigging.charItemsToRig[i].flats2.Add(Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/F" + j));
                        // rigging.charItemsToRig[i].flats3.Add(Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/" + j));

                    }
                    break;
                case Chartype.Blush:
                    rigging.charItemsToRig[i].s1 = Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/M");

                    break;
                case Chartype.EyeShadow:
                    rigging.charItemsToRig[i].s1 = Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/M");

                    break;
                default:
                    break;
            }
        }
    }
    [MenuItem("System/RigItems")]
    public static void RigItems()
    {
        RiggingScript rigging = GameObject.FindGameObjectWithTag("GameManager").GetComponent<RiggingScript>();
        for (int i = 1; i < rigging.itemsToRig.Count; i++)
        {
            EditorUtility.SetDirty(rigging.itemsToRig[i]);
            rigging.itemsToRig[i].set1.Clear();
            rigging.itemsToRig[i].set2.Clear();
            rigging.itemsToRig[i].set3.Clear();
            rigging.itemsToRig[i].flat1.Clear();
            rigging.itemsToRig[i].flat2.Clear();
            rigging.itemsToRig[i].flat3.Clear();
         
            rigging.itemsToRig[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + "icons/" + rigging.categ + "/" + rigging.subCateg + "/" + i);
            rigging.itemsToRig[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (rigging.itemsToRig[i].transform.GetSiblingIndex() + 1).ToString();
            rigging.itemsToRig[i].transform.GetChild(0).gameObject.SetActive(false);
           // Debug.Log("wtf");
            for (int j = 1; j < 6; j++)
            {
                rigging.itemsToRig[i].flat1.Add(Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/" + j));
                rigging.itemsToRig[i].flat2.Add(Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/S" + j));
                rigging.itemsToRig[i].flat3.Add(Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/B" + j));
            }
          //  Debug.Log("wtf");
            rigging.itemsToRig[i].set1.Add(Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/M"));
            rigging.itemsToRig[i].set1.Add(Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/S"));
            rigging.itemsToRig[i].set1.Add(Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/H"));
            rigging.itemsToRig[i].set1.Add(Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/O"));
            rigging.itemsToRig[i].set1.Add(Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/T"));
           // Debug.Log("wtf2");
            rigging.itemsToRig[i].set2.Add(Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/SM"));
            rigging.itemsToRig[i].set2.Add(Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/SS"));
            rigging.itemsToRig[i].set2.Add(Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/SH"));
            rigging.itemsToRig[i].set2.Add(Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/SO"));
            rigging.itemsToRig[i].set2.Add(Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/ST"));
         //   Debug.Log("wtf3");
            rigging.itemsToRig[i].set3.Add(Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/BM"));
            rigging.itemsToRig[i].set3.Add(Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/BS"));
            rigging.itemsToRig[i].set3.Add(Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/BH"));
            rigging.itemsToRig[i].set3.Add(Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/BO"));
            rigging.itemsToRig[i].set3.Add(Resources.Load<Sprite>("Store" + rigging.storeNumber + "/" + rigging.categ + "/" + rigging.subCateg + "/" + i + "/BT"));
        }
    }

}
#endif
