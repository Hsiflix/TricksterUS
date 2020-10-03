using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class WinMenuMoney : MonoBehaviour, IUnityAdsListener {

    public GameObject Achive, MoneyMenu, leftBottomMenu, rightBottomMenu;
    public GameObject canvas;
    public GameObject key_shine; //for lvlB levels
    public GameObject TheEndB3;
    public GameObject music;
    public GameObject Map, Retry;
    private int lvlB3count = 0;
    bool adsShowAlready = false;
    private string myPlacementId = "video";
    private bool winAdsOn = false;
    static public int moneyAdd = 10000;
    static public int coopPlayRounds = 0;
    private bool startAnimAlready = false;

    public void Start()
    {
        info.money+=moneyAdd;
        rightBottomMenu.GetComponent<Text>().text = ""+ (info.money);
        leftBottomMenu.GetComponent<Text>().text = "+"+moneyAdd;
        string tmp = SceneManager.GetActiveScene().name;
        if(tmp.Substring(3,1)!= "B" && tmp.Substring(3,1)!= "E" && tmp.Substring(3,1)!= "H" && tmp.Substring(3,1)!= "C"){
            int tmpLvl = int.Parse(tmp.Substring(3));
            if(tmpLvl >= info.lvl){
                info.lvl=tmpLvl+1;
                switch (tmpLvl)
                {
                    case 4: MapCrossPushHide.firstMeet[0] = true;
                        break;
                    case 12: MapCrossPushHide.firstMeet[1] = true;
                        break;
                    case 18: MapCrossPushHide.firstMeet[2] = true;
                        break;
                }
            }
        }
        if(tmp == "lvlB3"){
            info.lvl = 19;
        }
        info.Save();

        winAdsOn = false;
        /*if(ButLoadLvl._namelvl == "lvlB1" || ButLoadLvl._namelvl == "lvlB2" || ButLoadLvl._namelvl == "lvlB3" ||
            ButLoadLvl._namelvl == "lvl4" || ButLoadLvl._namelvl == "lvl8" || ButLoadLvl._namelvl == "lvl14" ||
            ButLoadLvl._namelvl == "lvl16" || ButLoadLvl._namelvl == "lvl18" ||
            ButLoadLvl._namelvl == "lvlH1" || ButLoadLvl._namelvl == "lvlH3" || ButLoadLvl._namelvl == "lvlH5" ||
            ButLoadLvl._namelvl == "lvlH7" || ButLoadLvl._namelvl == "lvlH9" || ButLoadLvl._namelvl == "lvlH11" ||
            ButLoadLvl._namelvl == "lvlH13" || ButLoadLvl._namelvl == "lvlH15" || ButLoadLvl._namelvl == "lvlH17")*/


        if(!info.isCoop && !info.isEndless)
        {
            if(UnityEngine.Random.Range(0,100)<33) winAdsOn = true;
        }

        if(info.isCoop && coopPlayRounds >= 2){
            coopPlayRounds = 0;
            winAdsOn = true;
        }else if(info.isCoop){
            coopPlayRounds++;
        }

        if(info.isEndless){
            winAdsOn = true;
        }

        if(winAdsOn){
            if(!Advertisement.isInitialized) {
                Advertisement.Initialize (BeginMonetization.AndroidGameId, BeginMonetization.testMode);
            }

            if(!info.noAds){
                if(Advertisement.isSupported){
                    //Debug.LogWarning("Advertisement.AddListener");
                    Advertisement.AddListener(this);
                    StartCoroutine(myOnUnityAdsReady());
                }else{
                    Debug.Log("Данная платформа не поддерживается");
                    Advertisement.RemoveListener(this);
                    StartAnims();
                }
            }else{
                Advertisement.RemoveListener(this);
                StartAnims();
            }

        }else{
            Advertisement.RemoveListener(this);
            StartAnims();
        }
    }
    /*//Затемнение и финальный ролик добавляем сюда:
            if(SceneManager.GetActiveScene().name=="lvlB3"){
                TheEndB3.GetComponent<Animation>().Play();
            }
            // */

    public void StartAnims(){
        if(!startAnimAlready){
            startAnimAlready = true;
            Debug.LogWarning("StartAnims()");
            if(info.isEndless){
                GameObject.Find("LvlScene").GetComponent<endlessIE>().StartEndlessIEAfterAds();
                Debug.Log("Game.GetComponent<endlessIE>().StartEndlessIE();");
            }else{
                Debug.Log("Advertisement.RemoveListener(this);");
                Advertisement.RemoveListener(this);
                canvas.SetActive(true);
                music.SetActive(true);
                MoneyMenu.GetComponent<Animator>().enabled = true;
                string tmp = SceneManager.GetActiveScene().name;
                bool isNewBlvl = false;
                Debug.LogWarning(tmp.Substring(3,1));
                if(tmp.Substring(3,1) == "B"){
                    Debug.Log(AchivementMap.achivementKeys[0]+","+ AchivementMap.achivementKeys[1] +"," + AchivementMap.achivementKeys[2]);
                    if(!AchivementMap.achivementKeys[int.Parse(tmp.Substring(4))-1]){
                        AchivementMap.achivementKeys[int.Parse(tmp.Substring(4))-1] = true;
                        isNewBlvl = true;
                        key_shine.SetActive(true);
                        info.SaveAchive();
                    }else{
                        Map.SetActive(true);
                        Retry.SetActive(true);
                    }
                }
                if(!isNewBlvl){
                    StartCoroutine(StartAchive(1.5f));
                }else{
                    StartCoroutine(StartAchive(1f));
                    StartCoroutine(StartNewBLvl(2.5f));
                }
            }
        }
    }

    public void NewBlvlAchive(){
        StartCoroutine(StartAchive(1.5f));
    }

    IEnumerator StartNewBLvl(float time){
        yield return new WaitForSeconds(time);
        GameObject.Find("LvlBDialogPrefab").GetComponent<DialogView>().StartDialogView();
    }

    IEnumerator StartAchive(float time){
        Debug.LogWarning("StartAchive");
        yield return new WaitForSeconds(time);
        if(!info.isCoop) Achive.GetComponent<winMenuAchive>().StartPlay();
    }

    public void TheEnd(){
        Debug.LogWarning("TheEnd()");
        if(SceneManager.GetActiveScene().name=="lvlB3"){
            lvlB3count++;
            Debug.LogWarning(lvlB3count);
            if(lvlB3count >= 3){
                TheEndB3.SetActive(true);
                lvlB3count = 0;
            }
        }
    }

    public void ShowAds(){
        Debug.Log("ShowAds()");
        if(!adsShowAlready && !info.noAds && winAdsOn){
            if(Advertisement.IsReady(myPlacementId)){
                Advertisement.Show(myPlacementId);
                adsShowAlready = true;
            }
        }
    }

    public void OnUnityAdsDidFinish (string placementId, ShowResult showResult) {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished) {
            // Reward the user for watching the ad to completion.
            Debug.Log("Reward the user for watching the ad to completion.");
        } else if (showResult == ShowResult.Skipped) {
            // Do not reward the user for skipping the ad.
            Debug.Log("Do not reward the user for skipping the ad.");
        } else if (showResult == ShowResult.Failed) {
            Debug.LogWarning ("The ad did not finish due to an error.");
        }
        Advertisement.RemoveListener(this);
        StartAnims();
    }

    public void OnUnityAdsReady (string placementId) {
        // If the ready Placement is rewarded, show the ad:
        Debug.Log("If the ready Placement is rewarded, show the ad: "+placementId);
        ShowAds();
    }

    public void OnUnityAdsDidError (string message) {
        // Log the error.
        Debug.Log("OnUnityAdsDidError: " + message);
        Advertisement.RemoveListener(this);
        StartAnims();
    }

    public void OnUnityAdsDidStart (string placementId) {
        // Optional actions to take when the end-users triggers an ad.
        Debug.Log("OnUnityAdsDidStart: " + placementId);
    }


    private IEnumerator myOnUnityAdsReady(bool notReady = true){
        yield return new WaitForSeconds(0.25f);
        if(Advertisement.IsReady(myPlacementId)){
            OnUnityAdsReady(myPlacementId);
        }else{
            if(notReady){
                StartCoroutine(myOnUnityAdsReady());
                StartCoroutine(OnUnityAdsNotReady());
            }else{
                StartCoroutine(myOnUnityAdsReady(false));
            }
        }
    }

    private IEnumerator OnUnityAdsNotReady(){ //Если реклама не загрузилась за 5 секунд, то пропускаем
        yield return new WaitForSeconds(5f);
        Debug.Log("OnUnityAdsNotReady()");
        if(!Advertisement.IsReady(myPlacementId)) {
            Advertisement.RemoveListener(this);
            StartAnims();
        }
    }
} 