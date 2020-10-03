using System;
using UnityEngine;
using UnityEngine.UI;

public class RUENGTextChanger : MonoBehaviour
{
    public string RUS, ENG;
    public void Start()
    {
        try{
            if(info.lang == 1){ //RUS
                GetComponent<Text>().text = RUS;
            }else{ //ENG
                GetComponent<Text>().text = ENG;
            }
        }catch(Exception e){
            Debug.Log("RUENGFontChanger: " + e);
        }
    }
}
