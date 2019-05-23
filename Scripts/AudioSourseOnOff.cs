using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourseOnOff : MonoBehaviour {

	static private AudioSource Audio;
	void Start(){
		Audio = GetComponent<AudioSource>();
		AudioOnOff.audios.Add(Audio);
		if(info.AudioOn){
			Audio.volume = 0.5f;
		} else {
			Audio.volume = 0f;
		}
	}
}
