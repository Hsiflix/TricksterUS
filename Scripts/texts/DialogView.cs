using UnityEngine;
using UnityEngine.UI;

public class DialogView : MonoBehaviour
{
    public string DialogName="";
    public bool isRandom = false;
    public GameObject DialogPrefab;
    public GameObject ETGO, GTGO, SCGO;
    public GameObject MainDialog;
    public GameObject SCETDialog;
    public Text MainDialogETText, MainDialogGTText, SCETDialogETText, SCETDialogSCText;
    public GameObject MonologET;
    public GameObject MonologGT;
    public GameObject MonologSC;
    public Text MonologETText, MonologGTText, MonologSCText;
    private Texts Dialog;
    private TextUnit DialogUnit;

    public void StartDialogView() {
        //string sceneName = SceneManager.GetActiveScene().name;
        string[] temp = new string[]{"",""};
        
        //Debug.Log("Test1");
        DialogPrefab.SetActive(true);

        if(DialogName.Equals("")){
            Debug.Log("DialogName = null on " + gameObject.name);
            DialogPrefab.SetActive(false);
            return;
        }else{
            Dialog = new Texts(DialogName);
            DialogUnit = Dialog.GetUnit();
            //temp = DialogUnit.ReturnDialog();
            if(!isRandom){
                temp = DialogUnit.ReturnDialog();
            }else{
                temp = DialogUnit.ReturnRandomDialog();
            }
        }

        SetFalseAll();

        if(temp[0].Equals("")){
            if(temp[1].Equals("")) { //DialogPrefabOff
                DialogPrefab.SetActive(false);
                return;
            }
            if(temp[1].Length > 4 && temp[1].Substring(0,4).Equals("@SC@")){ //MonologSC
                SCGO.SetActive(true);
                MonologSC.SetActive(true);
                MonologSCText.text = temp[1].Substring(4);
                return;
            }else{ //MonologGT
                GTGO.SetActive(true);
                MonologGT.SetActive(true);
                MonologGTText.text = temp[1];
                return;
            }
        }else{
            if(temp[1].Equals("")){ //MonologET
                ETGO.SetActive(true);
                MonologET.SetActive(true);
                MonologETText.text = temp[0];
                return;
            }
            if(temp[1].Length > 4 && temp[1].Substring(0,4).Equals("@SC@")){ //SCETDialog
                SCGO.SetActive(true);
                ETGO.SetActive(true);
                SCETDialog.SetActive(true);
                SCETDialogSCText.text = temp[1].Substring(4);
                SCETDialogETText.text = temp[0];
                return;
            }else{ //MainDialog
                GTGO.SetActive(true);
                ETGO.SetActive(true);
                MainDialog.SetActive(true);
                MainDialogGTText.text = temp[1];
                MainDialogETText.text = temp[0];
                return;
            }
        }
    }

    public void StoryPhrases_field(){
        string[] temp = DialogUnit.ReturnDialog();

        if(isRandom){
            temp = new string[]{"",""};
        }

        SetFalseAll();

        if(temp[0].Equals("")){
            if(temp[1].Equals("")) { //DialogPrefabOff
                DialogPrefab.SetActive(false);
                return;
            }
            if(temp[1].Substring(0,4).Equals("@SC@")){ //MonologSC
                SCGO.SetActive(true);
                MonologSC.SetActive(true);
                MonologSCText.text = temp[1].Substring(4);
                return;
            }else{ //MonologGT
                GTGO.SetActive(true);
                MonologGT.SetActive(true);
                MonologGTText.text = temp[1];
                return;
            }
        }else{
            if(temp[1].Equals("")){ //MonologET
                ETGO.SetActive(true);
                MonologET.SetActive(true);
                MonologETText.text = temp[0];
                return;
            }
            if(temp[1].Substring(0,4).Equals("@SC@")){ //SCETDialog
                SCGO.SetActive(true);
                ETGO.SetActive(true);
                SCETDialog.SetActive(true);
                SCETDialogSCText.text = temp[1].Substring(4);
                SCETDialogETText.text = temp[0];
                return;
            }else{ //MainDialog
                GTGO.SetActive(true);
                ETGO.SetActive(true);
                MainDialog.SetActive(true);
                MainDialogGTText.text = temp[1];
                MainDialogETText.text = temp[0];
                return;
            }
        }
    }

    public void SetFalseAll(){
        ETGO.SetActive(false); GTGO.SetActive(false); SCGO.SetActive(false);
        MainDialog.SetActive(false);
        SCETDialog.SetActive(false);
        MonologET.SetActive(false);
        MonologGT.SetActive(false);
        MonologSC.SetActive(false);
    }
}