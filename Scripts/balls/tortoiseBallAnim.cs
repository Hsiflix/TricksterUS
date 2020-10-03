using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class tortoiseBallAnim : MonoBehaviour
{
    private int[] listOfBoom;
    private Sprite colorSprite;
    private int color;
    private int num;
    private int i;
    private int nameI;

    public void Part1_tortoise(int nameInt, int Color){
        //Debug.LogWarning("Part1_tortoise: " + nameInt);
        nameI = nameInt;
        color = Color;

        listOfBoom = new int[9];

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

        /*for (int i = 0; i < 9; i++){
            Debug.Log("listOfBoom[" +i+ "]: "+listOfBoom[i]);
        }*/

        colorSprite = null;
        switch(color){
            case 0: colorSprite = info.ball_blue; break;
            case 1: colorSprite = info.ball_yellow; break;
            case 2: colorSprite = info.ball_green; break;
            case 3: colorSprite = info.ball_red; break;
        }
        num = 0;
        Part2_tortoise();
    }

    public void Part2_tortoise(){
        //Debug.LogWarning("Part2_tortoise: " + nameI);
        if(num <= 8){
            //Debug.Log("num: "+num);
            //Debug.Log("listOfBoom[num]: "+listOfBoom[num]);
            i = listOfBoom[num];
            num ++;
            if(i != -1){
                GameObject.Find(""+i).GetComponent<SpriteRenderer>().sprite = info.ball_tort;
                if(info.AudioOn) GameObject.Find("Audio_Turtle_2").GetComponent<AudioSource>().Play();
                GameObject.Find(""+nameI).GetComponent<Animation>().Stop();
                GameObject.Find(""+nameI).GetComponent<Animation>().Play();
            }else{
                Part2_tortoise();
            }
        }else{
            GameObject.Find("Game").GetComponent<tortoiseBall>().EndBoom();
            //GameObject.Find(this.name).GetComponent<tortoiseBallAnim>().enabled = false;
            //tortoiseBall.active = true;
        }
    }

    public void Part3_tortoise(){
        //Debug.LogWarning("Part3_tortoise: " + nameI);
        //Debug.LogWarning("Part3_tortoise = " + this.name);
        GameObject.Find(""+i).GetComponent<SpriteRenderer>().sprite = colorSprite;
        info.ballColors[spawn.ArrColor[i]]--;
        spawn.ArrColor[i] = color;
        info.ballColors[color]++;
        Part2_tortoise();
    }
}