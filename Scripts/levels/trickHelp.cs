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
    public int quantity = 1; //Кол-во облаков (Мб сделать случайным?)
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
    }

    public void MainFunc(){
        if(Active){
            Active = false;
            isCoolDown = true;
            CoolDownImage.fillAmount = 0.99f;
            clouds = new GameObject[quantity];
            int isOnlyFlash = UnityEngine.Random.Range(1, 6); //(1, 6) - в 20% случаях будут только flash, иначе us или angel
            flashCount = UnityEngine.Random.Range(5, 10);
            tmpFlashCount = 0;
            flashExist = 1;
            if(isOnlyFlash == 1){
                clouds = new GameObject[flashCount];
                Flash();
            }else{
                for (int i = 0; i < quantity; i++){
                    clouds[i] = Instantiate(cloudPrefab, Camera.main.transform.position - new Vector3(0f, 7.5f+(i*1.5f), -3f), Quaternion.Euler(0, 0, 0));
                    clouds[i].name = "Cloud_"+i;
                    int typeS = UnityEngine.Random.Range(2, 4); //1=Flash, 2=Angel, 3=Us
                    int trickS = UnityEngine.Random.Range(1, 5);
                    int modeS = 0; // 1 - AddStep, 2 - AddTime, 3 - Rotate, 4 - FindMaxWay, 5 - ColorBallBoom, 6 - TortBombBoom, 7 - HalfTime, 8 - HalfStep
                    int valueS = 0;
                    if(trickS != 1){
                        switch (typeS)
                        {
                            case 2: modeS = UnityEngine.Random.Range(1, 5); // 1 - AddStep, 2 - AddTime, 3 - Rotate, 4 - FindMaxWay
                                    valueS = UnityEngine.Random.Range(15, 30);
                                break;
                            case 3: modeS = UnityEngine.Random.Range(1, 4); // 1 - AddStep, 2 - AddTime, 3 - Rotate
                                    valueS = UnityEngine.Random.Range(10, 20);
                                break;
                        }
                    }else modeS = UnityEngine.Random.Range(5, 9);
                    GameObject.Find(clouds[i].name).GetComponent<cloud>().Initialize(typeS, modeS, trickS, valueS);
                }
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
                }else modeS = UnityEngine.Random.Range(5, 9);
                GameObject.Find(clouds[i].name).GetComponent<cloud>().Initialize(typeS, modeS, trickS, valueS);
                tmpFlashCount++;
            }
        }
    }
}