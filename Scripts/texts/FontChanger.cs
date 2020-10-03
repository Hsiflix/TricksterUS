using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontChanger : MonoBehaviour
{
    void Start()
    {
        //Load a text file (Assets/Resources/Text/textFile01.txt)
        var myFont = Resources.Load<Font>("TrixMagic");
        var textComponents = Component.FindObjectsOfType<Text>();
        foreach(var component in textComponents){
            component.font = myFont;
        }
    }
}
