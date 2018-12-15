using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TricksterHelp : MonoBehaviour { //Скрипт помощи доброго Трикстера

    private bool Active = true;//
    public Image CoolDown;
    public float CoolDownf = 10;
    bool isCoolDown = false;
    public GameObject Cloud;

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
        //
        if (isCloud)
        {
            isCloud = false;
			Cloud.SetActive(false);
            switch (change)
            {
                case 1: 
                    Rotate(); 
                    break;
                case 2: 
                    myGUI.trHelpValue = value;
                    myGUI.memTimer = myGUI.timersecond + value;
                    myGUI.timerUp = true;
                    AddTime(value); 
                    break;
                case 3:    
                    myGUI.trHelpValue = value;
                    myGUI.memTimer = myGUI.timersecond;
                    myGUI.stepUp = true; 
                    AddStep(value); 
                    break;
                case 4:
                    TempBool.start = true;
                    break;
                case 5:
                    myGUI.timersecond = (int)(myGUI.timersecond/2);
                    break;
                case 6:
                    FindMaxWay.Inicializate = true;
                    FindMaxWay.Activate = true;
                    break;
            }
        }

    }

    public void TrickHelp() //Скрипт кнопки
    {
        if (Active)
        {
            StartCoroutine(Wait());
            rerunCloud:
            short randomCloud = (short)Random.Range(1, 11);//Рандомное число для выбора облака 1=Flash, 2=Trick, 3=Angel, 4..10=Normal
            //short randomCloud = 3;
            if (!myGUI.timerGo && (randomCloud == 1)) goto rerunCloud;
            if(randomCloud==1){ //FlCloud
                Cloud_Ver2.ver = 1;

                Cloud_Ver2.flSound = true;
                short rand = (short)Random.Range(0, 1001);
                short randomTime = (short)Random.Range(13, 22); //Рандомное добавляемое время (max не включая)
                if(rand >= 600 && rand <= 610) randomTime = 66;
                if(rand == 1000) randomTime = 95;
                CoolDown.fillAmount = 0.99f;//
                isCoolDown = true;
                change = 2; 
                value = randomTime;

                Cloud.SetActive(true);
                Cloud_Ver2.start = true;
            }else if(randomCloud==2){ //TrCloud
                Cloud_Ver2.ver = 2;

                //
                TrRerun: short random = (short)Random.Range(1, 4); // 1 = colorBombs, 2 = TortoiseBombs, 3 = time/2
                if (!myGUI.timerGo && (random == 3)) goto TrRerun;
                switch (random)
                {
                    case 1: change = 4; break;
                    case 2: break;
                    case 3: change = 5; break;
                    default: Debug.Log("Недопустимое значение в TricksterHelp.cs -> TrickHelp(); "); goto TrRerun;
                }
                //

                CoolDown.fillAmount = 0.99f;//
                isCoolDown = true;
                Cloud.SetActive(true);
                Cloud_Ver2.start = true;

            }else if(randomCloud==3){ //AnCloud
                Cloud_Ver2.ver = 3;

                //
                rerun: short random = (short)Random.Range(1, 4);
                if (!myGUI.timerGo && (random == 1)) goto rerun;
                if (!myGUI.stepGo && (random == 2)) goto rerun;
                switch (random)
                {
                    case 1: change = 2; value = 20; //добавляет 20 сек
                        break;
                    case 2: change = 3; value = 10; //добавляет 10 шагов
                        break;
                    case 3: change = 6; //Поиск максимального пути
                        break;
                    default: Debug.Log("Недопустимое значение в TricksterHelp.cs -> TrickHelp(); "); goto rerun;
                }
                //
                
                CoolDown.fillAmount = 0.99f;//
                isCoolDown = true;
                Cloud.SetActive(true);
                Cloud_Ver2.start = true;
            }else { //UsCloud
                Cloud_Ver2.ver = 4;

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
                Cloud.SetActive(true);
                Cloud_Ver2.start = true;
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