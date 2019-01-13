using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class Infos : MonoBehaviour {

    static private int lvl = 17; //ПОМЕНЯТЬ НА 0 уровень!!"
    static private int max_lvl = 18; 
    static private int money; ///ПОМЕНЯТЬ!"
    static private string info = "";
    static private string tmpInfo = "";
    static private int i = 0;

    static public bool AudioOn= true;

    static public int get_money()
    {
        return money;
    }

    static public void add_money(int ad_money)
    {
        money += ad_money;
    }

    static public void sub_money(int sb_money)
    {
        money -= sb_money;
    }

    static public int view_max_Lvl()
    {
        return max_lvl;
    }

    static public int viewLvl()
    {
        return lvl;
    }
    static public void incLvl()
    {
        lvl++;
    }
    static public void newLvl()
    {
        lvl = 1;
        money = 0;
    }

    //Во время выйгрыша будет проверяться, последний ли это уровень, если да, то
    //мы вызываем функцию incLvl(), которая прибавляет к lvl +1, так же в этот момент
    //мы сохраняем игру, вызвав фунцию Save().
    //Игра загружается в главном меню

    public void Start()
    {
        //Узнаем номер активной сцены
        Scene actScene = SceneManager.GetActiveScene();
        string actSceneName = actScene.name;
        actSceneName = actSceneName.Substring(3);
        int actSceneInt = int.Parse(actSceneName);
        //Проверяем новый ли это уровень
        if(actSceneInt == lvl)
        {
            //27/10/18

            WinMenuMoney.moneyAdd += (Random.Range(700, 1100) - 1000); //Будет отнимать 1000 и прибавлять рандомное число от 700 до 1100
            //add_money(WinMenuMoney.moneyAdd);
            ///27/10/18
            incLvl();
            //Save();

        }
        else
        {
            //27/10/18

            WinMenuMoney.moneyAdd = Random.Range(0, WinMenuMoney.moneyAdd / 4);
            //add_money(WinMenuMoney.moneyAdd);

            ///27/10/18
        }
        WinMenuMoney.money = get_money();
        WinMenuMoney.after_infos = true;
        add_money(WinMenuMoney.moneyAdd);
        Save();
    }

    public static void Save()
    {
        info = lvl.ToString() + "*" + money.ToString() + "*" + AudioOn.ToString() + "*";
        //Debug.Log(info);
        BinaryFormatter bf = new BinaryFormatter();
        //Application.persistentDataPath это строка; выведите ее в логах и вы увидите расположение файла сохранений
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
        bf.Serialize(file, info);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            info = (string)bf.Deserialize(file);
            Debug.Log("Load: "+ info);
            i = 0;
            tmpInfo = "";
            while (info[i] != '*')
            {
                tmpInfo += info[i];
                i++;
            }
            lvl = int.Parse(tmpInfo);
            i++;
            tmpInfo = "";
            while (info[i] != '*')
            {
                tmpInfo += info[i];
                i++;
            }
            money = int.Parse(tmpInfo);
            i++;
            tmpInfo = "";
            while (info[i] != '*')
            {
                tmpInfo += info[i];
                i++;
            }
            if(tmpInfo == "True"){
                Infos.AudioOn = true;
                AudioSourseOnOff.ChangeAudioSourseOnOff(true);
            } else if (tmpInfo == "False"){
                Infos.AudioOn = false;
                AudioSourseOnOff.ChangeAudioSourseOnOff(false);
            } else Debug.Log("Error audio load: " + tmpInfo);
            file.Close();
        }
    }
}
