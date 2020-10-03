using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class tutorial_map : MonoBehaviour
{
    public GameObject training_0, training_1;
    public GameObject training_0_text, training_1_text;
    public Sprite points;
    public GameObject tutYesNo;
    public GameObject Sand;
    public GameObject Arrow;
    public GameObject CloudAnim;
    Texts tutorial_map_texts, tutorial_location_texts;

    private void Start() {
        tutorial_map_texts = new Texts("tutorial_map");
        tutorial_location_texts = new Texts("tutorial_location");
        if(info.tutorial && info.lvl == 0){
            training_0_text.GetComponent<Text>().text = tutorial_map_texts.tutorial_map.ReturnText();
            training_0.SetActive(true);
        }
    }

    public void Training_0_field(){
        string tmp = tutorial_map_texts.tutorial_map.ReturnText();
        if(tmp!=""){
            training_0_text.GetComponent<Text>().text = tmp;
        }else{
            training_0.SetActive(false);
        }
    }

    public void Training_1_field(){
        string tmp = tutorial_location_texts.tutorial_location.ReturnText();
        if(tmp!=""){
            training_1_text.GetComponent<Text>().text = tmp;
        }else{
            training_1.SetActive(false);
        }
    }

    public void tutYes(){
        NameOf();
        ButLoadLvl._namelvl += "0";
        WinMenuMoney.moneyAdd = 100;
        Sand.SetActive(true);
        training_1_text.GetComponent<Text>().text = tutorial_location_texts.tutorial_location.ReturnText();
        training_1.SetActive(true);
    }
    
    public void tutNo(){
        if(info.lvl == 0) info.lvl = 1;
        info.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void lvl0()
    {
        info.tutorial = false;
        training_0.SetActive(false);
        tutYesNo.SetActive(true);
        WinMenuMoney.moneyAdd = 56;
        AchivementMap.achive_time = 30;
        AchivementMap.achive_step = 2;
        AchivementMap.achive_bugs = 0;
        AchivementMap.lvl = 0;
    }
    void NameOf()
    {
        if(info.AudioOn) GameObject.Find("audio_map_step").GetComponent<AudioSource>().Play();
        if(info.AudioOn) GameObject.Find("audio_bg").GetComponent<AudioSource>().volume = 0f;
        ButLoadLvl._namelvl = "lvl";
    }

    public void hideTaining_1(){
        training_1.SetActive(false);
        Arrow.SetActive(false);
        CloudAnim.SetActive(false);
    }
}
