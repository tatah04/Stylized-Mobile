using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderNum : MonoBehaviour
{
    public TextMeshProUGUI textM;
    public Slider mySlider;
    public float multiplier;
    void Update()
    {
        textM.text = Mathf.RoundToInt(mySlider.value * multiplier).ToString();

    }
}
