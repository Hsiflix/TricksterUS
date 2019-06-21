using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.UI;

public class spawn : MonoBehaviour
{
    public GameObject ballPrefab; //Префаб шара
    public GameObject appearancePrefab;
    public Sprite ball_blue, ball_yellow, ball_green, ball_red, ball_static, ball_tort; //Спрайты шаров

    static public int field_size; //Размер поля
    private float SpawnSize = 0.9f; //размер шара
    private int SpawnNumberX; //начало спавна по Х
    private int SpawnNumberY; //начало спавна по Y

    static public int[] ArrColor; //массив цветов
    static public int[] ArrWay; //массив направлений
    static public GameObject[] Balls; //масив шаров
    static public bool endSpawn = false;
    private int RandomColor; //рандомный цвет
    private int RandomWay; //рандомное направление

    void Start()
    {
        endSpawn = false;
        if(info.steps < 1000) info.stepsText.text = ""+info.steps;
            else info.stepsText.text = "999+";
        if(info.timersecond < 1000) info.timerText.text = ""+info.timersecond;
            else info.timerText.text = "999+";

        SpawnNumberX = 1; //начало спавна по Х
        SpawnNumberY = 5; //начало спавна по Y
        ArrColor = new int[field_size * field_size];
        ArrWay = new int[field_size * field_size];
        Balls = new GameObject[field_size * field_size];
        Camera.main.transform.position = new Vector3(0.45f + field_size * 0.45f, 4.05f + field_size * 0.45f, -10);
        switch(info.winBall){
            case 0:   GameObject.Find("WinBall").GetComponent<Image>().sprite = ball_blue; 
                      GameObject.Find("Outline").GetComponent<Image>().color = Color.blue; 
            break;
            case 1:   GameObject.Find("WinBall").GetComponent<Image>().sprite = ball_yellow; 
                      GameObject.Find("Outline").GetComponent<Image>().color = Color.yellow;
            break;
            case 2:   GameObject.Find("WinBall").GetComponent<Image>().sprite = ball_green; 
                      GameObject.Find("Outline").GetComponent<Image>().color = Color.green; 
            break;
            case 3:   GameObject.Find("WinBall").GetComponent<Image>().sprite = ball_red; 
                      GameObject.Find("Outline").GetComponent<Image>().color = Color.red; 
            break;
        }
        info.ball_blue = this.ball_blue;
        info.ball_green = this.ball_green;
        info.ball_red = this.ball_red;
        info.ball_yellow = this.ball_yellow;
        info.ball_tort = this.ball_tort;
        info.ballPrefab = this.ballPrefab;
        info.appearancePrefab = this.appearancePrefab;
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn(){
        for (int i = 0; i < field_size * field_size; i++){
            RandomColor = UnityEngine.Random.Range(0, 4);
            RandomWay = UnityEngine.Random.Range(0, 4);

            Balls[i] = Instantiate(ballPrefab, new Vector2(SpawnNumberX * SpawnSize, SpawnNumberY * SpawnSize), Quaternion.Euler(0, 0, -90 * RandomWay));
            ArrColor[i] = RandomColor;
            ArrWay[i] = RandomWay;
            Balls[i].name = ""+i;

            if(info.stat_balls.Contains(i)){
                GameObject tmpAppear = Instantiate(appearancePrefab, GameObject.Find(""+Balls[i].name).transform.position + new Vector3(0f, 0f, -5.1f), Quaternion.Euler(0, 0, 0));
                tmpAppear.name = i+"A";
                StartCoroutine(DestroyAppearance(i));
                RandomColor = 4;
                ArrColor[i] = info.winBall;
                Balls[i].transform.rotation = Quaternion.Euler(0, 0, 0);;
                ArrWay[i] = -1;
            }

            switch (RandomColor){
                case 0: Balls[i].GetComponent<SpriteRenderer>().sprite = ball_blue; info.ballColors[0]++; break;
                case 1: Balls[i].GetComponent<SpriteRenderer>().sprite = ball_yellow; info.ballColors[1]++; break;
                case 2: Balls[i].GetComponent<SpriteRenderer>().sprite = ball_green; info.ballColors[2]++; break;
                case 3: Balls[i].GetComponent<SpriteRenderer>().sprite = ball_red; info.ballColors[3]++; break;
                case 4: Balls[i].GetComponent<SpriteRenderer>().sprite = ball_static; info.ballColors[info.winBall]++; Balls[i].GetComponent<ball>().busy = true; break;
            }

            yield return new WaitForSeconds(0.001f);

            if (SpawnNumberX < field_size) SpawnNumberX += 1;
            else if (SpawnNumberY < field_size + 4)
            {
                SpawnNumberY += 1;
                SpawnNumberX = 1;
            }

        }
        endSpawn = true;
    }

    IEnumerator DestroyAppearance(int nameInt){
        yield return new WaitForSeconds(1.1f);
        Destroy(GameObject.Find(nameInt+"A"));
    }
}
