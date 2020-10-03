using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungleRuinsText : MonoBehaviour
{
    public GameObject DialogGO;
    
    private void OnEnable() {
        if(Random.Range(0,2)==0){
            DialogGO.SetActive(true);
            if(Random.Range(0,2)==0){
                if(Random.Range(0,2)==0){
                    DialogGO.GetComponent<DialogView>().DialogName = "PhrasesInRuins_1Rr";
                    Debug.Log("PhrasesInRuins_1Rr");
                    DialogGO.GetComponent<DialogView>().isRandom = true;
                    DialogGO.GetComponent<DialogView>().StartDialogView();
                }else{
                    List<string> randomDialog = new List<string>{"PhrasesInRuins_2R", "PhrasesInRuins_3R", "PhrasesInRuins_4R"};
                    string dialogName = randomDialog[Random.Range(0,3)];
                    Debug.Log(dialogName);
                    DialogGO.GetComponent<DialogView>().isRandom = false;
                    DialogGO.GetComponent<DialogView>().DialogName = dialogName;
                    DialogGO.GetComponent<DialogView>().StartDialogView();
                }
            }else{
                if(Random.Range(0,2)==0){
                    DialogGO.GetComponent<DialogView>().DialogName = "PhrasesInRuins_1Jr";
                    Debug.Log("PhrasesInRuins_1Jr");
                    DialogGO.GetComponent<DialogView>().isRandom = true;
                    DialogGO.GetComponent<DialogView>().StartDialogView();
                }else{
                    List<string> randomDialog = new List<string>{"PhrasesInRuins_2J", "PhrasesInRuins_3J", "PhrasesInRuins_4J"};
                    string dialogName = randomDialog[Random.Range(0,3)];
                    Debug.Log(dialogName);
                    DialogGO.GetComponent<DialogView>().isRandom = false;
                    DialogGO.GetComponent<DialogView>().DialogName = dialogName;
                    DialogGO.GetComponent<DialogView>().StartDialogView();
                }
            }
        }
    }
}
