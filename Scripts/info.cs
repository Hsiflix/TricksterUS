using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class info : MonoBehaviour
{
    // =====>CONST<=====
    public static int maxAchive = 42;
    public static bool AllAciveDone = false;
    // =====>STATIC_PUBLIC<=====
    //Unity Object
    static public Sprite colorNext; //Цвет хода
    static public Sprite ball_blue, ball_yellow, ball_green, ball_red, ball_tort; //Спрайты шаров
    //static public GameObject ballPrefab; //Префаб шара
    //static public GameObject appearancePrefab;
    //static public Text timerText, stepsText;
    //Int
    static public int steps; //Кол-во шагов
    static public int money = 0; //Кол-во монет
    static public int trickHelpCount = 0; //Кол-во помощей трикстера
    static public int timersecond; //Кол-во времени
    static public int winBall; //Победный цвет
    static public int field_size; //Размер поля
    static public int colorNextInt; //Номер цвета хода
    static public int lvl = 0; //Текущий уровень
    static public int hardLvl = 0; //Текущий сложный уровень
    static public int max_hardLvl = 20; //Текущий сложный уровень
    static public int max_lvl = 18; //Последний уровень
    static public int bugsCount = 0;
    static public int queue = 0;
    static public int[] ballColors;
    static public int[] stat_balls;
    static public int botColor = 0;
    static public int endlessReboot = 0;
    static public int lang = 0; //0-Eng, 1-Rus
    static public int configTime = 0, configStep = 0, configBug = 0;
    //Bool
    static public bool[] firstMeet = new bool[]{false,false,false,false}; //Color, Tort, Stat, Bot
    static public bool stepGo = false; //Шагометр
    static public bool timerGo = false; //Таймер
    static public bool AudioOn = true; //Включение/выключение звука
    static public bool MusicOn = true; //Включение/выключение музыки
    static public bool activeRot = false;
    static public bool activeTouch = true;
    static public bool activeTouchBot = true;
    static public bool botActive = false;
    static public bool isEndless = false;
    static public bool isCoop = false;
    static public bool tutorial = false;
    static public bool intro = true;
    static public bool noAds = false;
    static public bool isPause = false;
    static public bool AllAcivements = false;
    static public bool EndlessOpen = false;
    // =====>PUBLIC<=====
    //Unity Object
    public GameObject LoseMenu;
    public GameObject WinMenu;
    public GameObject LolLose, NoColor;
    public GameObject CanvasBot;
    public GameObject endlessIE;
    //Int
    //Float
    public float timerSlowdown = 1;
    // =====>PRIVATE<=====
    //Unity Object
    private Camera cam;
    static public Color camColor;
    private Text timerText, stepsText;
    //Int
    private int timerLimitForBlink = 10;
    private int lolLoseTime;
    //Float
    private float secondgametime;
    //Bool
    private bool activeRotCheck = false;
    private bool activeWinLose = true;
    private bool NoColorAlready = false;

    void Start(){
        activeRot = false;
        activeTouch = true;
        activeTouchBot = true;
        activeRotCheck = false;
        NoColorAlready = false;
        activeWinLose = true;
        queue = 0;
        ballColors = new int[4];
        timerText = GameObject.Find("Timer").GetComponent<Text>();
        stepsText = GameObject.Find("Steps").GetComponent<Text>();
        cam = GameObject.Find("GameCamera").GetComponent<Camera>();
        camColor = cam.backgroundColor;
        /*achTimeAct = AchivementMap.achive_time;
        achStepAct = AchivementMap.achive_step;
        achBugAct = AchivementMap.achive_bugs;*/
        LolLose.SetActive(false);
        lolLoseTime = Random.Range(50,100);
    }

    public void Update(){
        //CHECK QUEUE, WIN AND STEPS_LOSE
        if(activeRotCheck && queue == 0){
            //Debug.Log("B:" + ballColors[0] + "; Y:" + ballColors[1] + "; G:"+ ballColors[2] + "; R:" + ballColors[3]);
            activeRot = false;
            activeRotCheck = false;

            //StartCoroutine(WinMenuIE()); //эта строчка выигрывает игру в один клик
            //LoseMenuIE(); //эта строчка проигрывает игру в один клик

            if(botActive || isCoop){
                CanvasBot.GetComponent<CanvasBot>().CallCanvasBot();
            }

            GetComponent<FindMaxWay>().DestroyTarget();
            if(activeWinLose){
                if(ballColors[winBall] == field_size * field_size){
                    Debug.Log("Выйграл по окончанию хода, т.к. ballColors[winBall] == field_size * field_size");
                    Debug.Log("B:" + ballColors[0] + "; Y:" + ballColors[1] + "; G:"+ ballColors[2] + "; R:" + ballColors[3]);
                    StartCoroutine(WinMenuIE());
                }else{
                    if(stepGo && steps <= 0){
                        if(!botActive){
                            Debug.Log("STEPS_LOSE");
                            if(!isCoop)LoseMenuIE();
                            else StartCoroutine(WinMenuIE());
                        }else{
                            if(ballColors[winBall]-stat_balls.Length > ballColors[botColor])
                            {
                                Debug.Log("Выйграл по окончанию хода, т.к. ballColors[winBall] > ballColors[botColor]");
                                Debug.Log("B:" + ballColors[0] + "; Y:" + ballColors[1] + "; G:"+ ballColors[2] + "; R:" + ballColors[3]);
                                StartCoroutine(WinMenuIE());
                            }else{
                                LoseMenuIE();
                            }
                        }
                    }
                }
                if(botActive){
                    if(ballColors[winBall]-stat_balls.Length == 0){
                        LoseMenuIE();
                    }
                    if(ballColors[botColor]/*-stat_balls.Length*/ == 0){
                        //Debug.LogWarning("THIS");
                        StartCoroutine(WinMenuIE());
                    }
                }
                if(isCoop){
                    if(ballColors[coopMenu.player1Color]-stat_balls.Length == 0){
                        StartCoroutine(WinMenuIE());
                    }
                    if(ballColors[coopMenu.player2Color]-stat_balls.Length == 0){
                        StartCoroutine(WinMenuIE());
                    }
                }
            }
        }
        if(activeRotCheck) {
            activeRotCheck = false;
        }
        if(activeRot && queue == 0){
            activeRotCheck = true;
        }
        //TIMER AND TIMER_LOSE
        secondgametime += Time.deltaTime;
        if (secondgametime >= timerSlowdown)
        {
            secondgametime = 0;
            //achTimeAct--;
            if(info.timerGo) timersecond -= 1;
            else timersecond++;
            /*22.09.2019*/
            if(!isEndless && !isCoop){
                if(timerText.color != Color.green && (
                                (!timerGo && timersecond == AchivementMap.achive_time)
                                ||
                                (timerGo && configTime-timersecond == AchivementMap.achive_time)
                    )){
                    timerText.color = new Color(255f/255f, 215f/255f, 0f/255f);
                } else if (timerText.color == new Color(255f/255f, 215f/255f, 0f/255f)) timerText.color = Color.white;
            }
            /* */
            if(timerText.color != Color.green){
                if(timersecond < 1000) timerText.text = ""+timersecond;
                else timerText.text = "999+";
            }
            if(timersecond < timerLimitForBlink && info.timerGo &&/*22.09.2019*/ timerText.color != new Color(255f/255f, 215f/255f, 0f/255f)){
                if (timersecond % 2 == 1){
                    cam.backgroundColor = Color.red;//new Color(160 / 255f, 61 / 255f, 45 / 255f); //Color.red
                    if(timerText.color != Color.green) timerText.color = Color.red;
                }
                else {
                    cam.backgroundColor = camColor; //72A9AD
                    if(timerText.color != Color.green) timerText.color = Color.white;
                }
            }else{
                cam.backgroundColor = camColor; //72A9AD
                if(timerText.color != Color.green &&/*22.09.2019*/ timerText.color != new Color(255f/255f, 215f/255f, 0f/255f)) timerText.color = Color.white;
            }
            if(((timersecond == lolLoseTime && !timerGo && !stepGo && !botActive && !isEndless)) && spawn.endSpawn){
                if(SceneManager.GetActiveScene().name != "lvl0" &&
                SceneManager.GetActiveScene().name != "lvl1" &&
                SceneManager.GetActiveScene().name != "lvl2" &&
                SceneManager.GetActiveScene().name != "lvl3" &&
                SceneManager.GetActiveScene().name != "lvl4" &&
                SceneManager.GetActiveScene().name != "lvl5" &&
                SceneManager.GetActiveScene().name != "lvl6"){
                    LolLose.SetActive(true);
                    info.timerGo = true;
                    timersecond = 10;
                }
            }
            //Debug.Log(winBall);
            if(spawn.endSpawn && ballColors[winBall]-stat_balls.Length == 0 && !botActive && SceneManager.GetActiveScene().name != "lvl0" && !isCoop && !NoColorAlready){ //NoColor
                NoColor.SetActive(true);
                NoColorAlready = true;
            }
        }
        if(activeWinLose){
            if (timerGo && timersecond <= 0)
            {
                Debug.Log("timerGo && timersecond <= 0");
                if (ballColors[winBall] == field_size * field_size){
                    Debug.Log("Выйграл по окончанию времени, т.к. ballColors[winBall] == field_size * field_size");
                    Debug.Log("B:" + ballColors[0] + "; Y:" + ballColors[1] + "; G:"+ ballColors[2] + "; R:" + ballColors[3]);
                    StartCoroutine(WinMenuIE());
                }else{
                    if (!botActive){
                        Debug.Log("TIMER_LOSE");
                        if(!isCoop)LoseMenuIE();
                        else StartCoroutine(WinMenuIE());
                    }else{
                        if(ballColors[winBall]-stat_balls.Length > ballColors[botColor]){
                            Debug.Log("Выйграл по окончанию времени, т.к. ballColors[winBall] > ballColors[botColor]");
                            Debug.Log("B:" + ballColors[0] + "; Y:" + ballColors[1] + "; G:"+ ballColors[2] + "; R:" + ballColors[3]);
                            StartCoroutine(WinMenuIE());
                        }else{
                            LoseMenuIE();
                        }
                    }
                }
            }
        }
    }

    private void DestroyAll(){
        foreach (GameObject go in spawn.Balls){
			Destroy(go);
		}
        GetComponent<trickHelp>().DestroyAll();
        GetComponent<colorBall>().DestroyAll();
    }

    public void Step(){
        //achStepAct--;
        if(stepGo){
            steps--;
        } else{
            steps++;
        }
        /*22.09.2019*/
        if(!isEndless && !isCoop){
            if(stepsText.color != Color.green && (
                                (!stepGo && steps == AchivementMap.achive_step)
                                ||
                                (stepGo && configStep-steps == AchivementMap.achive_step)
                    )){
                stepsText.color = new Color(255f/255f, 215f/255f, 0f/255f);
            } else if (stepsText.color == new Color(255f/255f, 215f/255f, 0f/255f)) stepsText.color = Color.white;
        }
        /* */
        if(steps < 1000) stepsText.text = ""+steps;
            else stepsText.text = "999+";
        if(steps <= 5 && info.stepGo && stepsText.color != new Color(255f/255f, 215f/255f, 0f/255f)) stepsText.color = Color.red;
    }

    private void LoseMenuIE(){
        activeWinLose = false;
        if(!isEndless){
            DestroyAll();
            LoseMenu.SetActive(true);
            GameObject.Find("Game").SetActive(false);
        }else{
            endlessScore.scoreNum = 0;
            endlessIE.GetComponent<endlessIE>().StartEndlessIE();
            //StartCoroutine(EndlessIE());
        }
        //activeWinLose = true;
    }

    IEnumerator WinMenuIE(){
        spawn.endSpawn = false;
        activeWinLose = false;
        Debug.LogWarning("WinMenuIE()");
        //Achivements
        //Debug.Log("Achive: time = "+ achTimeAct + ", step = " + achStepAct + ", bug = " + achBugAct + ";");
        if(timerGo){
            if(AchivementMap.achive_time >= configTime - timersecond) AchivementMap.achivements[AchivementMap.lvl,0] = true;
            Debug.Log("timerGo; if(AchivementMap.achive_time >= configTime - timersecond) = " + AchivementMap.achive_time + " >= " + configTime + " - " + timersecond);
        }else{
            if(AchivementMap.achive_time >= timersecond) AchivementMap.achivements[AchivementMap.lvl,0] = true;
            Debug.Log("if(AchivementMap.achive_time >= timersecond) = " + AchivementMap.achive_time + " >= " + timersecond);
        }
        if(stepGo){
            if(AchivementMap.achive_step >= configStep - steps) AchivementMap.achivements[AchivementMap.lvl,1] = true;
            Debug.Log("timerGo; if(AchivementMap.achive_step >= configStep - steps) = " + AchivementMap.achive_step + " >= " + configStep + " - " + steps);
        }else{
            if(AchivementMap.achive_step >= steps) AchivementMap.achivements[AchivementMap.lvl,1] = true;
            Debug.Log("if(AchivementMap.achive_step >= steps) = " + AchivementMap.achive_step + " >= " + steps);
        }
        if(AchivementMap.achive_bugs <= bugsCount && BugsOnMap.AchivePerformed && BugsOnLvls.AchivePerformed) AchivementMap.achivements[AchivementMap.lvl,2] = true;
        Debug.Log("if(AchivementMap.achive_bugs <= bugsCount && BugsOnMap.AchivePerformed && BugsOnLvls.AchivePerformed) = " + AchivementMap.achive_bugs + " <= " + bugsCount + " && " + BugsOnMap.AchivePerformed + "&&" + BugsOnLvls.AchivePerformed);
        info.SaveAchive();
        //--Achivements

        if(lvl==max_lvl && hardLvl==max_hardLvl){
            EndlessOpen = true;
            info.Save();
        }

        if(info.AudioOn) GameObject.Find("Audio_lvl_end").GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1.1f);
        if(!isEndless){
            WinMenu.SetActive(true);
            DestroyAll();
            GameObject.Find("Game").SetActive(false);
        }else{
            endlessScore.scoreNum++;
            GameObject.Find("LvlScene").GetComponent<endlessIE>().StartEndlessIE();
            //StartCoroutine(EndlessIE());
        }
        //activeWinLose = true;
    }

    /*=================================================================================================================*/
    /*=================================================================================================================*/
    /*=================================================================================================================*/

    public static void Save()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {
            File.Delete(Application.persistentDataPath + "/savedGames.gd");
        }
        string info = lvl.ToString() + "*" + money.ToString() + "*" + AudioOn.ToString() + "*"+ MusicOn.ToString() + "*" + trickHelpCount.ToString() + 
                    "*" + endlessReboot.ToString() + "*" + lang.ToString() + "*" + intro + "*" + hardLvl + "*" + firstMeet[0] + "*" + firstMeet[1] + 
                    "*" + firstMeet[2] + "*" + firstMeet[3] +
                    "*" + MapCrossPushHide.firstMeet[0] + "*" + MapCrossPushHide.firstMeet[1] + "*" + MapCrossPushHide.firstMeet[2] +
                    "*" + noAds + "*" + AllAciveDone + "*" + EndlessOpen;
        BinaryFormatter bf = new BinaryFormatter();
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
            string info = (string)bf.Deserialize(file);
            Debug.Log("Load: "+ info);
            string[] infos = info.Split('*');
            lvl = int.Parse(infos[0]);
            money = int.Parse(infos[1]);
            if(infos[2]=="True")
            AudioOn = true;
            else AudioOn = false;
            if(infos[3]=="True")
            MusicOn = true;
            else MusicOn = false;
            trickHelpCount = int.Parse(infos[4]);
            endlessReboot = int.Parse(infos[5]);
            lang = int.Parse(infos[6]);
            if(infos[7]=="True")
            intro = true;
            else intro = false;
            hardLvl = int.Parse(infos[8]);
            firstMeet[0]=infos[9]=="True"?true:false;
            firstMeet[1]=infos[10]=="True"?true:false;
            firstMeet[2]=infos[11]=="True"?true:false;
            firstMeet[3]=infos[12]=="True"?true:false;
            MapCrossPushHide.firstMeet[0]=infos[13]=="True"?true:false;
            MapCrossPushHide.firstMeet[1]=infos[14]=="True"?true:false;
            MapCrossPushHide.firstMeet[2]=infos[15]=="True"?true:false;
            noAds = infos[16]=="True"?true:false;
            AllAciveDone = infos[17]=="True"?true:false;
            EndlessOpen = infos[18]=="True"?true:false;
            file.Close();
        }else{
            Save();
        }
    }

    public static void SaveAchive()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGamesAchive.gd"))
        {
            File.Delete(Application.persistentDataPath + "/savedGamesAchive.gd");
        }
        string info = ""; //AchivementMap.achivements[,];
        for (int i = 0; i < maxAchive; i++){ //i < number of all lvls = AchivementMap.achivements
            info+=AchivementMap.achivements[i,0]+","+ AchivementMap.achivements[i,1] +"," + AchivementMap.achivements[i,2] +"," + AchivementMap.achivements[i,3];
            info+="*";
        }
        info += AchivementMap.achivementKeys[0]+","+ AchivementMap.achivementKeys[1] +"," + AchivementMap.achivementKeys[2];
        info+="*";
        Debug.Log(AchivementMap.achivementKeys[0]+","+ AchivementMap.achivementKeys[1] +"," + AchivementMap.achivementKeys[2]);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGamesAchive.gd");
        bf.Serialize(file, info);
        file.Close();
    }

    public static void FlushAchive(){
        if (File.Exists(Application.persistentDataPath + "/savedGamesAchive.gd"))
        {
            File.Delete(Application.persistentDataPath + "/savedGamesAchive.gd");
        }
        Debug.Log("Achive is flushed");
        string info = ""; //AchivementMap.achivements[,];
        for (int i = 0; i < maxAchive; i++){ //i < number of all lvls = AchivementMap.achivements
            info+="False" + "," + "False" + "," + "False" + "," + "False";
            info+="*";
        }
        info+="False" + "," + "False" + "," + "False";
        info+="*";
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGamesAchive.gd");
        bf.Serialize(file, info);
        file.Close();
    }

    public static void LoadAchive()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGamesAchive.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGamesAchive.gd", FileMode.Open);
            string info = (string)bf.Deserialize(file);
            Debug.Log("LoadAchive: "+ info);
            string[] infos = info.Split('*');
            for (int i = 0; i < maxAchive; i++){ //i < number of all lvls = AchivementMap.achivements
                string[] infoss = infos[i].Split(',');
                for(int j = 0; j < 4; j++){
                    if(infoss[j]=="True")
                        AchivementMap.achivements[i,j] = true;
                    else AchivementMap.achivements[i,j] = false;
                }
            }
            int num = maxAchive;
            string[] infosss = infos[num].Split(',');
            for(int j = 0; j < 3; j++){
                if(infosss[j]=="True")
                    AchivementMap.achivementKeys[j] = true;
                else AchivementMap.achivementKeys[j] = false;
            }
            Debug.Log(AchivementMap.achivementKeys[0]+","+ AchivementMap.achivementKeys[1] +"," + AchivementMap.achivementKeys[2]);
            file.Close();
        }else{
            SaveAchive();
        }
    }

    public static void FlushAll(){
        lvl = 0;
        hardLvl = 0;
        money = 0;
        trickHelpCount = 0;
        endlessReboot = 0;
        tutorial = true;
        FlushAchive();
        Save();
    }
}



    /*static public void setNextColor(int color){
        colorNextInt = color;
        switch(color){
            case 0: colorNext = ball_blue; break;
            case 1: colorNext = ball_yellow; break;
            case 2: colorNext = ball_green; break;
            case 3: colorNext = ball_red; break;
        }
    }*/

    /*public void ShowDif(int valueS, int modeS){ //modeS = {1=UpTime, 2=UpStep, 3=DwTime, 4=DwStep}
        StartCoroutine(ShowDifIE(valueS, modeS));
    }

    IEnumerator ShowDifIE(int valueS, int modeS){
        switch (modeS){ //modeS = {1=UpTime, 2=UpStep, 3=DwTime, 4=DwStep}
            case 1: timerText.color = Color.green;
                    timerText.text = "+"+valueS;
                    yield return new WaitForSeconds(1.5f);
                    timerText.color = Color.white;
                    timerText.text = ""+timersecond;
                break;
            case 2: stepsText.color = Color.green;
                    stepsText.text = "+"+valueS;
                    yield return new WaitForSeconds(1.5f);
                    stepsText.color = Color.white;
                    if(steps < 1000) stepsText.text = ""+steps;
                    else stepsText.text = "999+";
                break;
            case 3: timerText.color = Color.red;
                    timerText.text = ""+timersecond;
                    yield return new WaitForSeconds(1.5f);
                    timerText.color = Color.white;
                break;
            case 4: stepsText.color = Color.red;
                    if(steps < 1000) stepsText.text = ""+steps;
                    else stepsText.text = "999+";
                    yield return new WaitForSeconds(1.5f);
                    stepsText.color = Color.white;
                break;
        }
    }*/

    /*IEnumerator EndlessIE(){
        bool tempBool = false;
        endlessScore temp = GameObject.Find("EndLessScore").GetComponent<endlessScore>();
        switch (endlessScore.scoreNum)
        {
            case 5: money+=25000; Save(); 
                    temp.MoneyAdd.GetComponent<Text>().text = "+25000";
                    temp.MoneyAddFunc();
                    tempBool = true;
                break;
            case 10: money+=50000; Save(); 
                    temp.MoneyAdd.GetComponent<Text>().text = "+50000";
                    temp.MoneyAddFunc();
                    tempBool = true;
                break;
            case 15: money+=100000; Save(); 
                    temp.MoneyAdd.GetComponent<Text>().text = "+100000";
                    temp.MoneyAddFunc();
                    tempBool = true;
                break;
            case 20: money+=200000; Save(); 
                    temp.MoneyAdd.GetComponent<Text>().text = "+200000";
                    temp.MoneyAddFunc();
                    tempBool = true;
                break;
            case 30: money+=500000; Save(); 
                    temp.MoneyAdd.GetComponent<Text>().text = "+500000";
                    temp.MoneyAddFunc();
                    tempBool = true;
                break;
            default: if (endlessScore.scoreNum > 30 && endlessScore.scoreNum%10==0){
                        money+=500000; Save(); 
                        temp.MoneyAdd.GetComponent<Text>().text = "+500000";
                        temp.MoneyAddFunc();
                        tempBool = true;
                    }
                break;
        }
        endlessObj.GetComponent<endlessScore>().OnEnable();
        endlessObj.GetComponent<Animator>().SetBool("flag", false);
        if(!tempBool){
            yield return new WaitForSeconds(1f);
        }else{
            yield return new WaitForSeconds(2f);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }*/