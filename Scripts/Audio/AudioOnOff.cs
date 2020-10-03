using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AudioOnOff : MonoBehaviour {

	public Sprite AudioOn, AudioOff;
	public Sprite MusicOn, MusicOff;
	public bool isAudio = true;
	static public List<AudioSource> audios = new List<AudioSource>();
	static public List<AudioSource> musics = new List<AudioSource>();

	// Use this for initialization
	void Start () {
		if(isAudio){
			if(info.AudioOn){
				GetComponent<Image>().sprite = AudioOn;
			}else GetComponent<Image>().sprite = AudioOff;
		}else{		
			if(info.MusicOn){
				GetComponent<Image>().sprite = MusicOn;
			}else GetComponent<Image>().sprite = MusicOff;
		}
	}
	
    public void AudioChange(){
		try{
			if(info.AudioOn) GameObject.Find("Button_click").GetComponent<AudioSource>().Play();
		}catch{
			Debug.Log("Не найден Button_click");
		}
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
				ase.enabled = false;
			}
		}else{
			info.AudioOn = true;
			GetComponent<Image>().sprite = AudioOn;
			info.Save();
			Repeat1:
			foreach (AudioSource ase in audios){
				if(ase == null){
					audios.Remove(ase);
					goto Repeat1;
				}
				ase.enabled = true;
			}
		}
  	}

	public void MusicChange(){
		try{
			if(info.AudioOn) GameObject.Find("Button_click").GetComponent<AudioSource>().Play();
		}catch{
			Debug.Log("Не найден Button_click");
		}
      	if(info.MusicOn){
			info.MusicOn = false;
			GetComponent<Image>().sprite = MusicOff;
			info.Save();
			Repeat:
			foreach (AudioSource ase in musics){
				if(ase == null){
					musics.Remove(ase);
					goto Repeat;
				}
				ase.enabled = false;
			}
		}else{
			info.MusicOn = true;
			GetComponent<Image>().sprite = MusicOn;
			info.Save();
			Repeat1:
			foreach (AudioSource ase in musics){
				if(ase == null){
					musics.Remove(ase);
					goto Repeat1;
				}
				ase.enabled = true;
			}
		}
  	}
}
