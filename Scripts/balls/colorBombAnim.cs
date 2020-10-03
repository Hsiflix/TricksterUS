using UnityEngine;
using System;
using System.Linq;

public class colorBombAnim : MonoBehaviour
{
    private int[] listOfBoom;
    private int nameInt;

    private int color;

    public void SetColor(int i){
        color = i;
    }

    public void part1_preparation(){
        //Debug.Log("yield return new WaitForSeconds(7.2f);");
        //Debug.Log("part1_preparation");
        string name = transform.name.Substring(0,transform.name.Length-1);
        nameInt = Int32.Parse(name);
        GameObject.Find(nameInt+"C").transform.position = new Vector3 (GameObject.Find(nameInt+"C").transform.position.x,  GameObject.Find(nameInt+"C").transform.position.y,-5.5f);
        listOfBoom = new int[9];
    }

    public void part2_listOfBoom(){
        //Debug.Log("yield return new WaitForSeconds(0.8f);");
        try{
            //Debug.Log("part2_listOfBoom");
            listOfBoom[0] = nameInt-info.field_size-1;
            listOfBoom[1] = nameInt-info.field_size;
            listOfBoom[2] = nameInt-info.field_size+1;
            listOfBoom[3] = nameInt-1;
            listOfBoom[4] = nameInt;
            listOfBoom[5] = nameInt+1;
            listOfBoom[6] = nameInt+info.field_size-1;
            listOfBoom[7] = nameInt+info.field_size;
            listOfBoom[8] = nameInt+info.field_size+1;
        
            for (int i = 0; i < 9; i++){
                if(listOfBoom[i] < 0 || 
                listOfBoom[i] >= info.field_size*info.field_size || 
                info.stat_balls.Contains(listOfBoom[i]) ||
                GameObject.Find(""+listOfBoom[i]).GetComponent<ball>().busy && listOfBoom[i]!=nameInt){
                    listOfBoom[i] = -1;
                }
            }
            if(nameInt%info.field_size==0){
                listOfBoom[0] = -1;
                listOfBoom[3] = -1;
                listOfBoom[6] = -1;
            }
            if(nameInt%info.field_size==info.field_size-1){
                listOfBoom[2] = -1;
                listOfBoom[5] = -1;
                listOfBoom[8] = -1;
            }
            Sprite colorSprite = null;
            switch(color){
                case 0: colorSprite = info.ball_blue; break;
                case 1: colorSprite = info.ball_yellow; break;
                case 2: colorSprite = info.ball_green; break;
                case 3: colorSprite = info.ball_red; break;
            }
            foreach (int i in listOfBoom){
                if(i != -1){
                    GameObject.Find(""+i).GetComponent<SpriteRenderer>().sprite = colorSprite;
                    info.ballColors[spawn.ArrColor[i]]--;
                    spawn.ArrColor[i] = color;
                    info.ballColors[color]++;
                }
            }
            GameObject.Find(""+nameInt).GetComponent<ball>().busy = false;
        }catch (Exception e){
            Debug.Log("ERROR on colorBombAnim_Part2: " + e);
        }
    }

    public void part3_EndColorBomb(){
        //Debug.Log("yield return new WaitForSeconds(1f);");
        //Debug.Log("part3_EndColorBomb");
        colorBall.AudioPlay = false;
        Destroy(GameObject.Find(nameInt+"A"));
        Destroy(GameObject.Find(nameInt+"C"));
    }

    /*IEnumerator BoomIE(int color, int nameInt, int number){
        Debug.Log("Start BoomIE()");
        !!!!!!!!!!yield return new WaitForSeconds(7.2f);
        Debug.Log("WaitForSeconds(7.2f)");
        //Debug.Log(nameInt + " ColorBBBB");
        GameObject.Find(nameInt+"C").transform.position = new Vector3 (GameObject.Find(nameInt+"C").transform.position.x,  GameObject.Find(nameInt+"C").transform.position.y,-5.5f);
        listOfBoom = new int[9];
        !!!!!!!!!!yield return new WaitForSeconds(0.8f);
        Debug.Log("WaitForSeconds(0.8f)");
        listOfBoom[0] = nameInt-info.field_size-1;
        listOfBoom[1] = nameInt-info.field_size;
        listOfBoom[2] = nameInt-info.field_size+1;
        listOfBoom[3] = nameInt-1;
        listOfBoom[4] = nameInt;
        listOfBoom[5] = nameInt+1;
        listOfBoom[6] = nameInt+info.field_size-1;
        listOfBoom[7] = nameInt+info.field_size;
        listOfBoom[8] = nameInt+info.field_size+1;
        Debug.Log("End listOfBoom");
        
        GameObject.Find(""+nameInt).GetComponent<ball>().busy = false;

        for (int i = 0; i < 9; i++){
            if(listOfBoom[i] < 0 || 
            listOfBoom[i] >= info.field_size*info.field_size || 
            info.stat_balls.Contains(listOfBoom[i]) ||
            GameObject.Find(""+listOfBoom[i]).GetComponent<ball>().busy){
                listOfBoom[i] = -1;
            }
        }
        if(nameInt%info.field_size==0){
            listOfBoom[0] = -1;
            listOfBoom[3] = -1;
            listOfBoom[6] = -1;
        }
        if(nameInt%info.field_size==info.field_size-1){
            listOfBoom[2] = -1;
            listOfBoom[5] = -1;
            listOfBoom[8] = -1;
        }
        Debug.Log("End listOfBoom = -1");
        Sprite colorSprite = null;
        switch(color){
            case 0: colorSprite = info.ball_blue; break;
            case 1: colorSprite = info.ball_yellow; break;
            case 2: colorSprite = info.ball_green; break;
            case 3: colorSprite = info.ball_red; break;
        }
        foreach (int i in listOfBoom){
            if(i != -1){
                GameObject.Find(""+i).GetComponent<SpriteRenderer>().sprite = colorSprite;
                info.ballColors[spawn.ArrColor[i]]--;
                spawn.ArrColor[i] = color;
                info.ballColors[color]++;
            }
        }
        GameObject.Find(""+nameInt).GetComponent<ball>().busy = false;
        Debug.Log("End color_main");
        !!!!!!!!!!yield return new WaitForSeconds(1f);
        Destroy(GameObject.Find(nameInt+"A"));
        Destroy(GameObject.Find(nameInt+"C"));
        Debug.Log("End ColorBomb");
    }*/
}
