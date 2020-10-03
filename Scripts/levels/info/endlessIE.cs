using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endlessIE : MonoBehaviour
{
    static public GameObject EndlessObj;
    public GameObject WinMenu;
    public GameObject Game;

    public void StartEndlessIE(){
        if(endlessScore.scoreNum % 5 == 0 && !info.noAds){ //Показываем рекламу
            WinMenu.SetActive(true);
            Game.SetActive(false);
        }else{
            StartCoroutine(EndlessIE());
        }
    }

    public void StartEndlessIEAfterAds(){
        StartCoroutine(EndlessIE());
    }

    IEnumerator EndlessIE(){
        bool tempBool = false;
        endlessScore temp = GameObject.Find("EndLessScore").GetComponent<endlessScore>();
        switch (endlessScore.scoreNum)
        {
            /*case 0: info.money+=1000; info.Save(); 
                    temp.MoneyAdd.GetComponent<Text>().text = "+1000";
                    temp.MoneyAddFunc();
                    tempBool = true;
                break;*/
            case 3: info.money+=25000; info.Save(); 
                    temp.MoneyAdd.GetComponent<Text>().text = "+25000";
                    temp.MoneyAddFunc();
                    tempBool = true;
                break;
            case 6: info.money+=50000; info.Save(); 
                    temp.MoneyAdd.GetComponent<Text>().text = "+50000";
                    temp.MoneyAddFunc();
                    tempBool = true;
                break;
            case 9: info.money+=100000; info.Save(); 
                    temp.MoneyAdd.GetComponent<Text>().text = "+100000";
                    temp.MoneyAddFunc();
                    tempBool = true;
                break;
            case 12: info.money+=200000; info.Save(); 
                    temp.MoneyAdd.GetComponent<Text>().text = "+200000";
                    temp.MoneyAddFunc();
                    tempBool = true;
                break;
            case 15: info.money+=500000; info.Save(); 
                    temp.MoneyAdd.GetComponent<Text>().text = "+500000";
                    temp.MoneyAddFunc();
                    tempBool = true;
                break;
            default: if (endlessScore.scoreNum > 15 && endlessScore.scoreNum%5==0){
                        info.money+=500000; info.Save(); 
                        temp.MoneyAdd.GetComponent<Text>().text = "+500000";
                        temp.MoneyAddFunc();
                        tempBool = true;
                    }
                break;
        }
        EndlessObj.GetComponent<endlessScore>().OnEnable();
        EndlessObj.GetComponent<Animator>().SetBool("flag", false);
        if(!tempBool){
            yield return new WaitForSeconds(1f);
        }else{
            yield return new WaitForSeconds(2f);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
