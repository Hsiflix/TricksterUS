using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentTurnEvent : MonoBehaviour
{
    public void MainEvent(){
        //Debug.Log("OpponentTurn завершился!");
        if(info.isCoop) info.activeTouchBot = true;
        if(info.botActive) GameObject.Find("Game").GetComponent<Bot>().MainFunc();
    }
}
