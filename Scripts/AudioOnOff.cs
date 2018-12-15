using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AudioOnOff : MonoBehaviour {

	public Sprite AudioOn;
	public Sprite AudioOff;
	//Scene _scene;

	// Use this for initialization
	void Start () {
		//_scene = SceneManager.GetActiveScene();
		//Debug.Log(_scene.name);
		//if(_scene.name == "menu")
		if(Infos.AudioOn){
			GetComponent<Image>().sprite = AudioOn;
		}else GetComponent<Image>().sprite = AudioOff;
	}
	
    public void AudioChange(){
        if(Infos.AudioOn){
			 Infos.AudioOn = false;
			 //if(_scene.name == "menu")
			 	GetComponent<Image>().sprite = AudioOff;
			 Infos.Save();
			 AudioSourseOnOff.ChangeAudioSourseOnOff(false);
		}
        else {
			Infos.AudioOn = true;
			//if(_scene.name == "menu")
				GetComponent<Image>().sprite = AudioOn;
			Infos.Save();
			AudioSourseOnOff.ChangeAudioSourseOnOff(true);
		}
    }
}
