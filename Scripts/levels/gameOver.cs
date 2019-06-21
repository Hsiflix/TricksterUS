using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    public void Quir()
    {
        if(info.AudioOn)   GameObject.Find("Button_click").GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Map", LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public void Retry()
    {
        if(info.AudioOn)   GameObject.Find("Button_click").GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
