using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class tortoiseBall : MonoBehaviour
{
    static public int timeForExplosion = 0;
    static public int quantity = 0;
    private float secondgametime = 0f;
    private int timersecond = 1;
    private bool active = false;
    private int[] balls;
    private int[] ballsColor;
    private int[] listOfBoom;
    private string objectTouch = "";

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
                        for (int i = 0; i < quantity; i++)
                        {
                            if(""+balls[i]==objectTouch){
                                StartCoroutine(BoomIE(balls[i], ballsColor[i]));
                                break;
                            }
                        }
                    }catch{

                    }
                }
            }    
        }      
        secondgametime += Time.deltaTime;
        if (secondgametime >= 1)
        {
            secondgametime = 0;
            timersecond++;
        }
        if(timersecond%timeForExplosion==0 && !active){
            listOfBoom = new int[9];
            Boom();
        }
    }
    void Boom(){
        balls = new int[quantity];
        ballsColor = new int[quantity];
        for (int i = 0; i < quantity; i++){
            repeat: int ball = Random.Range(0, spawn.field_size*spawn.field_size);
            if(GameObject.Find(""+ball).GetComponent<ball>().busy) goto repeat;
            balls[i] = ball;
            ballsColor[i] = spawn.ArrColor[ball];
            GameObject.Find(""+ball).GetComponent<ball>().busy = true;
            //Debug.Log(""+ball);
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
        for (int i = 0; i < quantity; i++){
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
                yield return new WaitForSeconds(0.2f);
                GameObject.Find(""+i).GetComponent<SpriteRenderer>().sprite = colorSprite;
                info.ballColors[spawn.ArrColor[i]]--;
                spawn.ArrColor[i] = color;
                info.ballColors[color]++;
            }
        }
        for (int i = 0; i < quantity; i++){
            GameObject.Find(""+balls[i]).GetComponent<ball>().busy = false;
        }

        timersecond = 1;
        active = false;
        info.activeTouch = true;
    }
}