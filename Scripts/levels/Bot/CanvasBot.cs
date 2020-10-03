using UnityEngine;
using UnityEngine.UI;

public class CanvasBot : MonoBehaviour {
	static public bool turn_bt = true;
	public GameObject YourTurn_score, OpponentTurn_score, YourTurn_score_Text, OpponentTurn_score_Text;

	//=================================================================================================
	private bool isPlayerTurn = true;
	public Animation your_turn_anim, opponent_turn_anim;


	void Start(){
		info.activeTouchBot = true;
		switch (info.winBall)
		{
			case 0: YourTurn_score.GetComponent<Image>().color = new Color(0.3915094f,0.4214188f,1f); break;
			case 1: YourTurn_score.GetComponent<Image>().color = new Color(1f,1f,0.25f); break;
			case 2: YourTurn_score.GetComponent<Image>().color = new Color(0.25f,1f,0.25f); break;
			case 3: YourTurn_score.GetComponent<Image>().color = new Color(1f,0.25f,0.25f); break;			
		}
		switch (info.botColor)
		{
			case 0: OpponentTurn_score.GetComponent<Image>().color = new Color(0.3915094f,0.4214188f,1f); break;
			case 1: OpponentTurn_score.GetComponent<Image>().color = new Color(1f,1f,0.25f); break;
			case 2: OpponentTurn_score.GetComponent<Image>().color = new Color(0.25f,1f,0.25f); break;
			case 3: OpponentTurn_score.GetComponent<Image>().color = new Color(1f,0.25f,0.25f); break;			
		}
		if(info.isCoop){
			switch (coopMenu.player2Color)
			{
				case 0: OpponentTurn_score.GetComponent<Image>().color = new Color(0.3915094f,0.4214188f,1f); break;
				case 1: OpponentTurn_score.GetComponent<Image>().color = new Color(1f,1f,0.25f); break;
				case 2: OpponentTurn_score.GetComponent<Image>().color = new Color(0.25f,1f,0.25f); break;
				case 3: OpponentTurn_score.GetComponent<Image>().color = new Color(1f,0.25f,0.25f); break;			
			}
		}
		isPlayerTurn = false;
		your_turn_anim.Play();
	}

	public void CallCanvasBot(){
		Debug.LogWarning("CallCanvasBot");
		info.activeTouchBot = false;
		if(isPlayerTurn){
			YourTurn_score_Text.GetComponent<Text>().text = info.ballColors[info.winBall].ToString();
			if(info.isCoop) switch(info.winBall){
                case 0: GameObject.Find("Outline").GetComponent<Image>().color = Color.blue; 
                break;
                case 1: GameObject.Find("Outline").GetComponent<Image>().color = Color.yellow;
                break;
                case 2: GameObject.Find("Outline").GetComponent<Image>().color = Color.green; 
                break;
                case 3: GameObject.Find("Outline").GetComponent<Image>().color = Color.red; 
                break;
            }
			//Debug.Log("your_turn_anim.Play()");
			your_turn_anim.Play();
		}else{
			if(info.isCoop){ 
				OpponentTurn_score_Text.GetComponent<Text>().text = info.ballColors[coopMenu.player2Color].ToString();
			 	switch(coopMenu.player2Color){
					case 0: GameObject.Find("Outline").GetComponent<Image>().color = Color.blue; 
					break;
					case 1: GameObject.Find("Outline").GetComponent<Image>().color = Color.yellow;
					break;
					case 2: GameObject.Find("Outline").GetComponent<Image>().color = Color.green; 
					break;
					case 3: GameObject.Find("Outline").GetComponent<Image>().color = Color.red; 
					break;
          		}
			}else OpponentTurn_score_Text.GetComponent<Text>().text = info.ballColors[info.botColor].ToString();
			//Debug.Log("opponent_turn_anim.Play();");
			opponent_turn_anim.Play();
		}
		turn_bt = isPlayerTurn;
		isPlayerTurn = !isPlayerTurn;
	}
}