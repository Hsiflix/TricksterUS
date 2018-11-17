using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    public GameObject pause;
    public GameObject game;

    public void Continue()
    {
        //2.07.18
        for (int i = 1; i < Spawn.MySize * Spawn.MySize + 1; i++)
        {
            GameObject ball = GameObject.Find(i.ToString());
            Ball bollin = ball.GetComponent<Ball>();
            bollin.notpause = true;
        }
        ///2.07.18
        Time.timeScale = 1;
        pause.SetActive(false);
        game.SetActive(true);
    }

    public void OnTheMap()
    {
        SceneManager.LoadScene("Map 1", LoadSceneMode.Single);
        Time.timeScale = 1;
        //pause.SetActive(false);
        //game.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    
    public void isPause ()
    {
        if(Spawn.tmp == Spawn.MySize * Spawn.MySize + 1)
        {
            Time.timeScale = 0;
            //2.07.18
            for (int i = 1; i < Spawn.MySize * Spawn.MySize + 1; i++)
            {
                GameObject ball = GameObject.Find(i.ToString());
                Ball bollin = ball.GetComponent<Ball>();
                if (bollin.StepRot == 0) bollin.notpause = false;
            }
            ///2.07.18
            pause.SetActive(true);
            game.SetActive(false);
        }
    }
}
