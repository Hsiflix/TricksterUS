using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tortoiseBall : MonoBehaviour
{
    public GameObject DialogGO; 
    static public int timeForExplosion = 0;
    static public int quantity = 0;
    private int quantityAll = 0;
    private float secondgametime = 0f;
    private int timersecond = 1;
    private int timerBoom = 0;
    static public bool active = false;
    static public bool botActive = false;
    public bool lvlActive = false;
    //private int[] listOfBoom;
    private string objectTouch = "";
    private List<int> balls = new List<int>();
    private List<int> ballsColor = new List<int>();
    public GameObject appearancePrefab; //Префаб появления

    void Awake()
    {
        //Debug.Log("gsdgh");
        botActive = false;
        active = false;
    }

    void Update()
    {
        if (active) // Возможность касания
        {
            //Debug.Log(active);
            if (Input.GetMouseButtonDown(0)) // Если кнопку нажали
            {
                //Debug.Log("Input.GetMouseButtonDown(0)");
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    objectTouch = hit.collider.name; // Записывает имя объекта по которому каснулись
                    //Debug.Log(objectTouch);
                    try{
                        for (int i = 0; i < quantityAll; i++)
                        {
                            if(""+balls[i]==objectTouch){
                                active = false;
                                //Debug.LogWarning("StartBoom");
                                StartBoom(balls[i], ballsColor[i]);
                                //StartCoroutine(BoomIE(balls[i], ballsColor[i]));
                                if(info.AudioOn) GameObject.Find("Audio_Turtle_1").GetComponent<AudioSource>().Play();
                                goto contin;
                                //break;
                            }
                        }
                    }catch{

                    }
                }
            }    
        }
        contin:
        if (lvlActive)
        {
            secondgametime += Time.deltaTime;
            if (secondgametime >= 1)
            {
                secondgametime = 0;
                timersecond++;
            }
            if (timersecond % timeForExplosion == 0 && timersecond != timerBoom)
            {
                timerBoom = timersecond;
                Boom(quantity);
            }
        }
    }
    public void Boom(int quantityS){
        //Фраза, если info.firstMeet[1] = false;
        if(!info.firstMeet[1]){
            info.firstMeet[1] = true;
            string dialogName = "lvl_002";
            DialogGO.GetComponent<DialogView>().isRandom = false;
            DialogGO.GetComponent<DialogView>().DialogName = dialogName;
            DialogGO.GetComponent<DialogView>().StartDialogView();
        }

        //Debug.Log("Boom()");
        //quantityAll += quantityS;
        for (int i = 0; i < quantityS; i++){
            //Debug.Log("tort: " + i);
            int counts = 0;
            repeat: int ball = Random.Range(0, spawn.field_size*spawn.field_size);
            if(counts>=1000) goto theEnd;
            counts++;
            if(info.ballColors[info.winBall] != info.field_size * info.field_size){
                if(GameObject.Find(""+ball).GetComponent<ball>().busy) goto repeat;
                if(!info.isCoop || (info.isCoop && CanvasBot.turn_bt)){
                    if(spawn.ArrColor.Contains(info.winBall) && i==1){
                        if(spawn.ArrColor[balls[0]] != info.winBall){
                            if(spawn.ArrColor[ball] != info.winBall) goto repeat;
                        }else{
                            if(spawn.ArrColor[ball] == info.winBall) goto repeat;
                        }
                    }
                }else{
                    if(info.isCoop && !CanvasBot.turn_bt){
                        if(spawn.ArrColor.Contains(coopMenu.player2Color) && i==1){
                            if(spawn.ArrColor[balls[0]] != coopMenu.player2Color){
                                if(spawn.ArrColor[ball] != coopMenu.player2Color) goto repeat;
                            }else{
                                if(spawn.ArrColor[ball] == coopMenu.player2Color) goto repeat;
                            }
                        }
                    }
                }
            }else{
                Debug.Log("Здесь должно было быть зависание!");
            }
            quantityAll++;
            GameObject tmpAppear = Instantiate(appearancePrefab, GameObject.Find(""+ball).transform.position + new Vector3(0f, 0f, -5.1f), Quaternion.Euler(0, 0, 0));
            tmpAppear.name = i+"A";
            StartCoroutine(DestroyAppearance(i));
            balls.Add(ball);
            ballsColor.Add(spawn.ArrColor[ball]);
            GameObject.Find(""+ball).GetComponent<ball>().busy = true;
            GameObject.Find(""+ball).GetComponent<SpriteRenderer>().sprite = info.ball_tort;
            active = true;
            //Debug.Log(active);
            info.activeTouch = false;
            theEnd: ;
        }
        //ShowLists();
    }

    void SwitchColor(int nameInt, int color){
        Sprite colorSprite = null;
        switch(color){
            case 0: colorSprite = info.ball_blue; break;
            case 1: colorSprite = info.ball_yellow; break;
            case 2: colorSprite = info.ball_green; break;
            case 3: colorSprite = info.ball_red; break;
        }
        GameObject.Find(""+nameInt).GetComponent<SpriteRenderer>().sprite = colorSprite;
    }

    public void StartBoom(int nameInt, int color){
        //Debug.LogWarning("public void StartBoom(int nameInt, int color)");
        //for (int i = 0; i < quantityAll; i++){
        int ballsCount = balls.Count;
        for (int i = ballsCount-1; i >= 0; i--){
            SwitchColor(balls[i], ballsColor[i]);
        }
        if(GameObject.Find(""+nameInt).GetComponent<tortoiseBallAnim>()){
        }else{
            GameObject.Find(""+nameInt).AddComponent<tortoiseBallAnim>();
        }
        GameObject.Find(""+nameInt).GetComponent<tortoiseBallAnim>().Part1_tortoise(nameInt, color);
    }

    public void EndBoom(){
        //for (int i = 0; i < quantityAll; i++){
        //ShowLists();
        int ballsCount = balls.Count;
        //Debug.LogWarning(ballsCount);
        for (int i = ballsCount-1; i >= 0; i--){
            //Debug.LogWarning(i);
            GameObject.Find(""+balls[i]).GetComponent<ball>().busy = false;
            balls.Remove(balls[i]);
            ballsColor.Remove(ballsColor[i]);
            //ShowLists();
        }

        timersecond = 1;
        quantityAll = 0;
        //balls = new List<int>();
        //ballsColor = new List<int>();
        active = false;

        if(botActive){
            botActive = false;
            //Debug.Log("GetComponent<Bot>().MainFunc();");
            GetComponent<Bot>().MainFunc();
        }

        info.activeTouch = true;
    }

    private void ShowLists(){
        Debug.Log("========================================");
        string queue = "";
        for (int i = 0; i < balls.Count; i++){
            queue+=balls[i] + ", ";
        }
        Debug.Log("balls: " + queue);
        queue = "";
        for (int i = 0; i < ballsColor.Count; i++){
            queue+=ballsColor[i] + ", ";
        }
        Debug.Log("ballsColor: " + queue);
        Debug.Log("========================================");
    }


    IEnumerator DestroyAppearance(int nameInt){
        yield return new WaitForSeconds(1.1f);
        Destroy(GameObject.Find(nameInt+"A"));
    }
}