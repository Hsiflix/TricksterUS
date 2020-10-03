using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class RUENGVideoClipChanger : MonoBehaviour
{
    public VideoClip RUS, ENG;
    public void Start()
    {
        try{
            if(info.lang == 1){ //RUS
                GetComponent<VideoPlayer>().clip = RUS;
            }else{ //ENG
                GetComponent<VideoPlayer>().clip = ENG;
            }
        }catch(Exception e){
            Debug.Log("RUENGFontChanger: " + e);
        }
    }
}
