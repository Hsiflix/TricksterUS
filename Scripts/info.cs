using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class info : MonoBehaviour
{
    static public int steps; //Кол-во шагов
    static public int money = 11; //Кол-во монет
    static public bool stepGo = false; //Шагометр
    static public int timersecond; //Кол-во времени
    static public bool timerGo = false; //Таймер
    static public int winBall; //Победный цвет
    static public int field_size; //Размер поля
    static public int colorNextInt; //Номер цвета хода
    static public int lvl = 18; //Текущий уровень
    static public int max_lvl = 18; //Последний уровень
    static public bool AudioOn = true; //Включение/выключение звука
    static public Sprite colorNext; //Цвет хода
    static public Sprite ball_blue, ball_yellow, ball_green, ball_red, ball_tort; //Спрайты шаров
    static public GameObject ballPrefab; //Префаб шара
    static public bool activeRot = false;
    static public bool activeTouch = true;
    private bool activeRotCheck = false;
    static public int queue = 0;
    static public int[] ballColors;
    static public int[] stat_balls;
    static public int botColor = 0;
    static public bool botActive = false;
    private float secondgametime;
    static public Text timerText, stepsText;
    private int timerLimitForBlink = 10;
    private Color camColor;
    private Camera cam;
    public GameObject LoseMenu;
    public GameObject WinMenu;
    private bool botTurn = false;

    void Start(){
        activeRot = false;
        activeTouch = true;
        activeRotCheck = false;
        queue = 0;
        ballColors = new int[4];
        timerText = GameObject.Find("Timer").GetComponent<Text>();
        stepsText = GameObject.Find("Steps").GetComponent<Text>();
        cam = GameObject.Find("GameCamera").GetComponent<Camera>();
        camColor = cam.backgroundColor;
    }

    static public void setNextColor(int color){
        colorNextInt = color;
        switch(color){
            case 0: colorNext = ball_blue; break;
            case 1: colorNext = ball_yellow; break;
            case 2: colorNext = ball_green; break;
            case 3: colorNext = ball_red; break;
        }
    }

    public void Update(){
        //CHECK QUEUE, WIN AND STEPS_LOSE
        if(activeRotCheck && queue == 0){
            activeRot = false;
            if(botActive){
                if(botTurn){
                    CanvasBot.your_turn_bt = true;
                    botTurn = false;
                }else{
                    CanvasBot.opponent_turn_bt = true;
                    botTurn = true;
                }
            }
            if(ballColors[winBall] == field_size * field_size){
                WinMenu.SetActive(true);
                GameObject.Find("Game").SetActive(false);
            }else{
                if(stepGo && steps == 0){
                    if(!botActive){
                        Debug.Log("STEPS_LOSE");
                        LoseMenu.SetActive(true);
                        GameObject.Find("Game").SetActive(false);
                    }else{
                        int botCount = 0;
                        int playerCount = 0;
                        for (int i = 0; i < field_size * field_size; i++){
                            if(spawn.ArrColor[i] == winBall) playerCount++;
                            else if(spawn.ArrColor[i] == botColor) botCount++;
                        }
                        if(playerCount > botCount){
                            WinMenu.SetActive(true);
                            GameObject.Find("Game").SetActive(false);
                        }else{
                            LoseMenu.SetActive(true);
                            GameObject.Find("Game").SetActive(false);
                        }
                    }
                }
            }
        }
        if(activeRotCheck) activeRotCheck = false;
        if(activeRot && queue == 0){
            activeRotCheck = true;
        }
        //TIMER AND TIMER_LOSE
        secondgametime += Time.deltaTime;
        if (secondgametime >= 1)
        {
            secondgametime = 0;
            if(timerGo) timersecond -= 1;
            else timersecond++;
            if(timersecond < 1000) timerText.text = ""+timersecond;
            else timerText.text = "999+";
            if(timersecond < timerLimitForBlink && info.timerGo){
                if (timersecond % 2 == 1){
                    cam.backgroundColor = Color.red;//new Color(160 / 255f, 61 / 255f, 45 / 255f); //Color.red
                    timerText.color = Color.red;
                }
                else {
                    cam.backgroundColor = camColor; //72A9AD
                    timerText.color = Color.white;
                }
            }else{
                cam.backgroundColor = camColor; //72A9AD
                timerText.color = Color.white;
            }
        }
        if (timerGo && timersecond == 0)
        {
            if(!botActive && ballColors[winBall] != field_size * field_size){
                Debug.Log("TIMER_LOSE");
                LoseMenu.SetActive(true);
                GameObject.Find("Game").SetActive(false);
            }else{
                int botCount = 0;
                int playerCount = 0;
                for (int i = 0; i < field_size * field_size; i++){
                    if(spawn.ArrColor[i] == winBall) playerCount++;
                    else if(spawn.ArrColor[i] == botColor) botCount++;
                }
                if(playerCount > botCount){
                    WinMenu.SetActive(true);
                    GameObject.Find("Game").SetActive(false);
                }else{
                    LoseMenu.SetActive(true);
                    GameObject.Find("Game").SetActive(false);
                }
            }
        }
    }

    public void Step(){
        if(stepGo){
            steps--;
        } else{
            steps++;
        }
        if(steps < 1000) stepsText.text = ""+steps;
            else stepsText.text = "999+";
        if(steps <= 5 && info.stepGo) stepsText.color = Color.red;
    }

    public void ShowDif(int valueS, int modeS){ //modeS = {1=UpTime, 2=UpStep, 3=DwTime, 4=DwStep}
        StartCoroutine(ShowDifIE(valueS, modeS));
    }

    IEnumerator ShowDifIE(int valueS, int modeS){
        switch (modeS){ //modeS = {1=UpTime, 2=UpStep, 3=DwTime, 4=DwStep}
            case 1: timerText.color = Color.green;
                    timerText.text = "+"+valueS;
                    yield return new WaitForSeconds(1.5f);
                    timerText.color = Color.white;
                    timerText.text = ""+timersecond;
                break;
            case 2: stepsText.color = Color.green;
                    stepsText.text = "+"+valueS;
                    yield return new WaitForSeconds(1.5f);
                    stepsText.color = Color.white;
                    if(steps < 1000) stepsText.text = ""+steps;
                    else stepsText.text = "999+";
                break;
            case 3: timerText.color = Color.red;
                    timerText.text = ""+timersecond;
                    yield return new WaitForSeconds(1.5f);
                    timerText.color = Color.white;
                break;
            case 4: stepsText.color = Color.red;
                    if(steps < 1000) stepsText.text = ""+steps;
                    else stepsText.text = "999+";
                    yield return new WaitForSeconds(1.5f);
                    stepsText.color = Color.white;
                break;
        }
    }

    IEnumerator BlinkIE(int modeS){
        if(timersecond <= timerLimitForBlink)
        yield return new WaitForSeconds(1.5f);
    }

    public static void Save()
    {
        string info = lvl.ToString() + "*" + money.ToString() + "*" + AudioOn.ToString();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
        bf.Serialize(file, info);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            string info = (string)bf.Deserialize(file);
            Debug.Log("Load: "+ info);
            string[] infos = info.Split('*');
            lvl = int.Parse(infos[0]);
            money = int.Parse(infos[1]);
            if(infos[2]=="True")
            AudioOn = true;
            else AudioOn = false;
            file.Close();
        }
    }
}