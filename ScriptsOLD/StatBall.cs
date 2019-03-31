using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatBall : MonoBehaviour {

    static public bool StatBallOn = false;
    static public bool testKey = false;
    static public int[] StatArr;
    static private GameObject StatBallObject;
    public Sprite StatBallSprite;

    private void Start()
    {
        //Правка 10 июня 2018

        //Конец правки 10 июня 2018
    }

    private void Update()
    {
        if (testKey)
        {
            testKey = false;
            StaticBall();
        }
    }

    void StaticBall()
    {
        for (int i = 0; i < StatArr.Length; i++)
        {
            StatBallObject = GameObject.Find(StatArr[i].ToString());
            StatBallObject.GetComponent<SpriteRenderer>().sprite = StatBallSprite;
            StatBallObject.GetComponent<Ball>().Active = false;
            //StatBallObject.GetComponent<Ball>().enabled = false;
            Spawn.ArrColor[StatArr[i]] = Spawn.WinBall;
            Spawn.clone[StatArr[i]].transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}