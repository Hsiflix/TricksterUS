using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BugLvl2 : MonoBehaviour
{
    public GameObject me;
    private int speed = 2;
    private int part = 0;
    private float x = 0, y = 0;
    private List<Color> Colors = new List<Color>(){Color.blue, Color.cyan, Color.gray, Color.green, Color.grey, Color.magenta, Color.red, Color.yellow};
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(1320f, -230f, 0);
        int randCol = UnityEngine.Random.Range(0, Colors.Count);
        GetComponent<Image>().color = Colors[randCol];
        part = UnityEngine.Random.Range(0,2);
    }

    // Update is called once per frame
    void Update()
    {
        //local: x > 720;  y < -170, y>-310
        if(transform.localPosition.y<-360 && part == 1){
            part = 0;
        }
        if(transform.localPosition.y>-120 && part == 0){
            part = 1;
        }
        if(transform.localPosition.x<720 && part == 1){
            part = 2;
        }
        if(transform.localPosition.x<720 && part == 0){
            part = 3;
        }
        if(transform.localPosition.y<-360 && part == 2){
            part = 3;
        }
        if(transform.localPosition.y>-120 && part == 3){
            part = 2;
        }
        if(transform.localPosition.x>1350f){
            Destroy(this);
        }
        if(part == 0){
            x = UnityEngine.Random.Range(-0.9f,0f);
            y = UnityEngine.Random.Range(0f,0.99f);
        }else if(part == 1){
            x = UnityEngine.Random.Range(-0.9f,0f);
            y = UnityEngine.Random.Range(-0.99f,0f);
        }else if(part == 2){
            x = UnityEngine.Random.Range(0f,0.9f);
            y = UnityEngine.Random.Range(-0.99f,0f);
        }else if(part == 3){
            x = UnityEngine.Random.Range(0f,0.9f);
            y = UnityEngine.Random.Range(0f,0.99f);
        }
        float y1=y/Math.Abs(y);
        float x1=x/y1;
        float alpha = (float)(Math.Asin(x1)/Math.PI)*180;
        if(y1<0) alpha = alpha - 180;
        transform.rotation = Quaternion.Euler(0f,0f,-alpha);
        transform.localPosition = new Vector3(transform.localPosition.x+x*speed, transform.localPosition.y+y*speed,transform.localPosition.z);
    }

    public void Click(){
        info.bugsCount++;
        Destroy(this);
        me.SetActive(false);
    }
}
