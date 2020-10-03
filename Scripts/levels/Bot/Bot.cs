/* Super EVA */
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Bot : MonoBehaviour
{
    public GameObject DialogGO; 
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

    public void MainFunc(){
        if(!tortoiseBall.active){

            //Фраза, если info.firstMeet[3] = false;
            if(!info.firstMeet[3]){
                info.firstMeet[3] = true;
                string dialogName = "lvl_004";
                DialogGO.GetComponent<DialogView>().isRandom = false;
                DialogGO.GetComponent<DialogView>().DialogName = dialogName;
                DialogGO.GetComponent<DialogView>().StartDialogView();
            }

            List<int> myBalls = new List<int>();
            List<int> otBalls = new List<int>();
            Array.Copy(spawn.ArrColor,spawn.ArrColor.GetLowerBound(0),ArrColor,ArrColor.GetLowerBound(0),spawn.field_size*spawn.field_size);
            Array.Copy(spawn.ArrWay,spawn.ArrWay.GetLowerBound(0),ArrWay,ArrWay.GetLowerBound(0),spawn.field_size*spawn.field_size);
            Lengths = new int[spawn.field_size * spawn.field_size];
            if(ArrColor.Contains(info.botColor)){
                for (int i = ArrColor.GetLowerBound(0); i <= ArrColor.GetUpperBound(0); i++){
                    if (ArrColor[i] == info.botColor){
                        myBalls.Add(i);
                        Array.Copy(spawn.ArrColor,spawn.ArrColor.GetLowerBound(0),ArrColor,ArrColor.GetLowerBound(0),spawn.field_size*spawn.field_size);
                        Array.Copy(spawn.ArrWay,spawn.ArrWay.GetLowerBound(0),ArrWay,ArrWay.GetLowerBound(0),spawn.field_size*spawn.field_size);
                        currentBall = i;
                        LengthCheck(currentBall);
                    }
                }
            }else{ //Если нет нужного цвета, то берем цвет НЕ игрока
                for (int i = ArrColor.GetLowerBound(0); i <= ArrColor.GetUpperBound(0); i++){
                    if (ArrColor[i] != info.winBall){
                        otBalls.Add(i);
                        Array.Copy(spawn.ArrColor,spawn.ArrColor.GetLowerBound(0),ArrColor,ArrColor.GetLowerBound(0),spawn.field_size*spawn.field_size);
                        Array.Copy(spawn.ArrWay,spawn.ArrWay.GetLowerBound(0),ArrWay,ArrWay.GetLowerBound(0),spawn.field_size*spawn.field_size);
                        currentBall = i;
                        LengthCheck(currentBall);
                    }
                }
            }
            int maxValue = Lengths.Max();
            int maxIndex = 0;

            if(maxValue == 0){ //Бот в любом случае сходит или своими, или не игрока
                if(ArrColor.Contains(info.botColor)){
                    int temp = UnityEngine.Random.Range(0, myBalls.Count);
                    maxIndex = myBalls[temp];
                }else{
                    int temp = UnityEngine.Random.Range(0, otBalls.Count);
                    maxIndex = otBalls[temp];
                }
            }else{
                maxIndex = Lengths.ToList().IndexOf(maxValue);
            }
            /*info.*/setNextColor(spawn.ArrColor[maxIndex]);
            GetComponent<info>().Step();
            Debug.Log("Bot: maxIndex = " + maxIndex + ", maxValue = " + maxValue + ";");
            spawn.Balls[maxIndex].GetComponent<ball>().TouchThisF(); // Начинаем крутить шар, до которого каснулись
            info.activeRot = true;
        }else{
            tortoiseBall.botActive = true;
        }
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

    private void setNextColor(int color){
        info.colorNextInt = color;
        switch(color){
            case 0: info.colorNext = info.ball_blue; break;
            case 1: info.colorNext = info.ball_yellow; break;
            case 2: info.colorNext = info.ball_green; break;
            case 3: info.colorNext = info.ball_red; break;
        }
    }
}