using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ball : MonoBehaviour
{
    public bool touchThis = false;
    private int myNameInt;
    private int stepRot = 0;
    private int speed = 16;
    private bool rotNext = true;
    public bool busy = false;
    
    void Start()
    {
        try{
            myNameInt = Int32.Parse(transform.name);
        }catch{
            myNameInt = -1;
        }
    }

    public void RotateBall(int count){
        rotNext = false;
        stepRot += speed * count;
        spawn.ArrWay[myNameInt] += count;
        if (spawn.ArrWay[myNameInt] > 3)
            spawn.ArrWay[myNameInt] -= 4;
    }
    
    void Update()
    {
        if(touchThis){
            touchThis = false;
            if(!busy){
                info.queue++;
                wayUp();
                setColor();
                stepRot += speed;
                GetComponent<SpriteRenderer>().sprite = info.colorNext;
            }
        }
        if (stepRot > 0)
        {
            stepRot--;
            transform.Rotate(Vector3.Lerp(new Vector3(+0f, +0f, +0f), new Vector3(+0f, +0f, -90f), 0.0625f));
            if (stepRot == 0){
                if(rotNext) StartCoroutine(queue());
                else rotNext = true;
            }
        }
    }

    void wayUp(){
        if (spawn.ArrWay[myNameInt] < 3)
            spawn.ArrWay[myNameInt]++;
        else spawn.ArrWay[myNameInt] = 0;
    }

    void setColor(){
        GetComponent<SpriteRenderer>().sprite = info.colorNext;
        info.ballColors[spawn.ArrColor[myNameInt]]--;
        spawn.ArrColor[myNameInt] = info.colorNextInt;
        info.ballColors[info.colorNextInt]++;
    }

    IEnumerator queue(){
        yield return new WaitForSeconds(0.001f);
        switch (spawn.ArrWay[myNameInt]){
            case 0:
                if ((myNameInt + info.field_size < info.field_size * info.field_size)
                    &&(spawn.ArrWay[myNameInt + info.field_size] == 1 || spawn.ArrWay[myNameInt + info.field_size] == 2)){
                    GameObject.Find((myNameInt + info.field_size).ToString()).GetComponent<ball>().touchThis = true;
                }
                if ((myNameInt + 1 < info.field_size * info.field_size) && ((myNameInt + 1)%info.field_size != 0)
                    &&(spawn.ArrWay[myNameInt + 1] == 2 || spawn.ArrWay[myNameInt + 1] == 3)){
                    GameObject.Find((myNameInt + 1).ToString()).GetComponent<ball>().touchThis = true;
                }
                break;
            case 1:
                if ((myNameInt + 1 < info.field_size * info.field_size) && ((myNameInt + 1)%info.field_size != 0)
                    &&(spawn.ArrWay[myNameInt + 1] == 2 || spawn.ArrWay[myNameInt + 1] == 3)){
                    GameObject.Find((myNameInt + 1).ToString()).GetComponent<ball>().touchThis = true;
                }
                if ((myNameInt - info.field_size >= 0)
                    &&(spawn.ArrWay[myNameInt - info.field_size] == 3 || spawn.ArrWay[myNameInt - info.field_size] == 0)){
                    GameObject.Find((myNameInt - info.field_size).ToString()).GetComponent<ball>().touchThis = true;
                }
                break;
            case 2:
                if ((myNameInt - info.field_size >= 0)
                    &&(spawn.ArrWay[myNameInt - info.field_size] == 3 || spawn.ArrWay[myNameInt - info.field_size] == 0)){
                    GameObject.Find((myNameInt - info.field_size).ToString()).GetComponent<ball>().touchThis = true;
                }
                if ((myNameInt - 1 >= 0) && ((myNameInt - 1)%info.field_size != info.field_size - 1)
                    &&(spawn.ArrWay[myNameInt - 1] == 0 || spawn.ArrWay[myNameInt - 1] == 1)){
                    GameObject.Find((myNameInt - 1).ToString()).GetComponent<ball>().touchThis = true;
                }
                break;
            case 3:
                if ((myNameInt - 1 >= 0) && ((myNameInt - 1)%info.field_size != info.field_size - 1)
                    &&(spawn.ArrWay[myNameInt - 1] == 0 || spawn.ArrWay[myNameInt - 1] == 1)){
                    GameObject.Find((myNameInt - 1).ToString()).GetComponent<ball>().touchThis = true;
                }
                if ((myNameInt + info.field_size < info.field_size * info.field_size)
                    &&(spawn.ArrWay[myNameInt + info.field_size] == 1 || spawn.ArrWay[myNameInt + info.field_size] == 2)){
                    GameObject.Find((myNameInt + info.field_size).ToString()).GetComponent<ball>().touchThis = true;
                }
                break;
        }
        info.queue--;
    }
}