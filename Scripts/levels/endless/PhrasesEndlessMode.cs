using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhrasesEndlessMode : MonoBehaviour
{
    public GameObject DialogGO; 
    static public int scoreNum = 0;

    private void OnEnable() {
        if(Random.Range(0,2)==0 && !endlessScore.isNew){
            if(endlessScore.scoreNum == 0 && scoreNum!=0){ //Проиграл
                DialogGO.GetComponent<DialogView>().DialogName = "PhrasesEndlessMode21";
                DialogGO.GetComponent<DialogView>().isRandom = true;
                DialogGO.GetComponent<DialogView>().StartDialogView();
            }
            if(endlessScore.scoreNum != 0){ //Выиграл
                DialogGO.GetComponent<DialogView>().DialogName = "PhrasesEndlessMode22";
                DialogGO.GetComponent<DialogView>().isRandom = true;
                DialogGO.GetComponent<DialogView>().StartDialogView();
            }
            if(endlessScore.scoreNum == 0 && scoreNum==0){ //Default
                if(Random.Range(0,2)==1) {
                    List<string> randomDialog = new List<string>{"PhrasesEndlessMode1", "PhrasesEndlessMode2", "PhrasesEndlessMode3", "PhrasesEndlessMode4", "PhrasesEndlessMode5", 
                                                                "PhrasesEndlessMode6", "PhrasesEndlessMode7", "PhrasesEndlessMode8"};
                    string dialogName = randomDialog[Random.Range(0,8)];
                    DialogGO.GetComponent<DialogView>().isRandom = false;
                    DialogGO.GetComponent<DialogView>().DialogName = dialogName;
                }else{
                    DialogGO.GetComponent<DialogView>().isRandom = true;
                    DialogGO.GetComponent<DialogView>().DialogName = "PhrasesEndlessMode20";
                }
                DialogGO.GetComponent<DialogView>().StartDialogView();
            }
        }
        scoreNum = endlessScore.scoreNum;
        Debug.Log("endlessScore.isNew = false;");
        endlessScore.isNew = false;
    }
}
