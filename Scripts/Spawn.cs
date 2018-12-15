using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Spawn : MonoBehaviour {

    public GameObject ball1; //blue 1
    public GameObject ball2; //yellow 2
    public GameObject ball3; //red 3
    public GameObject ball4; //green 4

    static public int MySize; //размер поля

    public int RandomColor; //рандомный цвет
    public int RandomWay; //рандомное направление

    public float SpawnSize = 0.9f; //размер шара
    public int SpawnNumberX; //начало спавна по Х
    public int SpawnNumberY; //начало спавна по Y
    static public GameObject[] clone; //массив шаров
    static public int[] ArrColor; //массив цветов
    static public int[] ArrWay; //массив направлений
    static public int WinBall; // Номер победного шара, подробнее далее

    static public int tmp; //Номер шара для IE_Spawn()
    static public int steps; //кол-во шагов (менять в lvl*config!!@!!!)
    static public int timerseconds; // Кол-во секунд, 0 - показывает время игры, >0 - убывающий таймер

    static public void RestartLvl() // Установка таймера и ходов на начальные значения
    {
        myGUI.timersecond = timerseconds; // Кол-во секунд, 0 - показывает время игры, >0 - убывающий таймер
        myGUI.step = steps; // Кол-во ходов, 0 - показывает кол-во ходов, >0 - убывающее кол-во ходов
        ColorBall.StockTime = myGUI.timersecond; //Установка начального времени дял ColorBall, что бы при нем не взрывался, не менять!
    }

    public void Restart()//
    {
        Scene actScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(actScene.name);
        //Touchs.StartTouch = false;
        //for(int i = 1; i< MySize*MySize +1; i++)
        //{
        //    Destroy(clone[i]);
        //}
        //RestartLvl();
        //Touchs.LOSE = false;
        //Start();
    }
    void Start () {
        //Правка 10 июня 2018
        Touchs.LOSE = false;
        //Конец правки 10 июня 2018
        //Правка 7 ноября 2018
        //AudioSource audio = GetComponent<AudioSource>();
        //if(Infos.AudioOn) audio.Pause();
        //Конец правки 7 ноября 2018
        FindMaxWay.Inicializate = true;
        SpawnNumberX = 1; //начало спавна по Х
        SpawnNumberY = 5; //начало спавна по Y
        ArrColor = new int[MySize * MySize + 1];
        ArrWay = new int[MySize * MySize + 1];
        clone = new GameObject[MySize * MySize + 1];
        tmp = 1;
        transform.position = new Vector3(0.45f + MySize * 0.45f, 4.05f + MySize * 0.45f, -10);
        StartCoroutine(Spawn1());
    }
    IEnumerator Spawn1()
    {
        while (true)
        {
            RandomColor = UnityEngine.Random.Range(-10, 6);
            RandomWay = UnityEngine.Random.Range(0, 4);

            if (RandomColor < -6)
            {
                clone[tmp] = Instantiate(ball1, new Vector2(SpawnNumberX * SpawnSize, SpawnNumberY * SpawnSize), Quaternion.Euler(0, 0, -90 * RandomWay));
                ArrColor[tmp] = 1;
            }
            else if (RandomColor < -2)
            {
                clone[tmp] = Instantiate(ball2, new Vector2(SpawnNumberX * SpawnSize, SpawnNumberY * SpawnSize), Quaternion.Euler(0, 0, -90 * RandomWay));
                ArrColor[tmp] = 2;
            }
            else if (RandomColor < 2)
            {
                clone[tmp] = Instantiate(ball3, new Vector2(SpawnNumberX * SpawnSize, SpawnNumberY * SpawnSize), Quaternion.Euler(0, 0, -90 * RandomWay));
                ArrColor[tmp] = 3;
            }
            else if (RandomColor < 6)
            {
                clone[tmp] = Instantiate(ball4, new Vector2(SpawnNumberX * SpawnSize, SpawnNumberY * SpawnSize), Quaternion.Euler(0, 0, -90 * RandomWay));
                ArrColor[tmp] = 4;
            }

            clone[tmp].name = ""+tmp;
            ArrWay[tmp] = RandomWay + 1;
            tmp++;

            yield return new WaitForSeconds(0.005f);
            if (SpawnNumberX < MySize)
            {
                SpawnNumberX += 1;
            }
            else if (SpawnNumberY < MySize + 4)
            {
                SpawnNumberY += 1;
                SpawnNumberX = 1;
            }
            else
            {
                if (StatBall.StatBallOn == true)
                {
                    Touchs.StartTouch = true;
                    StatBall.testKey = true;
                }
                break;
            }
        }
    }
}
