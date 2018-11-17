using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touchs : MonoBehaviour {

    static public string NumberBall; // Название шарика по которому каснулись
    static public bool StartTouch = false; // Возможность касания
    public GameObject next; // Шар для кручения
    public GameObject testNext; // Проверка данного шара на кручение
    public int sumTest; //Проверка завершения всех кручений
    public int sumWin; // Проверка победы
    public int timer; // Таймер UPDATE
    static public bool LOSE = false; // Проигрыш
    static public bool WIN = false; // Выйгрыш
    static public int NumberOfStep = 1; //номер хода (для бота)

    // Use this for initialization
    void Start()
    {
        LOSE = false; //Устанавилваем значение проигрыша на false
        StartTouch = false;
        WIN = false;
        NumberOfStep = 1;
        //Правка 10 июня 2018
        sumTest = 0;
        sumWin = 0;
        timer = 0;
        //Конец правки 10 июня 2018
    }

    // Update is called once per frame
    void Update() {
        // Определение касания по шарику
        if (StartTouch) // Возможность касания
        {
            if (Input.GetMouseButtonDown(0)) // Если кнопку нажали
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    StartTouch = false; // Остановка возможности касания
                    NumberOfStep++;
                    Debug.Log(""+hit.collider.name);
                    NumberBall = hit.collider.name; // Записывает имя шарика по которому каснулись
                    if(NumberBall == "Cloud"){
                        TricksterHelp.isCloud = true;
                        Cloud_Ver2.end = true;
                    }else{
                        next = GameObject.Find(NumberBall.ToString()); // Ищем этот шарик среди наших и записываем в "next" его Gameobject
                        Ball nexing = next.GetComponent<Ball>(); // Получаем скрипт для прокрутки шара, которого мы коснулись
                        nexing.StepRot = Ball.Speed; // Начинаем крутить шар, до которого каснулись

                        //Изменение кол-ва ходов
                        if (myGUI.stepGo)
                            myGUI.step--;
                        else
                            myGUI.step++;
                        //---------------------
                    }
                }
            }
        }
        //-----------------------------------------------------------------------------
        timer++;
        if (timer % 25 == 0) //Каждый 25-й Update
        {
            for (int i = 1; i < Spawn.MySize * Spawn.MySize + 1; i++)
            {
                //Проверка завершения кручения щариков
                testNext = GameObject.Find(i.ToString());
                Ball testNexing = testNext.GetComponent<Ball>();
                sumTest += testNexing.StepRot;
                //---------------------------------------------
                //Проверка цвета шариков для завершения игры
                if (Spawn.ArrColor[i] == Spawn.WinBall)
                    sumWin++;
                //-----------------------------------------
                if (i == Spawn.MySize * Spawn.MySize)
                {
                    if (sumTest == 0) //Если шарики закончили крутиться
                        StartTouch = true;
                    else sumTest = 0;
                    //--------------------------------------------------------------------------
                    if (sumWin == Spawn.MySize * Spawn.MySize) //Если все шарики победного цвета
                        WIN = true;
                    else sumWin = 0;
                }
            }
        }
    }
}
