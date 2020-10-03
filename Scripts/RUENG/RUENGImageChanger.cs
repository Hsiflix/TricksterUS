using System;
using UnityEngine;
using UnityEngine.UI;

public class RUENGImageChanger : MonoBehaviour
{
    public Sprite RUS, ENG;
    public bool SecondVar;
    public Sprite RUS1, ENG1;
    public void Start()
    {
        try{
            if(info.lang == 1){ //RUS
                GetComponent<Image>().sprite = RUS;
            }else{ //ENG
                GetComponent<Image>().sprite = ENG;
            }
            if(SecondVar){
                if(info.lang == 1){ //RUS
                    GetComponent<Image>().sprite = RUS1;
                }else{ //ENG
                    GetComponent<Image>().sprite = ENG1;
                }
            }
        }catch(Exception e){
            Debug.Log("RUENGImageChanger: " + e);
        }
    }
}