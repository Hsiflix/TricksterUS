using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class cloud : MonoBehaviour
{
    private ConstantForce force;
    private float randX = 0f;

    private int type = 1; //1=Flash, 2=Angel, 3=Us
    private int mode = 1; // 1 - AddStep, 2 - AddTime, 3 - Rotate, 4 - FindMaxWay, 5 - ColorBallBoom, 6 - TortBombBoom, 7 - HalfTime, 8 - HalfStep
    private int value = 0; //Количество добавляемого (шагов или времени)
    private int trick = 0;

    private bool Active = false;
    private bool ActiveFlash = false;
    private double coefficient = 0;
    private float forceX = 0f;
    private float forceY = 0f;
    private float timeToShowTrick = 3f; //Время, между показом того, что облачно - трикстер. Рандомное, настраивается в Start()

    public Sprite UsCloud;
	public Sprite FlCloud;
	public Sprite TrCloud;
	public Sprite AnCloud;
	public GameObject AnCloudPart2;

    void Start()
    {
        force = GetComponent<ConstantForce>();
        timeToShowTrick = Random.Range(2f,3.5f);
    }

    void Update()
    {
        if(Active || ActiveFlash){
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    string Name = hit.collider.name;
                    if(Name == transform.name.ToString()){
                        Touch();
					}
				}
			}
        }
        if(ActiveFlash){
            if((transform.position.y > Camera.main.transform.position.y + 12f && transform.position.y < Camera.main.transform.position.y + 18f) || (transform.position.y < Camera.main.transform.position.y - 12f && transform.position.y > Camera.main.transform.position.y - 18f)) 
            {
                GameObject.Find("Game").GetComponent<trickHelp>().flashExist++;
                GameObject.Find("Game").GetComponent<trickHelp>().Flash();
                DestroyThis();
            }
        }
        if(Active){
            randX = Random.Range(-0.00000035f,0.0000003501f);
            force.force = new Vector3 (randX, 0.00000005f, 0f);
            if(transform.position.y > Camera.main.transform.position.y + 6f && transform.position.y < Camera.main.transform.position.y + 12f) DestroyThis();
        }
    }

    public void Initialize(int typeS, int modeS, int trickS, int valueS = 0){
        type = typeS;
        mode = modeS;
        value = valueS;
        trick = trickS;
        switch(type){ //1=Flash, 2=Angel, 3=Us
            case 1: GetComponent<SpriteRenderer>().sprite = FlCloud;
                    Vector3 p1 = Camera.main.ScreenToWorldPoint(new Vector3 (0f, 0f, 0f)); 
                    Vector3 p3 = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0f));
                    int UD = Random.Range(0,2);
                    switch (UD){
                        case 0: transform.position = new Vector3(Random.Range(p1.x, p3.x), Random.Range(p1.y-3.5f, p1.y-1.5f), -7f);
                            break;
                        case 1: transform.position = new Vector3(Random.Range(p1.x, p3.x), Random.Range(p3.y+1.5f, p3.y+3.5f), -7f);
                            break;
                    }
                    coefficient = (Camera.main.transform.position.y - transform.position.y) / (0.0000018); //Коэффициент умножения 0.0000007
                    if(coefficient<0) coefficient = -coefficient;
                    forceX = (Camera.main.transform.position.x - transform.position.x) / (float)coefficient;
                    forceY = (Camera.main.transform.position.y - transform.position.y) / (float)coefficient;
                    force = GetComponent<ConstantForce>();
                    force.force = new Vector3 (forceX, forceY, 0f);
                    if(trick == 1) StartCoroutine(trcikShow(FlCloud));
                    ActiveFlash = true;
                break;
            case 2: GetComponent<SpriteRenderer>().sprite = AnCloud;
                    if(trick == 1) StartCoroutine(trcikShow(AnCloud));
                    AnCloudPart2.SetActive(true);
                    Active = true;
                break;
            case 3: GetComponent<SpriteRenderer>().sprite = UsCloud;
                    if(trick == 1) StartCoroutine(trcikShow(UsCloud));
                    Active = true;
                break;
        }
    }

    void Touch(){
        Active = false;
        info.activeTouch = true;
        if(trick == 1 && type != 1){
              GameObject.Find("Game").GetComponent<trickHelp>().DestroyAll();
        }else{
              GameObject.Find("Game").GetComponent<trickHelp>().cloudsCount--;
        }
        if (trick != 1){
            switch (type)
            {
                case 3: int var = UnityEngine.Random.Range(0, 3);
                    switch (var)
                    {
                        case 0: if(info.AudioOn) GameObject.Find("Audio_Cloud_1").GetComponent<AudioSource>().Play();
                            break;
                        case 1: if(info.AudioOn) GameObject.Find("Audio_Cloud_2").GetComponent<AudioSource>().Play();
                            break;
                        case 2: if(info.AudioOn) GameObject.Find("Audio_Cloud_3").GetComponent<AudioSource>().Play();
                            break;
                    }
                    break;
                case 2: if(info.AudioOn) GameObject.Find("Audio_Angel").GetComponent<AudioSource>().Play();
                    break;
            }
        }
        Debug.Log("mode: "+mode);
        switch (mode) // 1 - AddStep, 2 - AddTime, 3 - Rotate, 4 - FindMaxWay, 5 - ColorBallBoom, 6 - TortBombBoom, 7 - HalfTime, 8 - HalfStep
        {
            case 1: AddStep(value);
                break;
            case 2: AddTime(value);
                break;
            case 3: Rotate();
                break;
            case 4: FindMaxWay();
                break;
            case 5: ColorBallBoom();
                break;
            case 6: TortBombBoom();
                break;
            case 7: HalfTime();
                break;
            case 8: HalfStep();
                break;
            default: Debug.Log("Error: cloud.Touch()"); DestroyThis();
                break;
        }
    }

    void FindMaxWay(){
        if(spawn.ArrColor.Contains(info.winBall)){
              GameObject.Find("Game").GetComponent<FindMaxWay>().MainFunc();
        }else{
            Rotate();
        }
        DestroyThis();
    }

    void HalfStep(int valueS = 2){
        if (info.stepGo && info.steps > 1)
        {
            info.steps = (int)(info.steps/valueS);
            GameObject.Find("Game").GetComponent<info>().ShowDif(valueS,4);
        }else{
            HalfTime();
        }
        DestroyThis();
    }

    void HalfTime(int valueS = 2){
        if (info.timerGo)
        {
            info.timersecond = (int)(info.timersecond/valueS);
            GameObject.Find("Game").GetComponent<info>().ShowDif(valueS,3);
        }else{
            if(info.stepGo){
                HalfStep();
            }else{
                TortBombBoom(1);
            }
        }
        DestroyThis();
    }

    void TortBombBoom(int valueS = 2){
        GameObject.Find("Game").GetComponent<tortoiseBall>().enabled = true;
        GameObject.Find("Game").GetComponent<tortoiseBall>().Boom(valueS);
        DestroyThis();
    }

    void ColorBallBoom(int valueS = 2){
        colorBall.quantity = valueS;
        GameObject.Find("Game").GetComponent<colorBall>().Boom();
        DestroyThis();
    }

    void Rotate()
    {
        for (int i = 0; i < spawn.field_size * spawn.field_size; i++)
        {
            if ((spawn.ArrColor[i] != info.winBall)&& !GameObject.Find(""+i).GetComponent<ball>().busy)
            {
                short randomRot = (short)Random.Range(1, 4);
                GameObject.Find(i.ToString()).GetComponent<ball>().RotateBall(randomRot);
            }
        }
        DestroyThis();
    }

    void AddTime(int valueS)
    {
        if (info.timerGo)
        {
            info.timersecond += valueS;
            GameObject.Find("Game").GetComponent<info>().ShowDif(valueS,1);
        }
        DestroyThis();
    }

    void AddStep(int valueS)
    {
        if (info.stepGo)
        {
            info.steps += valueS;
            GameObject.Find("Game").GetComponent<info>().ShowDif(valueS,2);
        }
        DestroyThis();
    }

    public void DestroyThis(){
        Destroy(GameObject.Find(transform.name.ToString()));
    }

    IEnumerator trcikShow(Sprite memorized){
        repeat:
        yield return new WaitForSeconds(timeToShowTrick);
        if(info.AudioOn) GameObject.Find("Audio_Bad_cloud").GetComponent<AudioSource>().Play();
        GetComponent<SpriteRenderer>().sprite = TrCloud;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().sprite = memorized;
        goto repeat;
    }
}