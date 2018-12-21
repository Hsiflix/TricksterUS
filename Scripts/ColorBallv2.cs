using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBallv2 : MonoBehaviour {

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
    public bool badTrickB;
    private int ExplTimeTest;
    public int number;
    static public int now = -1;

    public Sprite ballRender1; //sprite Ball1
    public Sprite ballRender2; //sprite Ball2
    public Sprite ballRender3; //sprite Ball3
    public Sprite ballRender4; //sprite Ball4
    private Sprite ballRender; //sprite

    private void Start()
    {
        //Правка 10 июня 2018
        //Debug.Log("ColorBall");
        SaveTime = -10;
        BoomFlag = false;
        if (Spawn.timerseconds == 0) ExplTimeTest = TimeForExplosion;
        else ExplTimeTest = Spawn.timerseconds - TimeForExplosion;
        //Конец правки 10 июня 2018
    }

    public void badTrickster(){
        badTrickB = true;
    }

    private void Update()
    {
            if (badTrickB)
            {
                badTrickB = false;
                if (Spawn.timerseconds == 0) ExplTimeTest += TimeForExplosion;
                else ExplTimeTest -= TimeForExplosion;
                ColorExplosion = Random.Range(1, 5);
                while (ColorExplosion == Spawn.WinBall)
                {
                    ColorExplosion = Random.Range(1, 5);
                }
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

                int[] other = new int[2];
                if(number == 1){
                    other[0] = TempBool.spawns[0]; other[1] = 0;
                }else if(number == 2){
                    other[0] = TempBool.spawns[1]; other[1] = TempBool.spawns[0];
                }

                while (ExplosionBallNow % Spawn.MySize == 0 || ExplosionBallNow % Spawn.MySize == Spawn.MySize - 1 || ExplosionBallNow == other[0] || ExplosionBallNow == other[1])
                    ExplosionBallNow = Random.Range(1, Spawn.MySize * (Spawn.MySize - 2) - 1); // Левый нижний край взрыва

                TempBool.spawns[number] = ExplosionBallNow;

                ExplosionBall = GameObject.Find(ExplosionBallNow.ToString());
                myBombAnim.transform.position = ExplosionBall.transform.position + new Vector3(0.9f, 0.9f, 0.9f);
                myBombAnim.SetActive(true);
                SaveTime = myGUI.timersecond;
                BoomFlag = true;
            }
        if((Spawn.timerseconds == 0 && myGUI.timersecond - SaveTime == 8 || SaveTime - myGUI.timersecond == 8)&& BoomFlag)
        {
            BoomFlag = false;
            badTrickB = false;
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