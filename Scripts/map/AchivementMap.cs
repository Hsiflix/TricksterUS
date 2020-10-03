using UnityEngine;
using UnityEngine.UI;

public class AchivementMap : MonoBehaviour
{
    static public bool[,] achivements = new bool[info.maxAchive,4]; //acivements[lvl][achievement number] lvl = 1..18+3(bot)+(hardcore), achivement = 0..3 (time, step, bug, all)
    static public bool[] achivementKeys = new bool[3]; 
    public GameObject star_1, star_2, star_3;
    static public int achive_time, achive_step, achive_bugs;
    static public int lvl = 1;
    
    private void OnEnable() {
        star_1.GetComponent<Image>().color = new Color (1,1,1);
        star_2.GetComponent<Image>().color = new Color (1,1,1);
        star_3.GetComponent<Image>().color = new Color (1,1,1);
        int temp = 0;
        for (int i = 0; i < 3; i++){
            if(achivements[lvl,i]){
                temp++;
            }
        }
        switch (temp)
        {
            case 1: star_1.GetComponent<Image>().color = new Color (1,1,0);
                break;
            case 2: star_1.GetComponent<Image>().color = new Color (1,1,0);
                    star_2.GetComponent<Image>().color = new Color (1,1,0);
                break;
            case 3: star_1.GetComponent<Image>().color = new Color (1,1,0);
                    star_2.GetComponent<Image>().color = new Color (1,1,0);
                    star_3.GetComponent<Image>().color = new Color (1,1,0);
                break;
        }
    }

    public void Achive_out(){
        gameObject.SetActive(false);
    }
}
