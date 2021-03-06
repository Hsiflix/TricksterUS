﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MapScroll_BackUp : MonoBehaviour
{
    public GameObject JungleLake;
    public GameObject JungleLakeNew1;
    public GameObject JungleLakeNew2;
    public GameObject Jungle;
    public GameObject JungleNew1;
    public GameObject JungleNew2;
    public GameObject Snow;
    public GameObject SnowNew1;
    public GameObject _DustRuins;
    public GameObject _JungleRuins;
    public GameObject _SnowRuins;
    public GameObject TheEndGO;

    private void Start() {
        /*Text moneyText = GameObject.Find("money_text").GetComponent<Text>();
        if(info.AudioOn) GameObject.Find("audio_bg").GetComponent<AudioSource>().volume = 0.035f;
        info.Load();
        if(info.money < 1000){
            moneyText.text = info.money.ToString();
        }else if(info.money < 1000000){
            string tmp = info.money.ToString().Substring(0,info.money.ToString().Length-3)+'.';
            tmp += info.money.ToString().Substring(info.money.ToString().Length-3,1)+'k';
            moneyText.text = tmp;
        }else{
            string tmp = info.money.ToString().Substring(0,1)+'.';
            tmp += info.money.ToString().Substring(1,1)+"kk+";
            moneyText.text = tmp;
        }*/
    }
    void NameOf()
    {
        if(info.AudioOn) GameObject.Find("audio_map_step").GetComponent<AudioSource>().Play();
        if(info.AudioOn) GameObject.Find("audio_bg").GetComponent<AudioSource>().volume = 0f;
        ButLoadLvl._namelvl = "lvl";
    }

    public void BackMenu()
    {
        //NameOf();
        SceneManager.LoadScene("menu");
    }
    public void lvlB1(){
        //Debug.Log("lvlB1()");
        NameOf();
        ButLoadLvl._namelvl += "B1"; //B* - уровни с ботом в руинах
        WinMenuMoney.moneyAdd = 1000;
        _JungleRuins.SetActive(true);
    }
    public void lvlB2(){
        //Debug.Log("lvlB2()");
        NameOf();
        ButLoadLvl._namelvl += "B2"; //B* - уровни с ботом в руинах
        WinMenuMoney.moneyAdd = 1000;
        _DustRuins.SetActive(true);
    }
    public void lvlB3(){
        //Debug.Log("lvlB3()");
        NameOf();
        ButLoadLvl._namelvl += "B3"; //B* - уровни с ботом в руинах
        WinMenuMoney.moneyAdd = 1000;
        _SnowRuins.SetActive(true);
    }
    public void lvl1()
    {
        NameOf();
        ButLoadLvl._namelvl += "1";
        WinMenuMoney.moneyAdd = 200;
        Jungle.SetActive(true);
    }
    public void lvl2()
    {
        NameOf();
        ButLoadLvl._namelvl += "2";
        WinMenuMoney.moneyAdd = 400;
        JungleNew1.SetActive(true);
    }
    public void lvl3()
    {
        NameOf();
        ButLoadLvl._namelvl += "3";
        WinMenuMoney.moneyAdd = 600;
        JungleLake.SetActive(true);
    }
    public void lvl4()
    {
        NameOf();
        ButLoadLvl._namelvl += "4";
        WinMenuMoney.moneyAdd = 800;
        JungleLakeNew1.SetActive(true);
    }
    public void lvl5()
    {
        NameOf();
        ButLoadLvl._namelvl += "5";
        WinMenuMoney.moneyAdd = 1000;
        Jungle.SetActive(true);
    }
    public void lvl6()
    {
        NameOf();
        ButLoadLvl._namelvl += "6";
        WinMenuMoney.moneyAdd = 2000;
        JungleNew2.SetActive(true);
    }
    public void lvl7()
    {
        NameOf();
        ButLoadLvl._namelvl += "7";
        WinMenuMoney.moneyAdd = 4000;
        JungleNew1.SetActive(true);
    }
    public void lvl8()
    {
        NameOf();
        ButLoadLvl._namelvl += "8";
        WinMenuMoney.moneyAdd = 6000;
        JungleLakeNew2.SetActive(true);
    }
    public void lvl9()
    {
        NameOf();
        ButLoadLvl._namelvl += "9";
        WinMenuMoney.moneyAdd = 8000;
        Jungle.SetActive(true);
    }
    public void lvl10()
    {
        NameOf();
        ButLoadLvl._namelvl += "10";
        WinMenuMoney.moneyAdd = 10000;
        Jungle.SetActive(true);
    }
    public void lvl11()
    {
        NameOf();
        ButLoadLvl._namelvl += "11";
        WinMenuMoney.moneyAdd = 12000;
        Jungle.SetActive(true);
    }
    public void lvl12()
    {
        NameOf();
        ButLoadLvl._namelvl += "12";
        WinMenuMoney.moneyAdd = 15000;
        JungleNew1.SetActive(true);
    }
    public void lvl13()
    {
        NameOf();
        ButLoadLvl._namelvl += "13";
        WinMenuMoney.moneyAdd = 20000;
        JungleNew1.SetActive(true);
    }
    public void lvl14()
    {
        NameOf();
        ButLoadLvl._namelvl += "14";
        WinMenuMoney.moneyAdd = 25000;
        JungleLakeNew2.SetActive(true);
    }
    public void lvl15()
    {
        NameOf();
        ButLoadLvl._namelvl += "15";
        WinMenuMoney.moneyAdd = 30000;
        JungleNew2.SetActive(true);
    }
    public void lvl16()
    {
        NameOf();
        ButLoadLvl._namelvl += "16";
        WinMenuMoney.moneyAdd = 35000;
        JungleLake.SetActive(true);
    }
    public void lvl17()
    {
        NameOf();
        ButLoadLvl._namelvl += "17";
        WinMenuMoney.moneyAdd = 40000;
        SnowNew1.SetActive(true);
    }
    public void lvl18()
    {
        NameOf();
        ButLoadLvl._namelvl += "18";
        WinMenuMoney.moneyAdd = 50000;
        Snow.SetActive(true);
    }
    /*public void lvl0() //Переехал в tutorial_map
    {
        NameOf();
        ButLoadLvl._namelvl += "0";
        WinMenuMoney.moneyAdd = 100;
        Sand.SetActive(true);
    }*/
    public void ToTricksterIsland()
    {
        StartCoroutine(ToTricksterIslandIE());
    }
    public void ToMap()
    {
        SceneManager.LoadScene("Map", LoadSceneMode.Single);
    }

    public void TheEnd(){
        TheEndGO.SetActive(true);
    }

    IEnumerator ToTricksterIslandIE(){
        if(info.AudioOn) GameObject.Find("audio_trix_island").GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("TricksterIsland");
    }
}
