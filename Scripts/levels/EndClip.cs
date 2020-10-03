using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndClip : MonoBehaviour
{
    public GameObject FMClip, FAClip;
    private int skiple = 0;
    void Start()
    {
        Debug.Log("Player have " + info.money + " money!");
        if(info.money > 90000){
            FMClip.SetActive(true);
        }else{
            FAClip.SetActive(true);
        }
        skiple = 0;
        //StartCoroutine(StartAchive(100));
        /*
        info.lvl = 0;
        info.money = 0;
        info.trickHelpCount = 0;
        info.endlessReboot = 0;
        info.tutorial = true;
        info.FlushAchive();
        info.Save();
        */
    }
    public void Skip(){
        if(skiple >=2){
            SceneManager.LoadScene("Credits", LoadSceneMode.Single);
        }else{
            skiple++;
        }
    }

    IEnumerator StartAchive(float time){ //100
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }
}