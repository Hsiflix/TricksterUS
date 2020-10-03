using System;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsRewardedVideo : MonoBehaviour, IUnityAdsListener
{
    //private string gameId = "3438527";
    private string myPlacementId = "rewardedVideo";
    //public GameObject moneyUpd;

    void Start()
    {
        //if(!info.noAds){
            if(Advertisement.isSupported){
                if(!Advertisement.isInitialized) {
                    Advertisement.Initialize (BeginMonetization.AndroidGameId, BeginMonetization.testMode);
                    Debug.LogWarning("Advertisement.AddListener");
                    Advertisement.AddListener (this);
                }
            }else{
                Debug.Log("Данная платформа не поддерживается");
            }
        //}
    }

    public void ShowAds(){
        //if(!info.noAds){
            if(Advertisement.IsReady(myPlacementId)){
                Advertisement.AddListener(this);
                Advertisement.Show(myPlacementId);
                Debug.Log("ShowAds");
            }
        //}
    }

    public void OnUnityAdsDidFinish (string placementId, ShowResult showResult) {
        if(placementId == myPlacementId){
            // Define conditional logic for each ad completion status:
            if (showResult == ShowResult.Finished ) {
                // Reward the user for watching the ad to completion.
                Debug.Log("Reward the user for watching the ad to completion.");
                if(info.isPause){
                    info.money += 5000; //12500;
                    Debug.Log("info.isPause money add: "+5000);
                    //info.Save();
                    //moneyUpd.GetComponent<pauseBuyMenu>().UpdateCount();
                    //Debug.Log(gameObject.name);
                    try{GameObject.Find("money_menu").GetComponent<pauseBuyMenu>().UpdateCount();}
                    catch{
                        try{GameObject.Find("trickHelp_menu").GetComponent<pauseBuyMenu>().UpdateCount();}
                        catch{info.Save();}
                    }
                }else{
                    info.money += 5000+1000*endlessScore.scoreNum;
                    Debug.Log("money add: "+(5000+1000*endlessScore.scoreNum));
                    Debug.LogWarning(endlessScore.scoreNum);
                    info.Save();
                    try{
                        GameObject.Find("EndLessScore").GetComponent<endlessScore>().OnEnable();
                    }catch(Exception e){
                        Debug.LogWarning(e);
                    }
                }
            } else if (showResult == ShowResult.Skipped) {
                // Do not reward the user for skipping the ad.
                Debug.Log("Do not reward the user for skipping the ad.");
            } else if (showResult == ShowResult.Failed) {
                Debug.LogWarning ("The ad did not finish due to an error.");
            }
        }
        Advertisement.RemoveListener(this);
    }

    public void OnUnityAdsReady (string placementId) {
        // If the ready Placement is rewarded, show the ad:
        /*if (placementId == myPlacementId) {
            Advertisement.Show (myPlacementId);
            Debug.Log("Advertisement.Show (myPlacementId);");
        }*/
    }

    public void OnUnityAdsDidError (string message) {
        // Log the error.
        Debug.Log("OnUnityAdsDidError: " + message);
        Advertisement.RemoveListener(this);
    }

    public void OnUnityAdsDidStart (string placementId) {
        // Optional actions to take when the end-users triggers an ad.
        Debug.Log("OnUnityAdsDidStart: " + placementId);
    } 
}
