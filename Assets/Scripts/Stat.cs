using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stat : MonoBehaviour
{
    public static Color outline;
    public static Color fill;
    public static Color white;
    //public static Color pink;
    public Color outline2;
    public Color fill2;
    public Color white2;

    //public Color pink2;
    private void Start()
    {
        Stat.outline = outline2;
        Stat.fill = fill2;
        Stat.white = white2;
       // Stat.pink = pink2;
    }
    public static void ColorSelect(GameObject input, bool isSelected)
    {
        if (isSelected==true)
        {
            input.gameObject.GetComponent<Image>().color = Stat.fill;
            input.transform.GetChild(0).GetComponent<Image>().color = Stat.white;
            input.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().color = Stat.fill;
        }
        else
        {
            input.gameObject.GetComponent<Image>().color = Stat.outline;
            input.transform.GetChild(0).GetComponent<Image>().color = Stat.fill;
            input.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().color = Stat.outline;
        }
    }
    public static void SetAct(GameObject input, bool active)
    {
        if (active==true)
        {
            Color color2 = new Color(white.r, white.g, white.b, 0f);
            input.GetComponent<Image>().color = color2;
            input.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            Color color2 = new Color(white.r, white.g, white.b, 1f);
            input.GetComponent<Image>().color = color2;
            input.transform.GetChild(0).gameObject.SetActive(false);
        }

    }
    public static void SetContent(ScrollRect scrollRect,RectTransform newContent)
    {
        if (scrollRect.content.gameObject.activeInHierarchy==true)
        {
            scrollRect.content.gameObject.SetActive(false);
        }
        scrollRect.content = newContent;
        newContent.gameObject.SetActive(true);
    }
    
        
}
