using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JungleRuins : MonoBehaviour
{
    // Start is called before the first frame update
    // 1 = sdgsdg
    // 2 = dsdsgsg
    // 3 = dsgddsgddsgddsgd

    private int mode = 0;
    private int position = 0;
    private bool ActiveCentralButton = true;
    private string[] sequence = {"sdgsdg", "dsdsgsg", "dsgddsgddsgddsgd"};
    public GameObject sym_l_bg, sym_r_bg, center_bg, LoadLvl_JungleRuins;
    public GameObject cat_bg, cat_2_bg, trickHelpBut;
    private Animation grass_anim, djembe_anim, skull_anim;
    private bool trickHelpActive = false;
    public GameObject DialogGO;
    void Start()
    {
        MapCrossPushHide.firstMeet[0] = false;
        GameObject.Find("BG").GetComponent<MapCrossPushHide>().SetTargets();
        Debug.Log("Set MapCrossPushHide.firstMeet[0] = false: " + MapCrossPushHide.firstMeet[0]);
        ActiveCentralButton = true;
        if(info.AudioOn) GameObject.Find("audio_jungleruins_f").GetComponent<AudioSource>().Play();
        grass_anim = GameObject.Find("grass_bg").GetComponent<Animation>();
        djembe_anim = GameObject.Find("djembe_bg").GetComponent<Animation>();
        skull_anim = GameObject.Find("skull_bg").GetComponent<Animation>();
        StartCoroutine(trickHelp());
        info.Save();
    }
    private void OnEnable() {
        cat_bg.SetActive(true);  
        cat_2_bg.SetActive(false);
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
                        if(info.AudioOn) GameObject.Find("audio_magic_light").GetComponent<AudioSource>().Play();
                        mode = 1;
                        position = 0;
                        trickHelpBut.SetActive(false);
                        trickHelpStop(symb, true);
                        StartCoroutine(trickHelp(60f));
                    break;
                case 1: sym_r_bg.SetActive(true);
                        if(info.AudioOn) GameObject.Find("audio_magic_light").GetComponent<AudioSource>().Play();
                        mode = 2;
                        position = 0;
                        trickHelpBut.SetActive(false);
                        trickHelpStop(symb, true);
                        StartCoroutine(trickHelp(80f));
                    break;
                case 2: center_bg.SetActive(true);
                        if(info.AudioOn) GameObject.Find("audio_magic_light").GetComponent<AudioSource>().Play();
                        LoadLvl_JungleRuins.SetActive(true);
                        GameObject.Find("audio_jungleruins_f").GetComponent<AudioSource>().Play();
                        GameObject.Find("audio_jungleruins_f").GetComponent<AudioSource>().loop = true;
                        trickHelpBut.SetActive(false);
                        trickHelpStop(symb, true);
                        //StartCoroutine(trickHelp());
                    break;
                default: Debug.Log("Error");
                    break;
            }
        }else{
            if (sequence[mode][position] == symb){
                position++;
                trickHelpStop(symb);
            }else{
                //lose
                position = 0;
            }
        }
    }

    public void trickHelpFunc(){
        trickHelpActive = true;
        switch (sequence[mode][position])
        {
            case 's': skull_anim.Play();
                break;
            case 'd': djembe_anim.Play();
                break;
            case 'g': grass_anim.Play();
                break;
            default: Debug.Log("Error: trickHelpFunc()");
                break;
        }
        //trickHelpBut.SetActive(false);
    }

    private void trickHelpStop(char symb, bool stopB = false){
        switch (symb)
        {
            case 's': skull_anim.Stop();
                GameObject.Find("skull_bg").GetComponent<Image>().color = Color.white;
                //if(!stopB && trickHelpActive) trickHelpFunc();
                break;
            case 'd': djembe_anim.Stop();
                GameObject.Find("djembe_bg").GetComponent<Image>().color = Color.white;
                //if(!stopB && trickHelpActive) trickHelpFunc();
                break;
            case 'g': grass_anim.Stop();
                GameObject.Find("grass_bg").GetComponent<Image>().color = Color.white;
                //if(!stopB && trickHelpActive) trickHelpFunc();
                break;
            default: Debug.Log("Error: trickHelpStop()");
                if(!stopB && trickHelpActive) trickHelpFunc();
                break;
        }
        if(stopB) trickHelpActive = false;
    }

    public void LoadLvl(){
        if(ActiveCentralButton) StartCoroutine(enterRuinsIE());
        ActiveCentralButton = false;
    }

    IEnumerator enterRuinsIE(){
        if(info.AudioOn) GameObject.Find("audio_enter_ruins").GetComponent<AudioSource>().Play(); 
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene("lvlB1", LoadSceneMode.Single);
    }

    IEnumerator closeJungle(){
        yield return new WaitForSeconds(0.7f);
        GameObject.Find("JungleRuins").SetActive(false);
    }

    IEnumerator trickHelp(float time = 30f){
        yield return new WaitForSeconds(time);
        trickHelpBut.SetActive(true);
        DialogStart();
    }

    private void DialogStart(){
		if(UnityEngine.Random.Range(0,2)==0){
            DialogGO.SetActive(true);
            List<string> randomDialog = new List<string>{"PhrasesInRuins_1H", "PhrasesInRuins_2H", "PhrasesInRuins_3H"};
            string dialogName = randomDialog[UnityEngine.Random.Range(0,3)];
            Debug.Log(dialogName);
            DialogGO.GetComponent<DialogView>().isRandom = false;
            DialogGO.GetComponent<DialogView>().DialogName = dialogName;
            DialogGO.GetComponent<DialogView>().StartDialogView();
        }
	}
    
}