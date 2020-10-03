using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;


public class PhrasesLoseMenu : MonoBehaviour
{
    public GameObject DialogGO; 

    private void OnEnable() {
        try{
            if(Int32.Parse(SceneManager.GetActiveScene().name.Substring(3,1))<10){ //Если это обычный уровень
                int rand = UnityEngine.Random.Range(0,4); //0,1,2,3
                if(rand == 0){ //Рандомное
                    DialogGO.GetComponent<DialogView>().DialogName = "Lose_r";
                    DialogGO.GetComponent<DialogView>().isRandom = true;
                    DialogGO.GetComponent<DialogView>().StartDialogView();
                }else if(rand == 1){ //Default
                    List<string> randomDialog = new List<string>{"Lose_001", "Lose_002", "Lose_010", "Lose_011", "Lose_013", "Lose_014", "Lose_015", "Lose_016", 
                                                                "Lose_020", "Lose_022", "Lose_025", "Lose_027", "Lose_030", "Lose_031"};
                    string dialogName = randomDialog[UnityEngine.Random.Range(0,randomDialog.Count)];
                    DialogGO.GetComponent<DialogView>().isRandom = false;
                    DialogGO.GetComponent<DialogView>().DialogName = dialogName;
                    DialogGO.GetComponent<DialogView>().StartDialogView();
                }     
            }
        }
        catch(Exception e){
            Debug.Log(e);
        }
    }
}
