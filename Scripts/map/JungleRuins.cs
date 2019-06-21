using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JungleRuins : MonoBehaviour
{
    // Start is called before the first frame update
    // 1 = sdgsdg
    // 2 = dsdsgsg
    // 3 = dsgddsgddsgddsgd

    private int mode = 0;
    private int position = 0;
    private string[] sequence = {"sdgsdg", "dsdsgsg", "dsgddsgddsgddsgd"};
    public GameObject sym_l_bg, sym_r_bg, center_bg, LoadLvl_JungleRuins;
    public GameObject cat_bg, cat_2_bg;
    void Start()
    {
        if(info.AudioOn) GameObject.Find("audio_jungleruins_f").GetComponent<AudioSource>().Play();
    }

    public void musicButton(){
        switch (mode)
        {
            case 0: if(info.AudioOn) GameObject.Find("audio_jungleruins_1").GetComponent<AudioSource>().Play();
                break;
            case 1: if(info.AudioOn) GameObject.Find("audio_jungleruins_2").GetComponent<AudioSource>().Play();
                break;
            case 2: if(info.AudioOn) GameObject.Find("audio_jungleruins_3").GetComponent<AudioSource>().Play();
                break;
            default: if(info.AudioOn) GameObject.Find("audio_jungleruins_f").GetComponent<AudioSource>().Play();
                break;
        }
    }
    public void skullButton(){
        if(info.AudioOn) GameObject.Find("audio_jungleruins_skull").GetComponent<AudioSource>().Play();
        button_processing('s');
    }
    public void grassButton(){
        if(info.AudioOn) GameObject.Find("audio_jungleruins_grass").GetComponent<AudioSource>().Play();
        button_processing('g');
    }
    public void djembeButton(){
        if(info.AudioOn) GameObject.Find("audio_jungleruins_djembe").GetComponent<AudioSource>().Play();
        button_processing('d');        
    }

    public void catButton(){
        if(info.AudioOn) GameObject.Find("audio_cat").GetComponent<AudioSource>().Play();  
        cat_bg.SetActive(false);  
        cat_2_bg.SetActive(true);
        StartCoroutine(closeJungle());
    }

    private void button_processing(char symb){
        Debug.Log(position);
        if (position == sequence[mode].Length-1 && sequence[mode][position] == symb){
            switch (mode)
            {
                case 0: sym_l_bg.SetActive(true);
                        mode = 1;
                        position = 0;
                    break;
                case 1: sym_r_bg.SetActive(true);
                        mode = 2;
                        position = 0;
                    break;
                case 2: center_bg.SetActive(true);
                        LoadLvl_JungleRuins.SetActive(true);
                    break;
                default: Debug.Log("Error");
                    break;
            }
        }else{
            if (sequence[mode][position] == symb) position++;
            else{
                //lose
                position = 0;
            }
        }
    }

    public void LoadLvl(){
        SceneManager.LoadScene("lvlB1", LoadSceneMode.Single);
    }

    IEnumerator closeJungle(){
        yield return new WaitForSeconds(0.7f);
        GameObject.Find("JungleRuins").SetActive(false);
    }
    
}