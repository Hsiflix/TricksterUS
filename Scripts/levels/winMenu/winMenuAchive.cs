using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winMenuAchive : MonoBehaviour
{
    public GameObject AchTime, AchStep, AchBugs, AchHard;
    public GameObject AchKey1, AchKey2, AchKey3;
    public void StartPlay()
    {
        /*AchTime.SetActive(true);
        AchStep.SetActive(true);
        AchBugs.SetActive(true);*/
        /*AchivementMap.achivements[AchivementMap.lvl,0] = true;
        AchivementMap.achivements[AchivementMap.lvl,1] = true;
        AchivementMap.achivements[AchivementMap.lvl,2] = true;*/
        StartCoroutine(StartAchive());
    }

    IEnumerator StartAchive(){
        yield return new WaitForSeconds(0.5f);
        AchTime.SetActive(true);
        if(AchivementMap.achivements[AchivementMap.lvl,0]){
            if(info.AudioOn) GameObject.Find("audio_achivement").GetComponent<AudioSource>().Play();
            AchTime.GetComponent<Animation>().Play();
            yield return new WaitForSeconds(0.5f);
        }
        AchStep.SetActive(true);
        if(AchivementMap.achivements[AchivementMap.lvl,1]){
            if(info.AudioOn) GameObject.Find("audio_achivement").GetComponent<AudioSource>().Play();
            AchStep.GetComponent<Animation>().Play();
            yield return new WaitForSeconds(0.5f);
        }
        AchBugs.SetActive(true);
        if(AchivementMap.achivements[AchivementMap.lvl,2]){
            if(info.AudioOn) GameObject.Find("audio_achivement").GetComponent<AudioSource>().Play();
            AchBugs.GetComponent<Animation>().Play();
            yield return new WaitForSeconds(0.5f);
        }
        /*AchKey1.SetActive(true); 
        AchKey2.SetActive(true);
        AchKey3.SetActive(true);*/

        if(AchivementMap.achivements[AchivementMap.lvl,0] && AchivementMap.achivements[AchivementMap.lvl,1] && AchivementMap.achivements[AchivementMap.lvl,2]){ //Open hardLvl
            if(!AchivementMap.achivements[AchivementMap.lvl,3]){
                AchivementMap.achivements[AchivementMap.lvl,3] = true;
                if(info.hardLvl < info.max_hardLvl){
                    info.hardLvl++;
                    AchHard.SetActive(true);
                    info.SaveAchive();
                    MapCrossPushHide.firsMeetHard = true;
                }
            }
        }

        yield return new WaitForSeconds(0.5f);
        if(AchivementMap.achivementKeys[0]){
            if(info.AudioOn) GameObject.Find("audio_achivement").GetComponent<AudioSource>().Play();
            AchKey1.GetComponent<Animation>().Play();
            yield return new WaitForSeconds(0.5f);
        }
        AchStep.SetActive(true);
        if(AchivementMap.achivementKeys[1]){
            if(info.AudioOn) GameObject.Find("audio_achivement").GetComponent<AudioSource>().Play();
            AchKey2.GetComponent<Animation>().Play();
            yield return new WaitForSeconds(0.5f);
        }
        AchBugs.SetActive(true);
        if(AchivementMap.achivementKeys[2]){
            if(info.AudioOn) GameObject.Find("audio_achivement").GetComponent<AudioSource>().Play();
            AchKey3.GetComponent<Animation>().Play();
        }
    }
}
