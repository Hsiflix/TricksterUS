using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System;
using UnityEngine.UI;

public class spawn : MonoBehaviour
{
    public GameObject ballPrefab; //Префаб шара
    public GameObject appearancePrefab;
    public GameObject endlessObj, Bugs;
    public Sprite ball_blue, ball_yellow, ball_green, ball_red, ball_static, ball_tort; //Спрайты шаров

    static public int field_size; //Размер поля
    private float SpawnSize = 0.9f; //размер шара
    private int SpawnNumberX; //начало спавна по Х
    private int SpawnNumberY; //начало спавна по Y

    static public int[] ArrColor; //массив цветов BLUE,YELLOW,GREEN,RED
    static public int[] ArrWay; //массив направлений
    static public GameObject[] Balls; //масив шаров
    static public bool endSpawn = false;
    private int RandomColor; //рандомный цвет
    private int RandomWay; //рандомное направление
    private StaticHardSpawn[] hardSpawn = new StaticHardSpawn[23];
    private StaticHardSpawn lvl0Spawn = new StaticHardSpawn(0, 2, new int[]{3,1,0,2}, new int[]{1,1,0,2});
    private Text timerText, stepsText;
    public GameObject DialogGO; 

    void Start()
    {
        timerText = GameObject.Find("Timer").GetComponent<Text>();
        stepsText = GameObject.Find("Steps").GetComponent<Text>();
        info.bugsCount = 0;
        if(!info.isEndless){
            endSpawn = false;
            if(info.steps < 1000) /*info.*/stepsText.text = ""+info.steps;
                else /*info.*/stepsText.text = "999+";
            if(info.timersecond < 1000) /*info.*/timerText.text = ""+info.timersecond;
                else /*info.*/timerText.text = "999+";

            SpawnNumberX = 1; //начало спавна по Х
            SpawnNumberY = 5; //начало спавна по Y

            ArrColor = new int[field_size * field_size];
            ArrWay = new int[field_size * field_size];
            Balls = new GameObject[field_size * field_size];
            //Camera.main.transform.position = new Vector3(0.45f + field_size * 0.45f, 4.05f + field_size * 0.45f, -10);

            if(field_size == 10 && (float)Screen.width/Screen.height<1.7) {
                //Debug.Log("Screen.width: "+ Screen.width);
                //Debug.Log("Screen.height: "+ Screen.height);
                //Debug.Log((float)Screen.width/Screen.height);
                Camera.main.transform.position = new Vector3(0.4f + field_size * 0.4f, 3.6f + field_size * 0.4f, -10);
                ballPrefab.transform.localScale = new Vector3(0.8f,0.8f,0.8f);
                SpawnSize = 0.8f;
            }else{
                Camera.main.transform.position = new Vector3(0.45f + field_size * 0.45f, 4.05f + field_size * 0.45f, -10);
                ballPrefab.transform.localScale = new Vector3(0.9f,0.9f,0.9f);
                SpawnSize = 0.9f;
            }

            switch(info.winBall){
                case 0:   GameObject.Find("WinBall").GetComponent<Image>().sprite = ball_blue; 
                        GameObject.Find("Outline").GetComponent<Image>().color = Color.blue; 
                break;
                case 1:   GameObject.Find("WinBall").GetComponent<Image>().sprite = ball_yellow; 
                        GameObject.Find("Outline").GetComponent<Image>().color = Color.yellow;
                break;
                case 2:   GameObject.Find("WinBall").GetComponent<Image>().sprite = ball_green; 
                        GameObject.Find("Outline").GetComponent<Image>().color = Color.green; 
                break;
                case 3:   GameObject.Find("WinBall").GetComponent<Image>().sprite = ball_red; 
                        GameObject.Find("Outline").GetComponent<Image>().color = Color.red; 
                break;
            }
            if(info.isCoop){
                switch(coopMenu.player2Color){
                    case 0:   GameObject.Find("WinBallPlayer2").GetComponent<Image>().sprite = ball_blue; break;
                    case 1:   GameObject.Find("WinBallPlayer2").GetComponent<Image>().sprite = ball_yellow; break;
                    case 2:   GameObject.Find("WinBallPlayer2").GetComponent<Image>().sprite = ball_green; break;
                    case 3:   GameObject.Find("WinBallPlayer2").GetComponent<Image>().sprite = ball_red; break;
                }
            }
            info.ball_blue = this.ball_blue;
            info.ball_green = this.ball_green;
            info.ball_red = this.ball_red;
            info.ball_yellow = this.ball_yellow;
            info.ball_tort = this.ball_tort;
            //info.ballPrefab = this.ballPrefab;
            //info.appearancePrefab = this.appearancePrefab;
            StartCoroutine(Spawn());
        }else {
            lvlEndlessConfig.isReboot = false;
            endlessObj.SetActive(true);
            GameObject.Find("Game").SetActive(false);
        }
    }

