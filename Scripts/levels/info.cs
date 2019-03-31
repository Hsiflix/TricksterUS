using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class info : MonoBehaviour
{
    static public int steps; //Кол-во шагов
    static public bool stepGo = false; //Шагометр
    static public int timersecond; //Кол-во времени
    static public bool timerGo = false; //Таймер
    static public int winBall; //Победный цвет
    static public int field_size; //Размер поля
    static public int colorNextInt; //Номер цвета хода
    static public Sprite colorNext; //Цвет хода
    static public Sprite ball_blue, ball_yellow, ball_green, ball_red, ball_tort; //Спрайты шаров
    static public GameObject ballPrefab; //Префаб шара
    static public bool activeRot = false;
    static public bool activeTouch = true;
    private bool activeRotCheck = false;
    static public int queue = 0, preQueue = 0;
    static public int[] ballColors;
    static public int[] stat_balls;
    private float secondgametime;
    static public Text timerText, stepsText;

    void Start(){
        ballColors = new int[4];
        timerText = GameObject.Find("Timer").GetComponent<Text>();
        stepsText = GameObject.Find("Steps").GetComponent<Text>();
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
            if(ballColors[winBall] == field_size * field_size){
                Debug.Log("WWWIIINN");
            }
            if(stepGo && steps == 0){
                Debug.Log("LLLOOOSSSEEE(steps)");
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
        }
        if (timerGo && timersecond == 0)
        {
            Debug.Log("LLLOOOSSSEEE(timer)");
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
    }
}