using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

public class touch : MonoBehaviour
{
    private string objectTouch = "";
    public GameObject PauseMenu;
    public GameObject YourTurn, OpponentTurn;
    private GameObject OptionButton, OptionMusic, OptionSound;
    private Animator OptionsAnim;


    private void Start() {
        OptionButton = GameObject.Find("OptionButton");
        OptionMusic = GameObject.Find("OptionMusic");
        OptionSound = GameObject.Find("OptionSound");
        OptionsAnim = GameObject.Find("Options").GetComponent<Animator>();
    }
    void Update()
    {
        if (!info.activeRot && info.activeTouch && info.activeTouchBot) // Возможность касания
        {
            if (Input.GetMouseButtonDown(0)) // Если кнопку нажали
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    objectTouch = hit.collider.name; // Записывает имя объекта по которому каснулись
                    try{
                        int objectTouchInt = Int32.Parse(objectTouch);
                        if(objectTouchInt>=0){
                            if(!info.stat_balls.Contains(objectTouchInt)){
                                if(!spawn.Balls[objectTouchInt].GetComponent<ball>().busy){
                                    if(SceneManager.GetActiveScene().name != "lvl0"){
                                        /*info.*/setNextColor(spawn.ArrColor[objectTouchInt]);
                                        GetComponent<info>().Step();
                                        spawn.Balls[objectTouchInt].GetComponent<ball>().TouchThisF(); // Начинаем крутить шар, до которого каснулись
                                        info.activeRot = true;
                                        if(FindMaxWay.targetActive){
                                            GetComponent<FindMaxWay>().DestroyTarget();
                                        }
                                    }else{
                                        if(spawn.ArrColor[objectTouchInt]==info.winBall){
                                            /*info.*/setNextColor(spawn.ArrColor[objectTouchInt]);
                                            GetComponent<info>().Step();
                                            spawn.Balls[objectTouchInt].GetComponent<ball>().TouchThisF(); // Начинаем крутить шар, до которого каснулись
                                            info.activeRot = true;
                                            if(FindMaxWay.targetActive){
                                                GetComponent<FindMaxWay>().DestroyTarget();
                                            }
                                        }
                                    }
                                }
                            }else{
                                if(info.AudioOn) GameObject.Find("Audio_StatBall").GetComponent<AudioSource>().Play();
                            }
                        }
                    }catch{

                    }
                }
            }    
        }else{
            //Debug.Log("!info.activeRot= " + !info.activeRot + "info.activeTouch= " + info.activeTouch + "info.activeTouchBot= " + info.activeTouchBot);
        }         
    }

    public void PauseButton(){
        if(spawn.endSpawn){
            info.isPause = true;
            /*21.09.2019*/
            if(colorBall.AudioPlay){
                int tmp = GetComponent<colorBall>().AudioBall;
                GameObject.Find(tmp.ToString()).GetComponent<AudioSource>().Pause();
            }
            /* */
            OptionButton.transform.rotation = Quaternion.Euler(0, 0, 0);
            OptionMusic.transform.localScale = new Vector3(0f, 0f, 0f);
            OptionSound.transform.localScale = new Vector3(0f, 0f, 0f);
            YourTurn.transform.localPosition = new Vector3(YourTurn.transform.localPosition.x, -750f , YourTurn.transform.localPosition.z);
            OpponentTurn.transform.localPosition = new Vector3(OpponentTurn.transform.localPosition.x, -750f , OpponentTurn.transform.localPosition.z);
            GameObject.Find("Game").GetComponent<showDiff>().SetDefault();
            info.Save();
            if(info.AudioOn) GameObject.Find("Button_click").GetComponent<AudioSource>().Play();
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
            GameObject.Find("Game").SetActive(false);
        }
    }

    public void RebootButton(){
        if(!info.isEndless){
            info.Save();
            if(info.AudioOn)   GameObject.Find("Button_click").GetComponent<AudioSource>().Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }else{
            lvlEndlessConfig.isReboot = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void setNextColor(int color){
        info.colorNextInt = color;
        switch(color){
            case 0: info.colorNext = info.ball_blue; break;
            case 1: info.colorNext = info.ball_yellow; break;
            case 2: info.colorNext = info.ball_green; break;
            case 3: info.colorNext = info.ball_red; break;
        }
    }
}