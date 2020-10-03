using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrickIslandHouse : MonoBehaviour
{
    public GameObject cat_bg, cat_2_bg;
    public GameObject trickHouse, trickIsland;
    public GameObject DialogGO;
    private int count = 0;

    public void ToTricksterHouse()
    {
        trickHouse.SetActive(true);
        trickIsland.SetActive(false);
    }
    public void ToMap()
    {
        StartCoroutine(ToMapIE());
        SceneManager.LoadScene("Map", LoadSceneMode.Single);
    }

    IEnumerator ToMapIE(){
        if(info.AudioOn) GameObject.Find("audio_departure").GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Map", LoadSceneMode.Single);
    }

    public void catButton(){
        if(info.AudioOn) GameObject.Find("audio_cat").GetComponent<AudioSource>().Play();  
        cat_bg.SetActive(false);  
        cat_2_bg.SetActive(true);
        StartCoroutine(closeTrickHouse());
    }

    public void DoorOnHouse(){
        if(info.AudioOn) GameObject.Find("audio_knockknock").GetComponent<AudioSource>().Play();
        count++;
        if(count>=3){
            count = 0;
            DialogGO.GetComponent<PhrasesTrickHome>().View();
        }
    }

    IEnumerator closeTrickHouse(){
        yield return new WaitForSeconds(0.7f);
        trickIsland.SetActive(true);
        cat_bg.SetActive(true);  
        cat_2_bg.SetActive(false);
        trickHouse.SetActive(false);
    }
}
