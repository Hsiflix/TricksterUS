using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class theEnd : MonoBehaviour
{

    public GameObject Canvas1, Canvas2;

    public void Ch_Yes(){
        if(info.AudioOn) GameObject.Find("audio_departure").GetComponent<AudioSource>().Play();
        TheEnd.money = info.money;
        info.FlushAll();
        info.Save();
        Canvas1.SetActive(false);
        SceneManager.LoadScene("TheEnd", LoadSceneMode.Single);
        //Canvas2.SetActive(true);
    }

    public void Ch_No(){
        Debug.Log("Ch_No");
        GameObject.Find("TheEnd").SetActive(false);
    }

    public void End(){
        GameObject.Find("BlackBG").GetComponent<Animation>().Play();
        StartCoroutine(TheEndIE());
    }

    IEnumerator TheEndIE(){
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("menu");
    }
}
