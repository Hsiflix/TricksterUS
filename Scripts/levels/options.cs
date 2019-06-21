using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class options : MonoBehaviour
{
	private Animator _animator;

	// Use this for initialization
	void Start () {
		_animator = gameObject.GetComponent<Animator>();
	}
	
	public void Opt(){
		if(info.AudioOn) GameObject.Find("Audio_Option_level").GetComponent<AudioSource>().Play();
		bool isOpen = _animator.GetBool("open");
		_animator.SetBool("open",!isOpen);
	}
	
	public void Mus(){
		if(info.AudioOn) GameObject.Find("Button_click").GetComponent<AudioSource>().Play();

	}

	public void Sou(){
		if(info.AudioOn) GameObject.Find("Button_click").GetComponent<AudioSource>().Play();

	}
}
