using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptLvl : MonoBehaviour {
	public Animator _animator;

	// Use this for initialization
	void Start () {
		//_anim = gameObject.GetComponent<Animation>();
		_animator = gameObject.GetComponent<Animator>();
	}
	
	public void Opt(){
		bool isOpen = _animator.GetBool("open");
		_animator.SetBool("open",!isOpen);
	}
	
	public void Mus(){

	}

	public void Sou(){

	}
}
