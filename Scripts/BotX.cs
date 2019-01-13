///Eeeva
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BotX : MonoBehaviour {

    private GameObject next; // Шар для кручения
    static public int BotWin;
    private int PlayerQu = 0;
    private int BotQu = 0;
    private int[] QueMas;
    static private int[] ArrColorBot; //массив цветов
    static private int[] ArrWayBot; //массив направлений
    private int count;
    private bool access;
    private int NextBall;
    private int NextBall1;
    private bool Rotating, Rotating1;
    static public bool your_turnn = false;
    static public bool BotOn;
    static public bool Way2 = false;
    static public bool Way2True = false;
    static public bool startBot;

    public void Restart()
    {
        if(Way2){
            Way2 = false;
            Way2True = true;
            for (int i = 1; i < Spawn.MySize * Spawn.MySize + 1; i++)
            {
                ArrColorBot[i] = Spawn.ArrColor[i];
                ArrWayBot[i] = Spawn.ArrWay[i];
                WayUp(i);
            }
        }
        else
            for (int i = 1; i < Spawn.MySize * Spawn.MySize + 1; i++)
            {
                ArrColorBot[i] = Spawn.ArrColor[i];
                ArrWayBot[i] = Spawn.ArrWay[i];
            }
    }

    private void RestartMas()
    {
        QueMas = new int[Spawn.MySize * Spawn.MySize + 1];
    }

    private void Start()
    {
        QueMas = new int[Spawn.MySize * Spawn.MySize +  1];
        ArrColorBot = new int[Spawn.MySize * Spawn.MySize + 1];
        ArrWayBot = new int[Spawn.MySize * Spawn.MySize + 1];
        count = 1;
        access = true;
    }

    private void FixedUpdate()
    {
        if(myGUI.stepGo && myGUI.step == 0 && Touchs.StartTouch)
        {
            for (int i = 1; i < Spawn.MySize * Spawn.MySize; i++)
            {
                if (Spawn.ArrColor[i] == Spawn.WinBall)
                    PlayerQu++;
                else if (Spawn.ArrColor[i] == BotWin)
                    BotQu++;
            }
            if (PlayerQu > BotQu)
                Touchs.WIN = true;
            else Touchs.LOSE = true;
        }
    }

    private void Update()
    {
        if  (Touchs.StartTouch && your_turnn){
            Touchs.StartTouch = false;
        }
        if (Touchs.StartTouch && Touchs.NumberOfStep % 2 == 0)
        {
            CanvasBot.opponent_turn_bt = true;
        }
        if(startBot){
            your_turnn = true;
            startBot = false;
            Touchs.NumberOfStep = 1;
            if (access)
            {
                Restart:
                access = false;
                Restart();
                RestartMas();
                for (int i = 1; i < Spawn.MySize * Spawn.MySize + 1; i++)
                {
                    if (Spawn.ArrColor[i] == BotWin)
                    {
                        count = i;
                        queueToRot(i);
                        Restart();
                    }
                }
                int max = -1;
                int maxj = 0;
                for (int j = 1; j < Spawn.MySize * Spawn.MySize + 1; j++)
                {
                    if (QueMas[j] > max)
                    {
                        max = QueMas[j];
                        maxj = j;
                    }
                }
                int tmp = 0;
                while (maxj == 0 && tmp < Spawn.MySize * Spawn.MySize)
                {
                    maxj = UnityEngine.Random.Range(1, Spawn.MySize * Spawn.MySize);
                    if (ArrColorBot[maxj] == Spawn.WinBall) { maxj = 0; tmp++;}
                }
                tmp = 0;
                if (QueMas[maxj] == 0) {
                    Way2 = true;
                    if(!Way2True){
                        goto Restart;
                    }
                    while(Spawn.ArrColor[maxj] == BotWin) {
                        maxj = UnityEngine.Random.Range(1, Spawn.MySize * Spawn.MySize);
                        Debug.Log(maxj);
                    }
                    if(Way2True){
                        Way2True = false;
                    }
                }
                
                //
        /*if (maxj == 1){
                    Debug.Log(maxj);
                    string test = "";
                    for (int i = 1; i < Spawn.MySize * Spawn.MySize + 1; i++)
                    {
                        test+=QueMas[i].ToString();
                    }
                    Debug.Log(test);
                }*/
                //
                
                next = GameObject.Find(maxj.ToString()); // Ищем этот шарик среди наших и записываем в "next" его Gameobject
                Ball nexing = next.GetComponent<Ball>(); // Получаем скрипт для прокрутки шара, которого мы коснулись
                nexing.StepRot = Ball.Speed; // Начинаем крутить шар, до которого каснулись
                access = true;
            }
        }
    }

    public void queueToRot(int present)
    {
        WayUp(present);
        Rotating1 = false;
        Rotating = false;
        switch (ArrWayBot[present])
        {
            case 1:
                    if (present + Spawn.MySize < Spawn.MySize * Spawn.MySize + 1)
                    {
                        if (ArrWayBot[present + Spawn.MySize] == 2 || ArrWayBot[present + Spawn.MySize] == 3)
                        {
                            NextBall = present + Spawn.MySize;
                            Rotating = true;
                        }
                    }
                    if (present + 1 < Spawn.MySize * Spawn.MySize + 1)
                        if (!((present + 1) % Spawn.MySize == 1))
                            if (ArrWayBot[present + 1] == 4 || ArrWayBot[present + 1] == 3)
                            {
                                NextBall1 = present + 1;
                                Rotating1 = true;
                            }
                break;
            case 2:
                    if (present - Spawn.MySize > 0)
                    {
                        if (ArrWayBot[present - Spawn.MySize] == 1 || ArrWayBot[present - Spawn.MySize] == 4)
                        {
                            NextBall = present - Spawn.MySize;
                            Rotating = true;
                        }
                    }
                    if (present + 1 < Spawn.MySize * Spawn.MySize + 1)
                        if (!((present + 1) % Spawn.MySize == 1))
                        {
                            if (ArrWayBot[present + 1] == 4 || ArrWayBot[present + 1] == 3)
                            {
                                NextBall1 = present + 1;
                                Rotating1 = true;
                            }
                        }
                break;
            case 3:
                    if (present - Spawn.MySize > 0)
                    {
                        if (ArrWayBot[present - Spawn.MySize] == 1 || ArrWayBot[present - Spawn.MySize] == 4)
                        {
                            NextBall = present - Spawn.MySize;
                            Rotating = true;
                        }
                    }
                    if (present - 1 > 0)
                        if (!((present - 1) % Spawn.MySize == 0))
                        {
                            if (ArrWayBot[present - 1] == 2 || ArrWayBot[present - 1] == 1)
                            {
                                NextBall1 = present - 1;
                                Rotating1 = true;
                            }
                        }
                break;
            case 4:
                    if (present - 1 > 0)
                        if (!((present - 1) % Spawn.MySize == 0))
                        {
                            if (ArrWayBot[present - 1] == 2 || ArrWayBot[present - 1] == 1)
                            {
                                NextBall = present - 1;
                                Rotating = true;
                            }
                        }
                    if (present + Spawn.MySize < Spawn.MySize * Spawn.MySize + 1)
                    {
                        if (ArrWayBot[present + Spawn.MySize] == 2 || ArrWayBot[present + Spawn.MySize] == 3)
                        {
                            NextBall1 = present + Spawn.MySize;
                            Rotating1 = true;
                        }
                    }
                break;
            default:
                Debug.Log("ОШИБКА!");
                break;
        }
        if (Rotating1)
        {
            if (ArrColorBot[present] != ArrColorBot[NextBall1])
            {
                ColorReplacement(NextBall1, ArrColorBot[present]);
                QueMas[count]++;
            }
            queueToRot(NextBall1);
        }
        if (Rotating)
        {
            if (ArrColorBot[present] != ArrColorBot[NextBall])
            {
                ColorReplacement(NextBall, ArrColorBot[present]);
                QueMas[count]++;
            }
            queueToRot(NextBall);
        }
    }

    void WayUp(int i)
    {
        if (ArrWayBot[i] < 4)
            ArrWayBot[i]++;
        else ArrWayBot[i] = 1;
    }

    void ColorReplacement(int present, int color)
    {
        next = GameObject.Find(present.ToString());
        switch (color) {
            case 1:
                ArrColorBot[present] = 1;
                break;
            case 2:
                ArrColorBot[present] = 2;
                break;
            case 3:
                ArrColorBot[present] = 3;
                break;
            case 4:
                ArrColorBot[present] = 4;
                break;
            default:
                Debug.Log("Ошибка color in ColorReplacement: " + color);
                break;
        }
    }
}