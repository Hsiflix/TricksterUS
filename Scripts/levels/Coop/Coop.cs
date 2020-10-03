using UnityEngine;
using UnityEngine.UI;

public class Coop : MonoBehaviour
{
    public GameObject CanvasBot;
    public GameObject Player1Name, Player2Name;
    public Sprite vingette1, vingette2, vingette3, vingette4, vingette5;
    static public int trickHelpNum = 0;

    void Start()
    {
        switch (info.field_size)
        {
            case 3: GameObject.Find("VIGNETTE").GetComponent<Image>().sprite = vingette1; break;
            case 4: GameObject.Find("VIGNETTE").GetComponent<Image>().sprite = vingette1; break;
            case 5: GameObject.Find("VIGNETTE").GetComponent<Image>().sprite = vingette1; break;
            case 6: GameObject.Find("VIGNETTE").GetComponent<Image>().sprite = vingette2; break;
            case 7: GameObject.Find("VIGNETTE").GetComponent<Image>().sprite = vingette3; break;
            case 8: GameObject.Find("VIGNETTE").GetComponent<Image>().sprite = vingette4; break;
            case 9: GameObject.Find("VIGNETTE").GetComponent<Image>().sprite = vingette5; break;
            case 10: GameObject.Find("VIGNETTE").GetComponent<Image>().sprite = vingette5; break;
            default: GameObject.Find("VIGNETTE").GetComponent<Image>().sprite = vingette5; break;
        }
        CanvasBot.SetActive(true);
        if(coopMenu.player1Name.Substring(0,1) == coopMenu.player2Name.Substring(0,1)){
            Player1Name.GetComponent<Text>().text = coopMenu.player1Name.Substring(0,1)+'1';
            Player2Name.GetComponent<Text>().text = coopMenu.player2Name.Substring(0,1)+'2';
        }else{
            Player1Name.GetComponent<Text>().text = coopMenu.player1Name.Substring(0,1);
            Player2Name.GetComponent<Text>().text = coopMenu.player2Name.Substring(0,1);
        }
    }
}
