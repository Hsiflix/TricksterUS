using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinMenuMoney : MonoBehaviour {

    public GameObject leftBottomMenu, rightBottomMenu;
    public GameObject leftShine, rightShine;

    static public int money;//
    private int tmp = 0;
    static public int moneyAdd = 1000;
    private float f = 0.001f; //scale Shine
    static public bool after_infos = false;
    //private bool flag = true;

    private void Update()
    {
        if (after_infos)
        {
            Start_after_infos();
            enabled = false;
        }
    }

    private void Start()
    {
        Time.timeScale = 1;
    }

    void Start_after_infos()
    {
       // Time.timeScale = 1;
       /* string _thislvl = ButLoadLvl._namelvl.Remove(0,3);
        int thislevel = int.Parse(_thislvl);
        Debug.Log("thislevel: " + thislevel + ", Infos.viewLvl():" + Infos.viewLvl());
        Debug.Log("moneyAdd: " + moneyAdd);
        if (thislevel >= Infos.viewLvl())
            moneyAdd += (Random.Range(700, 1100) - 1000); //Будет отнимать 1000 и прибавлять рандомное число от 700 до 1100
        else
            moneyAdd = Random.Range(0, moneyAdd / 4);
        Debug.Log("moneyAdd after: " + moneyAdd);*/
        //money = Infos.get_money();
        //Infos.add_money(moneyAdd);
        moneyAdd += money;
        rightBottomMenu.GetComponent<Text>().text = money.ToString();
        StartCoroutine(Delay());
    }

    IEnumerator Shine()
    {
        while (true)
        {
            //leftShine.transform.Rotate(Vector3.Lerp(new Vector3(+0f, +0f, +0f), new Vector3(+0f, +0f, 360f), 0.1f));
            rightShine.transform.localScale -= new Vector3(f, f, f);
            leftShine.transform.localScale += new Vector3(f, f, f);
            yield return new WaitForSeconds(0.1f);
            //rightShine.transform.Rotate(Vector3.Lerp(new Vector3(+0f, +0f, +0f), new Vector3(+0f, +0f, 360f), 0.1f));
            leftShine.transform.localScale -= new Vector3(f, f, f);
            rightShine.transform.localScale += new Vector3(f, f, f);
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator Delay()
    {
        //StartCoroutine(Shine());
        while (money <= moneyAdd - 100)
        {
            leftBottomMenu.GetComponent<Text>().text = "+" + tmp.ToString();
            tmp+=10;
            rightBottomMenu.GetComponent<Text>().text = money.ToString();
            money+=10;
            yield return new WaitForSeconds(0.0005f);
        }
        while (money <= moneyAdd - 13)
        {
            leftBottomMenu.GetComponent<Text>().text = "+" + tmp.ToString();
            tmp++;
            rightBottomMenu.GetComponent<Text>().text = money.ToString();
            money++;
            yield return new WaitForSeconds(0.03f);
        }
        while (money <= moneyAdd)
        {
            leftBottomMenu.GetComponent<Text>().text = "+" + tmp.ToString();
            tmp++;
            rightBottomMenu.GetComponent<Text>().text = money.ToString();
            money++;
            yield return new WaitForSeconds(0.08f);//
        }
    }
}