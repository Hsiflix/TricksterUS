using UnityEngine;

public class lvlCoopConfig : MonoBehaviour
{
    void Start()
    {
        spawn.field_size = Random.Range(7,11); //Размер поля
        info.steps = Random.Range(16,48); // Кол-во ходов, 0 - показывает кол-во ходов, >0 - убывающее кол-во ходов
        info.timersecond = Random.Range(0,2)==0?Random.Range(80,240):0; // Кол-во секунд, 0 - показывает время игры, >0 - убывающий таймер
        info.winBall = coopMenu.player1Color; // Победный цвет: 0-blue, 1- yellow, 2- green, 3-red;
        
        info.stat_balls = new int[] {}; //Статичные шарики [0..spawn.field_size*spawn.field_size]

        colorBall.timeForExplosion = 50; //Время между взрывами ColorBall'а  [9...]
        colorBall.quantity = 1; //Кол-во ColorBall'а
        GetComponent<colorBall>().enabled = false; //Вкл ColorBall'а

        tortoiseBall.timeForExplosion = 10; //Время между взрывами TortoiseBall'а  [9...]
        tortoiseBall.quantity = 4; //Кол-во TortoiseBall'а
        GetComponent<tortoiseBall>().enabled = false; //Вкл TortoiseBall'а

        GetComponent<trickHelp>().quantity = Random.Range(3,9);//4; //Кол-во облаков (Мб сделать случайным?)
        Coop.trickHelpNum = Random.Range(2,5);
        if(Coop.trickHelpNum%2==1)Coop.trickHelpNum--;

        GetComponent<Bot>().enabled = false; //Вкл бота (EVA)
        info.botColor = 0; //Цвет победы бота: 0-blue, 1- yellow, 2- green, 3-red;

        GetComponent<Coop>().enabled = true; //Вкл режима Коопа

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
