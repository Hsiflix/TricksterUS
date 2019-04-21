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

    private void DrawGizmos() 
    { 
        float distance = 2.5f;
        Vector3 p1 = Camera.main.ScreenToWorldPoint(new Vector3 (0f, 0f, distance)); 
        //Vector3 p2 = Camera.main.ScreenToWorldPoint(new Vector3(0f, Camera.main.pixelHeight, distance)); 
        Vector3 p3 = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, distance));
        //Vector3 p4 = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0f, distance)); 
        //Debug.Log(p1); //LD
        //Debug.Log(p2); //LU
        //Debug.Log(p3); //RU
        //Debug.Log(p4); //RD
        Debug.Log("Range(X) = ("+ p1.x +", "+ p3.x +")");
        Debug.Log("Range(Y).Down = ("+ (p1.y-3.5f) +", "+ (p1.y-1.5f) +")");
        Debug.Log("Range(Y).Up = ("+ (p3.y+1.5f) +", "+ (p3.y+3.5f) +")");
        Debug.Log("Center: "+ Camera.main.transform.position);
        Debug.Log("Force.X.LD: "+ (Camera.main.transform.position.x - p1.x));
        Debug.Log("Force.Y.LD: "+ (Camera.main.transform.position.y - p1.y));
        /*Debug.Log("Force.X.RD: "+ (Camera.main.transform.position.x - p3.x));
        Debug.Log("Force.Y.RD: "+ (Camera.main.transform.position.y - p1.y));
        Debug.Log("Force.X.LU: "+ (Camera.main.transform.position.x - p1.x));
        Debug.Log("Force.Y.LU: "+ (Camera.main.transform.position.y - p3.y));
        Debug.Log("Force.X.RU: "+ (Camera.main.transform.position.x - p3.x));
        Debug.Log("Force.Y.RU: "+ (Camera.main.transform.position.y - p3.y));
        Debug.Log("Force.X.U: "+ (Camera.main.transform.position.x - Camera.main.transform.position.x));
        Debug.Log("Force.Y.U: "+ (Camera.main.transform.position.y - p3.y));
        Debug.Log("Force.X.D: "+ (Camera.main.transform.position.x - Camera.main.transform.position.x));
        Debug.Log("Force.Y.D: "+ (Camera.main.transform.position.y - p1.y));*/
        //float a = (Camera.main.transform.position.x - p1.x) / (Camera.main.transform.position.y - p1.y); //Соотношение
        double b = (Camera.main.transform.position.y - p1.y) / (0.00000006); //Коэффициент умножения
        float ax = (Camera.main.transform.position.x - p1.x) / (float)b;
        float ay = (Camera.main.transform.position.y - p1.y) / (float)b;
        Debug.Log("Force.X.LD.end: "+ (ax));
        Debug.Log("Force.Y.LD.end: "+ (ay));
    }


    void Update()
    {

    }

    public void MainFunc(){
        if(Active){
            Active = false;
            isCoolDown = true;
            CoolDownImage.fillAmount = 0.99f;

            clouds = new GameObject[quantity];
            for (int i = 0; i < quantity; i++){
                clouds[i] = Instantiate(cloudPrefab, Camera.main.transform.position - new Vector3(0f, 7.5f+(i*1.5f), -3f), Quaternion.Euler(0, 0, 0));
                clouds[i].name = "Cloud_"+i;
                int typeS = UnityEngine.Random.Range(1, 5);
                //int typeS = 1;
                int modeS = UnityEngine.Random.Range(1, 8);
                int valueS = UnityEngine.Random.Range(1, 20);
                GameObject.Find(clouds[i].name).GetComponent<cloud>().Initialize(typeS, modeS, valueS);
            }
        }
    }
}