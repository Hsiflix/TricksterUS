using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginClip : MonoBehaviour {
    string sceneName = "menu";

    public void Start()
    {
        info.Load();
        info.LoadAchive();
        if(info.intro) StartCoroutine(Animat()); 
        else Skip();
    }


    IEnumerator Animat()
    {
        yield return new WaitForSeconds(12f);
        //SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void Skip()
    {
        SceneManager.LoadScene(sceneName);
    }
}