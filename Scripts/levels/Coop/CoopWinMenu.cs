using UnityEngine;
using UnityEngine.UI;

public class CoopWinMenu : MonoBehaviour
{
    public GameObject WinBallPlayer1, WinBallPlayer2, Player1Name, Player2Name, Player1Count, Player2Count;
    public Sprite ball_blue, ball_yellow, ball_green, ball_red;
    public GameObject CoopWinnerText;
    void Start()
    {
        switch(coopMenu.player1Color){
            case 0: WinBallPlayer1.GetComponent<Image>().sprite = ball_blue; 
                break;
            case 1: WinBallPlayer1.GetComponent<Image>().sprite = ball_yellow;
                break;
            case 2: WinBallPlayer1.GetComponent<Image>().sprite = ball_green;
                break;
            case 3: WinBallPlayer1.GetComponent<Image>().sprite = ball_red; 
                break;
        }
        switch(coopMenu.player2Color){
            case 0: WinBallPlayer2.GetComponent<Image>().sprite = ball_blue; 
                break;
            case 1: WinBallPlayer2.GetComponent<Image>().sprite = ball_yellow;
                break;
            case 2: WinBallPlayer2.GetComponent<Image>().sprite = ball_green;
                break;
            case 3: WinBallPlayer2.GetComponent<Image>().sprite = ball_red; 
                break;
        }
        if(coopMenu.player1Name.Substring(0,1) == coopMenu.player2Name.Substring(0,1)){
            Player1Name.GetComponent<Text>().text = coopMenu.player1Name.Substring(0,1)+'1';
            Player2Name.GetComponent<Text>().text = coopMenu.player2Name.Substring(0,1)+'2';
        }else{
            Player1Name.GetComponent<Text>().text = coopMenu.player1Name.Substring(0,1);
            Player2Name.GetComponent<Text>().text = coopMenu.player2Name.Substring(0,1);
        }
        Player1Count.GetComponent<Text>().text = info.ballColors[coopMenu.player1Color].ToString();
        Player2Count.GetComponent<Text>().text = info.ballColors[coopMenu.player2Color].ToString();
        if(info.ballColors[coopMenu.player1Color]>info.ballColors[coopMenu.player2Color]){
            CoopWinnerText.GetComponent<Text>().text = coopMenu.player1Name;
        }else{
            CoopWinnerText.GetComponent<Text>().text = coopMenu.player2Name;
        }
    }
}
