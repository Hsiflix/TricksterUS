using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;


public class PhrasesMapLocations : MonoBehaviour
{
    static public int locNum = 0; //0=J, 1=Sn, 2=Sa, 3=H, 4=B 
    public GameObject DialogGO;

    private void OnEnable() {
        int rand = UnityEngine.Random.Range(0,2); //0,1,2,3
        if(locNum == 0){ //Jungle
            if(rand == 0){ //Рандомное
                DialogGO.GetComponent<DialogView>().DialogName = "Location_Jr";
                DialogGO.GetComponent<DialogView>().isRandom = true;
                DialogGO.GetComponent<DialogView>().StartDialogView();
            }else if(rand == 1){ //Default
                List<string> randomDialog = new List<string>{"Location_J_001", "Location_J_002", "Location_J_006"};
                string dialogName = randomDialog[UnityEngine.Random.Range(0,randomDialog.Count)];
                DialogGO.GetComponent<DialogView>().isRandom = false;
                DialogGO.GetComponent<DialogView>().DialogName = dialogName;
                DialogGO.GetComponent<DialogView>().StartDialogView();
            }
        }else if(locNum == 1){ //Snow
            if(rand == 0){ //Рандомное
                DialogGO.GetComponent<DialogView>().DialogName = "Location_Snr";
                DialogGO.GetComponent<DialogView>().isRandom = true;
                DialogGO.GetComponent<DialogView>().StartDialogView();
            }else if(rand == 1){ //Default
                List<string> randomDialog = new List<string>{"Location_Sn_004", "Location_Sn_007", "Location_Sn_008"};
                string dialogName = randomDialog[UnityEngine.Random.Range(0,randomDialog.Count)];
                DialogGO.GetComponent<DialogView>().isRandom = false;
                DialogGO.GetComponent<DialogView>().DialogName = dialogName;
                DialogGO.GetComponent<DialogView>().StartDialogView();
            }
        }else if(locNum == 2){ //Sand
            if(rand == 0){ //Рандомное
                DialogGO.GetComponent<DialogView>().DialogName = "Location_Sar";
                DialogGO.GetComponent<DialogView>().isRandom = true;
                DialogGO.GetComponent<DialogView>().StartDialogView();
            }else if(rand == 1){ //Default
                List<string> randomDialog = new List<string>{"Location_Sa_002", "Location_Sa_003", "Location_Sa_004", "Location_Sa_005"};
                string dialogName = randomDialog[UnityEngine.Random.Range(0,randomDialog.Count)];
                DialogGO.GetComponent<DialogView>().isRandom = false;
                DialogGO.GetComponent<DialogView>().DialogName = dialogName;
                DialogGO.GetComponent<DialogView>().StartDialogView();
            }
        }else if(locNum == 3){ //Hard
            if(rand == 0){ //Рандомное
                DialogGO.GetComponent<DialogView>().DialogName = "Location_Hr";
                DialogGO.GetComponent<DialogView>().isRandom = true;
                DialogGO.GetComponent<DialogView>().StartDialogView();
            }else if(rand == 1){ //Default
                List<string> randomDialog = new List<string>{"Location_H_003", "Location_H_005", "Location_H_006"};
                string dialogName = randomDialog[UnityEngine.Random.Range(0,randomDialog.Count)];
                DialogGO.GetComponent<DialogView>().isRandom = false;
                DialogGO.GetComponent<DialogView>().DialogName = dialogName;
                DialogGO.GetComponent<DialogView>().StartDialogView();
            }
        }else if(locNum == 4){ //Boat
            if(rand == 0||rand == 1){ //Рандомное
                DialogGO.GetComponent<DialogView>().DialogName = "Location_Br";
                DialogGO.GetComponent<DialogView>().isRandom = true;
                DialogGO.GetComponent<DialogView>().StartDialogView();
            }
        }
    }
}
