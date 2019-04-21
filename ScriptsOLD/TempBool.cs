﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempBool : MonoBehaviour {

	public GameObject bomb;
	public GameObject bomb1;
	public GameObject bomb2;
	public GameObject bombTort1;
	public GameObject bombTort2;
	public GameObject bombTort3;

	static public bool start = false;
	static public bool startTort = false;
	static public bool startLvlTort = false;
	private bool Start = true;
	private IEnumerator[] coroutine = new IEnumerator[3];
	static public int[] spawns = {0,0,0};
	private int randomTime = 0;

	void Update(){
		if(Start){
			Start = false;
			if(myGUI.timerGo){
				randomTime = Random.Range(5, myGUI.timersecond - 5);
			} else {
				randomTime = Random.Range(10, 50);
			}
			Debug.Log(randomTime);
		}
		if(start){
			start = false;
			tapColorBall();
		}
		if(startTort){
			startTort = false;
			tapTortBall();
		}
		if((myGUI.timersecond == randomTime) && startLvlTort){
			startLvlTort = false;
			tapTortBall();
		}
	}
	public void tapColorBall(){
		coroutine[0] = Late(bomb, 0f);
		StartCoroutine(coroutine[0]);
		coroutine[1] = Late(bomb1, 0.5f);
		StartCoroutine(coroutine[1]);
		coroutine[2] = Late(bomb2, 1f);
		StartCoroutine(coroutine[2]);
	}
	public void tapTortBall(){
		coroutine[0] = Late(bombTort1, 0f);
		StartCoroutine(coroutine[0]);
		coroutine[1] = Late(bombTort2, 0.5f);
		StartCoroutine(coroutine[1]);
		coroutine[2] = Late(bombTort3, 1f);
		StartCoroutine(coroutine[2]);
	}

	IEnumerator Late(GameObject _obj, float time = 1)
    {
        yield return new WaitForSeconds(time);
		_obj.SetActive(true); 
		_obj.GetComponent<Tortoise>().badTrickster();
    }
}