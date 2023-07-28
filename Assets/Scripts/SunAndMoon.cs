using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunAndMoon : MonoBehaviour
{
    [SerializeField] Light lightSource;
    GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeLighting();
    }

    void ChangeLighting()
    {
        switch(gameManager.GetRemainingCheckpoints())
        {
            case int n when (n <= 15 && n > 12):
            lightSource.color = ColorFromHex("FFF4D6");
            Camera.main.backgroundColor = ColorFromHex("FFF4D6");
            break;

            case int n when (n <= 12 && n > 8):
            lightSource.color = ColorFromHex("FFD04E");
            Camera.main.backgroundColor = ColorFromHex("FFBC00");
            break;
            
            case int n when (n <=8 && n > 0):
            lightSource.color = ColorFromHex("CB0000");
            Camera.main.backgroundColor = ColorFromHex("65002A");
            break;

            default:
            lightSource.color = ColorFromHex("1900FF");
            Camera.main.backgroundColor = Color.black;
            break;
        }
    }

    Color32 ColorFromHex(string colorHex)
    {
        var m_Red = System.Convert.ToByte(colorHex.Substring(0, 2), 16);
        var m_Green = System.Convert.ToByte(colorHex.Substring(2, 2), 16);
        var m_Blue = System.Convert.ToByte(colorHex.Substring(4, 2), 16);

        // always requires the alpha parameter
        var m_NewColor = new UnityEngine.Color32(m_Red, m_Green, m_Blue, 255);
        return m_NewColor;
    }
}
