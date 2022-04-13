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
    public List<Image> imagesForIcons = new List<Image>();
    public List<Sprite> spritesForIcons = new List<Sprite>();
    public List<HeartsColor> heartsColors = new List<HeartsColor>();
    public List<Color> colorforHearts = new List<Color>();
    public List<BGitem> bgitems = new List<BGitem>();
    public List<Sprite> bgSprites = new List<Sprite>();
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

    [MenuItem("System/RigIcons")]
    public static void RigIcons()
    {
        RiggingScript rigging = GameObject.FindGameObjectWithTag("GameManager").GetComponent<RiggingScript>();
        for (int i = 1, j = 25; i < rigging.imagesForIcons.Count; i++, j++)
        {
            EditorUtility.SetDirty(rigging.imagesForIcons[i]);
            rigging.imagesForIcons[i].sprite = rigging.spritesForIcons[i];
            rigging.imagesForIcons[i].GetComponent<HeartsColor>().original = rigging.spritesForIcons[i];
            rigging.imagesForIcons[i].GetComponent<HeartsColor>().selected = rigging.spritesForIcons[j];
        }
    }
    [MenuItem("System/RigHearts")]
    public static void RigHearts()
    {
        RiggingScript rigging = GameObject.FindGameObjectWithTag("GameManager").GetComponent<RiggingScript>();
        rigging.colorforHearts.Add(new Color(230 / 255f, 217 / 255f, 219 / 255f));
        rigging.colorforHearts.Add(new Color(234 / 255f, 201 / 255f, 206 / 255f));
        rigging.colorforHearts.Add(new Color(228 / 255f, 174 / 255f, 183 / 255f));
        rigging.colorforHearts.Add(new Color(206 / 255f, 157 / 255f, 165 / 255f));
        rigging.colorforHearts.Add(new Color(213 / 255f, 125 / 255f, 139 / 255f));
        rigging.colorforHearts.Add(new Color(179 / 255f, 117 / 255f, 127 / 255f));
        rigging.colorforHearts.Add(new Color(180 / 255f, 119 / 255f, 118 / 255f));
        rigging.colorforHearts.Add(new Color(214 / 255f, 127 / 255f, 126 / 255f));
        rigging.colorforHearts.Add(new Color(206 / 255f, 158 / 255f, 157 / 255f));
        rigging.colorforHearts.Add(new Color(228 / 255f, 175 / 255f, 174 / 255f));
        rigging.colorforHearts.Add(new Color(234 / 255f, 202 / 255f, 201 / 255f));
        rigging.colorforHearts.Add(new Color(230 / 255f, 217 / 255f, 217 / 255f));

        rigging.colorforHearts.Add(new Color(231 / 255f, 221 / 255f, 219 / 255f));
        rigging.colorforHearts.Add(new Color(233 / 255f, 207 / 255f, 202 / 255f));
        rigging.colorforHearts.Add(new Color(230 / 255f, 184 / 255f, 173 / 255f));
        rigging.colorforHearts.Add(new Color(203 / 255f, 161 / 255f, 152 / 255f));
        rigging.colorforHearts.Add(new Color(219 / 255f, 138 / 255f, 121 / 255f));
        rigging.colorforHearts.Add(new Color(173 / 255f, 126 / 255f, 116 / 255f));
        rigging.colorforHearts.Add(new Color(165 / 255f, 131 / 255f, 108 / 255f));
        rigging.colorforHearts.Add(new Color(206 / 255f, 147 / 255f, 108 / 255f));
        rigging.colorforHearts.Add(new Color(197 / 255f, 166 / 255f, 145 / 255f));
        rigging.colorforHearts.Add(new Color(223 / 255f, 189 / 255f, 166 / 255f));
        rigging.colorforHearts.Add(new Color(229 / 255f, 210 / 255f, 197 / 255f));
        rigging.colorforHearts.Add(new Color(229 / 255f, 222 / 255f, 217 / 255f));

        rigging.colorforHearts.Add(new Color(234 / 255f, 230 / 255f, 223 / 255f));
        rigging.colorforHearts.Add(new Color(228 / 255f, 220 / 255f, 205 / 255f));
        rigging.colorforHearts.Add(new Color(217 / 255f, 203 / 255f, 176 / 255f));
        rigging.colorforHearts.Add(new Color(197 / 255f, 184 / 255f, 158 / 255f));
        rigging.colorforHearts.Add(new Color(195 / 255f, 172 / 255f, 126 / 255f));
        rigging.colorforHearts.Add(new Color(165 / 255f, 152 / 255f, 126 / 255f));
        rigging.colorforHearts.Add(new Color(160 / 255f, 156 / 255f, 121 / 255f));
        rigging.colorforHearts.Add(new Color(186 / 255f, 179 / 255f, 117 / 255f));
        rigging.colorforHearts.Add(new Color(192 / 255f, 188 / 255f, 153 / 255f));
        rigging.colorforHearts.Add(new Color(212 / 255f, 207 / 255f, 170 / 255f));
        rigging.colorforHearts.Add(new Color(225 / 255f, 222 / 255f, 202 / 255f));
        rigging.colorforHearts.Add(new Color(232 / 255f, 231 / 255f, 221 / 255f));

        rigging.colorforHearts.Add(new Color(225 / 255f, 229 / 255f, 221 / 255f));
        rigging.colorforHearts.Add(new Color(214 / 255f, 222 / 255f, 203 / 255f));
        rigging.colorforHearts.Add(new Color(192 / 255f, 208 / 255f, 170 / 255f));
        rigging.colorforHearts.Add(new Color(174 / 255f, 186 / 255f, 157 / 255f));
        rigging.colorforHearts.Add(new Color(155 / 255f, 180 / 255f, 121 / 255f));
        rigging.colorforHearts.Add(new Color(141 / 255f, 151 / 255f, 127 / 255f));
        rigging.colorforHearts.Add(new Color(134 / 255f, 154 / 255f, 130 / 255f));
        rigging.colorforHearts.Add(new Color(138 / 255f, 187 / 255f, 128 / 255f));
        rigging.colorforHearts.Add(new Color(166 / 255f, 190 / 255f, 161 / 255f));
        rigging.colorforHearts.Add(new Color(181 / 255f, 213 / 255f, 175 / 255f));
        rigging.colorforHearts.Add(new Color(209 / 255f, 224 / 255f, 205 / 255f));
        rigging.colorforHearts.Add(new Color(223 / 255f, 230 / 255f, 222 / 255f));

        rigging.colorforHearts.Add(new Color(219 / 255f, 227 / 255f, 224 / 255f));
        rigging.colorforHearts.Add(new Color(199 / 255f, 223 / 255f, 215 / 255f));
        rigging.colorforHearts.Add(new Color(169 / 255f, 213 / 255f, 199 / 255f));
        rigging.colorforHearts.Add(new Color(146 / 255f, 187 / 255f, 174 / 255f));
        rigging.colorforHearts.Add(new Color(108 / 255f, 184 / 255f, 159 / 255f));
        rigging.colorforHearts.Add(new Color(115 / 255f, 156 / 255f, 143 / 255f));
        rigging.colorforHearts.Add(new Color(120 / 255f, 150 / 255f, 161 / 255f));
        rigging.colorforHearts.Add(new Color(118 / 255f, 173 / 255f, 194 / 255f));
        rigging.colorforHearts.Add(new Color(152 / 255f, 181 / 255f, 192 / 255f));
        rigging.colorforHearts.Add(new Color(175 / 255f, 206 / 255f, 219 / 255f));
        rigging.colorforHearts.Add(new Color(202 / 255f, 219 / 255f, 226 / 255f));
        rigging.colorforHearts.Add(new Color(220 / 255f, 226 / 255f, 228 / 255f));

        rigging.colorforHearts.Add(new Color(218 / 255f, 220 / 255f, 224 / 255f));
        rigging.colorforHearts.Add(new Color(204 / 255f, 212 / 255f, 223 / 255f));
        rigging.colorforHearts.Add(new Color(185 / 255f, 197 / 255f, 215 / 255f));
        rigging.colorforHearts.Add(new Color(160 / 255f, 171 / 255f, 188 / 255f));
        rigging.colorforHearts.Add(new Color(134 / 255f, 154 / 255f, 183 / 255f));
        rigging.colorforHearts.Add(new Color(132 / 255f, 141 / 255f, 155 / 255f));
        rigging.colorforHearts.Add(new Color(137 / 255f, 137 / 255f, 160 / 255f));
        rigging.colorforHearts.Add(new Color(146 / 255f, 147 / 255f, 195 / 255f));
        rigging.colorforHearts.Add(new Color(166 / 255f, 166 / 255f, 194 / 255f));
        rigging.colorforHearts.Add(new Color(192 / 255f, 192 / 255f, 222 / 255f));
        rigging.colorforHearts.Add(new Color(209 / 255f, 209 / 255f, 228 / 255f));
        rigging.colorforHearts.Add(new Color(219 / 255f, 219 / 255f, 226 / 255f));

        rigging.colorforHearts.Add(new Color(224 / 255f, 221 / 255f, 230 / 255f));
        rigging.colorforHearts.Add(new Color(216 / 255f, 209 / 255f, 228 / 255f));
        rigging.colorforHearts.Add(new Color(200 / 255f, 189 / 255f, 222 / 255f));
        rigging.colorforHearts.Add(new Color(176 / 255f, 166 / 255f, 195 / 255f));
        rigging.colorforHearts.Add(new Color(163 / 255f, 143 / 255f, 202 / 255f));
        rigging.colorforHearts.Add(new Color(143 / 255f, 135 / 255f, 159 / 255f));
        rigging.colorforHearts.Add(new Color(150 / 255f, 132 / 255f, 156 / 255f));
        rigging.colorforHearts.Add(new Color(180 / 255f, 136 / 255f, 195 / 255f));
        rigging.colorforHearts.Add(new Color(185 / 255f, 163 / 255f, 192 / 255f));
        rigging.colorforHearts.Add(new Color(209 / 255f, 185 / 255f, 218 / 255f));
        rigging.colorforHearts.Add(new Color(221 / 255f, 207 / 255f, 226 / 255f));
        rigging.colorforHearts.Add(new Color(226 / 255f, 220 / 255f, 228 / 255f));

        rigging.colorforHearts.Add(new Color(233 / 255f, 226 / 255f, 232 / 255f));
        rigging.colorforHearts.Add(new Color(230 / 255f, 212 / 255f, 228 / 255f));
        rigging.colorforHearts.Add(new Color(221 / 255f, 187 / 255f, 217 / 255f));
        rigging.colorforHearts.Add(new Color(198 / 255f, 170 / 255f, 195 / 255f));
        rigging.colorforHearts.Add(new Color(198 / 255f, 144 / 255f, 191 / 255f));
        rigging.colorforHearts.Add(new Color(167 / 255f, 143 / 255f, 164 / 255f));
        rigging.colorforHearts.Add(new Color(168 / 255f, 144 / 255f, 155 / 255f));
        rigging.colorforHearts.Add(new Color(201 / 255f, 146 / 255f, 171 / 255f));
        rigging.colorforHearts.Add(new Color(199 / 255f, 171 / 255f, 184 / 255f));
        rigging.colorforHearts.Add(new Color(223 / 255f, 189 / 255f, 204 / 255f));
        rigging.colorforHearts.Add(new Color(231 / 255f, 212 / 255f, 221 / 255f));
        rigging.colorforHearts.Add(new Color(233 / 255f, 226 / 255f, 229 / 255f));

        rigging.colorforHearts.Add(new Color(228 / 255f, 228 / 255f, 228 / 255f));
        rigging.colorforHearts.Add(new Color(219 / 255f, 218 / 255f, 218 / 255f));
        rigging.colorforHearts.Add(new Color(202 / 255f, 200 / 255f, 200 / 255f));
        rigging.colorforHearts.Add(new Color(180 / 255f, 178 / 255f, 178 / 255f));
        rigging.colorforHearts.Add(new Color(169 / 255f, 165 / 255f, 165 / 255f));
        rigging.colorforHearts.Add(new Color(151 / 255f, 149 / 255f, 149 / 255f));
        rigging.colorforHearts.Add(new Color(144 / 255f, 142 / 255f, 142 / 255f));
        rigging.colorforHearts.Add(new Color(132 / 255f, 130 / 255f, 130 / 255f));
        rigging.colorforHearts.Add(new Color(123 / 255f, 121 / 255f, 121 / 255f));
        rigging.colorforHearts.Add(new Color(112 / 255f, 110 / 255f, 110 / 255f));
        rigging.colorforHearts.Add(new Color(96 / 255f, 94 / 255f, 94 / 255f));
        rigging.colorforHearts.Add(new Color(85 / 255f, 84 / 255f, 84 / 255f));
        for (int i = 1; i < rigging.heartsColors.Count; i++)
        {
            EditorUtility.SetDirty(rigging.heartsColors[i]);

            rigging.heartsColors[i].myColor = rigging.colorforHearts[i];
        }
    }

    [MenuItem("System/RigBG")]
    public static void RigBG()
    {
        RiggingScript rigging = GameObject.FindGameObjectWithTag("GameManager").GetComponent<RiggingScript>();
        for (int i = 1; i < rigging.bgitems.Count; i++)
        {
            rigging.bgitems[i].GetComponent<Image>().sprite = rigging.spritesForIcons[i];
            rigging.bgitems[i].myBG = rigging.bgSprites[i];
            rigging.bgitems[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = (rigging.bgitems[i].transform.GetSiblingIndex() + 1).ToString();
            rigging.bgitems[i].transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}

#endif
