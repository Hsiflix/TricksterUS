using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBall : MonoBehaviour {

    static public bool ColorBallOn = false;
    private int ExplosionBallNow;
    private GameObject ExplosionBall;
    private int ColorExplosion;
    private int TimeNow;
    static public int TimeForExplosion;
    static public int StockTime;
    private int SaveTime = - 10;
    public GameObject myBombAnim;
    private bool BoomFlag = false;
    private int ExplTimeTest;

    public Sprite ballRender1; //sprite Ball1
    public Sprite ballRender2; //sprite Ball2
    public Sprite ballRender3; //sprite Ball3
    public Sprite ballRender4; //sprite Ball4
    private Sprite ballRender; //sprite

    private void Start()
    {
        //Правка 10 июня 2018
        Debug.Log("ColorBall");
        TimeNow = myGUI.timersecond;
        SaveTime = -10;
        BoomFlag = false;
        if (Spawn.timerseconds == 0) ExplTimeTest = TimeForExplosion;
        else ExplTimeTest = Spawn.timerseconds - TimeForExplosion;
        //Конец правки 10 июня 2018
    }

    private void Update()
    {
        if (ColorBallOn)
        {
            if (myGUI.timersecond == ExplTimeTest && myGUI.timersecond != StockTime && myGUI.timersecond != TimeNow)
            {
                if (Spawn.timerseconds == 0) ExplTimeTest += TimeForExplosion;
                else ExplTimeTest -= TimeForExplosion;
                TimeNow = myGUI.timersecond;
                ColorExplosion = Random.Range(1, 5);
                while (ColorExplosion == Spawn.WinBall)
                {
                    ColorExplosion = Random.Range(1, 5);
                }
                Debug.Log(ColorExplosion);
                switch (ColorExplosion) {
                    case 1:
                        ballRender = ballRender1;
                        break;
                    case 2:
                        ballRender = ballRender2;
                        break;
                    case 3:
                        ballRender = ballRender3;
                        break;
                    case 4:
                        ballRender = ballRender4;
                        break;
                    default:
                        Debug.Log("Error ColorExplosion: " + ColorExplosion);
                        break;
                }

                ExplosionBallNow = Random.Range(1, Spawn.MySize * (Spawn.MySize - 2) - 1); // Левый нижний край взрыва
                while (ExplosionBallNow % Spawn.MySize == 0 || ExplosionBallNow % Spawn.MySize == Spawn.MySize - 1)
                    ExplosionBallNow = Random.Range(1, Spawn.MySize * (Spawn.MySize - 2) - 1); // Левый нижний край взрыва
                ExplosionBall = GameObject.Find(ExplosionBallNow.ToString());
                myBombAnim.transform.position = ExplosionBall.transform.position + new Vector3(0.9f, 0.9f, 0.9f);
                myBombAnim.SetActive(true);
                SaveTime = myGUI.timersecond;
                BoomFlag = true;
            }
        }
        if((Spawn.timerseconds == 0 && myGUI.timersecond - SaveTime == 8 || SaveTime - myGUI.timersecond == 8)&& BoomFlag)
        {
            BoomFlag = false;
            Boom();
        }
    }

    private void Boom()
    {
        for (int i = 0; i < 3; i++)
        {
            ExplosionBall = GameObject.Find(ExplosionBallNow.ToString());
            if (ExplosionBall.GetComponent<Ball>().Active)
            {
                ExplosionBall.GetComponent<SpriteRenderer>().sprite = ballRender;
                Spawn.ArrColor[ExplosionBallNow] = ColorExplosion;
            }
                ExplosionBallNow++;
        }
        ExplosionBallNow--;
        ExplosionBallNow += Spawn.MySize;
        for (int i = 0; i < 3; i++)
        {
            ExplosionBall = GameObject.Find(ExplosionBallNow.ToString());
            if (ExplosionBall.GetComponent<Ball>().Active)
            {
                ExplosionBall.GetComponent<SpriteRenderer>().sprite = ballRender;
                Spawn.ArrColor[ExplosionBallNow] = ColorExplosion;
            }
            ExplosionBallNow--;
        }
        ExplosionBallNow++;
        ExplosionBallNow += Spawn.MySize;
        for (int i = 0; i < 3; i++)
        {
            ExplosionBall = GameObject.Find(ExplosionBallNow.ToString());
            if (ExplosionBall.GetComponent<Ball>().Active)
            {
                ExplosionBall.GetComponent<SpriteRenderer>().sprite = ballRender;
                Spawn.ArrColor[ExplosionBallNow] = ColorExplosion;
            }
            ExplosionBallNow++;
        }
        myBombAnim.SetActive(false);

    }
}

