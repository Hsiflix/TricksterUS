using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourseOnOff : MonoBehaviour {

	static public bool AudioSourse = true;
	static private AudioSource Audio;
	void Start(){
		Audio = GetComponent<AudioSource>();
		if(AudioSourse){
			Debug.Log("Audio.volume = 0.5f;");
			Audio.volume = 0.5f;
		} else {
			Debug.Log("Audio.volume = 0f;");
			Audio.volume = 0f;
		}
	}

	static public void ChangeAudioSourseOnOff(bool Ch = true){
		AudioSourse = Ch;
		if(AudioSourse){
			Debug.Log("Audio.volume = 0.5f;");
			Audio.volume = 0.3f;
		} else {
			Debug.Log("Audio.volume = 0f;");
			Audio.volume = 0f;
		}
	}

}
