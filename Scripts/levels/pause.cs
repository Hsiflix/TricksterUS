using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pause : MonoBehaviour
{
    public GameObject Game;

    private void Start() {
        /*Text moneyText = GameObject.Find("money_text").GetComponent<Text>();
        info.Load();
        if(info.money < 1000){
            moneyText.text = info.money.ToString();
        }else if(info.money < 1000000){
            string tmp = info.money.ToString().Substring(0,info.money.ToString().Length-3)+'.';
            tmp += info.money.ToString().Substring(info.money.ToString().Length-3,1)+'k';
            moneyText.text = tmp;
        }else{
            string tmp = info.money.ToString().Substring(0,1)+'.';
            tmp += info.money.ToString().Substring(1,1)+"kk+";
            moneyText.text = tmp;
        }*/
    }

    public void Continue()
    {
        Time.timeScale = 1;
        if(info.AudioOn)   GameObject.Find("Button_click").GetComponent<AudioSource>().Play();
        Game.SetActive(true);
        /*Text trickHelpTextLvl = GameObject.Find("TrickHelpCount").GetComponent<Text>();
        if(info.trickHelpCount < 10){
            trickHelpTextLvl.text = info.trickHelpCount.ToString();
        }else{
            trickHelpTextLvl.text = "9+";
        }*/
        GameObject.Find("Pause").SetActive(false);
    }

    public void OnTheMap()
    {
        Time.timeScale = 1;
        if(info.AudioOn)   GameObject.Find("Button_click").GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Map", LoadSceneMode.Single);
    }

    public void Exit()
    {
        if(info.AudioOn)   GameObject.Find("Button_click").GetComponent<AudioSource>().Play();
        Application.Quit();
    }
}
