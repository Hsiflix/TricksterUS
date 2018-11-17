using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Ball : MonoBehaviour {

    public GameObject next1; //Слудующий дял кручения шар №1
    public GameObject next; //Слудующий дял кручения шар №2

    public Sprite ballRender1; //sprite Ball1
    public Sprite ballRender2; //sprite Ball2
    public Sprite ballRender3; //sprite Ball3
    public Sprite ballRender4; //sprite Ball4

    public GameObject ball1; //blue 1
    public GameObject ball2; //yellow 2
    public GameObject ball3; //red 3
    public GameObject ball4; //green 4

    public int NextBall;
    public int NextBall1;
    public bool Rotating = false;
    public bool Rotating1 = false;
    public int StepRot;
    public string NameOfBall;
    static public int Speed;
    public bool Active = true;
    public bool notpause = true;
    public bool RotNext = true;

    // Use this for initialization
    void Start () {
        StepRot = 0;
        Speed = 16;
        //Speed = 100;
        //Правка 10 июня 2018
        Rotating = false;
        Rotating1 = false;
        Active = true;
        //Конец правки 10 июня 2018
    }

    // Update is called once per frame
    void Update () {
        if (Active && notpause)
        {
            if (StepRot == Speed)
            {
                if(Infos.AudioOn)GetComponent<AudioSource>().Play();
                NameOfBall = transform.name;
                NextBall = Int32.Parse(NameOfBall);
                //Debug.Log("This: " + NextBall + ' ' + "WayOld: " + Spawn.ArrWay[NextBall]);
                if (RotNext) WayUp(NextBall);
            }
            if (StepRot > 0)
            {
                StepRot--;
                //transform.Rotate(Vector3.Lerp(new Vector3(+0f, +0f, +0f), new Vector3(+0f, +0f, -90f), 0.01f));
                transform.Rotate(Vector3.Lerp(new Vector3(+0f, +0f, +0f), new Vector3(+0f, +0f, -90f), 0.0625f));
                if (!RotNext && StepRot == 0) RotNext = true;
            }
            if (StepRot == 1 && RotNext)
            {
                queueToRot(NextBall);
            }
        }
        else if (StepRot == Speed) //Правка 10.07.18
        {
            StepRot = 0;
            Spawn.ArrColor[NextBall] = Spawn.WinBall;
        }
    }

    public void queueToRot(int present)
    {
        Rotating1 = false;
        Rotating = false;
        //Debug.Log("queueToRot!!  " + present + "---" + Spawn.ArrWay[present]);
        if (Spawn.ArrWay[present] == 1)
        {
            if (present + Spawn.MySize < Spawn.MySize * Spawn.MySize + 1)
            {
                if (Spawn.ArrWay[present + Spawn.MySize] == 2 || Spawn.ArrWay[present + Spawn.MySize] == 3)
                {
                    NextBall = present + Spawn.MySize;
                    Rotating = true;
                }
            }
            if (present + 1 < Spawn.MySize * Spawn.MySize + 1)
                if (!((present + 1) % Spawn.MySize == 1))
                    if (Spawn.ArrWay[present + 1] == 4 || Spawn.ArrWay[present + 1] == 3)
                    {
                        NextBall1 = present + 1;
                        Rotating1 = true;
                    }
        }
        else if (Spawn.ArrWay[present] == 2)
        {
            if (present - Spawn.MySize > 0)
            {
                if (Spawn.ArrWay[present - Spawn.MySize] == 1 || Spawn.ArrWay[present - Spawn.MySize] == 4)
                {
                    NextBall = present - Spawn.MySize;
                    Rotating = true;
                }
            }
            if (present + 1 < Spawn.MySize * Spawn.MySize + 1)
                if (!((present + 1) % Spawn.MySize == 1))
                {
                    if (Spawn.ArrWay[present + 1] == 4 || Spawn.ArrWay[present + 1] == 3)
                    {
                        NextBall1 = present + 1;
                        Rotating1 = true;
                    }
                }
        }
        else if (Spawn.ArrWay[present] == 3)
        {
            if (present - Spawn.MySize > 0)
            {
                if (Spawn.ArrWay[present - Spawn.MySize] == 1 || Spawn.ArrWay[present - Spawn.MySize] == 4)
                {
                    NextBall = present - Spawn.MySize;
                    Rotating = true;
                }
            }
            if (present - 1 > 0)
                if (!((present - 1) % Spawn.MySize == 0))
                {
                    if (Spawn.ArrWay[present - 1] == 2 || Spawn.ArrWay[present - 1] == 1)
                    {
                        NextBall1 = present - 1;
                        Rotating1 = true;
                    }
                }
        }
        else if (Spawn.ArrWay[present] == 4)
        {
            if (present - 1 > 0)
                if (!((present - 1) % Spawn.MySize == 0))
                {
                    if (Spawn.ArrWay[present - 1] == 2 || Spawn.ArrWay[present - 1] == 1)
                    {
                        NextBall = present - 1;
                        Rotating = true;
                    }
                }
            if (present + Spawn.MySize < Spawn.MySize * Spawn.MySize + 1)
            {
                if (Spawn.ArrWay[present + Spawn.MySize] == 2 || Spawn.ArrWay[present + Spawn.MySize] == 3)
                {
                    NextBall1 = present + Spawn.MySize;
                    Rotating1 = true;
                }
            }
        }
        else Debug.Log("ОШИБКА!");

        if (Rotating1)
        {
            next1 = GameObject.Find(NextBall1.ToString());
            Ball nexing1 = next1.GetComponent<Ball>();
            if (nexing1.Active)
            {
                if (Spawn.ArrColor[present] != Spawn.ArrColor[NextBall1])
                    ColorReplacement(NextBall1, Spawn.ArrColor[present], true);
                //next1 = GameObject.Find(NextBall1.ToString());
                //Ball nexing1 = next1.GetComponent<Ball>();
                nexing1.StepRot = Speed;
            }
        }

        if (Rotating)
        {
            next = GameObject.Find(NextBall.ToString());
            Ball nexing = next.GetComponent<Ball>();
            if (nexing.Active)
            {
                if (Spawn.ArrColor[present] != Spawn.ArrColor[NextBall])
                    ColorReplacement(NextBall, Spawn.ArrColor[present], false);
                nexing.StepRot = Speed;
            }
        }
    }
    void WayUp(int i)
    {
        if (Spawn.ArrWay[i] < 4)
            Spawn.ArrWay[i]++;
        else Spawn.ArrWay[i] = 1;
    }
    void ColorReplacement(int present, int color, bool var)
    {
            next = GameObject.Find(present.ToString());
            if (color == 1)
            {
                next.GetComponent<SpriteRenderer>().sprite = ballRender1;
                Spawn.ArrColor[present] = 1;
            }
            else if (color == 2)
            {
                next.GetComponent<SpriteRenderer>().sprite = ballRender2;
                Spawn.ArrColor[present] = 2;
            }
            else if (color == 3)
            {
                next.GetComponent<SpriteRenderer>().sprite = ballRender3;
                Spawn.ArrColor[present] = 3;
            }
            else if (color == 4)
            {
                next.GetComponent<SpriteRenderer>().sprite = ballRender4;
                Spawn.ArrColor[present] = 4;
            }
    }
}
