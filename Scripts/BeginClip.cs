using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginClip : MonoBehaviour {
    string sceneName = "menu";

    public void Start()
    {
        Infos.Load();
        StartCoroutine(Animat());
    }


    IEnumerator Animat()
    {
        yield return new WaitForSeconds(12f);
        //Infos.Load();
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void Skip()
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}