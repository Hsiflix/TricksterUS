using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCrossPushHide : MonoBehaviour {

    private float minimum = 1.0F;
    private float maximum = 1.3F;
    private GameObject lvl_cross;
    private GameObject last_lvl;

    void Start()
    {
        info.Load();
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
    }

    private void Update()
    {
        last_lvl.transform.localScale = new Vector2(Mathf.PingPong(Time.time/4f, maximum - minimum) + minimum, Mathf.PingPong(Time.time/4f, maximum - minimum) + minimum);
    }
}
