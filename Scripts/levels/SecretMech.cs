using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SecretMech : MonoBehaviour
{
    private float timer;
    private int count = 0;
    private bool active = true;
    private Image CoolDownImage;
    static public int hardLvlTrickHelpCount = 0;

    private void Start() {
        CoolDownImage = GameObject.Find("TrickCoolDown").GetComponent<Image>();
    }

    private void Update() {
        if(!active && CoolDownImage.fillAmount == 0){
            active = true;
            //Debug.Log("active = true;");
        }
    }
    public void Click(){
        if(active && GameObject.Find("Game").GetComponent<trickHelp>().isCoolDown){
            count++;
            StartCoroutine(WaitClickIE(1f));
        }
    }

    IEnumerator WaitClickIE(float time){
        timer+=time;
        yield return new WaitForSeconds(time);
        timer-=time;
        if(timer == 0f){
            if(SceneManager.GetActiveScene().name.Substring(3,1)!="H" && SceneManager.GetActiveScene().name.Substring(3,1)!="E" && count > 1) count = 0;
            if(SceneManager.GetActiveScene().name.Substring(3,1)=="E" && count > 3) count = 0;
            if(SceneManager.GetActiveScene().name.Substring(3,1)=="C") count = 0;
            if(SceneManager.GetActiveScene().name.Substring(3,1)=="B") count = 0;
            Debug.Log("YES: " + count + "; " + SceneManager.GetActiveScene().name.Substring(3,1));
            switch (count)
            {
                case 1: GameObject.Find("Game").GetComponent<trickHelp>().SecretMechCnenario = 6;//В след. вызов выелтает флеш
                        GameObject.Find("Game").GetComponent<trickHelp>().isSecretMech = true;
                    break;
                case 2: GameObject.Find("Game").GetComponent<trickHelp>().SecretMechCnenario = 7;//Три облака в след. вызов помощи, 2 плохих, одно с макс цепочкой
                        GameObject.Find("Game").GetComponent<trickHelp>().isSecretMech = true;
                    break;
                case 3: GameObject.Find("Game").GetComponent<colorBall>().SecretMech3 = true;//В след. вызове, если попадется калр бомб то он будет взрываться нашим цветом
                    break;
                case 5: StartCoroutine(TimerSlowDownIE(20f, 4));//Замедляем таймер в 2 раза на 10 секунд
                    break;
            }
            count = 0;
            active = false;
        }
    }

    IEnumerator TimerSlowDownIE(float time, int coef){
        GameObject.Find("Game").GetComponent<info>().timerSlowdown = coef;
        yield return new WaitForSeconds(time);
        GameObject.Find("Game").GetComponent<info>().timerSlowdown = 1;
    }
}
