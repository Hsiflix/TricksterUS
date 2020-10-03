using UnityEngine;
using UnityEngine.UI;

public class optionsMenu : MonoBehaviour
{
    public GameObject logo, langRuBut, langEnBut, turnOffIntro, Tables;
    public GameObject Endless, Coop, NewGame, CoopInputField;
    public Sprite[] logos;
    public mainMenu mainMenuScr;
    private int logoNum = 0;

    private void Start() {
        if(info.intro){
            turnOffIntro.GetComponent<Image>().color = new Color(1,1,1,0);
        }else{
            turnOffIntro.GetComponent<Image>().color = new Color(1,1,1,1);
        }
        if(info.lang == 0){
            langRuBut.SetActive(true);
            langEnBut.SetActive(false);
        }else{
            langRuBut.SetActive(false);
            langEnBut.SetActive(true);
        }
    }

    public void logoTap(){
        if (logoNum < logos.Length-1){
            logoNum++;
        }else{
            logoNum = 0;
        }
        logo.GetComponent<Image>().sprite = logos[logoNum];
    }

    public void LangRU(){
        langRuBut.SetActive(false);
        langEnBut.SetActive(true);
        info.lang = 1;
        GetComponent<RUENGImageChanger>().Start();
        Tables.GetComponent<RUENGTablesChanger>().Start();
        Endless.GetComponent<RUENGImageChanger>().Start();
        Coop.GetComponent<RUENGImageChanger>().Start();
        NewGame.GetComponent<RUENGImageChanger>().Start();
        CoopInputField.GetComponent<RUENGTextChanger>().Start();
        info.Save();
    }

    public void LangEN(){
        langRuBut.SetActive(true);
        langEnBut.SetActive(false);
        info.lang = 0;
        GetComponent<RUENGImageChanger>().Start();
        Tables.GetComponent<RUENGTablesChanger>().Start();
        Endless.GetComponent<RUENGImageChanger>().Start();
        Coop.GetComponent<RUENGImageChanger>().Start();
        NewGame.GetComponent<RUENGImageChanger>().Start();
        CoopInputField.GetComponent<RUENGTextChanger>().Start();
        info.Save();
    }

    public void turnOffIntroFunc(){
        if(info.intro){
            info.intro = false;
            turnOffIntro.GetComponent<Image>().color = new Color(1,1,1,1);
        }else{
            info.intro = true;
            turnOffIntro.GetComponent<Image>().color = new Color(1,1,1,0);
        }
        info.Save();
    }

    public void TwitterBtn(){
        if(info.lang == 0){
            Application.OpenURL("https://twitter.com/MetalDarter"); //Twitter
        }else{
            Application.OpenURL("https://vk.com/public185736306"); //Vk
        }
    }

    public void InstagramBtn(){
        Application.OpenURL("https://www.instagram.com/albertgcrea");
    }

    public void YouTubeBtn(){
        Application.OpenURL("https://www.youtube.com/channel/UCCIrVm40A_f4EbxGLuJZe0w");
    }

    public void RidAds(){
        if(!info.noAds)
            mainMenuScr.OptionsRidAds();
    }

    public void FiveStars(){
        mainMenuScr.OptionsFiveStars();
    }
}