    public void StartSpawn(){
            endSpawn = false;
            if(info.steps < 1000) /*info.*/stepsText.text = ""+info.steps;
                else /*info.*/stepsText.text = "999+";
            if(info.timersecond < 1000) /*info.*/timerText.text = ""+info.timersecond;
                else /*info.*/timerText.text = "999+";

            SpawnNumberX = 1; //начало спавна по Х
            SpawnNumberY = 5; //начало спавна по Y
            ArrColor = new int[field_size * field_size];
            ArrWay = new int[field_size * field_size];
            Balls = new GameObject[field_size * field_size];
            Camera.main.transform.position = new Vector3(0.45f + field_size * 0.45f, 4.05f + field_size * 0.45f, -10);
            switch(info.winBall){
                case 0:   GameObject.Find("WinBall").GetComponent<Image>().sprite = ball_blue; 
                        GameObject.Find("Outline").GetComponent<Image>().color = Color.blue; 
                break;
                case 1:   GameObject.Find("WinBall").GetComponent<Image>().sprite = ball_yellow; 
                        GameObject.Find("Outline").GetComponent<Image>().color = Color.yellow;
                break;
                case 2:   GameObject.Find("WinBall").GetComponent<Image>().sprite = ball_green; 
                        GameObject.Find("Outline").GetComponent<Image>().color = Color.green; 
                break;
                case 3:   GameObject.Find("WinBall").GetComponent<Image>().sprite = ball_red; 
                        GameObject.Find("Outline").GetComponent<Image>().color = Color.red; 
                break;
            }
            info.ball_blue = this.ball_blue;
            info.ball_green = this.ball_green;
            info.ball_red = this.ball_red;
            info.ball_yellow = this.ball_yellow;
            info.ball_tort = this.ball_tort;
            //info.ballPrefab = this.ballPrefab;
            //info.appearancePrefab = this.appearancePrefab;
            endlessScore.endlessEnd = false;
            StartCoroutine(Spawn());
    }

