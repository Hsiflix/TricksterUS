using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class AdsVideo : MonoBehaviour, IUnityAdsListener
{

    bool adsShowAlready = false;
    private string myPlacementId = "video";
    private bool winAdsOn = true;
    private bool startAnimAlready = false;

    public void Start()
    {
        if(winAdsOn){
            if(!Advertisement.isInitialized) {
                Advertisement.Initialize (BeginMonetization.AndroidGameId, BeginMonetization.testMode);
            }

            if(!info.noAds){
                if(Advertisement.isSupported){
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

    public void StartAnims(){
        if(!startAnimAlready){
            if(info.isEndless){
                GameObject.Find("LvlScene").GetComponent<endlessIE>().StartEndlessIEAfterAds();
                Debug.Log("Game.GetComponent<endlessIE>().StartEndlessIE();");
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
        if(placementId == myPlacementId){
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

    /*private string myPlacementId = "video";
    private bool testMode = true;
    void Start()
    {
        //if(!info.noAds){
            if(Advertisement.isSupported){
                if(!Advertisement.isInitialized) {
                    Advertisement.Initialize (BeginMonetization.AndroidGameId, testMode);
                }
                Debug.LogWarning("Advertisement.AddListener");
                Advertisement.AddListener (this);
            }else{
                Debug.Log("Данная платформа не поддерживается");
                AfterAds();
            }
        //}else{
        //    AfterAds();
        //}
    }

    public void ShowAds(){
        //if(!info.noAds){
            if(Advertisement.IsReady(myPlacementId)){
                Advertisement.Show(myPlacementId);
            }
        //}else{
        //    AfterAds();
        ///
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
        AfterAds();
    }

    public void OnUnityAdsReady (string placementId) {
        // If the ready Placement is rewarded, show the ad:
        if (placementId == myPlacementId) {
            Advertisement.Show (myPlacementId);
            Advertisement.RemoveListener(this);
            Debug.Log("Advertisement.Show (myPlacementId);");
        }
    }

    public void OnUnityAdsDidError (string message) {
        // Log the error.
        Debug.Log("OnUnityAdsDidError: " + message);
        AfterAds();
    }

    public void OnUnityAdsDidStart (string placementId) {
        // Optional actions to take when the end-users triggers an ad.
        Debug.Log("OnUnityAdsDidStart: " + placementId);
        AfterAds();
    }

    private void AfterAds(){
        if(info.isEndless){
            //GameObject.Find("Game").GetComponent<endlessIE>().StartEndlessIEAfterAds();
        }
    }*/
}
