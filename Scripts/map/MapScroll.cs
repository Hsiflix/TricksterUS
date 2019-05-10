using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MapScroll : MonoBehaviour
{
    public GameObject _ButLvlLo;
    public GameObject _ButLvlLoJun;
    public GameObject _ButLvlLoPe;
    public GameObject _ButLvlLoNew1;
    public GameObject _ButLvlLoNew2;
    public GameObject _ButLvlLoJunNew1;
    public GameObject _ButLvlLoJunNew2;
    public GameObject _ButLvlLoPeNew;
    public GameObject _DustRuins;

    void NameOf()
    {
        ButLoadLvl._namelvl = "lvl";
    }

    public void BackMenu()
    {
        NameOf();
        SceneManager.LoadScene("menu");
    }
    public void lvlB1(){
        //Debug.Log("lvlB1()");
        NameOf();
        ButLoadLvl._namelvl += "B1"; //B* - уровни с ботом в руинах
        WinMenuMoney.moneyAdd = 1000;
        //_DustRuins.SetActive(true);
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
        //_DustRuins.SetActive(true);
    }
    public void lvl1()
    {
        NameOf();
        ButLoadLvl._namelvl += "1";
        WinMenuMoney.moneyAdd = 1000;
        _ButLvlLoJun.SetActive(true);
    }
    public void lvl2()
    {
        NameOf();
        ButLoadLvl._namelvl += "2";
        WinMenuMoney.moneyAdd = 1000;
        _ButLvlLoJunNew1.SetActive(true);
    }
    public void lvl3()
    {
        NameOf();
        ButLoadLvl._namelvl += "3";
        WinMenuMoney.moneyAdd = 1000;
        _ButLvlLo.SetActive(true);
    }
    public void lvl4()
    {
        NameOf();
        ButLoadLvl._namelvl += "4";
        WinMenuMoney.moneyAdd = 1000;
        _ButLvlLoNew1.SetActive(true);
    }
    public void lvl5()
    {
        NameOf();
        ButLoadLvl._namelvl += "5";
        WinMenuMoney.moneyAdd = 1000;
        _ButLvlLoJun.SetActive(true);
    }
    public void lvl6()
    {
        NameOf();
        ButLoadLvl._namelvl += "6";
        WinMenuMoney.moneyAdd = 1000;
        _ButLvlLoJunNew2.SetActive(true);
    }
    public void lvl7()
    {
        NameOf();
        ButLoadLvl._namelvl += "7";
        WinMenuMoney.moneyAdd = 1000;
        _ButLvlLoJunNew1.SetActive(true);
    }
    public void lvl8()
    {
        NameOf();
        ButLoadLvl._namelvl += "8";
        WinMenuMoney.moneyAdd = 1000;
        _ButLvlLoNew2.SetActive(true);
    }
    public void lvl9()
    {
        NameOf();
        ButLoadLvl._namelvl += "9";
        WinMenuMoney.moneyAdd = 1000;
        _ButLvlLoJun.SetActive(true);
    }
    public void lvl10()
    {
        NameOf();
        ButLoadLvl._namelvl += "10";
        WinMenuMoney.moneyAdd = 1000;
        _ButLvlLoJun.SetActive(true);
    }
    public void lvl11()
    {
        NameOf();
        ButLoadLvl._namelvl += "11";
        WinMenuMoney.moneyAdd = 1000;
        _ButLvlLoJun.SetActive(true);
    }
    public void lvl12()
    {
        NameOf();
        ButLoadLvl._namelvl += "12";
        WinMenuMoney.moneyAdd = 1000;
        _ButLvlLoJunNew1.SetActive(true);
    }
    public void lvl13()
    {
        NameOf();
        ButLoadLvl._namelvl += "13";
        WinMenuMoney.moneyAdd = 1000;
        _ButLvlLoJunNew1.SetActive(true);
    }
    public void lvl14()
    {
        NameOf();
        ButLoadLvl._namelvl += "14";
        WinMenuMoney.moneyAdd = 1000;
        _ButLvlLoNew2.SetActive(true);
    }
    public void lvl15()
    {
        NameOf();
        ButLoadLvl._namelvl += "15";
        WinMenuMoney.moneyAdd = 1000;
        _ButLvlLoJunNew2.SetActive(true);
    }
    public void lvl16()
    {
        NameOf();
        ButLoadLvl._namelvl += "16";
        WinMenuMoney.moneyAdd = 1000;
        _ButLvlLo.SetActive(true);
    }
    public void lvl17()
    {
        NameOf();
        ButLoadLvl._namelvl += "17";
        WinMenuMoney.moneyAdd = 1000;
        _ButLvlLoPeNew.SetActive(true);
    }
    public void lvl18()
    {
        NameOf();
        ButLoadLvl._namelvl += "18";
        WinMenuMoney.moneyAdd = 1000;
        _ButLvlLoPe.SetActive(true);
    }
    public void lvl0()
    {
        NameOf();
        ButLoadLvl._namelvl += "0";
        WinMenuMoney.moneyAdd = 1000;
        _ButLvlLoJun.SetActive(true);
    }
    public void ToTricksterIsland()
    {
        SceneManager.LoadScene("TricksterIsland");
    }
    public void ToMap()
    {
        SceneManager.LoadScene("Map", LoadSceneMode.Single);
    }
    private void checkActLvl(){
        
    }
}