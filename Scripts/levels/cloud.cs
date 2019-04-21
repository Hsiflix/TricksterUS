﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cloud : MonoBehaviour
{
    private ConstantForce force;
    private float randX = 0f;

    private int type = 1; //1=Flash, 2=Trick, 3=Angel, 4=Us
    private int mode = 1; //1=AddStep, 2=AddTime, 3=Rotation, 4= 
    private int value = 0; //Количество добавляемого (шагов или времени)

    private bool Active = false;
    private bool ActiveFlash = false;
    private double coefficient = 0;
    private float forceX = 0f;
    private float forceY = 0f;

    public Sprite UsCloud;
	public Sprite FlCloud;
	public Sprite TrCloud;
	public Sprite AnCloud;
	public GameObject AnCloudPart2;

    void Start()
    {
        force = GetComponent<ConstantForce>();
    }

    void Update()
    {
        if(Active || ActiveFlash){
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    string Name = hit.collider.name;
                    if(Name == transform.name.ToString()){
                        Touch();
					}
				}
			}
        }
        if(ActiveFlash){
            if((transform.position.y > Camera.main.transform.position.y + 12f && transform.position.y < Camera.main.transform.position.y + 18f) || (transform.position.y < Camera.main.transform.position.y - 12f && transform.position.y > Camera.main.transform.position.y - 18f)) DestroyThis();
        }
        if(Active){
            randX = Random.Range(-0.00000035f,0.0000003501f);
            force.force = new Vector3 (randX, 0.00000005f, 0f);
            if(transform.position.y > Camera.main.transform.position.y + 6f && transform.position.y < Camera.main.transform.position.y + 12f) DestroyThis();
        }
    }

    public void Initialize(int typeS, int modeS, int valueS = 0){
        type = typeS;
        mode = modeS;
        value = valueS;
        switch(type){ //1=Flash, 2=Trick, 3=Angel, 4=Us
            case 1: GetComponent<SpriteRenderer>().sprite = FlCloud;
                    Vector3 p1 = Camera.main.ScreenToWorldPoint(new Vector3 (0f, 0f, 0f)); 
                    Vector3 p3 = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0f));
                    int UD = Random.Range(0,2);
                    switch (UD){
                        case 0: transform.position = new Vector3(Random.Range(p1.x, p3.x), Random.Range(p1.y-3.5f, p1.y-1.5f), -3f);
                            break;
                        case 1: transform.position = new Vector3(Random.Range(p1.x, p3.x), Random.Range(p3.y+1.5f, p3.y+3.5f), -3f);
                            break;
                    }
                    coefficient = (Camera.main.transform.position.y - transform.position.y) / (0.0000007); //Коэффициент умножения
                    if(coefficient<0) coefficient = -coefficient;
                    forceX = (Camera.main.transform.position.x - transform.position.x) / (float)coefficient;
                    forceY = (Camera.main.transform.position.y - transform.position.y) / (float)coefficient;
                    force = GetComponent<ConstantForce>();
                    force.force = new Vector3 (forceX, forceY, 0f);
                    ActiveFlash = true;
                break;
            case 2: GetComponent<SpriteRenderer>().sprite = TrCloud;
                    Active = true;
                break;
            case 3: GetComponent<SpriteRenderer>().sprite = AnCloud;
                    AnCloudPart2.SetActive(true);
                    Active = true;
                break;
            case 4: GetComponent<SpriteRenderer>().sprite = UsCloud;
                    Active = true;
                break;
        }
    }

    void Touch(){
        Active = false;
        info.activeTouch = true;
        switch (mode)
        {
            case 1: AddStep(value);
                break;
            case 2: AddTime(value);
                break;
            case 3: Rotate();
                break;
            case 4: ColorBallBoom();
                break;
            case 5: TortBombBoom();
                break;
            case 6: HalfTime();
                break;
            case 7: FindMaxWay();
                break;
            default: Debug.Log("Error: cloud.Touch()"); DestroyThis();
                break;
        }
    }

    void FindMaxWay(){
        /* Здесь должен быть код */
        DestroyThis();
    }

    void HalfTime(int valueS = 2){
        if (info.timerGo)
        {
            info.timersecond = (int)(info.timersecond/valueS);
        }
        DestroyThis();
    }

    void TortBombBoom(int valueS = 2){
        GameObject.Find("Game").GetComponent<tortoiseBall>().enabled = true;
        GameObject.Find("Game").GetComponent<tortoiseBall>().Boom(valueS);
        DestroyThis();
    }

    void ColorBallBoom(int valueS = 2){
        colorBall.quantity = valueS;
        GameObject.Find("Game").GetComponent<colorBall>().Boom();
        DestroyThis();
    }

    void Rotate()
    {
        for (int i = 0; i < spawn.field_size * spawn.field_size; i++)
        {
            if (spawn.ArrColor[i] != info.winBall)
            {
                short randomRot = (short)Random.Range(1, 4);
                GameObject.Find(i.ToString()).GetComponent<ball>().RotateBall(randomRot);
            }
        }
        DestroyThis();
    }

    void AddTime(int valueS)
    {
        if (info.timerGo)
        {
            info.timersecond += valueS;
        }
        DestroyThis();
    }

    void AddStep(int valueS)
    {
        if (info.stepGo)
        {
            info.steps += valueS;
        }
        GameObject.Find("Game").GetComponent<info>().Step();
        DestroyThis();
    }

    void DestroyThis(){
        Destroy(GameObject.Find(transform.name.ToString()));
    }
}