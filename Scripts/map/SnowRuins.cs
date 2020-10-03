using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SnowRuins : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sym_bg, LoadLvl_SnowRuins;
    public GameObject cat_bg, cat_2_bg;
    public GameObject sym_bg_1, sym_bg_2, sym_bg_3;
    private bool[] skulls = {false,false,false};
    private bool ActiveCentralButton = true;
    private void OnEnable() {
        cat_bg.SetActive(true);  
        cat_2_bg.SetActive(false);
    }
    void Start()
    {
        //if(info.AudioOn) GameObject.Find("audio_jungleruins_f").GetComponent<AudioSource>().Play();
        MapCrossPushHide.firstMeet[2] = false;
        GameObject.Find("BG").GetComponent<MapCrossPushHide>().SetTargets();
        ActiveCentralButton = true;
        info.Save();
    }

    public void skull1Button(){
        if(info.AudioOn) GameObject.Find("audio_magic_light").GetComponent<AudioSource>().Play();
        sym_bg_1.SetActive(true);
        skulls[0] = true;
        processing();
    }
    public void skull2Button(){
        if(info.AudioOn) GameObject.Find("audio_magic_light").GetComponent<AudioSource>().Play();
        sym_bg_2.SetActive(true);
        skulls[1] = true;
        processing();
    }
    public void skull3Button(){
        if(info.AudioOn) GameObject.Find("audio_magic_light").GetComponent<AudioSource>().Play();
        sym_bg_3.SetActive(true);
        skulls[2] = true;
        processing();
    }

    public void catButton(){
        if(info.AudioOn) GameObject.Find("audio_cat").GetComponent<AudioSource>().Play();  
        cat_bg.SetActive(false);  
        cat_2_bg.SetActive(true);
        StartCoroutine(closeSnow());
    }

    private void processing(){
        if (skulls[0]&&skulls[1]&&skulls[2]){
            sym_bg.SetActive(true);
            if(info.AudioOn) GameObject.Find("audio_magic_light_all").GetComponent<AudioSource>().Play();
            LoadLvl_SnowRuins.SetActive(true);
        }
    }

    public void LoadLvl(){
        if(ActiveCentralButton) StartCoroutine(enterRuinsIE());
        ActiveCentralButton = false;
    }

    IEnumerator enterRuinsIE(){
        if(info.AudioOn) GameObject.Find("audio_enter_ruins").GetComponent<AudioSource>().Play(); 
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene("lvlB3", LoadSceneMode.Single);
    }

    IEnumerator closeSnow(){
        yield return new WaitForSeconds(0.7f);
        GameObject.Find("SnowRuins").SetActive(false);
    }
}