using System.Collections;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class colorBall : MonoBehaviour
{
    public GameObject DialogGO; 
    static public int timeForExplosion = 0;
    static public int quantity = 0;
    static public bool AudioPlay = false;
    public int AudioBall;
    private float secondgametime = 0f;
    private int timersecond = 1;
    private bool active = false;
    public GameObject ballPrefab; //Префаб шара
    public GameObject appearancePrefab; //Префаб появления
    private GameObject[] balls = new GameObject[]{};
    public bool SecretMech3 = false;
    void Start()
    {
        SecretMech3 = false;
    }

    void Update()
    {
        secondgametime += Time.deltaTime;
        if (secondgametime >= 1)
        {
            secondgametime = 0;
            timersecond++;
        }
        if(timersecond%timeForExplosion==9) active = true;
        if(timersecond%timeForExplosion==0 && active){
            //active = false;
            //listOfBoom = new int[quantity][];
            Boom();
        }
    }
    public void Boom(){

        //Фраза, если info.firstMeet[0] = false;
        if(!info.firstMeet[0]){
            info.firstMeet[0] = true;
            string dialogName = "lvl_001";
            DialogGO.GetComponent<DialogView>().isRandom = false;
            DialogGO.GetComponent<DialogView>().DialogName = dialogName;
            DialogGO.GetComponent<DialogView>().StartDialogView();
        }

        AudioPlay = false;
        active = false;
        //listOfBoom = new int[quantity][];
        balls = new GameObject[quantity];
        for (int i = 0; i < quantity; i++){
            repeat:
            int ball = UnityEngine.Random.Range(0, spawn.field_size*spawn.field_size);

            if(GameObject.Find(""+ball).GetComponent<ball>().busy){
                goto repeat;
            }
            GameObject tmpAppear = Instantiate(/*info.*/appearancePrefab, GameObject.Find(""+ball).transform.position + new Vector3(0f, 0f, -5.1f), Quaternion.Euler(0, 0, 0));
            tmpAppear.name = i+"A";
            StartCoroutine(DestroyAppearance(i));
            balls[i] = Instantiate(/*info.*/ballPrefab,   GameObject.Find(""+ball).transform.position + new Vector3(0f, 0f, -5f), Quaternion.Euler(0, 0, 0));
            balls[i].name = ball+"C";
            GameObject.Find(""+ball).GetComponent<ball>().busy = true;
            GameObject.Find(ball+"C").GetComponent<Animator>().enabled = true;
            
            int randomColorBoom = 0;
            if(SecretMech3){
                randomColorBoom = info.winBall;
            }else{
                if(!info.isCoop){
                    repeatColor:
                    randomColorBoom = UnityEngine.Random.Range(0, 4);
                    if(randomColorBoom==info.winBall){
                        goto repeatColor;
                    }
                }else{
                    randomColorBoom = UnityEngine.Random.Range(0, 4);
                }
            }
            if(i==0){
                if(info.AudioOn) GameObject.Find(ball.ToString()).GetComponent<AudioSource>().Play();
                AudioPlay = true;
                AudioBall = ball;
            }
            /*20.09.2019*/
            GameObject.Find(ball+"C").GetComponent<colorBombAnim>().SetColor(randomColorBoom);
            /* */
            /*20.09.2019*//*StartCoroutine(BoomIE(randomColorBoom, ball, i));*/
        }
        SecretMech3 = false;
    }

    /*20.09.2019*//*IEnumerator BoomIE(int color, int nameInt, int number){
        Debug.Log("int color = " + color + ", int nameInt = " + nameInt + ", int number = "+ number);
        Debug.Log("Start BoomIE()");
        yield return new WaitForSeconds(7.2f);
        Debug.Log("WaitForSeconds(7.2f)");
        //Debug.Log(nameInt + " ColorBBBB");
        GameObject.Find(nameInt+"C").transform.position = new Vector3 (GameObject.Find(nameInt+"C").transform.position.x,  GameObject.Find(nameInt+"C").transform.position.y,-5.5f);
        listOfBoom[number] = new int[9];
        yield return new WaitForSeconds(0.8f);
        Debug.Log("WaitForSeconds(0.8f)");
        listOfBoom[number][0] = nameInt-info.field_size-1;
        listOfBoom[number][1] = nameInt-info.field_size;
        listOfBoom[number][2] = nameInt-info.field_size+1;
        listOfBoom[number][3] = nameInt-1;
        listOfBoom[number][4] = nameInt;
        listOfBoom[number][5] = nameInt+1;
        listOfBoom[number][6] = nameInt+info.field_size-1;
        listOfBoom[number][7] = nameInt+info.field_size;
        listOfBoom[number][8] = nameInt+info.field_size+1;
        Debug.Log("End listOfBoom");
        
        GameObject.Find(""+nameInt).GetComponent<ball>().busy = false;

        for (int i = 0; i < 9; i++){
            if(listOfBoom[number][i] < 0 || 
            listOfBoom[number][i] >= info.field_size*info.field_size || 
            info.stat_balls.Contains(listOfBoom[number][i]) ||
            GameObject.Find(""+listOfBoom[number][i]).GetComponent<ball>().busy){
                listOfBoom[number][i] = -1;
            }
        }
        if(nameInt%info.field_size==0){
            listOfBoom[number][0] = -1;
            listOfBoom[number][3] = -1;
            listOfBoom[number][6] = -1;
        }
        if(nameInt%info.field_size==info.field_size-1){
            listOfBoom[number][2] = -1;
            listOfBoom[number][5] = -1;
            listOfBoom[number][8] = -1;
        }
        Debug.Log("End listOfBoom = -1");
        Sprite colorSprite = null;
        switch(color){
            case 0: colorSprite = info.ball_blue; break;
            case 1: colorSprite = info.ball_yellow; break;
            case 2: colorSprite = info.ball_green; break;
            case 3: colorSprite = info.ball_red; break;
        }
        foreach (int i in listOfBoom[number]){
            if(i != -1){
                GameObject.Find(""+i).GetComponent<SpriteRenderer>().sprite = colorSprite;
                info.ballColors[spawn.ArrColor[i]]--;
                spawn.ArrColor[i] = color;
                info.ballColors[color]++;
            }
        }
        GameObject.Find(""+nameInt).GetComponent<ball>().busy = false;
        Debug.Log("End color_main");
        yield return new WaitForSeconds(1f);
        Destroy(GameObject.Find(nameInt+"A"));
        Destroy(GameObject.Find(nameInt+"C"));
        Debug.Log("End ColorBomb");
    }*/

    IEnumerator DestroyAppearance(int nameInt){
        yield return new WaitForSeconds(1.1f);
        Destroy(GameObject.Find(nameInt+"A"));
    }

    public void DestroyAll(){
        foreach (var item in balls)
        {
            try{
                Destroy(item);
            }catch{
            }
        }
    }
}