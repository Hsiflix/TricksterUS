using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Cloud_Ver2 : MonoBehaviour {

	public Sprite UsCloud;
	public Sprite FlCloud;
	public Sprite TrCloud;
	public Sprite AnCloud;
	public Sprite AnCloudPart2;
	static public bool active = false;
	static public bool end = false;
	static public bool start = true;
	//static public short ver = -1; //1=Flash, 2=Trick, 3=Angel, 4=Us
	static public short ver = 4; //1=Flash, 2=Trick, 3=Angel, 4=Us
	private Vector3 position;
	private Vector3 target;

	// Use this for initialization
	void Start () {
		position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(start){
			start = false;
			float x = UnityEngine.Random.Range(-2, 7);
            target = transform.position = new Vector3(x, -3f, -2.45f);//
			switch (ver){ //1=Flash, 2=Trick, 3=Angel, 4=Us
				case 1: GetComponent<SpriteRenderer>().sprite = FlCloud; break;
				case 2: GetComponent<SpriteRenderer>().sprite = TrCloud; break;
				case 3: GetComponent<SpriteRenderer>().sprite = AnCloud; break;
				case 4: GetComponent<SpriteRenderer>().sprite = UsCloud; break;
			}
			active = true;
		}
		if(active){

			switch (ver){ //1=Flash, 2=Trick, 3=Angel, 4=Us
				case 1: 

					break;
				case 2:

					break;
				case 3:

					break;
				case 4:
					target.x += UnityEngine.Random.Range(-1f,1.01f);
					target.y += UnityEngine.Random.Range(0.05f, 0.2f);
					transform.position = Vector3.Lerp(transform.position, target, 0.005f);
					if(transform.position.y >= 15)
					{
						end = true;
					}
					break;
			}

		}
		if(end){
			end = false;
			active = false;
			GetComponent<SpriteRenderer>().sprite = null;
		}
	}
}
