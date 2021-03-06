﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class FindMaxWay : MonoBehaviour {

    public GameObject Target;
    static public bool targetActive = false;
    private int[] ArrColor; //массив цветов
    private int[] Lengths; //длины цепочек
    private int[] ArrWay; //массив направлений
    private int currentBall = 0;
    private GameObject TargenInst;

    void Start()
    {

    }

    public void MainFunc(){
        ArrColor = new int[spawn.field_size * spawn.field_size];
        ArrWay = new int[spawn.field_size * spawn.field_size];
        Array.Copy(spawn.ArrColor,spawn.ArrColor.GetLowerBound(0),ArrColor,ArrColor.GetLowerBound(0),spawn.field_size*spawn.field_size);
        Array.Copy(spawn.ArrWay,spawn.ArrWay.GetLowerBound(0),ArrWay,ArrWay.GetLowerBound(0),spawn.field_size*spawn.field_size);
        Lengths = new int[spawn.field_size * spawn.field_size];
        if(!info.isCoop){
            if(ArrColor.Contains(info.winBall)){
                for (int i = ArrColor.GetLowerBound(0); i <= ArrColor.GetUpperBound(0); i++){
                    if (ArrColor[i] == info.winBall && !GameObject.Find(""+i).GetComponent<ball>().busy){
                        Array.Copy(spawn.ArrColor,spawn.ArrColor.GetLowerBound(0),ArrColor,ArrColor.GetLowerBound(0),spawn.field_size*spawn.field_size);
                        Array.Copy(spawn.ArrWay,spawn.ArrWay.GetLowerBound(0),ArrWay,ArrWay.GetLowerBound(0),spawn.field_size*spawn.field_size);
                        currentBall = i;
                        LengthCheck(currentBall);
                    }
                }
            }else{
                Rotate();
                return;
            }
            try{Destroy(TargenInst);}catch{}
            int maxValue = Lengths.Max();
            if(maxValue > 0){
                int maxIndex = Lengths.ToList().IndexOf(maxValue);
                TargenInst = Instantiate(Target, new Vector2(spawn.Balls[maxIndex].transform.position.x,spawn.Balls[maxIndex].transform.position.y), Quaternion.Euler(0, 0, 0));
                targetActive = true;
            }else{
                Rotate();
            }
        }else{
            if(ArrColor.Contains(coopMenu.player1Color) && CanvasBot.turn_bt || ArrColor.Contains(coopMenu.player2Color) && !CanvasBot.turn_bt){
                for (int i = ArrColor.GetLowerBound(0); i <= ArrColor.GetUpperBound(0); i++){
                    if (((ArrColor[i] == coopMenu.player1Color && CanvasBot.turn_bt) || (ArrColor[i] == coopMenu.player2Color && !CanvasBot.turn_bt) ) && !GameObject.Find(""+i).GetComponent<ball>().busy){
                        Array.Copy(spawn.ArrColor,spawn.ArrColor.GetLowerBound(0),ArrColor,ArrColor.GetLowerBound(0),spawn.field_size*spawn.field_size);
                        Array.Copy(spawn.ArrWay,spawn.ArrWay.GetLowerBound(0),ArrWay,ArrWay.GetLowerBound(0),spawn.field_size*spawn.field_size);
                        currentBall = i;
                        LengthCheck(currentBall);
                    }
                }
            }else{
                Rotate();
                return;
            }
            try{Destroy(TargenInst);}catch{}
            int maxValue = Lengths.Max();
            if(maxValue > 0){
                int maxIndex = Lengths.ToList().IndexOf(maxValue);
                TargenInst = Instantiate(Target, new Vector2(spawn.Balls[maxIndex].transform.position.x,spawn.Balls[maxIndex].transform.position.y), Quaternion.Euler(0, 0, 0));
                targetActive = true;
            }else{
                Rotate();
            }
        }
    }

    void Rotate()
    {
        for (int i = 0; i < spawn.field_size * spawn.field_size; i++)
        {
            if ((spawn.ArrColor[i] != info.winBall)&& !GameObject.Find(""+i).GetComponent<ball>().busy)
            {
                short randomRot = (short)UnityEngine.Random.Range(1, 4);
                GameObject.Find(i.ToString()).GetComponent<ball>().RotateBall(randomRot);
            }
        }
    }

    public void DestroyTarget(){
        try{Destroy(TargenInst);}catch{}
    }

    void LengthCheck(int current){
        if(ArrColor[current] != info.winBall)
            Lengths[currentBall]++;
        if (ArrWay[current] < 3)
            ArrWay[current]++;
        else ArrWay[current] = 0;
        switch (ArrWay[current]){
            case 0:
                if ((current + info.field_size < info.field_size * info.field_size)
                    &&(ArrWay[current + info.field_size] == 1 || ArrWay[current + info.field_size] == 2)){
                    LengthCheck(current + info.field_size);
                }
                if ((current + 1 < info.field_size * info.field_size) && ((current + 1)%info.field_size != 0)
                    &&(ArrWay[current + 1] == 2 || ArrWay[current + 1] == 3)){                  
                    LengthCheck(current + 1);
                }
                break;
            case 1:
                if ((current + 1 < info.field_size * info.field_size) && ((current + 1)%info.field_size != 0)
                    &&(ArrWay[current + 1] == 2 || ArrWay[current + 1] == 3)){               
                    LengthCheck(current + 1);
                }
                if ((current - info.field_size >= 0)
                    &&(ArrWay[current - info.field_size] == 3 || ArrWay[current - info.field_size] == 0)){             
                    LengthCheck(current - info.field_size);
                }
                break;
            case 2:
                if ((current - info.field_size >= 0)
                    &&(ArrWay[current - info.field_size] == 3 || ArrWay[current - info.field_size] == 0)){
                    LengthCheck(current - info.field_size);
                }
                if ((current - 1 >= 0) && ((current - 1)%info.field_size != info.field_size - 1)
                    &&(ArrWay[current - 1] == 0 || ArrWay[current - 1] == 1)){
                    LengthCheck(current - 1);
                }
                break;
            case 3:
                if ((current - 1 >= 0) && ((current - 1)%info.field_size != info.field_size - 1)
                    &&(ArrWay[current - 1] == 0 || ArrWay[current - 1] == 1)){
                    LengthCheck(current - 1);
                }
                if ((current + info.field_size < info.field_size * info.field_size)
                    &&(ArrWay[current + info.field_size] == 1 || ArrWay[current + info.field_size] == 2)){
                    LengthCheck(current + info.field_size);
                }
                break;
            default:
                Debug.Log("Errr");
                break;
        }
    }
}