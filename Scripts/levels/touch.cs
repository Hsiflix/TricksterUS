using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class touch : MonoBehaviour
{
    private string objectTouch = "";

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
                        if(Int32.Parse(objectTouch)>=0){
                            if(!info.stat_balls.Contains(Int32.Parse(objectTouch))){
                                if(!GameObject.Find(objectTouch).GetComponent<ball>().busy){
                                    info.setNextColor(spawn.ArrColor[Int32.Parse(objectTouch)]);
                                    GetComponent<info>().Step();
                                    GameObject.Find(objectTouch).GetComponent<ball>().touchThis = true; // Начинаем крутить шар, до которого каснулись
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
}
