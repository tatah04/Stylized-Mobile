using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomPalette : MonoBehaviour
{
    public MainScript mainScript;
    public List<Button> palette = new List<Button>();
    public void Randomize()
    {
        int R = Random.Range(1, 108);
        palette[R].onClick.Invoke();
    }
}
