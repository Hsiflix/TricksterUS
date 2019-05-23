using System.Collections;
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
        if(ArrColor.Contains(info.winBall)){
            for (int i = ArrColor.GetLowerBound(0); i <= ArrColor.GetUpperBound(0); i++){
                if (ArrColor[i] == info.winBall){
                    Array.Copy(spawn.ArrColor,spawn.ArrColor.GetLowerBound(0),ArrColor,ArrColor.GetLowerBound(0),spawn.field_size*spawn.field_size);
                    Array.Copy(spawn.ArrWay,spawn.ArrWay.GetLowerBound(0),ArrWay,ArrWay.GetLowerBound(0),spawn.field_size*spawn.field_size);
                    currentBall = i;
                    LengthCheck(currentBall);
                }
            }
        }else{
            return;
        }
        try{Destroy(TargenInst);}catch{}
        int maxValue = Lengths.Max();
        int maxIndex = Lengths.ToList().IndexOf(maxValue);
        TargenInst = Instantiate(Target, new Vector2(spawn.Balls[maxIndex].transform.position.x,spawn.Balls[maxIndex].transform.position.y), Quaternion.Euler(0, 0, 0));
        targetActive = true;
    }

    public void DestroyTarget(){
        Destroy(TargenInst);
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