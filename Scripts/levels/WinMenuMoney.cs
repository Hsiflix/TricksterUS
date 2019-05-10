using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinMenuMoney : MonoBehaviour {

    public GameObject leftBottomMenu, rightBottomMenu;

    static public int moneyAdd = 1000;
    private int tmp = 0, tmpMoney = 0, tmpMoneyAdd = 0;
    private bool active = true;

    public void Start()
    {
        tmpMoney = info.money;
        info.money+=moneyAdd;
        rightBottomMenu.GetComponent<Text>().text = tmpMoney.ToString();
        leftBottomMenu.GetComponent<Text>().text = "+ "+0;
        StartCoroutine(AddMoney());
        if(int.Parse(SceneManager.GetActiveScene().name.Substring(3)) == info.lvl) info.lvl++;
        info.Save();
    }

    IEnumerator AddMoney(){
        while(active){
            tmp = Random.Range(20, 80);
            if(tmpMoneyAdd + tmp < moneyAdd) {
                tmpMoneyAdd += tmp;
            }
            else {
                tmpMoneyAdd = moneyAdd;
                active = false;
            }
            rightBottomMenu.GetComponent<Text>().text = ""+ (tmpMoney + tmpMoneyAdd);
            leftBottomMenu.GetComponent<Text>().text = "+ "+tmpMoneyAdd;
            yield return new WaitForSeconds(0.1f);
        }
    }
}