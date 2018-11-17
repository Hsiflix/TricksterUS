using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public void Quir()
    {
        SceneManager.LoadScene("Map 1", LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public void Retry()
    {
        Scene scene = SceneManager.GetActiveScene();
        Time.timeScale = 1;
        SceneManager.LoadScene(scene.name);
    }
}