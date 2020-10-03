using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lvl18config : MonoBehaviour
{
    void Start()
    {
        spawn.field_size = 10; //Размер поля
        info.steps = 20; // Кол-во ходов, 0 - показывает кол-во ходов, >0 - убывающее кол-во ходов
        info.timersecond = 70; // Кол-во секунд, 0 - показывает время игры, >0 - убывающий таймер
        info.winBall = 3; // Победный цвет: 0-blue, 1- yellow, 2- green, 3-red;
        
        info.stat_balls = new int[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 20, 30, 40, 50, 60, 70, 80, 90, 19, 29, 39, 49, 59, 69, 79, 89,
                                      99, 91, 92, 93, 94, 95, 96, 97, 98, 14, 15, 24, 25, 34, 35, 44, 45, 54, 55, 64, 65, 74, 75,
                                      84, 85, 94, 95}; //Статичные шарики [0..spawn.field_size*spawn.field_size]

        colorBall.timeForExplosion = 36; //Время между взрывами ColorBall'а  [9...]
        colorBall.quantity = 3; //Кол-во ColorBall'а
        GetComponent<colorBall>().enabled = true; //Вкл ColorBall'а

        tortoiseBall.timeForExplosion = 15; //Время между взрывами TortoiseBall'а  [9...]
        tortoiseBall.quantity = 2; //Кол-во TortoiseBall'а
        GetComponent<tortoiseBall>().enabled = false; //Вкл TortoiseBall'а

        GetComponent<trickHelp>().quantity = Random.Range(3,9);//4; //Кол-во облаков (Мб сделать случайным?)

        GetComponent<Bot>().enabled = false; //Вкл бота (EVA)
        info.botColor = 0; //Цвет победы бота: 0-blue, 1- yellow, 2- green, 3-red;

        //================================================================================================

        if(!GetComponent<Bot>().enabled) info.botActive = false;
        
        info.isEndless = false;
        
        info.field_size = spawn.field_size;

        if (info.steps > 0){ //Вкл шагометра
            info.stepGo = true;
            info.configStep = info.steps;
        }else{
            info.stepGo = false;
        }
        if (info.timersecond > 0){ //Вкл таймер
            info.timerGo = true;
            info.configTime = info.timersecond;
        }else{
            info.timerGo = false;
        }

        if(GetComponent<tortoiseBall>().enabled)
            GetComponent<tortoiseBall>().lvlActive = true;

        GetComponent<spawn>().enabled = true;
    }
}