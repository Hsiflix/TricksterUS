using System.Collections.Generic;
using UnityEngine;

public class PhrasesTrickHome : MonoBehaviour
{
    public GameObject DialogGO; 

    public void View() {
        Debug.Log("DialogView");
        int rand = UnityEngine.Random.Range(0,4); //0,1,2,3
        if(rand == 0){ //Рандомное
            DialogGO.GetComponent<DialogView>().DialogName = "home_r";
            DialogGO.GetComponent<DialogView>().isRandom = true;
            DialogGO.GetComponent<DialogView>().StartDialogView();
        }else if(rand == 1){ //Default
            List<string> randomDialog = new List<string>{"home_001", "home_002", "home_004", "home_005", "home_006", "home_008", "home_012", "home_014", 
                                                        "home_015", "home_017", "home_018", "home_020", "home_021", "home_022", "home_023", "home_024", "home_025", "home_026"};
            string dialogName = randomDialog[UnityEngine.Random.Range(0,randomDialog.Count)];
            DialogGO.GetComponent<DialogView>().isRandom = false;
            DialogGO.GetComponent<DialogView>().DialogName = dialogName;
            DialogGO.GetComponent<DialogView>().StartDialogView();
        }
    }
}
