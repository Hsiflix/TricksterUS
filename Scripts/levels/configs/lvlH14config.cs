using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lvlH14config : MonoBehaviour
{
    void Start()
    {
        spawn.field_size = 10; //Размер поля
        info.steps = 1; //Кол-во ходов, 0 - показывает кол-во ходов, >0 - убывающее кол-во ходов
        info.timersecond = 200; //Кол-во секунд, 0 - показывает время игры, >0 - убывающий таймер
        info.winBall = 3; //Победный цвет: 0-blue, 1- yellow, 2- green, 3-red;
        
        info.stat_balls = new int[] {}; //Статичные шарики [0..spawn.field_size*spawn.field_size]

        colorBall.timeForExplosion = 10; //Время между взрывами ColorBall'а  [9...]
        colorBall.quantity = 3; //Кол-во ColorBall'а
        GetComponent<colorBall>().enabled = false; //Вкл ColorBall'а

        tortoiseBall.timeForExplosion = 10; //Время между взрывами TortoiseBall'а  [9...]
        tortoiseBall.quantity = 5; //Кол-во TortoiseBall'а
        GetComponent<tortoiseBall>().enabled = false; //Вкл TortoiseBall'а

        GetComponent<trickHelp>().quantity = Random.Range(1,1);//4; //Кол-во облаков (Мб сделать случайным?)

        GetComponent<Bot>().enabled = false; //Вкл бота (EVA)
        info.botColor = 1; //Цвет победы бота: 0-blue, 1- yellow, 2- green, 3-red;

        SecretMech.hardLvlTrickHelpCount = 5; //Кол-во помощи трикстера

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
