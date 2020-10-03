using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coopMenu : MonoBehaviour
{
    public GameObject coopOK, CoopEnteredText;
    public GameObject CoopTarget1, CoopTarget2, CoopTarget3, CoopTarget4; //BLUE,YELLOW,RED,GREEN
    public GameObject mainMenu;
    static public int player1Color, player2Color;
    static public string player1Name, player2Name;
    private bool first = true;
    //BLUE,YELLOW,GREEN,RED

    private void OnEnable() {
        first = true;
        TargetOff();
        CoopTarget1.SetActive(true);
        player1Color = 0;
    }
    public void SetBlue(){
        //Debug.Log("SetBlue");
        if(first){
            TargetOff();
            player1Color = 0; 
            CoopTarget1.SetActive(true);
        }else{
            if(player1Color!=0){
                TargetOff();
                player2Color = 0;
                CoopTarget1.SetActive(true);
            }
        }
    }
    public void SetYellow(){
        //Debug.Log("SetYellow");
        if(first){
            TargetOff();
            player1Color = 1;
            CoopTarget2.SetActive(true);
        }else{
            if(player1Color!=1){
                TargetOff();
                player2Color = 1;
                CoopTarget2.SetActive(true);
            }
        }
    }
    public void SetRed(){
        //Debug.Log("SetRed");
        if(first){
            TargetOff();
            player1Color = 3;
            CoopTarget3.SetActive(true);
        }else{
            if(player1Color!=3){
                TargetOff();
                player2Color = 3;
                CoopTarget3.SetActive(true);
            }
        }
    }
    public void SetGreen(){
        //Debug.Log("SetGreen");
        if(first){
            TargetOff();
            player1Color = 2;
            CoopTarget4.SetActive(true);
        }else{
            if(player1Color!=2){
                TargetOff();
                player2Color = 2;
                CoopTarget4.SetActive(true);
            }
        }
    }

    public void CoopOK(){
        if(first){
            player1Name = CoopEnteredText.GetComponent<InputField>().text;
            if(player1Name == "") player1Name = "Player1";
            if(player1Color == 0){
                TargetOff();
                CoopTarget2.SetActive(true);
                player2Color = 1;
            }else{
                TargetOff();
                CoopTarget1.SetActive(true);
                player2Color = 0;
            }
            CoopEnteredText.GetComponent<InputField>().text = "";
            first = false;
        }else{
            player2Name = CoopEnteredText.GetComponent<InputField>().text;
            if(player2Name == "") player2Name = "Player2";
            mainMenu.GetComponent<mainMenu>().CoopRun();
        }
    }

    public void TargetOff(){
        CoopTarget1.SetActive(false);
        CoopTarget2.SetActive(false);
        CoopTarget3.SetActive(false);
        CoopTarget4.SetActive(false);
    }
}
