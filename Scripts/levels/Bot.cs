/* EVA */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Bot : MonoBehaviour
{
    public GameObject CanvasBot;
    private int[] ArrColor; //массив цветов
    private int[] Lengths; //длины цепочек
    private int[] ArrWay; //массив направлений
    //private int bestColor = 0; //бот будет искать макс. в 1:его цвете, 0:любом цвете НЕ игрока
    private int currentBall = 0;

    // Start is called before the first frame update
    void Start()
    {
        CanvasBot.SetActive(true);
        info.botActive = true;
        ArrColor = new int[spawn.field_size * spawn.field_size];
        ArrWay = new int[spawn.field_size * spawn.field_size];
        Lengths = new int[spawn.field_size * spawn.field_size];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainFunc(){
        Array.Copy(spawn.ArrColor,spawn.ArrColor.GetLowerBound(0),ArrColor,ArrColor.GetLowerBound(0),spawn.field_size*spawn.field_size);
        Array.Copy(spawn.ArrWay,spawn.ArrWay.GetLowerBound(0),ArrWay,ArrWay.GetLowerBound(0),spawn.field_size*spawn.field_size);
        Lengths = new int[spawn.field_size * spawn.field_size];
        if(ArrColor.Contains(info.botColor)){
            for (int i = ArrColor.GetLowerBound(0); i <= ArrColor.GetUpperBound(0); i++){
                if (ArrColor[i] == info.botColor){
                    Array.Copy(spawn.ArrColor,spawn.ArrColor.GetLowerBound(0),ArrColor,ArrColor.GetLowerBound(0),spawn.field_size*spawn.field_size);
                    Array.Copy(spawn.ArrWay,spawn.ArrWay.GetLowerBound(0),ArrWay,ArrWay.GetLowerBound(0),spawn.field_size*spawn.field_size);
                    currentBall = i;
                    LengthCheck(currentBall);
                }
            }
        }else{ //Если нет нужного цвета, то берем цвет НЕ игрока
            for (int i = ArrColor.GetLowerBound(0); i <= ArrColor.GetUpperBound(0); i++){
                if (ArrColor[i] != info.winBall){
                    Array.Copy(spawn.ArrColor,spawn.ArrColor.GetLowerBound(0),ArrColor,ArrColor.GetLowerBound(0),spawn.field_size*spawn.field_size);
                    Array.Copy(spawn.ArrWay,spawn.ArrWay.GetLowerBound(0),ArrWay,ArrWay.GetLowerBound(0),spawn.field_size*spawn.field_size);
                    currentBall = i;
                    LengthCheck(currentBall);
                }
            }
        }
        int maxValue = Lengths.Max();
        int maxIndex = Lengths.ToList().IndexOf(maxValue);
        info.setNextColor(spawn.ArrColor[maxIndex]);
        GetComponent<info>().Step();
        spawn.Balls[maxIndex].GetComponent<ball>().touchThis = true; // Начинаем крутить шар, до которого каснулись
        info.activeRot = true;
    }

    void LengthCheck(int current){
        if(ArrColor[current] != info.botColor)
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