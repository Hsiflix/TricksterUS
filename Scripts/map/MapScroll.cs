using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class MapScroll : MonoBehaviour
{
    public GameObject JungleLake;
    public GameObject JungleLakeNew1;
    public GameObject JungleLakeNew2;
    public GameObject Jungle;
    public GameObject JungleNew1;
    public GameObject JungleNew2;
    public GameObject Snow;
    public GameObject SnowNew1;
    public GameObject SandNew;
    public GameObject SandNew1;
    public GameObject Ship;
    public GameObject _DustRuins;
    public GameObject _JungleRuins;
    public GameObject _SnowRuins;
    public GameObject HardJungle;
    public GameObject HardSnow;
    public GameObject HardSand;
    public GameObject HardJungleTable;
    public GameObject HardSnowTable;
    public GameObject HardSandTable;
    public GameObject TheEndGO;
    public GameObject Achivement;
    public GameObject NoKeys;
    private GameObject memoryLocation;
    public Font myFont;

    private void Start() {
        Achivement.SetActive(false);
        info.LoadAchive();
    }
    void NameOf()
    {
        ButLoadLvl._namelvl = "lvl";
        if(info.AudioOn) GameObject.Find("audio_click_button").GetComponent<AudioSource>().Play();
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("menu");
    }
    public void lvlH1(){
        NameOf();
        ButLoadLvl._namelvl += "H1"; //Не трогать!
        WinMenuMoney.moneyAdd = 15000;
        memoryLocation = HardJungle; //HardJungle, HardSnow, HardSand //HardJungle, HardSnow, HardSand
        HardJungleTable.GetComponent<Text>().text = info.lang==1?"Что ита?":"Wut is dat?";
        PhrasesMapLocations.locNum = 3; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 1;
        AchivementMap.achive_step = 1;
        AchivementMap.achive_bugs = 1;
        AchivementFunc(22);
    }
    public void lvlH2(){
        NameOf();
        ButLoadLvl._namelvl += "H2";
        WinMenuMoney.moneyAdd = 15000;
        memoryLocation = HardJungle; //HardJungle, HardSnow, HardSand
        HardJungleTable.GetComponent<Text>().text = info.lang==1?"Статрай":"Statdise";
        PhrasesMapLocations.locNum = 3; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 1;
        AchivementMap.achive_step = 1;
        AchivementMap.achive_bugs = 1;
        AchivementFunc(23);
    }
    public void lvlH3(){
        NameOf();
        ButLoadLvl._namelvl += "H3";
        WinMenuMoney.moneyAdd = 15000;
        memoryLocation = HardJungle; //HardJungle, HardSnow, HardSand
        HardJungleTable.GetComponent<Text>().text = info.lang==1?"Статад":"Stathell";
        PhrasesMapLocations.locNum = 3; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 0;
        AchivementMap.achive_step = 0;
        AchivementMap.achive_bugs = 1;
        AchivementFunc(24);
    }
    public void lvlH4(){
        NameOf();
        ButLoadLvl._namelvl += "H4";
        WinMenuMoney.moneyAdd = 15000;
        memoryLocation = HardJungle; //HardJungle, HardSnow, HardSand
        HardJungleTable.GetComponent<Text>().text = info.lang==1?"Бистро":"Harry up";
        PhrasesMapLocations.locNum = 3; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 1;
        AchivementMap.achive_step = 1;
        AchivementMap.achive_bugs = 1;
        AchivementFunc(25);
    }
    public void lvlH5(){
        NameOf();
        ButLoadLvl._namelvl += "H5";
        WinMenuMoney.moneyAdd = 15000;
        memoryLocation = HardJungle; //HardJungle, HardSnow, HardSand
        HardJungleTable.GetComponent<Text>().text = info.lang==1?"Радуга":"Rainbow";
        PhrasesMapLocations.locNum = 3; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 2;
        AchivementMap.achive_step = 50;
        AchivementMap.achive_bugs = 1;
        AchivementFunc(26);
    }
    public void lvlH6(){
        NameOf();
        ButLoadLvl._namelvl += "H6";
        WinMenuMoney.moneyAdd = 15000;
        memoryLocation = HardJungle; //HardJungle, HardSnow, HardSand
        HardJungleTable.GetComponent<Text>().text = info.lang==1?"Осторожно, очень сложно":"Warning, very hard";
        PhrasesMapLocations.locNum = 3; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 45;
        AchivementMap.achive_step = 1;
        AchivementMap.achive_bugs = 1;
        AchivementFunc(27);
    }
    public void lvlH7(){
        NameOf();
        ButLoadLvl._namelvl += "H7";
        WinMenuMoney.moneyAdd = 15000;
        memoryLocation = HardJungle; //HardJungle, HardSnow, HardSand
        HardJungleTable.GetComponent<Text>().text = info.lang==1?"Шаг за шагом":"Step by step";
        PhrasesMapLocations.locNum = 3; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 45;
        AchivementMap.achive_step = 0;
        AchivementMap.achive_bugs = 1;
        AchivementFunc(28);
    }
    public void lvlH8(){
        NameOf();
        ButLoadLvl._namelvl += "H8";
        WinMenuMoney.moneyAdd = 15000;
        memoryLocation = HardSand; //HardJungle, HardSnow, HardSand
        HardSandTable.GetComponent<Text>().text = info.lang==1?"8 секунд":"8 seconds";
        PhrasesMapLocations.locNum = 3; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 0;
        AchivementMap.achive_step = 0;
        AchivementMap.achive_bugs = 1;
        AchivementFunc(29);
    }
    public void lvlH9(){
        NameOf();
        ButLoadLvl._namelvl += "H9";
        WinMenuMoney.moneyAdd = 15000;
        memoryLocation = HardSand; //HardJungle, HardSnow, HardSand
        HardSandTable.GetComponent<Text>().text = info.lang==1?"Потная катка":"Tough one";
        PhrasesMapLocations.locNum = 3; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 35;
        AchivementMap.achive_step = 10;
        AchivementMap.achive_bugs = 1;
        AchivementFunc(30);
    }
    public void lvlH10(){
        NameOf();
        ButLoadLvl._namelvl += "H10";
        WinMenuMoney.moneyAdd = 15000;
        memoryLocation = HardSand; //HardJungle, HardSnow, HardSand
        HardSandTable.GetComponent<Text>().text = info.lang==1?"Третья Мировая":"World War III";
        PhrasesMapLocations.locNum = 3; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 1;
        AchivementMap.achive_step = 0;
        AchivementMap.achive_bugs = 1;
        AchivementFunc(31);
    }
    public void lvlH11(){
        NameOf();
        ButLoadLvl._namelvl += "H11";
        WinMenuMoney.moneyAdd = 15000;
        memoryLocation = HardSand; //HardJungle, HardSnow, HardSand
        HardSandTable.GetComponent<Text>().text = info.lang==1?"Любимка":"Lovy";
        PhrasesMapLocations.locNum = 3; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 1;
        AchivementMap.achive_step = 0;
        AchivementMap.achive_bugs = 1;
        AchivementFunc(32);
    }
    public void lvlH12(){
        NameOf();
        ButLoadLvl._namelvl += "H12";
        WinMenuMoney.moneyAdd = 15000;
        memoryLocation = HardSand; //HardJungle, HardSnow, HardSand
        HardSandTable.GetComponent<Text>().text = info.lang==1?"Одна попытка":"One try";
        PhrasesMapLocations.locNum = 3; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 1;
        AchivementMap.achive_step = 0;
        AchivementMap.achive_bugs = 1;
        AchivementFunc(33);
    }
    public void lvlH13(){
        NameOf();
        ButLoadLvl._namelvl += "H13";
        WinMenuMoney.moneyAdd = 15000;
        memoryLocation = HardSand; //HardJungle, HardSnow, HardSand
        HardSandTable.GetComponent<Text>().text = info.lang==1?"Зеркальный":"Mirrored";
        PhrasesMapLocations.locNum = 3; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 1;
        AchivementMap.achive_step = 0;
        AchivementMap.achive_bugs = 1;
        AchivementFunc(34);
    }
    public void lvlH14(){
        NameOf();
        ButLoadLvl._namelvl += "H14";
        WinMenuMoney.moneyAdd = 15000;
        memoryLocation = HardSnow; //HardJungle, HardSnow, HardSand
        HardSnowTable.GetComponent<Text>().text = info.lang==1?"Побег":"Breakout";
        PhrasesMapLocations.locNum = 3; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 185;
        AchivementMap.achive_step = 0;
        AchivementMap.achive_bugs = 1;
        AchivementFunc(35);
    }
    public void lvlH15(){
        NameOf();
        ButLoadLvl._namelvl += "H15";
        WinMenuMoney.moneyAdd = 15000;
        memoryLocation = HardSnow; //HardJungle, HardSnow, HardSand
        HardSnowTable.GetComponent<Text>().text = info.lang==1?"Пуск":"Launcher";
        PhrasesMapLocations.locNum = 3; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 15;
        AchivementMap.achive_step = 0;
        AchivementMap.achive_bugs = 1;
        AchivementFunc(36);
    }
    public void lvlH16(){
        NameOf();
        ButLoadLvl._namelvl += "H16";
        WinMenuMoney.moneyAdd = 15000;
        memoryLocation = HardSnow; //HardJungle, HardSnow, HardSand
        HardSnowTable.GetComponent<Text>().text = info.lang==1?"Изи вин":"Easy win";
        PhrasesMapLocations.locNum = 3; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 0;
        AchivementMap.achive_step = 0;
        AchivementMap.achive_bugs = 1;
        AchivementFunc(37);
    }
    public void lvlH17(){
        NameOf();
        ButLoadLvl._namelvl += "H17";
        WinMenuMoney.moneyAdd = 15000;
        memoryLocation = HardSnow; //HardJungle, HardSnow, HardSand
        HardSnowTable.GetComponent<Text>().text = info.lang==1?"Змейка":"Snaky";
        PhrasesMapLocations.locNum = 3; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 0;
        AchivementMap.achive_step = 0;
        AchivementMap.achive_bugs = 1;
        AchivementFunc(38);
    }
    public void lvlH18(){
        NameOf();
        ButLoadLvl._namelvl += "H18";
        WinMenuMoney.moneyAdd = 15000;
        memoryLocation = HardSnow; //HardJungle, HardSnow, HardSand
        HardSnowTable.GetComponent<Text>().text = info.lang==1?"Найди меня":"Find me";
        PhrasesMapLocations.locNum = 3; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 100;
        AchivementMap.achive_step = 1;
        AchivementMap.achive_bugs = 1;
        AchivementFunc(39);
    }
    public void lvlH19(){
        NameOf();
        ButLoadLvl._namelvl += "H19";
        WinMenuMoney.moneyAdd = 15000;
        memoryLocation = HardSnow; //HardJungle, HardSnow, HardSand
        HardSnowTable.GetComponent<Text>().text = info.lang==1?"Буит мясо>":"Gonna be meat";
        PhrasesMapLocations.locNum = 3; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 0;
        AchivementMap.achive_step = 0;
        AchivementMap.achive_bugs = 1;
        AchivementFunc(40);
    }
    public void lvlH20(){
        NameOf();
        ButLoadLvl._namelvl += "H20";
        WinMenuMoney.moneyAdd = 15000;
        memoryLocation = HardSnow; //HardJungle, HardSnow, HardSand
        HardSnowTable.GetComponent<Text>().text = info.lang==1?"Гая":"Gaya";
        PhrasesMapLocations.locNum = 3; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 0;
        AchivementMap.achive_step = 0;
        AchivementMap.achive_bugs = 1;
        AchivementFunc(41);
    }
    
    public void lvlB1(){
        NameOf();
        ButLoadLvl._namelvl += "B1";
        WinMenuMoney.moneyAdd = 2000;
        memoryLocation = _JungleRuins;
        AchivementMap.achive_time = 65;
        AchivementMap.achive_step = 10;
        AchivementMap.achive_bugs = 3;
        AchivementFunc(19);
    }
    public void lvlB2(){
        NameOf();
        ButLoadLvl._namelvl += "B2";
        WinMenuMoney.moneyAdd = 20000;
        memoryLocation = _DustRuins;
        AchivementMap.achive_time = 50;
        AchivementMap.achive_step = 10;
        AchivementMap.achive_bugs = 3;
        AchivementFunc(20);
    }
    public void lvlB3(){
        NameOf();
        ButLoadLvl._namelvl += "B3";
        WinMenuMoney.moneyAdd = 1;
        memoryLocation = _SnowRuins;
        AchivementMap.achive_time = 50;
        AchivementMap.achive_step = 10;
        AchivementMap.achive_bugs = 3;
        AchivementFunc(21);
    }
    public void lvl1()
    {
        NameOf();
        ButLoadLvl._namelvl += "1";
        WinMenuMoney.moneyAdd = 100;
        memoryLocation = Jungle;
        PhrasesMapLocations.locNum = 0; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 70;
        AchivementMap.achive_step = 20;
        AchivementMap.achive_bugs = 3;
        Debug.Log("AchivementMap.achive_time = " + AchivementMap.achive_time);
        Debug.Log("AchivementMap.achive_step = " + AchivementMap.achive_step);
        AchivementFunc(1);
    }
    public void lvl2()
    {
        NameOf();
        ButLoadLvl._namelvl += "2";
        WinMenuMoney.moneyAdd = 150;
        memoryLocation = JungleNew1;
        PhrasesMapLocations.locNum = 0; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 55;
        AchivementMap.achive_step = 5;
        AchivementMap.achive_bugs = 3;
        AchivementFunc(2);
    }
    public void lvl3()
    {
        NameOf();
        ButLoadLvl._namelvl += "3";
        WinMenuMoney.moneyAdd = 200;
        memoryLocation = JungleLake;
        PhrasesMapLocations.locNum = 0; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 25;
        AchivementMap.achive_step = 10;
        AchivementMap.achive_bugs = 3;
        AchivementFunc(3);
    }
    public void lvl4()
    {
        NameOf();
        ButLoadLvl._namelvl += "4";
        WinMenuMoney.moneyAdd = 250;
        memoryLocation = JungleLakeNew1;
        PhrasesMapLocations.locNum = 0; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 30;
        AchivementMap.achive_step = 10;
        AchivementMap.achive_bugs = 3;
        AchivementFunc(4);
    }
    public void lvl5()
    {
        NameOf();
        ButLoadLvl._namelvl += "5";
        WinMenuMoney.moneyAdd = 300;
        memoryLocation = Jungle;
        PhrasesMapLocations.locNum = 0; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 45;
        AchivementMap.achive_step = 25;
        AchivementMap.achive_bugs = 3;
        AchivementFunc(5);
    }
    public void lvl6()
    {
        NameOf();
        ButLoadLvl._namelvl += "6";
        WinMenuMoney.moneyAdd = 500;
        memoryLocation = JungleNew2;
        PhrasesMapLocations.locNum = 0; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 23;
        AchivementMap.achive_step = 18;
        AchivementMap.achive_bugs = 3;
        AchivementFunc(6);
    }
    public void lvl7()
    {
        NameOf();
        ButLoadLvl._namelvl += "7";
        WinMenuMoney.moneyAdd = 1000;
        memoryLocation = JungleNew1;
        PhrasesMapLocations.locNum = 0; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 45;
        AchivementMap.achive_step = 5;
        AchivementMap.achive_bugs = 3;
        AchivementFunc(7);
    }
    public void lvl8()
    {
        NameOf();
        ButLoadLvl._namelvl += "8";
        WinMenuMoney.moneyAdd = 1500;
        memoryLocation = JungleLakeNew2;
        PhrasesMapLocations.locNum = 0; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 23;
        AchivementMap.achive_step = 38;
        AchivementMap.achive_bugs = 3;
        AchivementFunc(8);
    }
    public void lvl9()
    {
        NameOf();
        ButLoadLvl._namelvl += "9";
        WinMenuMoney.moneyAdd = 2000;
        memoryLocation = Jungle;
        PhrasesMapLocations.locNum = 0; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 123;
        AchivementMap.achive_step = 18;
        AchivementMap.achive_bugs = 3;
        AchivementFunc(9);
    }
    public void lvl10()
    {
        NameOf();
        ButLoadLvl._namelvl += "10";
        WinMenuMoney.moneyAdd = 3000;
        memoryLocation = Jungle;
        PhrasesMapLocations.locNum = 0; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 50;
        AchivementMap.achive_step = 18;
        AchivementMap.achive_bugs = 3;
        AchivementFunc(10);
    }
    public void lvl11()
    {
        NameOf();
        ButLoadLvl._namelvl += "11";
        WinMenuMoney.moneyAdd = 4000;
        memoryLocation = Jungle;
        PhrasesMapLocations.locNum = 0; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 17;
        AchivementMap.achive_step = 5;
        AchivementMap.achive_bugs = 2;
        AchivementFunc(11);
    }
    public void lvl12()
    {
        NameOf();
        ButLoadLvl._namelvl += "12";
        WinMenuMoney.moneyAdd = 5000;
        memoryLocation = JungleNew1;
        PhrasesMapLocations.locNum = 0; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 25;
        AchivementMap.achive_step = 26;
        AchivementMap.achive_bugs = 3;
        AchivementFunc(12);
    }
    public void lvl13()
    {
        NameOf();
        ButLoadLvl._namelvl += "13";
        WinMenuMoney.moneyAdd = 6000;
        memoryLocation = SandNew;
        PhrasesMapLocations.locNum = 2; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 43;
        AchivementMap.achive_step = 9;
        AchivementMap.achive_bugs = 3;
        AchivementFunc(13);
    }
    public void lvl14()
    {
        NameOf();
        ButLoadLvl._namelvl += "14";
        WinMenuMoney.moneyAdd = 7000;
        memoryLocation = JungleLakeNew2;
        PhrasesMapLocations.locNum = 0; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 33;
        AchivementMap.achive_step = 9;
        AchivementMap.achive_bugs = 3;
        AchivementFunc(14);
    }
    public void lvl15()
    {
        NameOf();
        ButLoadLvl._namelvl += "15";
        WinMenuMoney.moneyAdd = 8000;
        memoryLocation = SandNew1;
        PhrasesMapLocations.locNum = 2; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 15;
        AchivementMap.achive_step = 45;
        AchivementMap.achive_bugs = 3;
        AchivementFunc(15);
    }
    public void lvl16()
    {
        NameOf();
        ButLoadLvl._namelvl += "16";
        WinMenuMoney.moneyAdd = 10000;
        memoryLocation = Ship;
        PhrasesMapLocations.locNum = 4; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 125;
        AchivementMap.achive_step = 10;
        AchivementMap.achive_bugs = 3;
        AchivementFunc(16);
    }
    public void lvl17()
    {
        NameOf();
        ButLoadLvl._namelvl += "17";
        WinMenuMoney.moneyAdd = 12000;
        memoryLocation = SnowNew1;
        PhrasesMapLocations.locNum = 1; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 60;
        AchivementMap.achive_step = 10;
        AchivementMap.achive_bugs = 3;
        AchivementFunc(17);
    }
    public void lvl18()
    {
        NameOf();
        ButLoadLvl._namelvl += "18";
        WinMenuMoney.moneyAdd = 15000;
        memoryLocation = Snow;
        PhrasesMapLocations.locNum = 1; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
        AchivementMap.achive_time = 60;
        AchivementMap.achive_step = 10;
        AchivementMap.achive_bugs = 3;
        AchivementFunc(18);
    }

    private void AchivementFunc(int in_lvl){
        AchivementMap.achive_bugs = 3; //Const
        AchivementMap.lvl = in_lvl;
        Debug.LogWarning(ButLoadLvl._namelvl);
        Achivement.transform.localPosition = GameObject.Find(ButLoadLvl._namelvl).transform.localPosition + new Vector3(0f,60f,0f);
        Achivement.SetActive(true);
    }

    public void GoBtn(){
        if(ButLoadLvl._namelvl == "lvlB3" && (!AchivementMap.achivementKeys[0] || !AchivementMap.achivementKeys[1])) {
            Debug.Log("THIS");
            NoKeys.SetActive(true);
        }else{
            if(info.AudioOn) GameObject.Find("audio_bg").GetComponent<AudioSource>().volume = 0f;
            if(info.AudioOn) GameObject.Find("audio_map_step").GetComponent<AudioSource>().Play();
            memoryLocation.SetActive(true);
        }
    }
    
    public void NoKeysOff(){
        NoKeys.SetActive(false);
    }

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