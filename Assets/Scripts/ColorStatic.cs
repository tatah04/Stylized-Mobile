using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorStatic : MonoBehaviour
{
    // Start is called before the first frame update
   
    #region ColorOperation
    public static Color ColorMultiply(Color main, Color Oper, float percentage)
    {
        Color result1 = main * Oper;
        Color finalResult = (main * (1 - percentage)) + (result1 * percentage);
        return finalResult;
    }
    public static Color ColorDodge(Color main, Color Oper, float percentage)
    {
        float newR;
        float newG;
        float newB;
        if (Oper.r == 1)
        {
            newR = 1;
        }
        else
        {
            newR = Mathf.Clamp(main.r / (1 - Oper.r), 0, 1);
        }
        if (Oper.g == 1)
        {
            newG = 1;
        }
        else
        {
            newG = Mathf.Clamp(main.g / (1 - Oper.g), 0, 1);
        }
        if (Oper.b == 1)
        {
            newB = 1;
        }
        else
        {
            newB = Mathf.Clamp(main.b / (1 - Oper.b), 0, 1);
        }
        Color dodge1 = new Color(newR, newG, newB);
        Color finalResult = (main * (1 - percentage)) + (dodge1 * percentage);
        return finalResult;
    }
    public static Color ColorLinearBurn(Color main, Color Oper, float percentage)
    {
        float newR;
        float newG;
        float newB;
        newR = Mathf.Clamp((main.r + Oper.r - 1), 0, 1);
        newG = Mathf.Clamp((main.g + Oper.g - 1), 0, 1);
        newB = Mathf.Clamp((main.b + Oper.b - 1), 0, 1);
        Color burn1 = new Color(newR, newG, newB);
        Color FinalResult = (main * (1 - percentage)) + (burn1 * percentage);
        return FinalResult;

    }

    public static Color ColorNormal(Color main, Color Oper, float percentage)
    {
        Color finalResult = (main * (1 - percentage) + (Oper * percentage));
        return finalResult;
    }
    public static Color ColorAdd(Color main, Color Oper, float percentage)
    {
        float newR = Mathf.Clamp(main.r + Oper.r, 0, 1);
        float newG = Mathf.Clamp(main.g + Oper.g, 0, 1);
        float newB = Mathf.Clamp(main.b + Oper.b, 0, 1);
        Color result1 = new Color(newR, newG, newB);
        Color finalResult = (main * (1 - percentage)) + (result1 * percentage);
        return finalResult;
    }

    public static Color ColorLinearLight(Color main, Color Oper, float percentage)
    {
        float newR;
        float newG;
        float newB;
        if (Oper.r > 0.5f)
        {
            newR = Mathf.Clamp(main.r + (2 * (Oper.r - 0.5f)), 0, 1);
        }
        else
        {
            newR = Mathf.Clamp((main.r - 1 + (2 * Oper.r)), 0, 1);
        }
        if (Oper.g > 0.5f)
        {
            newG = Mathf.Clamp(main.g + (2 * (Oper.g - 0.5f)), 0, 1);
        }
        else
        {
            newG = Mathf.Clamp((main.g - 1 + (2 * Oper.g)), 0, 1);
        }
        if (Oper.b > 0.5f)
        {
            newB = Mathf.Clamp(main.b + (2 * (Oper.b - 0.5f)), 0, 1);
        }
        else
        {
            newB = Mathf.Clamp((main.b - 1 + (2 * Oper.b)), 0, 1);
        }
        Color result1 = new Color(newR, newG, newB);
        Color finalResult = (main * (1 - percentage)) + (result1 * percentage);
        return finalResult;
    }

    public static void CalculateHSO(int Texture, Color mainColor, out Color outline, out Color shadow, out Color highlight)
    {
        switch (Texture)
        {
            case 1:
                Color outline1 = new Color(121f / 255, 87f / 255, 87f / 255);
                outline = ColorMultiply(mainColor, outline1, .44f);

                Color highlight1 = new Color(236f / 255, 222f / 255, 192f / 255);
                highlight = ColorDodge(mainColor, highlight1, .40f);

                Color shadow1 = new Color(121f / 255, 87f / 255, 87f / 255);
                shadow = ColorMultiply(mainColor, shadow1, .17f);
                break;
            case 2:
                Color outline2 = new Color(79f / 255, 60f / 255, 53f / 255);
                Color outline22 = ColorMultiply(mainColor, outline2, .05f);
                Color outline23 = ColorLinearBurn(outline22, new Color(103f / 255, 82f / 255, 74f / 255), .20f);
                Color outline24 = ColorMultiply(outline23, new Color(203f / 255, 133f / 255, 118f / 255), .20f);
                outline = ColorMultiply(mainColor, outline24, 1f);

                Color highlight2 = new Color(255f / 255, 255f / 255, 255f / 255);
                Color highlight22 = ColorNormal(mainColor, highlight2, .30f);
                highlight = ColorLinearLight(mainColor, highlight22, .30f);

                Color shadow2 = new Color(203f / 255, 133f / 255, 118f / 255);
                shadow = ColorMultiply(mainColor, shadow2, .2f);
                break;
            case 3:
                Color outline3 = new Color(145f / 255, 77f / 255, 77f / 255);
                outline = ColorMultiply(mainColor, outline3, .53f);

                Color highlight3 = new Color(255f / 255, 221f / 255, 148f / 255);
                highlight = ColorDodge(mainColor, highlight3, .18f);

                Color shadow3 = new Color(145f / 255, 77f / 255, 77f / 255);
                shadow = ColorMultiply(mainColor, shadow3, .10f);
                break;
            case 4:
                Color outline4 = new Color(0f / 255, 0f / 255, 0f / 255);
                outline = ColorNormal(mainColor, outline4, .38f);

                Color highlight4 = new Color(255f / 255, 255f / 255, 255f / 255);
                highlight = ColorNormal(mainColor, highlight4, .49f);

                Color shadow4 = new Color(0f / 255, 0f / 255, 0f / 255);
                shadow = ColorNormal(mainColor, shadow4, .09f);
                break;
            case 5:
                Color outline5 = new Color(255f / 255, 255f / 255, 255f / 255);
                outline = ColorNormal(mainColor, outline5, .55f);

                Color highlight5 = new Color(255f / 255, 255f / 255, 255f / 255);
                highlight = ColorNormal(mainColor, highlight5, .21f);

                shadow = ColorMultiply(mainColor, mainColor, .41f);
                break;
            case 6:
                outline = ColorAdd(mainColor, mainColor, .80f);

                highlight = ColorDodge(mainColor, mainColor, .40f);

                shadow = ColorMultiply(mainColor, mainColor, .60f);
                break;
            case 7:
                Color outline7 = new Color(230f / 255, 19f / 255, 138f / 255);
                outline = ColorMultiply(mainColor, outline7, .30f);

                highlight = ColorDodge(mainColor, mainColor, .40f);

                Color shadow7 = new Color(230f / 255, 19f / 255, 138f / 255);
                shadow = ColorLinearLight(mainColor, shadow7, .17f);
                break;
            case 8:
                Color outline8 = new Color(170f / 255, 38f / 255, 206f / 255);
                outline = ColorMultiply(mainColor, outline8, .30f);

                highlight = ColorDodge(mainColor, mainColor, .40f);

                shadow = ColorLinearLight(mainColor, outline8, .17f);
                break;
            case 9:
                Color outline9 = new Color(41f / 255, 84f / 255, 255f / 255);
                outline = ColorMultiply(mainColor, outline9, .30f);

                highlight = ColorDodge(mainColor, mainColor, .40f);

                shadow = ColorLinearLight(mainColor, outline9, .17f);
                break;
            case 10:
                Color outline10 = new Color(38f / 255, 206f / 255, 175f / 255);
                outline = ColorMultiply(mainColor, outline10, .40f);

                highlight = ColorDodge(mainColor, mainColor, .40f);

                shadow = ColorLinearLight(mainColor, outline10, .13f);
                break;
            case 11:
                Color outline11 = new Color(206f / 255, 181f / 255, 38f / 255);
                outline = ColorMultiply(mainColor, outline11, .42f);

                highlight = ColorDodge(mainColor, mainColor, .40f);

                shadow = ColorLinearLight(mainColor, outline11, .11f);
                break;
            case 12:
                Color outline12 = new Color(255f / 255, 41f / 255, 41f / 255);
                outline = ColorMultiply(mainColor, outline12, .46f);

                highlight = ColorDodge(mainColor, mainColor, .40f);

                shadow = ColorLinearLight(mainColor, outline12, .17f);
                break;
            case 13:
                //wool
                outline = ColorLinearLight(mainColor, new Color(68f / 255, 38f / 255, 50f / 255), .42f);

                highlight = ColorAdd(mainColor, new Color(253f / 255, 253f / 255, 253f / 255), .33f);

                shadow = ColorMultiply(mainColor, new Color(246f / 255, 226f / 255, 239f / 255), 1);

                break;
            case 14:
                //silk peach
                outline = ColorLinearLight(mainColor, new Color(127f / 255, 91f / 255, 100f / 255), .72f);

                highlight = ColorAdd(mainColor, new Color(253f / 255, 253f / 255, 253f / 255), .33f);

                shadow = ColorMultiply(mainColor, new Color(242f / 255, 228f / 255, 255f / 255), 1);
                break;
            case 15:
                //silk powder
                outline = ColorLinearLight(mainColor, new Color(66f / 255, 99f / 255, 149f / 255), .72f);

                highlight = ColorAdd(mainColor, new Color(253f / 255, 253f / 255, 253f / 255), .33f);

                shadow = ColorMultiply(mainColor, new Color(242f / 255, 228f / 255, 255f / 255), 1);

                break;
            case 16:
                //satin olive
                outline = ColorMultiply(mainColor, new Color(144f / 255, 172f / 255, 102f / 255), 1);

                highlight = ColorAdd(mainColor, new Color(253f / 255, 253f / 255, 253f / 255), .48f);

                shadow = ColorMultiply(mainColor, new Color(222f / 255, 225f / 255, 217f / 255), 1);
                break;
            case 17:
                //Satin cherry
                outline = ColorMultiply(mainColor, new Color(223f / 255, 142f / 255, 138f / 255), 1);

                highlight = ColorAdd(mainColor, new Color(253f / 255, 253f / 255, 253f / 255), .48f);

                shadow = ColorMultiply(mainColor, new Color(222f / 255, 225f / 255, 217f / 255), 1);
                break;
            case 18:
                //satin violet
                outline = ColorMultiply(mainColor, new Color(144f / 255, 160f / 255, 220f / 255), 1);

                highlight = ColorAdd(mainColor, new Color(253f / 255, 253f / 255, 253f / 255), .48f);

                shadow = ColorMultiply(mainColor, new Color(222f / 255, 225f / 255, 217f / 255), 1);
                break;
            case 19:
                //vinyl pink
                outline = ColorDodge(mainColor, new Color(252f / 255, 69f / 255, 51f / 255), .75f);

                highlight = ColorNormal(mainColor, new Color(151f / 255, 189f / 255, 255f / 255), .76f);

                shadow = ColorLinearLight(mainColor, new Color(34f / 255, 83f / 255, 255f / 255), .13f);

                break;
            case 20:
                //vinyl green
                outline = ColorDodge(mainColor, new Color(48f / 255, 132f / 255, 48f / 255), .82f);

                highlight = ColorNormal(mainColor, new Color(255f / 255, 125f / 255, 217f / 255), .76f);

                shadow = ColorLinearLight(mainColor, new Color(93f / 255, 50f / 255, 255f / 255), .13f);

                break;
            case 21:
                //vinyl blue
                outline = ColorDodge(mainColor, new Color(0f / 255, 34f / 255, 172f / 255), .9f);

                highlight = ColorNormal(mainColor, new Color(255f / 255, 172f / 255, 125f / 255), .76f);

                shadow = ColorLinearLight(mainColor, new Color(231f / 255, 3f / 255, 165f / 255), .13f);
                break;
            case 22:
                //poly green
                outline = ColorNormal(mainColor, new Color(147f / 255, 147f / 255, 68f / 255), .7f);

                highlight = ColorAdd(mainColor, new Color(253f / 255, 253f / 255, 253f / 255), .49f);

                shadow = ColorMultiply(mainColor, new Color(246f / 255, 226f / 255, 239f / 255), 1);

                break;
            case 23:
                //poly blue
                outline = ColorNormal(mainColor, new Color(93f / 255, 152f / 255, 180f / 255), .7f);

                highlight = ColorAdd(mainColor, new Color(253f / 255, 253f / 255, 253f / 255), .49f);

                shadow = ColorMultiply(mainColor, new Color(246f / 255, 226f / 255, 239f / 255), 1);
                break;
            case 24:
                outline = ColorNormal(mainColor, new Color(192f / 255, 107f / 255, 155f / 255), .7f);

                highlight = ColorAdd(mainColor, new Color(253f / 255, 253f / 255, 253f / 255), .49f);

                shadow = ColorMultiply(mainColor, new Color(246f / 255, 226f / 255, 239f / 255), 1);
                break;
            default:
                Color outline0 = new Color(121f / 255, 87f / 255, 87f / 255);
                outline = ColorMultiply(mainColor, outline0, .44f);

                Color highlight0 = new Color(236f / 255, 222f / 255, 192f / 255);
                highlight = ColorDodge(mainColor, highlight0, .40f);

                Color shadow0 = new Color(121f / 255, 87f / 255, 87f / 255);
                shadow = ColorMultiply(mainColor, shadow0, .17f);
                break;
        }

    }
    #endregion
}
