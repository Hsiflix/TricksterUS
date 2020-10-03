using UnityEngine;

public class MapCrossPushHide : MonoBehaviour {

    private float minimum = 1.0F;
    private float maximum = 1.3F;
    private GameObject lvl_cross;
    private GameObject last_lvl;
    static public bool[] firstMeet = new bool[3];
    static public bool firsMeetHard = false;
    public GameObject b1FM, b2FM, b3FM;
    public GameObject DialogGO;

    public void Start()
    {
        //info.Load();
        SetTargets();
        Debug.Log("firstMeet: " + firstMeet[0] + firstMeet[1] + firstMeet[2]);
        string last_lvl_name = "lvl" + info.lvl.ToString();
        last_lvl = GameObject.Find(last_lvl_name);
        for (int i = info.lvl + 1; i <= info.max_lvl; i++)
        {
            lvl_cross = GameObject.Find("lvl"+i.ToString());
            lvl_cross.SetActive(false);
        }
        if (info.lvl<5){
            lvl_cross = GameObject.Find("lvlB1");
            lvl_cross.SetActive(false);
        }
        if (info.lvl<13){
            lvl_cross = GameObject.Find("lvlB2");
            lvl_cross.SetActive(false);
        }
        if (info.lvl<19){
            lvl_cross = GameObject.Find("lvlB3");
            lvl_cross.SetActive(false);
        }
        for (int i = info.hardLvl + 1; i <= 20/*info.max_lvl+4*/; i++)
        {
            lvl_cross = GameObject.Find("lvlH"+i.ToString());
            lvl_cross.SetActive(false);
        }
        if(firsMeetHard){
            firsMeetHard = false;
            FirsMeetHard();
        }
    }

    public void SetTargets(){
        Debug.Log("firstMeet: " + firstMeet[0] + firstMeet[1] + firstMeet[2]);
        b1FM.SetActive(firstMeet[0]);
        b2FM.SetActive(firstMeet[1]);
        b3FM.SetActive(firstMeet[2]);
        if (info.lvl>=5 && firstMeet[0]){
            ViewDialog_mapNewRuins();
        }
        if (info.lvl>=13 && firstMeet[1]){
            ViewDialog_mapNewRuins();
        }
        if (info.lvl>=19 && firstMeet[2]){
            ViewDialog_mapNewRuins();
        }
    }

    private void ViewDialog_mapNewRuins(){
        DialogGO.GetComponent<DialogView>().DialogName = "mapNewRuins";
        DialogGO.GetComponent<DialogView>().isRandom = false;
        DialogGO.GetComponent<DialogView>().StartDialogView();
    }

    private void FirsMeetHard(){
        GameObject.Find("lvlH"+info.hardLvl.ToString()).GetComponent<Animation>().Play();;
    }

    private void Update()
    {
        if (info.lvl<19)
            last_lvl.transform.localScale = new Vector2(Mathf.PingPong(Time.time/4f, maximum - minimum) + minimum, Mathf.PingPong(Time.time/4f, maximum - minimum) + minimum);
    }
}
