using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public GameObject RU, EN;
    private int clickToSkip = 0;
    private AsyncOperation async;
    private bool stop = true;

    private void Awake() {
        if(info.lang == 1){ //RUS
            RU.SetActive(true);
            EN.SetActive(false);
        }else{ //ENG
            EN.SetActive(true);
            RU.SetActive(false);
        }
        StartCoroutine(StartLoad());
        clickToSkip = 0;
        transform.localPosition = new Vector3(0f, -920f, 0f);
    }

    private void FixedUpdate() {
        if(stop){
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y+1.7f,transform.localPosition.z);//1.7f
        //Debug.Log(transform.localPosition.y);
        if(transform.localPosition.y>5000f){
            async.allowSceneActivation = true;
            stop = false;
            //SceneManager.LoadScene("menu", LoadSceneMode.Single);
        }
        }
    }

    public void Skip(){
        if(clickToSkip >3){
            async.allowSceneActivation = true;
            //SceneManager.LoadScene("menu", LoadSceneMode.Single);
        }else{
            clickToSkip++;
        }
    }

    IEnumerator StartLoad(){
        yield return new WaitForSeconds(1f);
        async = SceneManager.LoadSceneAsync("menu");
		async.allowSceneActivation = false;
    }
}
