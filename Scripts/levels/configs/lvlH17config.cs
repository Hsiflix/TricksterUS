using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lvlH17config : MonoBehaviour
{
    void Start()
    {
        spawn.field_size = 9; //Размер поля
        info.steps = 100; //Кол-во ходов, 0 - показывает кол-во ходов, >0 - убывающее кол-во ходов
        info.timersecond = 20; //Кол-во секунд, 0 - показывает время игры, >0 - убывающий таймер
        info.winBall = 1; //Победный цвет: 0-blue, 1- yellow, 2- green, 3-red;
        
        info.stat_balls = new int[] {0,1,2,3,4,5,6,7,8,9,18,20,21,22,23,24,25,27,29,34,36,38,40,41,43,45,47,50,52,54,56,57,58,59,61,63,70,72,73,74,75,76,77,78,79}; //Статичные шарики [0..spawn.field_size*spawn.field_size]

        colorBall.timeForExplosion = 20; //Время между взрывами ColorBall'а  [9...]
        colorBall.quantity = 1; //Кол-во ColorBall'а
        GetComponent<colorBall>().enabled = true; //Вкл ColorBall'а

        tortoiseBall.timeForExplosion = 25; //Время между взрывами TortoiseBall'а  [9...]
        tortoiseBall.quantity = 2; //Кол-во TortoiseBall'а
        GetComponent<tortoiseBall>().enabled = true; //Вкл TortoiseBall'а

        GetComponent<trickHelp>().quantity = Random.Range(1,5);//4; //Кол-во облаков (Мб сделать случайным?)

        GetComponent<Bot>().enabled = false; //Вкл бота (EVA)
        info.botColor = 1; //Цвет победы бота: 0-blue, 1- yellow, 2- green, 3-red;

        SecretMech.hardLvlTrickHelpCount = 50; //Кол-во помощи трикстера

        GetComponent<info>().timerSlowdown = 1f; //Ускорить/замедлить таймер. 0.5 = ускорить в 2 раза, 2 = замелить в 2 раза

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
