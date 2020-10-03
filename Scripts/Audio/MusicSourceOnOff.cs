using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSourceOnOff : MonoBehaviour
{
    static private AudioSource Music;
	void Start(){
		Music = GetComponent<AudioSource>();
		AudioOnOff.musics.Add(Music);
        //AudioOnOff.audios.Add(Music);
		if(info.MusicOn){
			Music.enabled = true;
		} else {
			Music.enabled = false;
		}
	}
}
