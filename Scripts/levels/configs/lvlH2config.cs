using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lvlH2config : MonoBehaviour
{
    void Start()
    {
        spawn.field_size = 6; //Размер поля
        info.steps = 50; // Кол-во ходов, 0 - показывает кол-во ходов, >0 - убывающее кол-во ходов
        info.timersecond = 900; // Кол-во секунд, 0 - показывает время игры, >0 - убывающий таймер
        info.winBall = 2; // Победный цвет: 0-blue, 1- yellow, 2- green, 3-red;
        
        info.stat_balls = new int[] {0,1,2,3,4,5,6,7,10,11,12,14,15,17,18,20,21,23,24,25,28,29,30,31,32,33,34,35}; //Статичные шарики [0..spawn.field_size*spawn.field_size]

        colorBall.timeForExplosion = 10; //Время между взрывами ColorBall'а  [9...]
        colorBall.quantity = 2; //Кол-во ColorBall'а
        GetComponent<colorBall>().enabled = false; //Вкл ColorBall'а

        tortoiseBall.timeForExplosion = 15; //Время между взрывами TortoiseBall'а  [9...]
        tortoiseBall.quantity = 2; //Кол-во TortoiseBall'а
        GetComponent<tortoiseBall>().enabled = false; //Вкл TortoiseBall'а

        GetComponent<trickHelp>().quantity = Random.Range(3,9);//4; //Кол-во облаков (Мб сделать случайным?)

        GetComponent<Bot>().enabled = false; //Вкл бота (EVA)
        info.botColor = 0; //Цвет победы бота: 0-blue, 1- yellow, 2- green, 3-red;

        SecretMech.hardLvlTrickHelpCount = 20; //Кол-во помощи трикстера

        GetComponent<info>().timerSlowdown = 0.5f; //Ускорить/замедлить таймер. 0.5 = ускорить в 2 раза, 2 = замелить в 2 раза

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