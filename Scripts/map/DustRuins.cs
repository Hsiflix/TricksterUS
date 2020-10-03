using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DustRuins : MonoBehaviour {

	public GameObject button_1;
	public GameObject[] levers;
	public GameObject cat_bg, cat_2_bg, trickHelpBut;
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
	private bool trickHelpActive = false;
	public GameObject DialogGO;

	private void OnEnable() {
        cat_bg.SetActive(true);  
        cat_2_bg.SetActive(false);
    }
	// Use this for initialization
	void Start () {
		MapCrossPushHide.firstMeet[1] = false;
		GameObject.Find("BG").GetComponent<MapCrossPushHide>().SetTargets();
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
		button_1 = GameObject.Find("CentralButton");
		foreach (char a in "1245"){
			levers[Int32.Parse(a.ToString())].SetActive(false);
		}
		foreach (char a in "01234"){
			syms[Int32.Parse(a.ToString())].SetActive(false);
		}
		foreach (char a in "012345"){
			usyms[Int32.Parse(a.ToString())].SetActive(false);
		}
		//button_1.SetActive(false);

        scrinWidth = Screen.width;
        scrinHeight = Screen.height;
        BalansWidth = 1280 / scrinWidth;
        BalansHeight = 720 / scrinHeight;

		leftLeverPos = 1;
		rightLeverPos = 1;
		centralButtonPos = 0;

		StartCoroutine(trickHelp());

		info.Save();
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
			if(info.AudioOn) GameObject.Find("audio_lever").GetComponent<AudioSource>().Play(); 
			switch (leftLeverPos){
				case 1: leftLeverPos = 2; levers[0].GetComponent<Image>().color = Color.white;
					levers[0].SetActive(false);
					levers[1].SetActive(true); break;
				case 2: leftLeverPos = 3; levers[1].GetComponent<Image>().color = Color.white;
					levers[1].SetActive(false);
					levers[2].SetActive(true); break;
				case 3: leftLeverPos = 1; levers[2].GetComponent<Image>().color = Color.white;
					levers[2].SetActive(false);
					levers[0].SetActive(true); break;
			}
			StopAnim();
			switch(sequence){
				case 0: sequence = 1; syms[0].SetActive(true); 
						if(info.AudioOn) GameObject.Find("audio_magic_light").GetComponent<AudioSource>().Play();  
					break;
				case 1: sequence = 2; break;
				case 2: sequence = 0; dumpSyms(); break;
				case 3: sequence = 4; break;
				case 4: sequence = 0; dumpSyms(); break;
				case 5: sequence = 6; syms[3].SetActive(true);  
						if(info.AudioOn) GameObject.Find("audio_magic_light").GetComponent<AudioSource>().Play();  
					break;
				case 6: sequence = 7; break;
				case 7: sequence = 0; dumpSyms(); break;
				case 8: sequence = 0; dumpSyms(); break;
			}
		};
		if(GUI.Button(new Rect(815 / BalansWidth, 250 / BalansHeight, 110 / BalansWidth, 130 / BalansHeight), "", myStyle)){ //Right lever
			if(info.AudioOn) GameObject.Find("audio_lever").GetComponent<AudioSource>().Play(); 
			switch (rightLeverPos){
				case 1: rightLeverPos = 2; levers[3].GetComponent<Image>().color = Color.white;
					levers[3].SetActive(false); 
					levers[4].SetActive(true); break;
				case 2: rightLeverPos = 3; levers[4].GetComponent<Image>().color = Color.white;
					levers[4].SetActive(false); 
					levers[5].SetActive(true); break;
				case 3: rightLeverPos = 1; levers[5].GetComponent<Image>().color = Color.white;
					levers[5].SetActive(false); 
					levers[3].SetActive(true); break;
			}
			StopAnim();
			switch(sequence){
				case 0: sequence = 0; dumpSyms(); break;
				case 1: sequence = 0; dumpSyms(); break;
				case 2: sequence = 3; syms[1].SetActive(true);  
						if(info.AudioOn) GameObject.Find("audio_magic_light").GetComponent<AudioSource>().Play();  
					break;
				case 3: sequence = 0; dumpSyms(); break;
				case 4: sequence = 0; dumpSyms(); break;
				case 5: sequence = 0; dumpSyms(); break;
				case 6: sequence = 0; dumpSyms(); break;
				case 7: sequence = 8; syms[4].SetActive(true);  
						if(info.AudioOn) GameObject.Find("audio_magic_light_all").GetComponent<AudioSource>().Play();  
					Access(); 
					if(trickHelpActive) {trickHelpBut.SetActive(false);}
					break;
				case 8: sequence = 0; dumpSyms(); break;
			}

		};
		if(GUI.Button(new Rect(592 / BalansWidth, 260 / BalansHeight, 110 / BalansWidth, 115 / BalansHeight), "", myStyle)){ //Central button
			switch (centralButtonPos){
				case 0: centralButtonPos = 1; GameObject.Find("CentralButton").GetComponent<Animation>().Stop();
					button_1.GetComponent<Image>().color = Color.black; break;
				case 1: centralButtonPos = 0; GameObject.Find("CentralButton").GetComponent<Animation>().Stop();
					button_1.GetComponent<Image>().color = Color.white; break;
			}
			StopAnim();
			if(info.AudioOn) GameObject.Find("audio_flagstone").GetComponent<AudioSource>().Play();
			switch(sequence){
				case 0: sequence = 0; dumpSyms(); break;
				case 1: sequence = 0; dumpSyms(); break;
				case 2: sequence = 0; dumpSyms(); break;
				case 3: sequence = 0; dumpSyms(); break;
				case 4: sequence = 5; 
					syms[2].SetActive(true); 
					if(trickHelpActive) {trickHelpBut.SetActive(false); StartCoroutine(trickHelp(20));}
					if(info.AudioOn) GameObject.Find("audio_magic_light").GetComponent<AudioSource>().Play();
					break;
				case 5: sequence = 0; dumpSyms(); break;
				case 6: sequence = 0; dumpSyms(); break;
				case 7: sequence = 0; dumpSyms(); break;
				case 8: sequence = 0; dumpSyms(); break;
			}
		};
		if(GUI.Button(new Rect(585 / BalansWidth, 445 / BalansHeight, 115 / BalansWidth, 255 / BalansHeight), "", myStyle)){ //Central button
			//Debug.Log("//Central button");
			if(loadLvl){
				loadLvl = false;
        		StartCoroutine(enterRuinsIE());
			}
		};
	}

    IEnumerator enterRuinsIE(){
        if(info.AudioOn) GameObject.Find("audio_enter_ruins").GetComponent<AudioSource>().Play(); 
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene("lvlB2", LoadSceneMode.Single);
    }

	public void catButton(){
        if(info.AudioOn) GameObject.Find("audio_cat").GetComponent<AudioSource>().Play();  
        cat_bg.SetActive(false);  
        cat_2_bg.SetActive(true);
        StartCoroutine(closeJungle());
    }

	public void trickHelpFunc(){
        trickHelpActive = true;
		//GameObject.Find("grass_bg").GetComponent<Animation>().Play();
		switch(sequence){
			case 0: LeftButtonAnim(); break;
			case 1: LeftButtonAnim(); break;
			case 2: RightButtonAnim(); break;
			case 3: LeftButtonAnim(); break;
			case 4: CentralButtonAnim(); break;
			case 5: LeftButtonAnim(); break;
			case 6: LeftButtonAnim(); break;
			case 7: RightButtonAnim(); break;
			case 8: CentralButtonAnim(); break;
		}
    }

	private void StopAnim(){
		switch(sequence){
			case 0: LeftButtonAnim(false); break;
			case 1: LeftButtonAnim(false); break;
			case 2: RightButtonAnim(false); break;
			case 3: LeftButtonAnim(false); break;
			case 4: CentralButtonAnim(false); break;
			case 5: LeftButtonAnim(false); break;
			case 6: LeftButtonAnim(false); break;
			case 7: RightButtonAnim(false); break;
			case 8: CentralButtonAnim(false); break;
		}
	}

	private void LeftButtonAnim(bool mode = true){
		//Debug.Log("LeftButtonAnim");
		if(mode){
			switch (leftLeverPos){
				case 1: levers[0].GetComponent<Animation>().Play(); break;
				case 2: levers[1].GetComponent<Animation>().Play(); break;
				case 3: levers[2].GetComponent<Animation>().Play(); break;
			}
		}else{
			switch (leftLeverPos){
				case 1: levers[0].GetComponent<Animation>().Stop(); levers[0].GetComponent<Image>().color = Color.white; break;
				case 2: levers[1].GetComponent<Animation>().Stop(); levers[1].GetComponent<Image>().color = Color.white; break;
				case 3: levers[2].GetComponent<Animation>().Stop(); levers[2].GetComponent<Image>().color = Color.white; break;
			}
		}
	}

	private void RightButtonAnim(bool mode = true){
		//Debug.Log("RightButtonAnim");
		if(mode){
			switch (rightLeverPos){
				case 1: levers[3].GetComponent<Animation>().Play(); break;
				case 2: levers[4].GetComponent<Animation>().Play(); break;
				case 3: levers[5].GetComponent<Animation>().Play(); break;
			}
		}else{
			switch (rightLeverPos){
				case 1: levers[3].GetComponent<Animation>().Stop(); levers[3].GetComponent<Image>().color = Color.white; break;
				case 2: levers[4].GetComponent<Animation>().Stop(); levers[4].GetComponent<Image>().color = Color.white; break;
				case 3: levers[5].GetComponent<Animation>().Stop(); levers[5].GetComponent<Image>().color = Color.white; break;
			}
		}
	}

	private void CentralButtonAnim(bool mode = true){
		//Debug.Log("CentralButtonAnim");
		if(mode){
			GameObject.Find("CentralButton").GetComponent<Animation>().Play();
		}
		else {
			GameObject.Find("CentralButton").GetComponent<Animation>().Stop();
			button_1.GetComponent<Image>().color = Color.white; 
		}
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

	IEnumerator trickHelp(float time = 45f){

        yield return new WaitForSeconds(time);
        trickHelpBut.SetActive(true);
		DialogStart();
    }

	private void DialogStart(){
		if(UnityEngine.Random.Range(0,2)==0){
            DialogGO.SetActive(true);
            List<string> randomDialog = new List<string>{"PhrasesInRuins_1H", "PhrasesInRuins_2H", "PhrasesInRuins_3H"};
            string dialogName = randomDialog[UnityEngine.Random.Range(0,3)];
            Debug.Log(dialogName);
            DialogGO.GetComponent<DialogView>().isRandom = false;
            DialogGO.GetComponent<DialogView>().DialogName = dialogName;
            DialogGO.GetComponent<DialogView>().StartDialogView();
        }
	}
}
