using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class tortoiseBall : MonoBehaviour
{
    static public int timeForExplosion = 0;
    static public int quantity = 0;
    private int quantityAll = 0;
    private float secondgametime = 0f;
    private int timersecond = 1;
    private bool active = false;
    public bool lvlActive = false;
    private int[] listOfBoom;
    private string objectTouch = "";
    private List<int> balls = new List<int>();
    private List<int> ballsColor = new List<int>();

    void Start()
    {

    }

    void Update()
    {
        if (active) // Возможность касания
        {
            if (Input.GetMouseButtonDown(0)) // Если кнопку нажали
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    objectTouch = hit.collider.name; // Записывает имя объекта по которому каснулись
                    try{
                        for (int i = 0; i < quantityAll; i++)
                        {
                            if(""+balls[i]==objectTouch){
                                StartCoroutine(BoomIE(balls[i], ballsColor[i]));
                                if(info.AudioOn) GameObject.Find("Audio_Turtle_1").GetComponent<AudioSource>().Play();
                                break;
                            }
                        }
                    }catch{

                    }
                }
            }    
        }
        if (lvlActive)
        {
            secondgametime += Time.deltaTime;
            if (secondgametime >= 1)
            {
                secondgametime = 0;
                timersecond++;
            }
            if (timersecond % timeForExplosion == 0 && !active)
            {
                Boom(quantity);
            }
        }
    }
    public void Boom(int quantityS){
        quantityAll += quantityS;
        for (int i = 0; i < quantityS; i++){
            repeat: int ball = Random.Range(0, spawn.field_size*spawn.field_size);
            if(GameObject.Find(""+ball).GetComponent<ball>().busy) goto repeat;
            GameObject tmpAppear = Instantiate(info.appearancePrefab, GameObject.Find(""+ball).transform.position + new Vector3(0f, 0f, -5.1f), Quaternion.Euler(0, 0, 0));
            tmpAppear.name = i+"A";
            StartCoroutine(DestroyAppearance(i));
            balls.Add(ball);
            ballsColor.Add(spawn.ArrColor[ball]);
            GameObject.Find(""+ball).GetComponent<ball>().busy = true;
            GameObject.Find(""+ball).GetComponent<SpriteRenderer>().sprite = info.ball_tort;
            active = true;
            info.activeTouch = false;
        }
    }

    void SwitchColor(int nameInt, int color){
        Sprite colorSprite = null;
        switch(color){
            case 0: colorSprite = info.ball_blue; break;
            case 1: colorSprite = info.ball_yellow; break;
            case 2: colorSprite = info.ball_green; break;
            case 3: colorSprite = info.ball_red; break;
        }
        GameObject.Find(""+nameInt).GetComponent<SpriteRenderer>().sprite = colorSprite;
    }


    IEnumerator BoomIE(int nameInt, int color){
        listOfBoom = new int[9];
        for (int i = 0; i < quantityAll; i++){
            SwitchColor(balls[i], ballsColor[i]);
        }
        yield return new WaitForSeconds(0.001f);
        listOfBoom[0] = nameInt-info.field_size-1;
        listOfBoom[1] = nameInt-info.field_size;
        listOfBoom[2] = nameInt-info.field_size+1;
        listOfBoom[3] = nameInt+1;
        listOfBoom[4] = nameInt+info.field_size+1;
        listOfBoom[5] = nameInt+info.field_size;
        listOfBoom[6] = nameInt+info.field_size-1;
        listOfBoom[7] = nameInt-1;
        listOfBoom[8] = nameInt;

        for (int i = 0; i < 9; i++){
            if(listOfBoom[i] < 0 || listOfBoom[i] >= info.field_size*info.field_size || info.stat_balls.Contains(listOfBoom[i])){
                listOfBoom[i] = -1;
            }
        }
        if(nameInt%info.field_size==0){
            listOfBoom[0] = -1;
            listOfBoom[6] = -1;
            listOfBoom[7] = -1;
        }
        if(nameInt%info.field_size==info.field_size-1){
            listOfBoom[2] = -1;
            listOfBoom[3] = -1;
            listOfBoom[4] = -1;
        }
        Sprite colorSprite = null;
        switch(color){
            case 0: colorSprite = info.ball_blue; break;
            case 1: colorSprite = info.ball_yellow; break;
            case 2: colorSprite = info.ball_green; break;
            case 3: colorSprite = info.ball_red; break;
        }
        foreach (int i in listOfBoom){
            if(i != -1){
                GameObject.Find(""+i).GetComponent<SpriteRenderer>().sprite = info.ball_tort;
                if(info.AudioOn) GameObject.Find("Audio_Turtle_2").GetComponent<AudioSource>().Play();
                yield return new WaitForSeconds(0.2f);
                GameObject.Find(""+i).GetComponent<SpriteRenderer>().sprite = colorSprite;
                info.ballColors[spawn.ArrColor[i]]--;
                spawn.ArrColor[i] = color;
                info.ballColors[color]++;
            }
        }
        for (int i = 0; i < quantityAll; i++){
            GameObject.Find(""+balls[i]).GetComponent<ball>().busy = false;
        }

        timersecond = 1;
        quantityAll = 0;
        balls = new List<int>();
        ballsColor = new List<int>();
        active = false;
        info.activeTouch = true;
    }

    IEnumerator DestroyAppearance(int nameInt){
        yield return new WaitForSeconds(1.1f);
        Destroy(GameObject.Find(nameInt+"A"));
    }
}