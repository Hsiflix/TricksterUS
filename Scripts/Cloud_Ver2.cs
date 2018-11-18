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
	public GameObject AnCloudPart2;
	static public bool flSound = false;
	static public bool active = false;
	static public bool end = false;
	static public bool start = true;
	//static public short ver = -1; //1=Flash, 2=Trick, 3=Angel, 4=Us
	static public short ver = 1; //1=Flash, 2=Trick, 3=Angel, 4=Us
	private Vector3 target;
	static public Vector3 cameraPosition;
	private double k = 0; // y = k*x + b
	private double b = 0; // y = k*x + b
	private double x = 0;
	private bool trigger = true;
	private short rat = 1;
	private int numerate = 0;
	private int randNum = 0;

	// Use this for initialization
	void Start () {
		cameraPosition = new Vector3(0.45f + Spawn.MySize * 0.45f, 4.05f + Spawn.MySize * 0.45f, -10);
		//k = UnityEngine.Random.Range(-1f,1.01f);
		//b = cameraPosition.y - cameraPosition.x*k;
		//x = -15;
	}
	
	void Update () {
		if(flSound){
			flSound = false;
			GetComponent<AudioSource>().Play();
		}
		if(start){
			start = false;
			float x = UnityEngine.Random.Range(-1, 6);
            target = transform.position = new Vector3(x, -3f, -2.45f);//
			switch (ver){ //1=Flash, 2=Trick, 3=Angel, 4=Us
				case 1: 
					transform.position = new Vector3(-15f, 0f,0f);
					GetComponent<SpriteRenderer>().sprite = FlCloud; 
					k = UnityEngine.Random.Range(-1f,1.01f);
					b = cameraPosition.y - cameraPosition.x*k;
					do
						rat = (short)UnityEngine.Random.Range(-1,2);
					while (rat == 0);
					Debug.Log(rat);
					this.x = 15*rat; //
					break;
				case 2: GetComponent<SpriteRenderer>().sprite = UsCloud; break;
				case 3: GetComponent<SpriteRenderer>().sprite = AnCloud; AnCloudPart2.SetActive(true); break;
				case 4: GetComponent<SpriteRenderer>().sprite = UsCloud; break;
			}
			active = true;
		}
		if(active){
			switch (ver){ //1=Flash, 2=Trick, 3=Angel, 4=Us
				case 1: 
					x -= UnityEngine.Random.Range(0.15f, 0.3f)*rat;
					target = new Vector3((float)x, (float)(k*x+b), -2.45f);
					transform.position = Vector3.Lerp(transform.position, target, 0.5f);
					if(transform.position.x > 16 || transform.position.x < -16){
						end = true;
					}
					break;
				case 2:
					// Меняется через 40-80 кадров после цента экрана
					if ((transform.position.y > cameraPosition.y) && trigger && numerate<=randNum) {
						trigger = false;
						randNum =  UnityEngine.Random.Range(40,80);
						Debug.Log(randNum);
					}
					if(!trigger){
						if(numerate == randNum){
							GetComponent<SpriteRenderer>().sprite = TrCloud;
							trigger = true;
						}
						numerate++;
					}
					/*numerate++; // Меняется каждые 100-160 кадров на 3 кадра
					if(trigger){
						trigger = false;
						randNum += UnityEngine.Random.Range(100,160);
					}
					if(!trigger){
						if(numerate==randNum){
							GetComponent<SpriteRenderer>().sprite = TrCloud;
						}
						if(numerate==randNum+3){
							GetComponent<SpriteRenderer>().sprite = UsCloud;
							trigger = true;
						}
					} */
				
					if(target.x > cameraPosition.x + 3) target.x += UnityEngine.Random.Range(-1.3f,1f);
					else if (target.x < cameraPosition.x - 3) target.x += UnityEngine.Random.Range(-1f,1.3f);
					else target.x += UnityEngine.Random.Range(-1f,1.000001f);
					target.y += UnityEngine.Random.Range(0.05f, 0.1f);
					transform.position = Vector3.Lerp(transform.position, target, 0.003f);
					if(transform.position.y >= 15)
					{
						end = true;
					}
					break;
				case 3:
					if(target.x > cameraPosition.x + 3) target.x += UnityEngine.Random.Range(-1.3f,1f);
					else if (target.x < cameraPosition.x - 3) target.x += UnityEngine.Random.Range(-1f,1.3f);
					else target.x += UnityEngine.Random.Range(-1f,1.000001f);
					target.y += UnityEngine.Random.Range(0.05f, 0.1f);
					transform.position = Vector3.Lerp(transform.position, target, 0.003f);
					if(transform.position.y >= 15)
					{
						end = true;
					}
					break;
				case 4:
					if(target.x > cameraPosition.x + 3) target.x += UnityEngine.Random.Range(-1.3f,1f);
					else if (target.x < cameraPosition.x - 3) target.x += UnityEngine.Random.Range(-1f,1.3f);
					else target.x += UnityEngine.Random.Range(-1f,1.000001f);
					target.y += UnityEngine.Random.Range(0.05f, 0.1f);
					transform.position = Vector3.Lerp(transform.position, target, 0.003f);
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
			AnCloudPart2.SetActive(false);
			GetComponent<SpriteRenderer>().sprite = null;
		}
	}
}
