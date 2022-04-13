using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{
    public MainScript mainScript;
    public List<RectTransform> charRects = new List<RectTransform>();
    public List<SubCategory> subs = new List<SubCategory>();
    public int CharInt;
    public int Start;
    public int End;
    public void moveChar(bool isUp)
    {
        int x = subs.IndexOf(mainScript.selectedSub);

        switch (x)
        {
            case 1:
                Start = 1;
                End = 7;
                break;
            case 2:
                Start = 8;
                End = 9;
                break;
            case 3:
                Start = 10;
                End = 12;
                break;
            case 4:
                Start = 13;
                End = 18;
                break;
            default:
                break;
        }
        for (int i = Start; i < End + 1; i++)
        {
            float charInt = charRects[i].anchoredPosition.y;
            if (isUp == true)
            {
                if (charInt < 5f)
                {
                    charInt += 1;
                }
            }
            else
            {
                if (charInt > -5f)
                {
                    charInt -= 1;
                }
            }
            charRects[i].anchoredPosition = new Vector2(charRects[i].anchoredPosition.x, charInt);
        }

    }
}
