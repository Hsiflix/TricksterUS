using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AudioOnOff : MonoBehaviour {

	public Sprite AudioOn;
	public Sprite AudioOff;
	private float volume = 0.5f;
	static public List<AudioSource> audios = new List<AudioSource>();

	// Use this for initialization
	void Start () {
		if(info.AudioOn){
			GetComponent<Image>().sprite = AudioOn;
		}else GetComponent<Image>().sprite = AudioOff;
	}
	
    public void AudioChange(){
        if(info.AudioOn){
			info.AudioOn = false;
			GetComponent<Image>().sprite = AudioOff;
			info.Save();
			Repeat:
			foreach (AudioSource ase in audios){
				if(ase == null){
					audios.Remove(ase);
					goto Repeat;
				}
				ase.volume = 0f;
			}
		}
        else {
			info.AudioOn = true;
			GetComponent<Image>().sprite = AudioOn;
			info.Save();
			Repeat1:
			foreach (AudioSource ase in audios){
				if(ase == null){
					audios.Remove(ase);
					goto Repeat1;
				}
				ase.volume = this.volume;
			}
		}
    }
}
