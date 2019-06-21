using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class colorBall : MonoBehaviour
{
    static public int timeForExplosion = 0;
    static public int quantity = 0;
    private float secondgametime = 0f;
    private int timersecond = 1;
    private bool active = false;
    private GameObject[] balls;
    private int[][] listOfBoom;
    void Start()
    {
        
    }

    void Update()
    {
        secondgametime += Time.deltaTime;
        if (secondgametime >= 1)
        {
            secondgametime = 0;
            timersecond++;
        }
        if(timersecond%timeForExplosion==9) active = true;
        if(timersecond%timeForExplosion==0 && active){
            //active = false;
            //listOfBoom = new int[quantity][];
            Boom();
        }
    }
    public void Boom(){
        active = false;
        listOfBoom = new int[quantity][];
        balls = new GameObject[quantity];
        for (int i = 0; i < quantity; i++){
            repeat:
            int ball = Random.Range(0, spawn.field_size*spawn.field_size);

            if(GameObject.Find(""+ball).GetComponent<ball>().busy){
                goto repeat;
            }
            GameObject tmpAppear = Instantiate(info.appearancePrefab, GameObject.Find(""+ball).transform.position + new Vector3(0f, 0f, -5.1f), Quaternion.Euler(0, 0, 0));
            tmpAppear.name = i+"A";
            StartCoroutine(DestroyAppearance(i));
            balls[i] = Instantiate(info.ballPrefab,   GameObject.Find(""+ball).transform.position + new Vector3(0f, 0f, -5f), Quaternion.Euler(0, 0, 0));
            balls[i].name = ball+"C";
            GameObject.Find(""+ball).GetComponent<ball>().busy = true;
            GameObject.Find(ball+"C").GetComponent<Animator>().enabled = true;

            repeatColor:
            int randomColorBoom = UnityEngine.Random.Range(0, 4);
            if(randomColorBoom==info.winBall){
                goto repeatColor;
            }
            if(i==1){
                if(info.AudioOn) GameObject.Find(ball.ToString()).GetComponent<AudioSource>().Play();
            }
            StartCoroutine(BoomIE(randomColorBoom, ball, i));
        }
    }

    IEnumerator BoomIE(int color, int nameInt, int number){
        yield return new WaitForSeconds(7.2f);
        GameObject.Find(nameInt+"C").transform.position = new Vector3 (  GameObject.Find(nameInt+"C").transform.position.x,  GameObject.Find(nameInt+"C").transform.position.y,-5.5f);
        listOfBoom[number] = new int[9];
        yield return new WaitForSeconds(0.8f);
        listOfBoom[number][0] = nameInt-info.field_size-1;
        listOfBoom[number][1] = nameInt-info.field_size;
        listOfBoom[number][2] = nameInt-info.field_size+1;
        listOfBoom[number][3] = nameInt-1;
        listOfBoom[number][4] = nameInt;
        listOfBoom[number][5] = nameInt+1;
        listOfBoom[number][6] = nameInt+info.field_size-1;
        listOfBoom[number][7] = nameInt+info.field_size;
        listOfBoom[number][8] = nameInt+info.field_size+1;
        
        GameObject.Find(""+nameInt).GetComponent<ball>().busy = false;

        for (int i = 0; i < 9; i++){
            if(listOfBoom[number][i] < 0 || 
            listOfBoom[number][i] >= info.field_size*info.field_size || 
            info.stat_balls.Contains(listOfBoom[number][i]) ||
            GameObject.Find(""+listOfBoom[number][i]).GetComponent<ball>().busy){
                listOfBoom[number][i] = -1;
            }
        }
        if(nameInt%info.field_size==0){
            listOfBoom[number][0] = -1;
            listOfBoom[number][3] = -1;
            listOfBoom[number][6] = -1;
        }
        if(nameInt%info.field_size==info.field_size-1){
            listOfBoom[number][2] = -1;
            listOfBoom[number][5] = -1;
            listOfBoom[number][8] = -1;
        }
        Sprite colorSprite = null;
        switch(color){
            case 0: colorSprite = info.ball_blue; break;
            case 1: colorSprite = info.ball_yellow; break;
            case 2: colorSprite = info.ball_green; break;
            case 3: colorSprite = info.ball_red; break;
        }
        foreach (int i in listOfBoom[number]){
            if(i != -1){
                GameObject.Find(""+i).GetComponent<SpriteRenderer>().sprite = colorSprite;
                info.ballColors[spawn.ArrColor[i]]--;
                spawn.ArrColor[i] = color;
                info.ballColors[color]++;
            }
        }
        GameObject.Find(""+nameInt).GetComponent<ball>().busy = false;
        yield return new WaitForSeconds(1f);
        Destroy(GameObject.Find(nameInt+"A"));
        Destroy(GameObject.Find(nameInt+"C"));
    }

    IEnumerator DestroyAppearance(int nameInt){
        yield return new WaitForSeconds(1.1f);
        Destroy(GameObject.Find(nameInt+"A"));
    }
}