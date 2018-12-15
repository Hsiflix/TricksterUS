using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetWay : MonoBehaviour {

	static public bool activate = false;
	static public bool cleaner = false;
	static public bool actCleaner = false;
	static public int ballNum = -1;
	public GameObject target;
	private GameObject ball;

	// Use this for initialization
	void Start () {
		target.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(activate){
			activate = false;
			cleaner = true;
			try{
				ball = GameObject.Find(ballNum.ToString()); // Ищем этот шарик среди наших и записываем в "next" его Gameobject
				target.transform.position = ball.transform.position ;
				target.SetActive(true);
			}catch{
				Debug.Log("Error in next = GameObject.Find(ballNum.ToString());");
			}
		}
		if(cleaner && actCleaner){
			cleaner = false;
			actCleaner = false;
			target.SetActive(false);
		}

	}
}
