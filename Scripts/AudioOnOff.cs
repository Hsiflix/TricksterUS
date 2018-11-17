using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AudioOnOff : MonoBehaviour {

	public Sprite AudioOn;
	public Sprite AudioOff;

	// Use this for initialization
	void Start () {
		if(Infos.AudioOn){
			GetComponent<Image>().sprite = AudioOn;
		}else GetComponent<Image>().sprite = AudioOff;
	}
	
    public void AudioChange(){
        if(Infos.AudioOn){
			 Infos.AudioOn = false;
			 GetComponent<Image>().sprite = AudioOff;
			 Infos.Save();
			 AudioSourseOnOff.ChangeAudioSourseOnOff(false);
		}
        else {
			Infos.AudioOn = true;
			GetComponent<Image>().sprite = AudioOn;
			Infos.Save();
			AudioSourseOnOff.ChangeAudioSourseOnOff(true);
		}
    }
}
