using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tortoise : MonoBehaviour {
    private int ExplosionBallNow;
    private int centerBall;
    private GameObject ExplosionBall;
    private GameObject centerBallGO;
    public GameObject tort1;
    public GameObject tort2;
    private int ColorExplosion;
    static public int touchBall;
    public GameObject myBombAnim;
    static public bool BoomFlag = false;
    public bool Delete = false;
    public bool badTrickB = true;
    public int number;
    public Sprite ballRender1; //sprite Ball1
    public Sprite ballRender2; //sprite Ball2
    public Sprite ballRender3; //sprite Ball3
    public Sprite ballRender4; //sprite Ball4
    private Sprite ballRender; //sprite
    public Sprite tortBall; 

    private void Start()
    {
        BoomFlag = false;
        badTrickster();
    }

    public void badTrickster(){
        badTrickB = true;
    }

    private void Update()
    {
            if (badTrickB)
            {
                badTrickB = false;

                ExplosionBallNow = Random.Range(1, Spawn.MySize * (Spawn.MySize - 2) - 1); // Левый нижний край взрыва

                int[] other = new int[2];
                if(number == 1){
                    other[0] = TempBool.spawns[0] - Spawn.MySize - 1; other[1] = 0;
                }else if(number == 2){
                    other[0] = TempBool.spawns[1] - Spawn.MySize - 1; other[1] = TempBool.spawns[0] - Spawn.MySize - 1;//
                }

                while (ExplosionBallNow % Spawn.MySize == 0 || ExplosionBallNow % Spawn.MySize == Spawn.MySize - 1 || ExplosionBallNow == other[0] || ExplosionBallNow == other[1])
                    ExplosionBallNow = Random.Range(1, Spawn.MySize * (Spawn.MySize - 2) - 1); // Левый нижний край взрыва

				ColorExplosion = Spawn.ArrColor[ExplosionBallNow + Spawn.MySize + 1];

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


                //
                centerBall = ExplosionBallNow + Spawn.MySize + 1;
                centerBallGO = GameObject.Find(centerBall.ToString());
                centerBallGO.GetComponent<SpriteRenderer>().sprite = tortBall;
                //
                TempBool.spawns[number] = centerBall;

                //Debug.Log(centerBall);

                ExplosionBall = GameObject.Find(ExplosionBallNow.ToString());
                myBombAnim.transform.position = ExplosionBall.transform.position + new Vector3(0.9f, 0.9f, 0.9f);
                Touchs.TortoiseB = true;
            }

        if(BoomFlag){
            BoomFlag = false;
            badTrickB = false;
            ExplosionBallNow = touchBall - 1 - Spawn.MySize;
            Boom();//
        }

        if(Delete){
            Delete = false;
            switch (Spawn.ArrColor[centerBall]) {
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
            centerBallGO.GetComponent<SpriteRenderer>().sprite = ballRender;
            BoomFlag = false;
            TempBool.spawns[0] = 0;
            TempBool.spawns[1] = 0;
            TempBool.spawns[2] = 0;
            myBombAnim.SetActive(false);
        }
    }

    private void Boom()
    {
        Debug.Log(number);
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
        //Debug.Log(TempBool.spawns[0] + " " + TempBool.spawns[1] + " " +TempBool.spawns[2]);
        Delete = true;
        tort1.GetComponent<Tortoise>().Delete = true;
        tort2.GetComponent<Tortoise>().Delete = true;
    }
}
