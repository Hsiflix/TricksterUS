using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lvlH20config : MonoBehaviour
{
    void Start()
    {
        spawn.field_size = 10; //Размер поля
        info.steps = 50; //Кол-во ходов, 0 - показывает кол-во ходов, >0 - убывающее кол-во ходов
        info.timersecond = 500; //Кол-во секунд, 0 - показывает время игры, >0 - убывающий таймер
        info.winBall = 0; //Победный цвет: 0-blue, 1- yellow, 2- green, 3-red;
        
        info.stat_balls = new int[] {2,3,12,13,22,23,32,33,42,43,52,53,62,63,72,73,82,83,84,85,86,87,92,93,94,95,96,97}; //Статичные шарики [0..spawn.field_size*spawn.field_size]

        colorBall.timeForExplosion = 30; //Время между взрывами ColorBall'а  [9...]
        colorBall.quantity = 10; //Кол-во ColorBall'а
        GetComponent<colorBall>().enabled = false; //Вкл ColorBall'а

        tortoiseBall.timeForExplosion = 1; //Время между взрывами TortoiseBall'а  [9...]
        tortoiseBall.quantity = 10; //Кол-во TortoiseBall'а
        GetComponent<tortoiseBall>().enabled = false; //Вкл TortoiseBall'а

        GetComponent<trickHelp>().quantity = Random.Range(5,7);//4; //Кол-во облаков (Мб сделать случайным?)

        GetComponent<Bot>().enabled = false; //Вкл бота (EVA)
        info.botColor = 1; //Цвет победы бота: 0-blue, 1- yellow, 2- green, 3-red;

        SecretMech.hardLvlTrickHelpCount = 50; //Кол-во помощи трикстера

        GetComponent<info>().timerSlowdown = 0.6f; //Ускорить/замедлить таймер. 0.5 = ускорить в 2 раза, 2 = замелить в 2 раза

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
