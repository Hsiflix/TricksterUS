using System;
using UnityEngine;
using UnityEngine.UI;

public class RUENGFontChanger : MonoBehaviour
{
    public Font RUS, ENG;
    public void Start()
    {
        try{
            if(info.lang == 1){ //RUS
                GetComponent<Text>().font = RUS;
            }else{ //ENG
                GetComponent<Text>().font = ENG;
            }
        }catch(Exception e){
            Debug.Log("RUENGFontChanger: " + e);
        }
    }
}