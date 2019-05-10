using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class CanvasBot : MonoBehaviour {

	public Animator your_turn;
	static public bool your_turn_bt = false;
	public Animator opponent_turn;
	static public bool opponent_turn_bt = false;
	private bool isTrue;
	
	void Update () {
		if(your_turn_bt){
			your_turn_bt = false;
			info.activeTouch = false;
			your_turn.SetBool("Animat",true);
		}
		if(opponent_turn_bt){
			opponent_turn_bt = false;
			info.activeTouch = false;
			opponent_turn.SetBool("Animat",true);
		}
		isTrue = your_turn.GetBool("Animat");
		if(your_turn.GetCurrentAnimatorStateInfo(0).IsName("Trn") && isTrue){
			your_turn.SetBool("Animat",false);
			info.activeTouch = true;
		}
		isTrue = opponent_turn.GetBool("Animat");
		if(opponent_turn.GetCurrentAnimatorStateInfo(0).IsName("Trn") && isTrue){
			opponent_turn.SetBool("Animat",false);
            GameObject.Find("Game").GetComponent<Bot>().MainFunc();
		}
	}
}
