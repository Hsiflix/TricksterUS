using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvlB2Config : MonoBehaviour {

    public Texture ballRender1; //sprite Ball1
    public Texture ballRender2; //sprite Ball2
    public Texture ballRender3; //sprite Ball3
    public Texture ballRender4; //sprite Ball4

    void Start() {
        Spawn.steps = 0; // Кол-во ходов, 0 - показывает кол-во ходов, >0 - убывающее кол-во ходов
        Spawn.timerseconds = 60; // Кол-во секунд, 0 - показывает время игры, >0 - убывающий таймер
        Spawn.MySize = 9; // Размер поля
        Spawn.RestartLvl(); // Функция перезагрузки
        ColorBall.ColorBallOn = false; //Включение ColorBall'а
        TempBool.startLvlTort = false; //Включение TortBall'а
        ColorBall.TimeForExplosion = 10; //Время между взрывами ColorBall'а (БОЛЬШЕ 9!!!)

        StatBall.StatArr = new int[] {37,38,39,40,41,42,43,44,45};
        StatBall.StatBallOn = true; //Включение StatBall'a

        Spawn.WinBall = 2; // Победный цвет: 1-blue, 2- yellow, 3- red, 4-green; 

        BotX.BotOn = true; // Включение бота (не забудь включить кол-во ходов)
        BotX.BotWin = 4; // Победный цвет бота: 1-blue, 2- yellow, 3- red, 4-green; 

        if (myGUI.timersecond != 0)
            myGUI.timerGo = true; // Запустить Таймер, не менять!
        else myGUI.timerGo = false;
        if (myGUI.step != 0)
            myGUI.stepGo = true; // Запустить ходы, не менять!
        else myGUI.stepGo = false;
        switch (Spawn.WinBall) {
            case 1:
                myGUI.ballRender = ballRender1;
                break;
            case 2:
                myGUI.ballRender = ballRender2;
                break;
            case 3:
                myGUI.ballRender = ballRender3;
                break;
            case 4:
                myGUI.ballRender = ballRender4;
                break;
        }
        GetComponent<Spawn>().enabled = true;
        GetComponent<myGUI>().enabled = true;
        GetComponent<Touchs>().enabled = true;
        // FromOutLine-Interface
        switch (Spawn.WinBall)
        { //Победный цвет: 1 - blue, 2 - yellow, 3 - red, 4 - green;// Бот всегда красный (мб исправить?)
            case 1: myGUI.outline_color = Color.blue; break;
            case 2: myGUI.outline_color = Color.yellow; break;
            case 3: myGUI.outline_color = Color.red; break;
            case 4: myGUI.outline_color = Color.green; break;
            default: Debug.Log("Errrrrrrroe_OUTLINE"); break;
        }
        if (ColorBall.ColorBallOn == true)
            GetComponent<ColorBall>().enabled = true;
        if(StatBall.StatBallOn == true)
            GetComponent<StatBall>().enabled = true;
        if (BotX.BotOn == true)
            GetComponent<BotX>().enabled = true;
    }
}
