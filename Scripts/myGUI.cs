using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class myGUI : MonoBehaviour // -----TIMER + STEP-----
{
    static public Texture ballRender;

    public GameObject game;
    public GameObject gameover;
    public GameObject gamewin;
    public GameObject lolLose;

    private int lolLoseTime = -1;

    //outline
    public GameObject outline;
    static public Color outline_color = Color.white;
    static public Image _image;


    static public int timersecond;
    private float secondgametime;
    public Font myFont;
    static public bool timerGo = false;
    static public bool stepGo = false;
    static public int step;

    public float scrinWidth;
    public float scrinHeight;
    public float BalansWidth;
    public float BalansHeight;

    //======================================== СТАРТ ===============================================================
    public void Start()
    {

        //Правка 10 июня 2018
        //Конец правки 10 июня 2018

        //outline
        _image = outline.gameObject.GetComponent<Image>(); //Смена цвета
        _image.color = outline_color;

        // 1 Присваивание переменным значений
        scrinWidth = Screen.width;
        scrinHeight = Screen.height;
        BalansWidth = 800 / scrinWidth;
        BalansHeight = 480 / scrinHeight;//
        if (!timerGo)
        {
            lolLoseTime = UnityEngine.Random.Range(10, 100);
            //Debug.Log(lolLoseTime);
        }
    }

    public void Pause()
    {
        SceneManager.LoadScene("menu", LoadSceneMode.Single);
    }

    void Update()
    {
        if (stepGo)
        {
            if (step == 0 && BotX.BotOn == false && Touchs.StartTouch)
            {
                Touchs.LOSE = true;
            }
        }

        if (Touchs.LOSE)
        {
            //2.07.18
            for (int i = 1; i < Spawn.MySize * Spawn.MySize + 1; i++)
            {
                GameObject ball = GameObject.Find(i.ToString());
                Ball bollin = ball.GetComponent<Ball>();
                if (bollin.StepRot == 0) bollin.Active = false;
            }
            ///2.07.18
            //02.10.18
            //Time.timeScale = 0;
            ///02.10.18
            gameover.SetActive(true);
            game.SetActive(false);
        }
        if (Touchs.WIN) // ОБЯЗАТЕЛЬНО ИЗМЕНИТЬ!!!!
        {
            //2.07.18
            for (int i = 1; i < Spawn.MySize * Spawn.MySize + 1; i++)
            {
                GameObject ball = GameObject.Find(i.ToString());
                Ball bollin = ball.GetComponent<Ball>();
                if (bollin.StepRot == 0) bollin.Active = false;
            }
            ///2.07.18
            //Time.timeScale = 0; 01/09/2018
            gamewin.SetActive(true);
            game.SetActive(false);
        }

        if (timerGo)
        {
            if (!Touchs.LOSE)
            {
                secondgametime += Time.deltaTime;
                if (secondgametime >= 1)
                {
                    timersecond -= 1;
                    secondgametime = 0;
                }
                if (timersecond == 0)
                {
                    Touchs.LOSE = true;
                }
            }
        }
        else
        {
            secondgametime += Time.deltaTime;
            if (secondgametime >= 1)
            {
                timersecond += 1;
                secondgametime = 0;
                if (timersecond == lolLoseTime)
                {
                    lolLose.SetActive(true);
                    timersecond = 5;
                    timerGo = true;
                }
            }
        }
    }
    void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle();
        myStyle.font = myFont;
        myStyle.fontSize = (int)(40 / BalansHeight);
        myStyle.normal.textColor = new Color(36 / 255f, 0, 51 / 255f);
        //GUI.Label(new Rect(38 / BalansWidth, 5 / BalansHeight, 0 / BalansWidth, 0 / BalansHeight), "Timer:" , myStyle);
        myStyle.normal.textColor = Color.white;
        if (timerGo && !Touchs.LOSE && timersecond <= 10)
        {
            myStyle.normal.textColor = Color.white;
            for (int i = 11; i > 4; i -= 2)
                if (timersecond == i)
                    myStyle.normal.textColor = Color.red;
            if (timersecond < 4) myStyle.normal.textColor = Color.red;//
        }
        GUI.Label(new Rect(48 / BalansWidth, 68 / BalansHeight, 0 / BalansWidth, 0 / BalansHeight), ""+timersecond, myStyle);
        myStyle.normal.textColor = new Color(36 / 255f, 0, 51 / 255f);
        //GUI.Label(new Rect(23 / BalansWidth, 130 / BalansHeight, 0 / BalansWidth, 0 / BalansHeight), "Step:", myStyle);
        myStyle.normal.textColor = Color.white;
        GUI.Label(new Rect(40 / BalansWidth, 187 / BalansHeight, 0 / BalansWidth, 0 / BalansHeight), ""+step, myStyle);
        myStyle.normal.textColor = Color.black;

        switch (Spawn.WinBall) //Победный цвет: 1 - blue, 2 - yellow, 3 - red, 4 - green;//
        {
            case 1: myStyle.normal.textColor = Color.blue; break;
            case 2: myStyle.normal.textColor = Color.yellow; break;
            case 3: myStyle.normal.textColor = Color.red; break;
            case 4: myStyle.normal.textColor = Color.green; break;
            default: myStyle.normal.textColor = Color.black; break;
        }
        //GUI.Label(new Rect(25 / BalansWidth, 242 / BalansHeight, 0 / BalansWidth, 0 / BalansHeight), "Color:", myStyle);
        GUI.DrawTexture(new Rect(40 / BalansWidth, 305 / BalansHeight, 35 / BalansWidth, 35 / BalansHeight), ballRender);
    }



}