﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TricksterHelp : MonoBehaviour { //Скрипт помощи доброго Трикстера

    private bool Active = true;//
    public Image CoolDown;
    public float CoolDownf = 10;
    bool isCoolDown = false;

    static public bool isCloud = false;
    static public short change = 0;
    static public short value = 0;


    private void Update()
    {
        if (isCoolDown)
        {
            CoolDown.fillAmount -= 1 / CoolDownf * Time.deltaTime;
            if (CoolDown.fillAmount <= 0)
            {
                isCoolDown = false;
                CoolDown.fillAmount = 0;
            }
        }

        if (isCloud)
        {
            isCloud = false;
            switch (change)
            {
                case 1: Rotate(); break;
                case 2: AddTime(value); break;
                case 3: AddStep(value); break;
            }
        }

    }

    public void TrickHelp() //Скрипт кнопки
    {
        //Debug.Log(Active);
        if (Active)
        {
            StartCoroutine(Wait());

            short randomCloud = (short)Random.Range(1, 11);//Рандомное число для выбора облака 1=Flash, 2=Trick, 3=Angel, 4..10=Normal
            if(randomCloud==1){
                CLoud.ChoiseVer = 1;
                short randomTime = (short)Random.Range(10, 20); //Рандомное добавляемое время (max не включая)
                if(randomTime > 18) randomTime = (short)Random.Range(20, 45);
                if(randomTime > 43) randomTime = (short)Random.Range(45, 95);
                CoolDown.fillAmount = 0.99f;//
                isCoolDown = true;
                change = 2; value = randomTime;
                CLoud.setvalue = true;
                //CLoud.value = value;
                CLoud.Trigger = true;
            }else if(randomCloud==2){
                CLoud.ChoiseVer = 2;

                CoolDown.fillAmount = 0.99f;//
                isCoolDown = true;

            }else if(randomCloud==3){
                CLoud.ChoiseVer = 3;

                CoolDown.fillAmount = 0.99f;//
                isCoolDown = true;

            }else { 
                CLoud.ChoiseVer = 4;
                short randomTime = (short)Random.Range(3, 8); //Рандомное добавляемое время (max не включая)
                short randomStep = (short)Random.Range(1, 4); //Рандомные добовляемые ходы (max не включая)
                //1-повернуть
                //2-добавить время
                //3-добавить шаги
                CoolDown.fillAmount = 0.99f;//
                isCoolDown = true;
                rerun: short random = (short)Random.Range(1, 4);
                if (!myGUI.timerGo && (random == 2)) goto rerun;
                if (!myGUI.stepGo && (random == 3)) goto rerun;
                switch (random)
                {
                    case 1: change = 1; value = -1;
                        break;
                    case 2: change = 2; value = randomTime;
                        break;
                    case 3: change = 3; value = randomStep;
                        break;
                    default: Debug.Log("Недопустимое значение в TricksterHelp.cs -> TrickHelp(); "); goto rerun;
                }
                CLoud.setvalue = true;
                CLoud.value = value;
                CLoud.Trigger = true;
            }
        }
    }

    void Rotate()
    {
        Active = false;
        Touchs.StartTouch = false;
        for (int i = 1; i< Spawn.MySize*Spawn.MySize+1; i++)
        {
            if (Spawn.ArrColor[i] != Spawn.WinBall)
            {
                GameObject ball = GameObject.Find(i.ToString());
                Ball bollin = ball.GetComponent<Ball>();
                bollin.RotNext = false;
                short randomRot = (short)Random.Range(1, 4); //Рандомное кручение (max не включая)
                WayUp(i,randomRot);
                bollin.StepRot += Ball.Speed*randomRot;
            }
        }
        //StartCoroutine(Wait());
    }

    void AddTime(int value) //Помощь - добавить время
    {
        Active = false;
        if (myGUI.timerGo)
        {
            myGUI.timersecond += value;
        }
        //StartCoroutine(Wait());
    }

    void AddStep(int value) //Помощь - добавить ходы
    {
        Active = false;
        if (myGUI.stepGo)
        {
            myGUI.step+= value;
        }
        //StartCoroutine(Wait());
    }

    void WayUp(int i, short count)
    {
        Spawn.ArrWay[i] += count;
        if (Spawn.ArrWay[i] > 4)
            Spawn.ArrWay[i]-=4;
    }

    IEnumerator Wait()
    {
        Active = false;
        yield return new WaitForSeconds(CoolDownf); // Время кулдауна
        Active = true;
    }
}