using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CLoud : MonoBehaviour {

    //static public bool Trigger = false;
    static public bool Trigger = false;
    public int Ver; //1=Flash, 2=Trick, 3=Angel, 4=Normal
    static public int ChoiseVer = -1;
    public GameObject cloud;
    public GameObject image;
    public GameObject text;
    public GameObject button;
    public Text texts;
    public Vector3 start;//Начальнрая позиция - рандом
    public Vector3 then;
    static public bool setvalue = false;
    static public short value;
    private float scrinWidth;
    private float scrinHeight;
    private bool newCloud = false;


    // Use this for initialization
    void Start () {
        Trigger = false;
        scrinWidth = Screen.width;
        scrinHeight = Screen.height;
    }
	
    public void Touches()
    {
        TricksterHelp.isCloud = true;
        image.SetActive(false);
        text.SetActive(false);
        button.SetActive(false);
    }

	// Update is called once per frame
	void Update () {
        if (Trigger && ChoiseVer == Ver && Ver == 4)
        {
            if (setvalue)
            {
                setvalue = false;
                image.SetActive(true);
                text.SetActive(true);
                button.SetActive(true);
                float x = Random.Range(-100, 100);
                start = then = new Vector3(x + 850f, -320f, 0f);//
                texts.text = ("+" + value.ToString());
            }
            start = cloud.transform.position;
            then.x += Random.Range(-40,42);
            then.y += Random.Range(2, 8);
            cloud.transform.position = Vector3.Lerp(start, then, 0.01f);
            if(cloud.transform.position.y >= 1500)//
            {
                Trigger = false;
            }
        }else
        if (Trigger && ChoiseVer == Ver && Ver == 1){
            if (setvalue)
            {
                setvalue = false;
                newCloud = true;
                float startX = Random.Range(0, scrinWidth);
                float startY = Random.Range(-300, -100);
                start = new Vector3(startX, startY, 0f);
                cloud.transform.position = start;
                then = new Vector3(scrinWidth/2, scrinHeight/2, 0f);
            }
            start = cloud.transform.position;
            if(newCloud && start.y >= scrinHeight/3){
                newCloud = false;
                float startX = Random.Range(0, scrinWidth);
                float startY = Random.Range(scrinHeight+200, scrinHeight + 300);
                then = new Vector3(startX, startY, 0f);
            }
            cloud.transform.position = Vector3.Lerp(start, then, 0.06f);
        }
	}
}
