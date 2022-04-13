using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SimpleToggle : MonoBehaviour
{
    public Color outLine;
    public Color fill;
    public Color white;

    public Image myOutline;
    public Image myFill;
    public TextMeshProUGUI text;
    public bool isOn;
    public void toggle()
    {
        isOn = !isOn;
        if (isOn==true)
        {
            myOutline.color = outLine;
            myFill.color = fill;
            text.color = outLine;
        }
        else
        {
            myOutline.color = fill;
            myFill.color = white;
            text.color = fill;
        }
    }
}
