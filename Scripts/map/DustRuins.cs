using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DustRuins : MonoBehaviour {

	public GameObject button_1;
	public GameObject[] levers;
	public GameObject cat_bg, cat_2_bg;
	public GameObject[] syms;
	public GameObject[] usyms;
    public float scrinWidth;
    public float scrinHeight;
    public float BalansWidth;
    public float BalansHeight;
	private short leftLeverPos = -1;
	private short rightLeverPos = -1;
	private short centralButtonPos = -1;
	private short sequence = 0;
	public GUIStyle myStyle;
	public Texture2D aTexture;
	private bool loadLvl = false;

	// Use this for initialization
	void Start () {
		loadLvl = false;
		levers = new GameObject[6];
		for (int i=0; i<6; i++){
			string name = "lever_";
			name+=(i+1).ToString();
			levers[i] = GameObject.Find(name.ToString());
		}
		syms = new GameObject[5];
		for (int i=0; i<5; i++){
			string name = "sym_";
			name+=(i+1).ToString();
			syms[i] = GameObject.Find(name.ToString());
		}
		usyms = new GameObject[6];
		for (int i=0; i<6; i++){
			string name = "usym_";
			name+=(i+1).ToString();
			usyms[i] = GameObject.Find(name.ToString());
		}
		button_1 = GameObject.Find("button_1");
		foreach (char a in "1245"){
			levers[Int32.Parse(a.ToString())].SetActive(false);
		}
		foreach (char a in "01234"){
			syms[Int32.Parse(a.ToString())].SetActive(false);
		}
		foreach (char a in "012345"){
			usyms[Int32.Parse(a.ToString())].SetActive(false);
		}
		button_1.SetActive(false);

        scrinWidth = Screen.width;
        scrinHeight = Screen.height;
        BalansWidth = 1280 / scrinWidth;
        BalansHeight = 720 / scrinHeight;

		leftLeverPos = 1;
		rightLeverPos = 1;
		centralButtonPos = 0;

		//GUI.skin.button.active.background = aTexture;
	}

	private void Access(){
		//foreach (char a in "012345"){
		//	usyms[Int32.Parse(a.ToString())].SetActive(true);
		//}
		StartCoroutine("Animat");
		loadLvl = true;
	}

	private void dumpSyms(){
		foreach (char a in "01234"){
			syms[Int32.Parse(a.ToString())].SetActive(false);
		}
	}

	void OnGUI()
    {
		//GUI.skin.button.active.background = aTexture;
		if(GUI.Button(new Rect(375 / BalansWidth, 250 / BalansHeight, 110 / BalansWidth, 130 / BalansHeight), "", myStyle)){ //Left lever
			switch (leftLeverPos){
				case 1: leftLeverPos = 2; levers[0].SetActive(false); levers[1].SetActive(true); break;
				case 2: leftLeverPos = 3; levers[1].SetActive(false); levers[2].SetActive(true); break;
				case 3: leftLeverPos = 1; levers[2].SetActive(false); levers[0].SetActive(true); break;
			}
			switch(sequence){
				case 0: sequence = 1; syms[0].SetActive(true); break;
				case 1: sequence = 2; break;
				case 2: sequence = 0; dumpSyms(); break;
				case 3: sequence = 4; break;
				case 4: sequence = 0; dumpSyms(); break;
				case 5: sequence = 6; syms[3].SetActive(true); break;
				case 6: sequence = 7; break;
				case 7: sequence = 0; dumpSyms(); break;
				case 8: sequence = 0; dumpSyms(); break;
			}
		};
		if(GUI.Button(new Rect(815 / BalansWidth, 250 / BalansHeight, 110 / BalansWidth, 130 / BalansHeight), "", myStyle)){ //Right lever
			switch (rightLeverPos){
				case 1: rightLeverPos = 2; levers[3].SetActive(false); levers[4].SetActive(true); break;
				case 2: rightLeverPos = 3; levers[4].SetActive(false); levers[5].SetActive(true); break;
				case 3: rightLeverPos = 1; levers[5].SetActive(false); levers[3].SetActive(true); break;
			}
			switch(sequence){
				case 0: sequence = 0; dumpSyms(); break;
				case 1: sequence = 0; dumpSyms(); break;
				case 2: sequence = 3; syms[1].SetActive(true); break;
				case 3: sequence = 0; dumpSyms(); break;
				case 4: sequence = 0; dumpSyms(); break;
				case 5: sequence = 0; dumpSyms(); break;
				case 6: sequence = 0; dumpSyms(); break;
				case 7: sequence = 8; syms[4].SetActive(true); Access(); break;
				case 8: sequence = 0; dumpSyms(); break;
			}

		};
		if(GUI.Button(new Rect(592 / BalansWidth, 260 / BalansHeight, 110 / BalansWidth, 115 / BalansHeight), "", myStyle)){ //Central button
			switch (centralButtonPos){
				case 0: centralButtonPos = 1; button_1.SetActive(true); break;
				case 1: centralButtonPos = 0; button_1.SetActive(false); break;
			}
			switch(sequence){
				case 0: sequence = 0; dumpSyms(); break;
				case 1: sequence = 0; dumpSyms(); break;
				case 2: sequence = 0; dumpSyms(); break;
				case 3: sequence = 0; dumpSyms(); break;
				case 4: sequence = 5; syms[2].SetActive(true); break;
				case 5: sequence = 0; dumpSyms(); break;
				case 6: sequence = 0; dumpSyms(); break;
				case 7: sequence = 0; dumpSyms(); break;
				case 8: sequence = 0; dumpSyms(); break;
			}
		};
		if(GUI.Button(new Rect(585 / BalansWidth, 445 / BalansHeight, 115 / BalansWidth, 255 / BalansHeight), "", myStyle)){ //Central button
			//Debug.Log("//Central button");
			if(loadLvl){
        		SceneManager.LoadScene("lvlB2");
			}
		};
	}

	public void catButton(){
        if(info.AudioOn) GameObject.Find("audio_cat").GetComponent<AudioSource>().Play();  
        cat_bg.SetActive(false);  
        cat_2_bg.SetActive(true);
        StartCoroutine(closeJungle());
    }

    IEnumerator Animat()
    {
		foreach (char a in "012345"){
			usyms[Int32.Parse(a.ToString())].SetActive(true);
			yield return new WaitForSeconds(0.2f);
		}
	}

	IEnumerator closeJungle(){
        yield return new WaitForSeconds(0.7f);
        GameObject.Find("DustRuins").SetActive(false);
    }

}
