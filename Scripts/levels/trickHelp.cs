using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trickHelp : MonoBehaviour
{
    private Image CoolDownImage;
    private float CoolDownPart = 10;
    private bool isCoolDown = false;
    private bool Active = true;
    public GameObject cloudPrefab;
    public int quantity = 1;
    public int trickCount = 0;
    public int cloudsCount = 0;
    private GameObject[] clouds;
    private int flashCount;
    public int flashExist, tmpFlashCount;

    void Start()
    {
        CoolDownImage = GameObject.Find("TrickCoolDown").GetComponent<Image>();
    }

    private void FixedUpdate() {
        if (isCoolDown)
        {
            CoolDownImage.fillAmount -= 1 / CoolDownPart * Time.deltaTime;
            if (CoolDownImage.fillAmount <= 0)
            {
                isCoolDown = false;
                CoolDownImage.fillAmount = 0;
                Active = true;
            }
        }
        if(trickCount > 0 && cloudsCount == trickCount){
            DestroyAll();
            trickCount = 0;
        }
    }

    public void MainFunc(){
        if(Active){
            Active = false;
            isCoolDown = true;
            CoolDownImage.fillAmount = 0.99f;
            clouds = new GameObject[quantity];
            int scenario = UnityEngine.Random.Range(1, 6); //(1, 6) - в 20% случаях (==1) будет только flash, иначе us или angel
            cloudsCount = quantity;
            trickCount = 0;
            switch (scenario){
                case 1: flashCount = UnityEngine.Random.Range(0, 10);
                        if(flashCount < 5) flashCount = 1;
                        else if (flashCount < 8) flashCount = 2;
                        else flashCount = 3;
                        tmpFlashCount = 0;
                        flashExist = 1;
                        clouds = new GameObject[flashCount];
                        Flash();
                    break;
                default:
                    for (int i = 0; i < quantity; i++){
                        clouds[i] = Instantiate(cloudPrefab, Camera.main.transform.position - new Vector3(0f, 7.5f+(i*1.5f), -3f), Quaternion.Euler(0, 0, 0));
                        clouds[i].name = "Cloud_"+i;
                        int typeS = UnityEngine.Random.Range(2, 4); //2=Angel, 3=Us
                        int trickS = UnityEngine.Random.Range(1, 4);
                        int modeS = 0; // 1 - AddStep, 2 - AddTime, 3 - Rotate, 4 - FindMaxWay, 5 - ColorBallBoom, 6 - TortBombBoom, 7 - HalfTime, 8 - HalfStep
                        int valueS = 0;
                        //Делаем так, что бы 1 трикстер был 100%
                        if(i == quantity - 1 && trickCount == 0) trickS = 1;
                        if(trickS != 1){
                            switch (typeS)
                            {
                                case 2: modeS = UnityEngine.Random.Range(1, 5); // 1 - AddStep, 2 - AddTime, 3 - Rotate, 4 - FindMaxWay
                                        switch (modeS)
                                        {
                                            case 1: valueS = UnityEngine.Random.Range(4, 10); break;
                                            case 2: valueS = UnityEngine.Random.Range(15, 30); break;
                                            default: break;
                                        }
                                    break;
                                case 3: modeS = UnityEngine.Random.Range(1, 4); // 1 - AddStep, 2 - AddTime, 3 - Rotate
                                        switch (modeS)
                                        {
                                            case 1: valueS = UnityEngine.Random.Range(2, 8); break;
                                            case 2: valueS = UnityEngine.Random.Range(10, 20); break;
                                            default: break;
                                        }
                                    break;
                            }
                        }else {
                            modeS = UnityEngine.Random.Range(5, 9); //5 - ColorBallBoom, 6 - TortBombBoom, 7 - HalfTime, 8 - HalfStep
                            trickCount++;
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
                int trickS = UnityEngine.Random.Range(1, 6);
                int modeS = 0; // 1 - AddStep, 2 - AddTime, 3 - Rotate, 4 - FindMaxWay, 5 - ColorBallBoom, 6 - TortBombBoom, 7 - HalfTime, 8 - HalfStep
                int valueS = 0;
                if(trickS != 1){
                    modeS = UnityEngine.Random.Range(1, 4); // 1 - AddStep, 2 - AddTime, 3 - Rotate
                    valueS = UnityEngine.Random.Range(20, 35);
                }else modeS = UnityEngine.Random.Range(5, 9); // 5 - ColorBallBoom, 6 - TortBombBoom, 7 - HalfTime, 8 - HalfStep
                GameObject.Find(clouds[i].name).GetComponent<cloud>().Initialize(typeS, modeS, trickS, valueS);
                tmpFlashCount++;
            }
        }
    }

    public void DestroyAll(){
        foreach (var item in clouds)
        {
            try{
                item.GetComponent<cloud>().DestroyThis();
            }catch{
            }
        }
    }
}