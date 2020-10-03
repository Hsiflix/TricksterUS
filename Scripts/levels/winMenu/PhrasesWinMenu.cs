using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class PhrasesWinMenu : MonoBehaviour
{
    public GameObject DialogGO;

    private void OnEnable() {
        try{
            if(Int32.Parse(SceneManager.GetActiveScene().name.Substring(3,1))<10){ //Если это обычный уровень
                DialogGO.SetActive(true);
                int rand = UnityEngine.Random.Range(0,4); //0,1,2,3
                if(AchivementMap.achivements[AchivementMap.lvl,0]&&AchivementMap.achivements[AchivementMap.lvl,1]&&AchivementMap.achivements[AchivementMap.lvl,2]) //Если все ачивы
                {
                    if(rand == 0){ //Рандомное
                        DialogGO.GetComponent<DialogView>().DialogName = "WinMenu3achieve_r";
                        DialogGO.GetComponent<DialogView>().isRandom = true;
                        DialogGO.GetComponent<DialogView>().StartDialogView();
                    }else if(rand == 1){ //Default
                        List<string> randomDialog = new List<string>{"WinMenu3achieve_003","WinMenu3achieve_005","WinMenu3achieve_006","WinMenu3achieve_007"};
                        string dialogName = randomDialog[UnityEngine.Random.Range(0,randomDialog.Count)];
                        DialogGO.GetComponent<DialogView>().isRandom = false;
                        DialogGO.GetComponent<DialogView>().DialogName = dialogName;
                        DialogGO.GetComponent<DialogView>().StartDialogView();
                    }
                }else if(!(AchivementMap.achivements[AchivementMap.lvl,0]||AchivementMap.achivements[AchivementMap.lvl,1]||AchivementMap.achivements[AchivementMap.lvl,2])){ //Если 0 ачив
                    if(rand == 0){ //Рандомное
                        DialogGO.GetComponent<DialogView>().DialogName = "WinMenu0achieve_r";
                        DialogGO.GetComponent<DialogView>().isRandom = true;
                        DialogGO.GetComponent<DialogView>().StartDialogView();
                    }else if(rand == 1){ //Default
                        List<string> randomDialog = new List<string>{"WinMenu0achieve_002","WinMenu0achieve_004","WinMenu0achieve_005"};
                        string dialogName = randomDialog[UnityEngine.Random.Range(0,randomDialog.Count)];
                        DialogGO.GetComponent<DialogView>().isRandom = false;
                        DialogGO.GetComponent<DialogView>().DialogName = dialogName;
                        DialogGO.GetComponent<DialogView>().StartDialogView();
                    }
                }else{ //Deafult
                    if(rand == 0){ //Рандомное
                        DialogGO.GetComponent<DialogView>().DialogName = "WinMenu001r";
                        DialogGO.GetComponent<DialogView>().isRandom = true;
                        DialogGO.GetComponent<DialogView>().StartDialogView();
                    }else if(rand == 1){ //Default
                        List<string> randomDialog = new List<string>{"WinMenu002", "WinMenu003", "WinMenu004", "WinMenu006", "WinMenu007", "WinMenu008", "WinMenu009", "WinMenu010", 
                                                                    "WinMenu011", "WinMenu012", "WinMenu013", "WinMenu014", "WinMenu015", "WinMenu016", "WinMenu018", "WinMenu019", 
                                                                    "WinMenu022", "WinMenu023", "WinMenu025", "WinMenu027","WinMenuChester_002","WinMenuChester_003","WinMenuChester_004",
                                                                    "WinMenuChester_005","WinMenuChester_007","WinMenuChester_008","WinMenuChester_009","WinMenuChester_010", 
                                                                    "WinMenuChester_012","WinMenuChester_013","WinMenuChester_014","WinMenuChester_015","WinMenuChester_016",
                                                                    "WinMenuChester_017","WinMenuChester_019","WinMenuChester_020", "WinMenuChester_022","WinMenuChester_023",
                                                                    "WinMenuChester_025","WinMenuChester_026","WinMenuChester_027","WinMenuChester_028","WinMenuChester_031",
                                                                    "WinMenuChester_033", "WinMenuChester_034"};
                        string dialogName = randomDialog[UnityEngine.Random.Range(0,randomDialog.Count)];
                        DialogGO.GetComponent<DialogView>().isRandom = false;
                        DialogGO.GetComponent<DialogView>().DialogName = dialogName;
                        DialogGO.GetComponent<DialogView>().StartDialogView();
                    }
                }
            }
        }
        catch(Exception e){
            Debug.Log(e);
        }
    }
}
