using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BugsOnLvls : MonoBehaviour
{
    public GameObject Bug1_1, Bug2_1, Bug1_2, Bug2_2;
    static public bool AchivePerformed;
    private List<GameObject> objects;
    private int timer0, timer1, timer2;
    private int count = 1;
    private int num = 0;
    private int collected = 0;
    private int timersecond;
    private bool end = false;
    // Start is called before the first frame update
    void Start()
    {
        if(info.isCoop || info.isEndless){
            //Debug.Log("if(info.isCoop || info.isEndless)");
            End();
        }

        end = false;
        AchivePerformed = false;
        collected = 0;

        /*DELETE THIS!*/
        /*AchivementMap.achive_time = 10;
        AchivementMap.achive_step = 10;
        AchivementMap.achive_bugs = 0;*/
        /*/DELETE*/


        objects = new List<GameObject>(){Bug1_1, Bug2_1, Bug1_2, Bug2_2};
        if(AchivementMap.achive_time < 10) {
            Debug.Log("ERROR: AchivementMap.achive_time < 10");
            End();
        }
        else if(AchivementMap.achive_time < 15) count = 1;
        else if(AchivementMap.achive_time < 20) count = 2;
        else count = 3;

        AchivementMap.achive_bugs = count;

        num = 0;

        if(count == 1){
            timer0 = Random.Range(0,AchivementMap.achive_time-10);
        }else if(count == 2){
            int zapas = AchivementMap.achive_time - 14;
            int zzz0 = Random.Range(0, zapas);
            int zzz1 = zzz0 + Random.Range(0, zapas-zzz0);
            timer0 = 0+zzz0;
            timer1 = 5+zzz1;
        }else{
            int zapas = AchivementMap.achive_time - 19;
            int zzz0 = Random.Range(0, zapas/2);
            int zzz1 = zzz0 + Random.Range(0, (zapas-zzz0)/2);
            int zzz2 = zzz1 + Random.Range(0, zapas-zzz1);
            timer0 = 0+zzz0;
            timer1 = 5+zzz1;
            timer2 = 10+zzz2;
            Debug.Log("AT: "+AchivementMap.achive_time+"; z0: "+ zzz0 + "; t0: "+timer0+"; z1: "+ zzz1 + "; t1: "+timer1+"; z2: "+ zzz2 + "; t2: "+timer2);
        }
    }

    void Update()
    {
        if(!end){
            if(info.timerGo){
                timersecond = info.configTime - info.timersecond;
            }else{
                timersecond = info.timersecond;
            }
            if(num==0 && timersecond>timer0){
                //Debug.Log(1);
                GameObject rand = objects[Random.Range(0,objects.Count)];
                rand.SetActive(true);
                objects.Remove(rand);
                if(count>1) num=1;
                else {
                    //Debug.Log(2);
                    //Debug.Log(rand.name);
                    end = true;
                    rand.GetComponent<Image>().color = Color.yellow;
                    rand.GetComponent<Animation>().Play();
                }
            }else if(num==1 && timersecond>timer1){
                GameObject rand = objects[Random.Range(0,objects.Count)];
                rand.SetActive(true);
                objects.Remove(rand);
                if(count>2) num=2;
                else {
                    end = true;
                    rand.GetComponent<Image>().color = Color.yellow;
                    rand.GetComponent<Animation>().Play();
                }
            }else if(num==2 && timersecond>timer2){
                GameObject rand = objects[Random.Range(0,objects.Count)];
                rand.SetActive(true);
                end = true;
                rand.GetComponent<Image>().color = Color.yellow;
                rand.GetComponent<Animation>().Play();
            }
        }
    }

    public void Click(){
        collected++;
        Debug.Log("Собрано жуков: "+collected);
        if(collected >= count){
            AchivePerformed = true;
            Debug.Log("Собраны все жуки на уровне");
            End();
        }
    }

    void End(){
        Destroy(this);
    }
}
