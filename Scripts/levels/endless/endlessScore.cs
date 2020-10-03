using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class endlessScore : MonoBehaviour
{
    public GameObject endlessObj, gameObj, scoreCamera, skipObj;
    public Camera gameCamera;
    public Sprite vingette1, vingette2, vingette3, vingette4, vingette5;
    public GameObject Reboot_count, Reboot_cloud_text, Reboot_cloud_money_text, Reboot_but, Reboot_buy;
    public Sprite cloud1, cloud2, cloud3;
    static public int scoreNum = 0;
    //static public int trickHelpNum = 0;
    static public bool isNew = true;
    static public bool endlessEnd = false;
    static public bool noColorOnEndless = false;
    private int rebootValue = 5000; //Стоимость ребута
    public GameObject MoneyAdd;
    public GameObject DialogGO;

    public void OnEnable() {
        //SCORE
        Text scoreText = GameObject.Find("Score").GetComponent<Text>();
        if(scoreNum < 10) 
            switch (scoreNum) //341A4B 52f/255f,26f/255f,75f/255f
            {
                case 0: scoreText.color = new Color(52f/255f,46f/255f,75f/255f);break;
                case 1: scoreText.color = new Color(72f/255f,66f/255f,75f/255f);break;
                case 2: scoreText.color = new Color(92f/255f,86f/255f,75f/255f);break;
                case 3: scoreText.color = new Color(112f/255f,106f/255f,75f/255f);break;
                case 4: scoreText.color = new Color(132f/255f,126f/255f,75f/255f);break;
                case 5: scoreText.color = new Color(152f/255f,146f/255f,75f/255f);break;
                case 6: scoreText.color = new Color(172f/255f,166f/255f,75f/255f);break;
                case 7: scoreText.color = new Color(192f/255f,186f/255f,75f/255f);break;
                case 8: scoreText.color = new Color(212f/255f,206f/255f,75f/255f);break;
                case 9: scoreText.color = new Color(232f/255f,226f/255f,75f/255f);break;
                default: scoreText.color = new Color(52f/255f,46f/255f,75f/255f);break;
            }
        else if (scoreNum <= 15) scoreText.color = new Color(65f/255f,0f/255f,255f/255f); 
        else if(scoreNum <= 20) scoreText.color = new Color(0f/255f,112f/255f,255f/255f);
        else if(scoreNum <= 30) scoreText.color = new Color(0/255f,255f/255f,255f/255f);
        else scoreText.color = new Color(228f/255f,0f/255f,255f/255f);
        scoreText.text = scoreNum.ToString();
        //REBOOT
        rebootValue = 5000 + 5000 * info.endlessReboot/10;
        Reboot_cloud_text.GetComponent<Text>().text = rebootValue.ToString();
        Reboot_count.GetComponent<Text>().text = info.endlessReboot.ToString();
        Reboot_cloud_money_text.GetComponent<Text>().text = info.money.ToString();
        //OTHER
        noColorOnEndless = false;
    }
    private void Start() {
        endlessIE.EndlessObj = this.endlessObj;
    }
    public void Skip(){
        if(info.AudioOn) GameObject.Find("Audio_endless_window").GetComponent<AudioSource>().Play();
        gameObject.GetComponent<Animator>().SetBool("flag", true);
        endlessEnd = true;
        gameObj.SetActive(true);
        Color tmp = Reboot_but.GetComponent<Image>().color;
        if(info.endlessReboot == 0) tmp.a = 0.4f;
        else tmp.a = 1f;
        Reboot_but.GetComponent<Image>().color = tmp;
        switch (info.field_size)
        {
            case 3: GameObject.Find("VIGNETTE").GetComponent<Image>().sprite = vingette1; break;
            case 4: GameObject.Find("VIGNETTE").GetComponent<Image>().sprite = vingette1; break;
            case 5: GameObject.Find("VIGNETTE").GetComponent<Image>().sprite = vingette1; break;
            case 6: GameObject.Find("VIGNETTE").GetComponent<Image>().sprite = vingette2; break;
            case 7: GameObject.Find("VIGNETTE").GetComponent<Image>().sprite = vingette3; break;
            case 8: GameObject.Find("VIGNETTE").GetComponent<Image>().sprite = vingette4; break;
            case 9: GameObject.Find("VIGNETTE").GetComponent<Image>().sprite = vingette5; break;
            case 10: GameObject.Find("VIGNETTE").GetComponent<Image>().sprite = vingette5; break;
            default: GameObject.Find("VIGNETTE").GetComponent<Image>().sprite = vingette5; break;
        }
        DialogGO.GetComponent<DialogView>().SetFalseAll();
        scoreCamera.SetActive(false);
        skipObj.SetActive(false);
        GameObject.Find("Game").GetComponent<spawn>().StartSpawn();
    }

    public void RebootButton(){
        if(info.endlessReboot > 0 || noColorOnEndless || lvlEndlessConfig.StatOn){
            if(!noColorOnEndless && !lvlEndlessConfig.StatOn) info.endlessReboot--;
            OnEnable();
            lvlEndlessConfig.isReboot = true;
            gameObject.GetComponent<Animator>().SetBool("flag", false);
            StartCoroutine(RebootEndlessIE());
        }
    }

    IEnumerator RebootEndlessIE(){
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CameraColorChange(){
        //CAMERA COLOR
        gameCamera.backgroundColor = new Color(Random.Range(0.3f, 0.7f),Random.Range(0.3f, 0.7f),Random.Range(0.3f, 0.7f));
        info.camColor = gameCamera.backgroundColor;
        Debug.Log("CameraColorChange");
    }

    public void BuyReboot(){
        if(info.money >= rebootValue){
            if(info.AudioOn) GameObject.Find("audio_buyReboot").GetComponent<AudioSource>().Play();
            info.money-=rebootValue;
            info.endlessReboot++;
            rebootValue = 5000 + 5000 * info.endlessReboot/10;
            Reboot_cloud_text.GetComponent<Text>().text = rebootValue.ToString();
            Reboot_count.GetComponent<Text>().text = info.endlessReboot.ToString();
            Reboot_cloud_money_text.GetComponent<Text>().text = info.money.ToString();
            int rand = Random.Range(0,3);
            if(rand == 0) Reboot_buy.GetComponent<Image>().sprite = cloud1;
            else if(rand == 1) Reboot_buy.GetComponent<Image>().sprite = cloud2;
            else Reboot_buy.GetComponent<Image>().sprite = cloud3;
            info.Save();
        }
    }

    public void noColorEndless(){
        noColorOnEndless = true;
        Color tmp = Reboot_but.GetComponent<Image>().color;
        tmp.a = 1f;
        Reboot_but.GetComponent<Image>().color = tmp;
    }

    public void MoneyAddFunc(){
        MoneyAdd.SetActive(true);
        MoneyAdd.GetComponent<Animation>().Play();
        if(info.AudioOn) GameObject.Find("audio_addMoney").GetComponent<AudioSource>().Play();
    }
}