    IEnumerator Spawn(){
        //Debug.Log("colorBall.AudioPlay = false;");
        colorBall.AudioPlay = false;
        if (SceneManager.GetActiveScene().name.Substring(0,4) == "lvlH"){ 
            //БУДЬ ВНИМАТЕЛЕН! Кол-во элементов при добавлении должно равняться field_size*field_size, где field_size берется из конфига уровня!
            /*
            Пример заполнения для 1-го сложного уровня при field_size = 3:
            0 - правый верхний
            дальше по часовой
            case 1: hardSpawn[lvlNum] = new StaticHardSpawn(lvlNum, field_size, 
                new int[]{0,1,2,3,0,1,2,3,0}, //Массив цветов
                new int[]{0,1,2,3,0,1,2,3,0}); //Массив направлений
                    break;

             */

            int lvlNum = Int32.Parse(SceneManager.GetActiveScene().name.Substring(4));
            switch (lvlNum)
            {
                case 1: hardSpawn[lvlNum] = new StaticHardSpawn(lvlNum, field_size, 
                new int[]{0,1,2,3,0,1,2,3,0,1,2,3,0,1,2,3,0,1,2,3,0,1,2,3,0},
                new int[]{0,1,2,3,0,1,2,3,0,1,2,3,0,1,2,3,0,1,2,3,0,1,2,3,0});
                    break;
                case 2: hardSpawn[lvlNum] = new StaticHardSpawn(lvlNum, field_size, 
                new int[]{0,2,0,1,3,3,2,1,0,0,0,3,2,1,1,1,0,2,3,3,3,0,0,2,1,0,2,3,0,0,1,2,1,3,1,0}, 
                new int[]{0,2,0,1,3,3,2,1,0,0,0,3,2,1,1,1,0,2,3,3,3,0,0,2,1,0,2,3,0,0,1,2,1,3,1,0});
                    break;
                case 3: hardSpawn[lvlNum] = new StaticHardSpawn(lvlNum, field_size, 
                new int[]{0,2,0,1,3,3,2,1,0,0,0,2,0,1,3,3,2,1,0,0,0,2,0,1,3,3,2,1,0,0,0,2,0,1,3,3,2,1,0,0,0,2,0,1,3,3,2,1,0,0,0,2,0,1,3,3,2,1,0,0,0,2,0,1,3,3,2,1,0,0,0,2,0,1,3,3,2,1,0,0,0,2,0,1,3,3,2,1,0,0,0,2,0,1,3,3,2,1,0,0}, 
                new int[]{0,2,0,1,3,3,2,1,0,0,0,2,0,1,3,3,2,1,0,0,0,2,0,1,3,3,2,1,0,0,0,2,0,1,3,3,2,1,0,0,0,2,0,1,3,3,2,1,0,0,0,2,0,1,3,3,2,1,0,0,0,2,0,1,3,3,2,1,0,0,0,2,0,1,3,3,2,1,0,0,0,2,0,1,3,3,2,1,0,0,0,2,0,1,3,3,2,1,0,0});
                    break;
                case 4: hardSpawn[lvlNum] = new StaticHardSpawn(lvlNum, field_size, 
                new int[]{0,2,0,1,3,3,0,2,0,1,3,3,0,2,0,1,3,3,0,2,0,1,3,3,0}, 
                new int[]{0,2,0,1,3,3,0,2,0,1,3,3,0,2,0,1,3,3,0,2,0,1,3,3,0});
                    break;
                case 5: hardSpawn[lvlNum] = new StaticHardSpawn(lvlNum, field_size, 
                new int[]{0,2,0,1,3,3,0,2,0,1,3,3,0,2,0,1,3,3,0,2,0,1,3,3,0,2,0,1,3,3,0,2,0,1,3,3}, 
                new int[]{0,2,0,1,3,3,0,2,0,1,3,3,0,2,0,1,3,3,0,2,0,1,3,3,0,2,0,1,3,3,0,2,0,1,3,3});
                    break;
                case 6: hardSpawn[lvlNum] = new StaticHardSpawn(lvlNum, field_size, 
                new int[]{1,1,1,1,3,1,1,1,1}, 
                new int[]{3,2,2,1,1,2,1,1,2});
                    break;
                case 7: hardSpawn[lvlNum] = new StaticHardSpawn(lvlNum, field_size, 
                new int[]{3,2,1,2,0,1,3,0,2,1,2,0,2,1,3,3}, 
                new int[]{0,3,2,2,2,0,1,2,3,1,1,2,0,0,0,2});
                    break;
                case 8: hardSpawn[lvlNum] = new StaticHardSpawn(lvlNum, field_size, 
                new int[]{1,2,2,2,0,1,3,0,2,2,1,0,0,1,3,0,3,0,1,2,0,1,3,0,0,2,1,2,0,2,3,0,3,2,0,2,2,1,3,0,3,2,0,2,0,1,3,0,3,2,1,2,1,1,3,2,3,3,1,3,0,1,3,0}, 
                new int[]{3,2,1,2,0,1,3,0,3,2,1,2,0,1,3,0,3,2,1,2,0,1,3,0,3,2,1,2,0,1,3,0,3,2,1,2,0,1,3,0,3,2,1,2,0,1,3,0,3,2,1,2,0,1,3,0,3,2,1,2,0,1,3,0});
                    break;
                case 9: hardSpawn[lvlNum] = new StaticHardSpawn(lvlNum, field_size, 
                new int[]{1,1,3,1,0,0,2,3,2,0,1,2,0,2,0,2,1,2,1,0,2,0,3,2,1}, 
                new int[]{3,2,1,2,1,1,2,2,3,0,1,2,1,2,0,2,2,2,2,3,1,2,1,2,0});
                    break;
                case 10: hardSpawn[lvlNum] = new StaticHardSpawn(lvlNum, field_size, 
                new int[]{1,1,3,1,0,0,2,3,2,0,1,1,3,1,0,0,2,3,2,0,1,1,3,1,0,0,2,3,2,0,1,1,3,1,0,0,2,3,2,0,1,1,3,1,0,0,2,3,2,0,1,1,3,1,0,0,2,3,2,0,1,1,3,1,0,0,2,3,2,0,1,1,3,1,0,0,2,3,2,0,1,1,3,1,0,0,2,3,2,0,1,1,3,1,0,0,2,3,2,0}, 
                new int[]{3,2,1,2,1,1,2,2,3,0,1,1,3,1,0,0,2,3,2,0,1,1,3,1,0,0,2,3,2,0,1,1,3,1,0,0,2,3,2,0,1,1,3,1,0,0,2,3,2,0,1,1,3,1,0,0,2,3,2,0,1,1,3,1,0,0,2,3,2,0,1,1,3,1,0,0,2,3,2,0,1,1,3,1,0,0,2,3,2,0,1,1,3,1,0,0,2,3,2,0});
                    break;
                case 11: hardSpawn[lvlNum] = new StaticHardSpawn(lvlNum, field_size, 
                new int[]{0,1,2,0,1,1,0,1,1,1,1,2,1,2,1,1,1,1,1,2,2,1,1,2,3,1,2,2,1,1,1,1,2,2,2,1,1,2,1,1,1,2,1,1,2,1,1,2,2}, 
                new int[]{3,2,1,2,1,1,2,3,2,1,2,1,1,2,3,2,1,2,1,1,2,3,2,1,2,1,1,2,3,2,1,2,1,1,2,3,2,1,2,1,1,2,3,2,1,2,1,1,2});
                    break;
                case 12: hardSpawn[lvlNum] = new StaticHardSpawn(lvlNum, field_size, 
                new int[]{1,1,1,1,3,1,1,1,1}, 
                new int[]{2,1,0,2,1,0,2,2,3});
                    break;
                case 13: hardSpawn[lvlNum] = new StaticHardSpawn(lvlNum, field_size, 
                new int[]{2,2,2,2,0,1,1,1,1,2,2,2,1,1,1,1,1,1,2,2,2,2,0,1,1,1,1,2,2,2,2,2,0,1,1,1,2,2,2,2,0,1,1,1,1,2,2,2,1,1,1,1,1,1,2,2,2,2,0,1,1,1,1,2,2,2,2,2,0,1,1,1,2,2,2,2,0,1,1,1,1}, 
                new int[]{3,2,1,2,1,1,2,2,3,3,2,1,2,1,1,2,2,3,3,2,1,2,1,1,2,2,3,3,2,1,2,1,1,2,2,3,3,2,1,2,1,1,2,2,3,3,2,1,2,1,1,2,2,3,3,2,1,2,1,1,2,2,3,3,2,1,2,1,1,2,2,3,3,2,1,2,1,1,2,2,3});
                    break;
                case 14: hardSpawn[lvlNum] = new StaticHardSpawn(lvlNum, field_size, 
                new int[]{
                3,3,3,3,3,3,3,3,3,3,
                1,1,3,1,0,0,2,3,2,0,
                1,1,3,1,0,0,2,3,1,0,
                3,3,3,3,3,3,3,3,3,3,
                1,1,3,1,0,0,2,3,2,0,
                1,1,3,1,0,0,2,3,2,0,
                3,3,3,3,3,3,3,3,3,3,
                1,1,3,1,0,0,2,3,2,0,
                1,1,3,1,0,0,2,3,2,0,
                3,3,3,3,3,3,3,3,3,3}, 
                new int[]{
                0,0,0,0,0,0,3,0,3,2,
                0,0,0,0,0,0,0,0,1,2,
                0,0,0,0,0,0,0,1,2,2,
                0,0,0,0,0,0,1,3,2,2,
                1,0,0,0,0,1,2,3,2,2,
                1,0,0,0,1,0,2,3,2,2,
                0,0,0,1,0,0,2,3,2,2,
                1,0,1,1,0,0,2,3,2,2,
                1,1,3,1,0,0,2,3,2,2,
                1,1,3,1,0,0,2,3,2,2});
                    break;
                case 15: hardSpawn[lvlNum] = new StaticHardSpawn(lvlNum, field_size, 
                new int[]{
                3,3,3,3,0,2,2,2,2,
                3,3,3,3,0,2,2,2,2,
                3,3,3,3,0,2,2,2,2,
                3,3,3,3,0,2,2,2,2,
                0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,1,1,1,1,
                0,0,0,0,0,1,1,1,1,
                0,0,0,0,0,1,1,1,1,
                0,0,0,0,0,1,1,1,1}, 
                new int[]{3,2,2,2,1,3,2,2,3,2,1,3,1,0,0,1,3,2,1,2,3,1,0,3,2,3,2,1,2,3,1,0,0,1,3,2,1,1,3,1,0,2,3,3,2,1,2,3,1,1,0,3,3,2,1,2,3,1,0,1,2,3,3,1,1,2,1,0,1,2,3,2,1,1,3,1,0,0,2,3,2});
                    break;
                case 16: hardSpawn[lvlNum] = new StaticHardSpawn(lvlNum, field_size, 
                new int[]{1,1,0,1,0,1,1,2,1,1,2,0,1,1,2,1,2,2,0,1,1,2,1,3,2,0,1,1,2,1,3,2,0,1,1,2,1,2,2,0,1,1,0,1,3,2,0,1,1}, 
                new int[]{3,2,1,2,1,1,2,2,3,3,2,1,2,1,1,2,2,3,3,2,1,2,1,1,2,2,3,3,2,1,2,1,1,2,2,3,3,2,1,2,1,1,2,2,3,3,2,1,2});
                    break;
                case 17: hardSpawn[lvlNum] = new StaticHardSpawn(lvlNum, field_size, 
                new int[]{0,3,3,2,0,1,3,1,3,2,2,2,2,1,0,3,1,3,3,2,3,2,0,1,0,3,3,0,2,0,2,3,0,3,1,3,0,2,2,0,0,1,0,1,3,2,1,2,0,3,1,0,3,0,2,3,2,2,0,3,3,3,1,0,2,0,2,2,0,1,1,0,2,3,2,3,0,1,3,3,0}, 
                new int[]{3,2,1,2,1,1,2,2,3,3,2,1,2,1,1,2,2,3,3,2,1,2,1,1,2,2,3,3,2,1,2,1,1,2,2,3,3,2,1,2,1,1,2,2,3,3,2,1,2,1,1,2,2,3,3,2,1,2,1,1,2,2,3,3,2,1,2,1,1,2,2,3,3,2,1,2,1,1,2,2,3});
                    break;
                case 18: hardSpawn[lvlNum] = new StaticHardSpawn(lvlNum, field_size, 
                new int[]{0,3,2,3,3,1,0,2,3,2,2,3,1,3,2,1,3,2,3,1,3,2,3,2,2,1,1,1,2,3,1,2,2,1,3,2,3,2,3,1,1,3,0,2,3,2,3,1,0}, 
                new int[]{0,0,0,0,0,0,3,1,0,3,3,3,3,2,0,0,0,0,3,2,2,0,0,0,0,2,2,2,0,0,0,1,2,2,3,0,0,1,2,2,2,3,1,1,2,2,2,2,2});
                    break;
                case 19: hardSpawn[lvlNum] = new StaticHardSpawn(lvlNum, field_size, 
                new int[]{
                3,3,3,3,1,1,0,0,0,0,
                3,3,3,3,1,1,0,0,0,0,
                3,3,3,3,1,1,0,0,0,0,
                3,3,3,3,1,1,0,0,0,0,
                1,1,1,1,1,2,2,1,1,1,
                1,1,1,1,1,2,2,1,1,1,
                0,0,0,0,1,1,3,3,3,3,
                0,0,0,0,1,1,3,3,3,3,
                0,0,0,0,1,1,3,3,3,3,
                0,0,0,0,1,1,3,3,3,3}, 
                new int[]{3,2,1,2,1,1,2,2,3,3,3,2,1,2,1,1,2,2,3,3,3,2,1,2,1,1,2,2,3,3,3,2,1,2,1,1,2,2,3,3,3,2,1,2,1,1,2,2,3,3,3,2,1,2,1,1,2,2,3,3,3,2,1,2,1,1,2,2,3,3,3,2,1,2,1,1,2,2,3,3,3,2,1,2,1,1,2,2,3,3,3,2,1,2,1,1,2,2,3,3});
                    break;
                case 20: hardSpawn[lvlNum] = new StaticHardSpawn(lvlNum, field_size, 
                new int[]{2,2,2,2,0,1,1,1,1,2,2,2,2,2,0,1,1,1,1,2,2,2,2,2,0,1,1,1,1,2,2,2,2,2,0,1,1,1,1,2,2,2,2,2,0,1,1,1,1,2,2,2,2,2,0,1,1,1,1,2,2,2,2,2,0,1,1,1,1,2,2,2,2,2,0,1,1,1,1,2,2,2,2,2,0,1,1,1,1,2,2,2,2,2,0,1,1,1,1,2}, 
                new int[]{3,2,1,2,1,1,2,2,3,3,3,2,1,2,1,1,2,2,3,3,3,2,1,2,1,1,2,2,3,3,3,2,1,2,1,1,2,2,3,3,3,2,1,2,1,1,2,2,3,3,3,2,1,2,1,1,2,2,3,3,3,2,1,2,1,1,2,2,3,3,3,2,1,2,1,1,2,2,3,3,3,2,1,2,1,1,2,2,3,3,3,2,1,2,1,1,2,2,3,3});
                    break;
            }
        }

        for (int i = 0; i < field_size * field_size; i++){
            RandomColor = UnityEngine.Random.Range(0, 4);
            RandomWay = UnityEngine.Random.Range(0, 4);
            /*RandomColor = 3;
            if(i==2) RandomColor = 0;
            if(i==5) RandomColor = 0;
            if(i==7) RandomColor = 0;
            if(i==16) RandomColor = 0;*/
            if(SceneManager.GetActiveScene().name == "lvl0"){
                RandomColor = lvl0Spawn.GetColorByIndex(i);
                RandomWay = lvl0Spawn.GetWayByIndex(i);
            }

            if (SceneManager.GetActiveScene().name.Substring(0,4) == "lvlH"){
                int lvlNum = Int32.Parse(SceneManager.GetActiveScene().name.Substring(4));
                RandomColor = hardSpawn[lvlNum].GetColorByIndex(i);
                RandomWay = hardSpawn[lvlNum].GetWayByIndex(i);
            }

            Balls[i] = Instantiate(ballPrefab, new Vector2(SpawnNumberX * SpawnSize, SpawnNumberY * SpawnSize), Quaternion.Euler(0, 0, -90 * RandomWay));
            ArrColor[i] = RandomColor;
            ArrWay[i] = RandomWay;
            Balls[i].name = ""+i;

            if(info.stat_balls.Contains(i)){
                //Фраза, если info.firstMeet[1] = false;
                if(!info.firstMeet[2]){
                    info.firstMeet[2] = true;
                    string dialogName = "lvl_003";
                    DialogGO.GetComponent<DialogView>().isRandom = false;
                    DialogGO.GetComponent<DialogView>().DialogName = dialogName;
                    DialogGO.GetComponent<DialogView>().StartDialogView();
                }
                GameObject tmpAppear = Instantiate(appearancePrefab, GameObject.Find(""+Balls[i].name).transform.position + new Vector3(0f, 0f, -5.1f), Quaternion.Euler(0, 0, 0));
                tmpAppear.name = i+"A";
                StartCoroutine(DestroyAppearance(i));
                RandomColor = 4;
                ArrColor[i] = info.winBall;
                Balls[i].transform.rotation = Quaternion.Euler(0, 0, 0);;
                ArrWay[i] = -1;
            }

            switch (RandomColor){
                case 0: Balls[i].GetComponent<SpriteRenderer>().sprite = ball_blue; info.ballColors[0]++; break;
                case 1: Balls[i].GetComponent<SpriteRenderer>().sprite = ball_yellow; info.ballColors[1]++; break;
                case 2: Balls[i].GetComponent<SpriteRenderer>().sprite = ball_green; info.ballColors[2]++; break;
                case 3: Balls[i].GetComponent<SpriteRenderer>().sprite = ball_red; info.ballColors[3]++; break;
                case 4: Balls[i].GetComponent<SpriteRenderer>().sprite = ball_static; info.ballColors[info.winBall]++; Balls[i].GetComponent<ball>().busy = true; break;
            }

            yield return new WaitForSeconds(0.001f);

            if (SpawnNumberX < field_size) SpawnNumberX += 1;
            else if (SpawnNumberY < field_size + 4)
            {
                SpawnNumberY += 1;
                SpawnNumberX = 1;
            }

        }
        endSpawn = true;
        Bugs.SetActive(true);
        if(info.isEndless){
            if(info.ballColors[info.winBall] == 0){
                GameObject.Find("EndLessScore").GetComponent<endlessScore>().noColorEndless();
            }
        }
    }

    IEnumerator DestroyAppearance(int nameInt){
        yield return new WaitForSeconds(1.1f);
        Destroy(GameObject.Find(nameInt+"A"));
    }
}

class StaticHardSpawn{
    private int numLvl;
    private int sizeField;
    private int[] color;
    private int[] way;

    public StaticHardSpawn(int numLvl, int sizeField, int[] colors, int[] ways){
        this.numLvl = numLvl;
        this.sizeField = sizeField;
        this.color = colors;
        this.way = ways;
        /*Debug.Log("numLvl: "+numLvl);
        Debug.Log("color.Length: "+color.Length);
        Debug.Log("ways.Length: "+ways.Length);
        Debug.Log("sizeField*sizeField: "+sizeField*sizeField);*/
        if(color.Length != sizeField*sizeField || ways.Length != sizeField*sizeField){
            Debug.Log("Ошибка! Неверное заполнение статичного спавна для сложного уровня!");
        }
    }

    public int GetColorByIndex(int index){
        return color[index];
    }

    public int GetWayByIndex(int index){
        return way[index];
    }
}
