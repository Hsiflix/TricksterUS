using System;
using UnityEngine;
using UnityEngine.UI;

public class RUENGSpriteChanger : MonoBehaviour
{
    public Sprite RUS, ENG;
    public bool SecondVar;
    public Sprite RUS1, ENG1;
    public void Start()
    {
        try{
            if(info.lang == 1){ //RUS
                GetComponent<SpriteRenderer>().sprite = RUS;
            }else{ //ENG
                GetComponent<SpriteRenderer>().sprite = ENG;
            }
            if(SecondVar){
                if(info.lang == 1){ //RUS
                    GetComponent<SpriteRenderer>().sprite = RUS1;
                }else{ //ENG
                    GetComponent<SpriteRenderer>().sprite = ENG1;
                }
            }
        }catch(Exception e){
            Debug.Log("RUENGSpriteChanger: " + e);
        }
    }
}
