using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class gameOver : MonoBehaviour, IUnityAdsListener
{

    public GameObject canvas;
    bool adsShowAlready = false;
    private bool winAdsOn = true;
    private string myPlacementId = "video";
    public void Quir()
    {
        if(info.AudioOn)   GameObject.Find("Button_click").GetComponent<AudioSource>().Play();
        if(info.isCoop){
            async.allowSceneActivation = true;
            //SceneManager.LoadScene("menu", LoadSceneMode.Single);
        }else{
            async.allowSceneActivation = true;
            //SceneManager.LoadScene("Map", LoadSceneMode.Single);
        }
        Time.timeScale = 1;
    }

    public void Retry()
    {
        if(info.AudioOn)   GameObject.Find("Button_click").GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void Start()
    {
        winAdsOn = false;
        winAdsOn = Random.Range(0,100)<30?true:false;

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
            } else{
                Advertisement.RemoveListener(this);
                StartAnims();
            }

        }else{
            Advertisement.RemoveListener(this);
            StartAnims();
        }

        StartCoroutine(StartLoad());
    }

    private void StartAnims(){
        try{
            canvas.SetActive(true);
        }catch{
            
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

    //StartCoroutine(StartLoad());
    //async.allowSceneActivation = true;
    private AsyncOperation async;

    IEnumerator StartLoad(){
        yield return new WaitForSeconds(1f);
        if(info.isCoop){
            async = SceneManager.LoadSceneAsync("menu");
        }else{
            async = SceneManager.LoadSceneAsync("Map");
        }
		async.allowSceneActivation = false;
    }
}
