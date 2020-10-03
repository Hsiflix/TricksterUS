using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class trickHelp : MonoBehaviour
{
    private Image CoolDownImage;
    private float CoolDownPart = 10;
    public bool isCoolDown = false;
    private bool Active = true;
    public GameObject cloudPrefab;
    public GameObject TrickHelpCount;
    public int quantity = 1;
    public int trickCount = 0;
    public int cloudsCount = 0;
    private GameObject[] clouds;
    private int flashCount;
    public int flashExist, tmpFlashCount;
    public bool isSecretMech = false;
    public int SecretMechCnenario = 0;

    void Start()
    {
        SecretMechCnenario = 0;
        isSecretMech = false;
        CoolDownImage = GameObject.Find("TrickCoolDown").GetComponent<Image>();
    }

    private void FixedUpdate() {
        if (isCoolDown)
        {
            CoolDownImage.fillAmount -= 1 / CoolDownPart * Time.deltaTime;
            if (CoolDownImage.fillAmount <= 0)
            {
                TrickHelpCount.SetActive(false);
                isCoolDown = false;
                CoolDownImage.fillAmount = 0;
                Active = true;
            }
        }
        if(trickCount > 0 && cloudsCount == trickCount){
            Debug.LogWarning("Убираем все облака, т.к. остались только плохие. trickCount = "+trickCount + ", cloudsCount = " + cloudsCount);
            DestroyAll();
            trickCount = 0;
        }
    }

    public void UpdateTrickCount(){
        if(/*!info.isEndless &&*/ !info.isCoop && SceneManager.GetActiveScene().name.Substring(3,1)!="H"){
            info.trickHelpCount--;
            info.Save();
            Text trickHelpText = GameObject.Find("TrickHelpCount").GetComponent<Text>();
            if(info.trickHelpCount < 10){
                trickHelpText.text = info.trickHelpCount.ToString();
            }else{
                trickHelpText.text = "9+";
            }
        }else
            if(info.isCoop){
                Coop.trickHelpNum--;
                Text trickHelpText = GameObject.Find("TrickHelpCount").GetComponent<Text>();
                if(Coop.trickHelpNum < 10){
                    trickHelpText.text = Coop.trickHelpNum.ToString();
                }else{
                    trickHelpText.text = "9+";
                }
            }
            /*if(info.isEndless){
                endlessScore.trickHelpNum--;
                Text trickHelpText = GameObject.Find("TrickHelpCount").GetComponent<Text>();
                if(endlessScore.trickHelpNum < 10){
                    trickHelpText.text = endlessScore.trickHelpNum.ToString();
                }else{
                    trickHelpText.text = "9+";
                }
            }*/
            if(SceneManager.GetActiveScene().name.Substring(3,1)=="H"){
                SecretMech.hardLvlTrickHelpCount--;
                Text trickHelpText = GameObject.Find("TrickHelpCount").GetComponent<Text>();
                if(SecretMech.hardLvlTrickHelpCount < 10){
                    trickHelpText.text = SecretMech.hardLvlTrickHelpCount.ToString();
                }else{
                    trickHelpText.text = "9+";
                }
            }
    }

    public void MainFunc(){
        if((Active && info.trickHelpCount > 0 && !info.isEndless && !info.isCoop && SceneManager.GetActiveScene().name.Substring(3,1)!="H") 
        || (Active && info.isEndless && info.trickHelpCount > 0/*&& endlessScore.trickHelpNum > 0*/)
        || (Active && info.isCoop && Coop.trickHelpNum > 0)
        || (Active && SceneManager.GetActiveScene().name.Substring(3,1)=="H" && SecretMech.hardLvlTrickHelpCount > 0)
        ){
            Active = false;
            isCoolDown = true;
            TrickHelpCount.SetActive(true);
            UpdateTrickCount();
            CoolDownImage.fillAmount = 0.99f;
            if(info.AudioOn)   GameObject.Find("Button_click").GetComponent<AudioSource>().Play();
            clouds = new GameObject[quantity];
            int scenario = UnityEngine.Random.Range(1, 6); //(1, 6) - в 20% случаях (==1) будет только flash, иначе us или angel
            cloudsCount = quantity;
            trickCount = 0;
            if(isSecretMech) {
                isSecretMech = false;
                scenario = SecretMechCnenario;
                Debug.LogWarning(scenario);
            }
            if(info.isCoop){
                scenario = 8;
            }

            switch (scenario){
                case 1: flashCount = UnityEngine.Random.Range(0, 12);
                        cloudsCount = flashCount;
                        if(flashCount < 5) flashCount = 1;
                        else if (flashCount < 9) flashCount = 2;
                        else flashCount = 3;
                        tmpFlashCount = 0;
                        flashExist = 1;
                        clouds = new GameObject[flashCount];
                        Flash();
                    break;
                case 6: flashCount = UnityEngine.Random.Range(0, 10); //SecretMech case 1 //В след. вызов вылетает флеш
                        cloudsCount = flashCount;
                        if(flashCount < 5) flashCount = 1;
                        else if (flashCount < 8) flashCount = 2;
                        else flashCount = 3;
                        tmpFlashCount = 0;
                        flashExist = 1;
                        clouds = new GameObject[flashCount];
                        Flash();
                    break;
                case 7: //Три облака в след. вызов помощи, 2 плохих, одно с макс цепочкой
                    int rand = Random.Range(0,3);
                    clouds = new GameObject[3];
                    cloudsCount = 3;
                    for (int i = 0; i < 3; i++){
                        clouds[i] = Instantiate(cloudPrefab, Camera.main.transform.position - new Vector3(0f, 7.5f+(i*1.5f), -2f), Quaternion.Euler(0, 0, 0));
                        clouds[i].name = "Cloud_"+i;
                        int typeS = 0; //2=Angel, 3=Us
                        int trickS = 0;
                        int modeS = 0; // 1 - AddStep, 2 - AddTime, 3 - Rotate, 4 - FindMaxWay, 5 - ColorBallBoom, 6 - TortBombBoom, 7 - HalfTime, 8 - HalfStep
                        int valueS = 0;
                        if (i == rand){
                            typeS = 3;
                            modeS = 4;
                        }else{
                            typeS = 3;
                            trickS = 1;
                            modeS = UnityEngine.Random.Range(5, 9); //5 - ColorBallBoom, 6 - TortBombBoom, 7 - HalfTime, 8 - HalfStep
                            trickCount++;
                        }
                        GameObject.Find(clouds[i].name).GetComponent<cloud>().Initialize(typeS, modeS, trickS, valueS);
                    }
                    break;
                case 8: for (int i = 0; i < quantity; i++){
                        clouds[i] = Instantiate(cloudPrefab, Camera.main.transform.position - new Vector3(0f, 7.5f+(i*1.5f), -2f), Quaternion.Euler(0, 0, 0));
                        clouds[i].name = "Cloud_"+i;
                        int modeS = Random.Range(3,7); // 3 - Rotate, 4 - FindMaxWay, 5 - ColorBallBoom, 6 - TortBombBoom
                        GameObject.Find(clouds[i].name).GetComponent<cloud>().Initialize(3, modeS, 0, 0);
                    }
                    break;
                default:
                    for (int i = 0; i < quantity; i++){
                        clouds[i] = Instantiate(cloudPrefab, Camera.main.transform.position - new Vector3(0f, 7.5f+(i*1.5f), -2f), Quaternion.Euler(0, 0, 0));
                        clouds[i].name = "Cloud_"+i;
                        int typeS = UnityEngine.Random.Range(2, 7); //2=Angel, 3=Us
                        if(typeS>2) typeS = 3;
                        int trickS = UnityEngine.Random.Range(1, 3);
                        Debug.Log("i = "+ i + ", typeS = " + typeS + ", trickS = "+trickS);
                        int modeS = 0; // 1 - AddStep, 2 - AddTime, 3 - Rotate, 4 - FindMaxWay, 5 - ColorBallBoom, 6 - TortBombBoom, 7 - HalfTime, 8 - HalfStep
                        int valueS = 0;
                        //Делаем так, что бы примерно 50% было плохими
                        if(i >= quantity/2 && trickCount < quantity/2) {trickS = 1; typeS = 3; /*Debug.Log("Делаем так, что бы примерно 50% было плохими");*/}
                        //Делаем так, что бы примерно 50% было хорошими
                        if(i >= quantity/2 && trickCount > (quantity/2)-1) trickS = 0;

                        Debug.Log("i = "+ i + ", typeS = " + typeS + ", trickS = "+trickS + ", quantity = "+ quantity+ ", trickCount = "+trickCount);

                        if(typeS == 2){ //Angel
                            modeS = UnityEngine.Random.Range(0, 10); // 0,1- AddStep, 2,3,4- AddTime, 5- Rotate, 6,7,8,9 - FindMaxWay
                            if(modeS < 2) modeS = 1; //AddStep
                            else if(modeS < 5) modeS = 2; //AddTime
                            else if(modeS < 6) modeS = 3; //Rotate
                            else if(modeS < 10) modeS = 4; //FindMaxWay
                            switch (modeS)
                            {
                                case 1: valueS = UnityEngine.Random.Range(5, 10); break;
                                case 2: valueS = UnityEngine.Random.Range(15, 30); break;
                                default: break;
                            }
                            trickS = 0;
                        }else if (typeS == 3){ //Us
                            if(trickS != 1){
                                modeS = UnityEngine.Random.Range(0, 6); // 0,1- AddStep, 2,3,4- AddTime, 5- Rotate
                                if(modeS < 2) modeS = 1; //AddStep
                                else if(modeS < 5) modeS = 2; //AddTime
                                else if(modeS < 6) modeS = 3; //Rotate
                                switch (modeS)
                                {
                                    case 1: valueS = UnityEngine.Random.Range(2, 8); break;
                                    case 2: valueS = UnityEngine.Random.Range(10, 20); break;
                                    default: break;
                                }
                            }else {
                                modeS = UnityEngine.Random.Range(5, 9); //5 - ColorBallBoom, 6 - TortBombBoom, 7 - HalfTime, 8 - HalfStep
                                trickCount++;
                            }
                        }
                        GameObject.Find(clouds[i].name).GetComponent<cloud>().Initialize(typeS, modeS, trickS, valueS);
                    }
                    break;
            }
        }
    }

    public void Flash(){
        if(tmpFlashCount < flashCount){
            if(tmpFlashCount < flashExist){
                int i = tmpFlashCount;
                clouds[i] = Instantiate(cloudPrefab, Camera.main.transform.position - new Vector3(0f, 7.5f+(i*1.5f), -3f), Quaternion.Euler(0, 0, 0));
                clouds[i].name = "Cloud_"+i;
                int typeS = 1; //1=Flash
                int modeS = 0; // 1 - AddStep, 2 - AddTime, 3 - Rotate, 4 - FindMaxWay, 5 - ColorBallBoom, 6 - TortBombBoom, 7 - HalfTime, 8 - HalfStep
                int valueS = 0;
                modeS = UnityEngine.Random.Range(0, 5); // 0,1- AddStep, 2,3,4- AddTime
                if(modeS < 2) modeS = 1; //AddStep
                else if(modeS < 5) modeS = 2; //AddTime
                switch (modeS)
                {
                    case 1: valueS = UnityEngine.Random.Range(10, 20); break;
                    case 2: valueS = UnityEngine.Random.Range(20, 35); break;
                    default: break;
                }
                GameObject.Find(clouds[i].name).GetComponent<cloud>().Initialize(typeS, modeS, 2, valueS);
                if(info.AudioOn) GameObject.Find("Audio_Flash_f").GetComponent<AudioSource>().Play();
                tmpFlashCount++;
            }
        }
    }

    public void DestroyAll(){
        try{
        foreach (var item in clouds)
        {
            item.GetComponent<cloud>().DestroyThis();
        }
        }catch{
        }
    }
}