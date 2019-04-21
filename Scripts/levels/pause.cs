using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public GameObject Game;

    public void Continue()
    {
        Time.timeScale = 1;
        Game.SetActive(true);
        GameObject.Find("Pause").SetActive(false);
    }

    public void OnTheMap()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Map", LoadSceneMode.Single);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
