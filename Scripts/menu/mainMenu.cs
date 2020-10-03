using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {

    //public GaussianBlur GausBlur;
    public GameObject continue1, continue2;
	public GameObject doski;
	public GameObject lamps;
    public GameObject NewGameA;
    public GameObject ContinueA;
    public GameObject EndLessA;
    public GameObject OptionsA;
    public GameObject ExitA;
    public GameObject mem;
    public GameObject Buttons;
    public GameObject Warning;
    public GameObject EndlessWarning;
    public GameObject Lock;
    public GameObject CanvasEndlessCoop;
    public GameObject CanvasOptions;
    public GameObject CanvasRidAds;
    public GameObject CanvasFiveStars;
    public GameObject Bugs;
    public GameObject Scene;
    public GameObject Intro;
    public GameObject Skip;
    public GameObject Blur;
    public GameObject CanvasCoop;
    private short incr = 0;
    private AsyncOperation async;

    public string nameScene;

    private void Start() {
        info.Load();
        if(info.lvl == 0 && info.money == 0){
            continue1.GetComponent<SpriteRenderer>().color = new Color(0.6f, 0.6f, 0.6f, 1f);
            continue2.GetComponent<SpriteRenderer>().color = new Color(0.6f, 0.6f, 0.6f, 1f);
        }else{
            continue1.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            continue2.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
        StartCoroutine(StartLoad());
    }

    public void AudioChange(){
        if(info.AudioOn) info.AudioOn = false;
        else info.AudioOn = true;
    }

    public void NewGame()
    {
        if(info.AudioOn)   GameObject.Find("Woodcrack_1").GetComponent<AudioSource>().Play();
        Buttons.SetActive(false);
        if (info.lvl != 0)
        {
            Warning.SetActive(true);
            Blur.SetActive(true);
            //GausBlur.enabled = true;
        }
        else NewGameYes();
    }

    public void Skiple()
    {
        incr++;
        if (incr == 2){
            SceneManager.LoadScene(nameScene);
            incr = 0;
        }
    }

    public void NewGameNo()
    {
        info.tutorial = false;
        Buttons.SetActive(true);
        Warning.SetActive(false);
        Blur.SetActive(false);
        //GausBlur.enabled = false;
    }
    public void NewGameYes()
    {
        Warning.SetActive(false);
        Blur.SetActive(false);
        //GausBlur.enabled = false;
        info.FlushAll();
        NewGameA.SetActive(true);
        mem = NewGameA;
        nameScene = "Map";
        lamps.gameObject.SetActive(true);
        doski.gameObject.SetActive(false);
        StartCoroutine(Animat(true));
    }
    public void Continue()
    {
        if(info.lvl != 0 || info.money != 0) {
        //info.Load();
            if(info.AudioOn)   GameObject.Find("Woodcrack_1").GetComponent<AudioSource>().Play();
            Buttons.SetActive(false);
            ContinueA.SetActive(true);
            mem = ContinueA;
            nameScene = "Map";
            info.tutorial = false;
            lamps.gameObject.SetActive (true);
            doski.gameObject.SetActive (false);
            StartCoroutine(Animat());
        }
    }
    public void EndLess()
    {
        if(info.AudioOn)   GameObject.Find("Woodcrack_1").GetComponent<AudioSource>().Play();
        Buttons.SetActive(false);
        Blur.SetActive(true);
        //GausBlur.enabled = true;
        CanvasEndlessCoop.SetActive(true);
        if(info.EndlessOpen){
            Lock.SetActive(false);
        }else{
            Lock.SetActive(true);
        }
    }

    public void EndLessYes(bool buyAccess = false)
    {
        Debug.Log("EndLessYes");
        if(info.EndlessOpen || buyAccess){
            CanvasEndlessCoop.SetActive(false);
            EndlessWarning.SetActive(false);
            EndLessA.SetActive(true);
            mem = EndLessA;
            Blur.SetActive(false);
            //GausBlur.enabled = false;
            info.isCoop = false;
            nameScene = "lvlEndless";
            lamps.gameObject.SetActive(true);
            doski.gameObject.SetActive(false);
            Debug.Log("endlessScore.isNew = true;");
            endlessScore.isNew = true;
            StartCoroutine(Animat());
        }else{
            Debug.Log("EndLessYes false");
            EndlessWarning.SetActive(true);
            CanvasEndlessCoop.SetActive(false);
        }
    }

    public void EndlessWarningYes(){
        if(info.money < 5000) EndlessWarningNo();
        else{
            if(info.AudioOn)   GameObject.Find("Audio_lock_open").GetComponent<AudioSource>().Play();
            info.money-=5000;
            info.Save();
            EndLessYes(true);
        }
    }

    public void EndlessWarningNo(){
        EndlessWarning.SetActive(false);
        CanvasEndlessCoop.SetActive(true);
    }

    public void CoopYes()
    {
        CanvasEndlessCoop.SetActive(false);
        mem = EndLessA;
        CanvasCoop.SetActive(true);
    }

    public void CoopRun(){
        CanvasCoop.SetActive(false);
        EndLessA.SetActive(true);
        mem = EndLessA;
        Blur.SetActive(false);
        //GausBlur.enabled = false;
        info.isCoop = true;
        info.isEndless = false;
        nameScene = "lvlCoop";
        lamps.gameObject.SetActive(true);
        doski.gameObject.SetActive(false);
        StartCoroutine(Animat());
    }

    public void EndlessExit()
    {
        CanvasEndlessCoop.SetActive(false);
        CanvasCoop.SetActive(false);
        Blur.SetActive(false);
        //GausBlur.enabled = false;
        Buttons.SetActive(true);
    }

    public void OptionsExit()
    {
        CanvasOptions.SetActive(false);
        Blur.SetActive(false);
        //GausBlur.enabled = false;
        Buttons.SetActive(true);
    }

    public void Options()
    {
        if(info.AudioOn)   GameObject.Find("Woodcrack_1").GetComponent<AudioSource>().Play();
        Buttons.SetActive(false);
        Blur.SetActive(true);
        //GausBlur.enabled = true;
        CanvasOptions.SetActive(true);
    }

    public void OptionsRidAds(){
        CanvasRidAds.SetActive(true);
        CanvasOptions.SetActive(false);
    }

    public void OptionsFiveStars(){
        CanvasFiveStars.SetActive(true);
        CanvasOptions.SetActive(false);
    }

    public void RidAdsDoIt(){
        info.noAds = true;
        info.Save();
        StartCoroutine(RidAdsLaterIE(0.5f));
    }

    public void RidAdsLater(){
        StartCoroutine(RidAdsLaterIE());
    }

    IEnumerator RidAdsLaterIE(float time = 0f)
    {
        yield return new WaitForSeconds(time);
        CanvasOptions.SetActive(true);
        CanvasRidAds.SetActive(false);
    }
    public void FiveStarsRate(){
        Application.OpenURL(getGooglePlayStoreUrl());
    }

    private String getGooglePlayStoreUrl(){
        /*Activity activity = UnityPlayer.currentActivity;
        String id = activity.getApplicationInfo().packageName; // current google play is   using package name as id
        PackageManager packageManager = activity.getApplicationContext().getPackageManager();
        Uri marketUri = Uri.parse("market://details?id=" + id);
        Intent marketIntent = new Intent(Intent.ACTION_VIEW).setData(marketUri);
        if (marketIntent.resolveActivity(packageManager) != null)
            return "market://details?id=" + id;
        else
            return "https://play.google.com/store/apps/details?id=" + id;*/
        return "market://details?id=" +"unstablesky.tricksterssecret.billing";
    }

    public void FiveStarsLater(){
        CanvasOptions.SetActive(true);
        CanvasFiveStars.SetActive(false);
    }

    public void Exit()
    {
        if(info.AudioOn)   GameObject.Find("Woodcrack_1").GetComponent<AudioSource>().Play();
        Buttons.SetActive(false);
        Application.Quit();
    }
    public void ToTricksterHouse()
    {
        SceneManager.LoadScene("TricksterHouse");
    }

    public void ToMap()
    {
        Debug.Log("ToMap");
        async.allowSceneActivation = true;
        //SceneManager.LoadScene("Map", LoadSceneMode.Single);
    }

    public void PurchError(UnityEngine.Purchasing.Product Product, UnityEngine.Purchasing.PurchaseFailureReason PurchasingUnavailable){
        Debug.LogWarning(PurchasingUnavailable.ToString());
        if(PurchasingUnavailable.ToString().Equals("DuplicateTransaction")){
            RidAdsDoIt();
        }
    }

    IEnumerator Animat(bool NwGm = false)
    {
        yield return new WaitForSeconds(0.9f);
        mem.SetActive(false);
        if(NwGm)
            IntroIE();
        else
            SceneManager.LoadScene(nameScene);
    }

    private void IntroIE()
    {
        if(info.AudioOn) GameObject.Find("Audio_Night").GetComponent<AudioSource>().Stop();
        if(info.AudioOn) GameObject.Find("audio_bg").GetComponent<AudioSource>().Stop();
        //Intro.GetComponent<videoEndEffect>().nameScene = "Map";
        //Intro.GetComponent<videoEndEffect>().asyncB = false;
        Intro.SetActive(true);
        Skip.SetActive(true);
        Scene.SetActive(false);
        Bugs.SetActive(false);
        Buttons.SetActive(false);
        doski.SetActive(false);
        //yield return new WaitForSeconds(49f);
        //SceneManager.LoadScene(nameScene);
    }

    IEnumerator StartLoad(){
        yield return new WaitForSeconds(1f);
        async = SceneManager.LoadSceneAsync("Map");
		async.allowSceneActivation = false;
    }
}
