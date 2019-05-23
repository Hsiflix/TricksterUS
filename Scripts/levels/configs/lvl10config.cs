﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lvl10config : MonoBehaviour
{
    void Start()
    {
        spawn.field_size = 9; //Размер поля
        info.steps = 0; // Кол-во ходов, 0 - показывает кол-во ходов, >0 - убывающее кол-во ходов
        info.timersecond = 0; // Кол-во секунд, 0 - показывает время игры, >0 - убывающий таймер
        info.winBall = 0; // Победный цвет: 0-blue, 1- yellow, 2- green, 3-red;
        
        info.stat_balls = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 19, 21, 22, 23, 24, 25, 26, 28, 30,
                                        35, 37, 39, 41, 42, 44, 46, 48, 51, 53, 55, 57,
                                        58, 59, 60, 62, 64, 71, 73, 74, 75, 76, 77, 78, 79, 80}; //Статичные шарики [0..spawn.field_size*spawn.field_size]

        colorBall.timeForExplosion = 23; //Время между взрывами ColorBall'а  [9...]
        colorBall.quantity = 1; //Кол-во ColorBall'а
        GetComponent<colorBall>().enabled = true; //Вкл ColorBall'а

        tortoiseBall.timeForExplosion = 15; //Время между взрывами TortoiseBall'а  [9...]
        tortoiseBall.quantity = 2; //Кол-во TortoiseBall'а
        GetComponent<tortoiseBall>().enabled = false; //Вкл TortoiseBall'а

        GetComponent<trickHelp>().quantity = 4; //Кол-во облаков (Мб сделать случайным?)

        GetComponent<Bot>().enabled = false; //Вкл бота (EVA)
        info.botColor = 0; //Цвет победы бота: 0-blue, 1- yellow, 2- green, 3-red;

        //================================================================================================
        
        info.field_size = spawn.field_size;

        if (info.steps > 0){ //Вкл шагометра
            info.stepGo = true;
        }else{
            info.stepGo = false;
        }
        if (info.timersecond > 0){ //Вкл таймер
            info.timerGo = true;
        }else{
            info.timerGo = false;
        }

        if(GetComponent<tortoiseBall>().enabled)
            GetComponent<tortoiseBall>().noTrick = true;

        GetComponent<spawn>().enabled = true;
    }
}