using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public GameObject Game;
    private Animator moneyMenuAnim, trickMenuAnim;
    public bool actionEnableTH = true, actionEnableM = true;

    private void Start() {
        moneyMenuAnim = GameObject.Find("money_menu").GetComponent<Animator>();
        trickMenuAnim = GameObject.Find("trickHelp_menu").GetComponent<Animator>();
    }

    public void Continue()
    {
        info.isPause = false;
        if(info.AudioOn)   GameObject.Find("Button_click").GetComponent<AudioSource>().Play();
        bool isOpenMoney = moneyMenuAnim.GetBool("open");
        bool isOpenTrick = trickMenuAnim.GetBool("open");
		if(isOpenMoney) { moneyMenuAnim.SetBool("open",!isOpenMoney); }
		if(isOpenTrick) { trickMenuAnim.SetBool("open",!isOpenTrick); }
        if(isOpenMoney || isOpenTrick){
            if(info.AudioOn) GameObject.Find("audio_buy_menu").GetComponent<AudioSource>().Play();
            StartCoroutine(ContinueIE(0.7f));
        }else{
            StartCoroutine(ContinueIE(0));
        }
    }

    IEnumerator ContinueIE(float timer){
        Time.timeScale = 1;
        yield return new WaitForSeconds(timer);

        //Debug.LogWarning("actionEnableTH = " + actionEnableTH + "; actionEnableM = "+actionEnableM);

        if(!(actionEnableTH && actionEnableM)){
            StartCoroutine(ContinueIE(0.1f));
        }else{

            /*21.09.2019*/
            if(colorBall.AudioPlay){
                int tmp = Game.GetComponent<colorBall>().AudioBall;
                if(info.AudioOn) GameObject.Find(tmp.ToString()).GetComponent<AudioSource>().Play();
            }
            /* */
            Game.SetActive(true);
            GameObject.Find("Pause").SetActive(false);

        }
    }

    public void OnTheMap()
    {
        string tmp = SceneManager.GetActiveScene().name;
        endlessScore.scoreNum = 0;
        Time.timeScale = 1;
        if(info.AudioOn)   GameObject.Find("Button_click").GetComponent<AudioSource>().Play();
        if(tmp.Substring(3,1)== "E" || tmp.Substring(3,1)== "C"){
            SceneManager.LoadScene("menu", LoadSceneMode.Single);
        }else{
            SceneManager.LoadScene("Map", LoadSceneMode.Single);
        }
    }

    public void Exit()
    {
        if(info.AudioOn)   GameObject.Find("Button_click").GetComponent<AudioSource>().Play();
        info.Save();
        Application.Quit();
    }
}
