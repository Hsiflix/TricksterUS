using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCrossPushHide : MonoBehaviour {

    public float minimum = 1.0F;
    public float maximum = 1.3F;
    private GameObject lvl_cross;
    private GameObject last_lvl;
    private int lvl = Infos.viewLvl();
    private int max_lvl = Infos.view_max_Lvl();
    void Start()
    {
        string last_lvl_name = "lvl" + lvl.ToString();
        last_lvl = GameObject.Find(last_lvl_name);
        for (int i = lvl + 1; i <= max_lvl; i++)
        {
            //Debug.Log("lvl" + i.ToString());
            string lvl_cross_name = "lvl" + i.ToString();
            lvl_cross = GameObject.Find(lvl_cross_name);
            lvl_cross.SetActive(false);
        }
        if (lvl<5){
            string lvl_cross_name = "lvlB1";
            lvl_cross = GameObject.Find(lvl_cross_name);
            lvl_cross.SetActive(false);
        }
        if (lvl<13){
            string lvl_cross_name = "lvlB2";
            lvl_cross = GameObject.Find(lvl_cross_name);
            lvl_cross.SetActive(false);
        }
        if (lvl<19){
            string lvl_cross_name = "lvlB3";
            lvl_cross = GameObject.Find(lvl_cross_name);
            lvl_cross.SetActive(false);
        }
     
    }

    private void Update()
    {
        last_lvl.transform.localScale = new Vector2(Mathf.PingPong(Time.time/4f, maximum - minimum) + minimum, Mathf.PingPong(Time.time/4f, maximum - minimum) + minimum);
    }
}
