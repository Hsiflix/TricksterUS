using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lvl2config : MonoBehaviour
{
    
    void Start()
    {
        spawn.field_size = 4; //Размер поля
        info.steps = 100; // Кол-во ходов, 0 - показывает кол-во ходов, >0 - убывающее кол-во ходов
        info.timersecond = 180; // Кол-во секунд, 0 - показывает время игры, >0 - убывающий таймер
        info.winBall = 3; // Победный цвет: 0-blue, 1- yellow, 2- green, 3-red;
        
        info.stat_balls = new int[] {}; //Статичные шарики [0..spawn.field_size*spawn.field_size]

        colorBall.timeForExplosion = 15; //Время между взрывами ColorBall'а  [9...]
        colorBall.quantity = 1; //Кол-во ColorBall'а
        GetComponent<colorBall>().enabled = false; //Вкл ColorBall'а

        tortoiseBall.timeForExplosion = 15; //Время между взрывами TortoiseBall'а  [9...]
        tortoiseBall.quantity = 1; //Кол-во TortoiseBall'а
        GetComponent<tortoiseBall>().enabled = false; //Вкл TortoiseBall'а

        //BotX.BotOn = false; // Включение бота (не забудь включить кол-во ходов)
        //BotX.BotWin = 2; // Победный цвет бота: 1-blue, 2- yellow, 3- green, 4-red; 
        
        info.field_size = spawn.field_size;

        if (info.steps > 0){ //Вкл шагометра
            info.stepGo = true;
        }
        if (info.timersecond > 0){ //Вкл таймер
            info.timerGo = true;
        }
        if(info.steps < 1000) info.stepsText.text = ""+info.steps;
            else info.stepsText.text = "999+";
        if(info.timersecond < 1000) info.timerText.text = ""+info.timersecond;
            else info.timerText.text = "999+";

        GetComponent<spawn>().enabled = true;
    }
}