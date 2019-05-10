﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

public class touch : MonoBehaviour
{
    private string objectTouch = "";
    public GameObject PauseMenu;

    void Start()
    {
        
    }

    void Update()
    {
        if (!info.activeRot && info.activeTouch) // Возможность касания
        {
            if (Input.GetMouseButtonDown(0)) // Если кнопку нажали
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    objectTouch = hit.collider.name; // Записывает имя объекта по которому каснулись
                    try{
                        int objectTouchInt = Int32.Parse(objectTouch);
                        if(objectTouchInt>=0){
                            if(!info.stat_balls.Contains(objectTouchInt)){
                                if(!spawn.Balls[objectTouchInt].GetComponent<ball>().busy){
                                    info.setNextColor(spawn.ArrColor[objectTouchInt]);
                                    GetComponent<info>().Step();
                                    spawn.Balls[objectTouchInt].GetComponent<ball>().touchThis = true; // Начинаем крутить шар, до которого каснулись
                                    info.activeRot = true;
                                }
                            }
                        }
                    }catch{

                    }
                }
            }    
        }         
    }

    public void PauseButton(){
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
        GameObject.Find("Game").SetActive(false);
    }

    public void RebootButton(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
