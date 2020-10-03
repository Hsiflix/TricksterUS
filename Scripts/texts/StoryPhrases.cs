using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryPhrases : MonoBehaviour
{
    public GameObject DialogETText, DialogGTText, DialogSCText, ETText, GTText;
    public GameObject StoryPhrasesObj, WinBG;
    public GameObject StoryPhrasesGT, StoryPhrasesSC;
    private Texts Dialog_texts, Textss;
    public GameObject Dialog, ET, GT;
    private int num = 0;
    private void Start() {
        string sceneName = SceneManager.GetActiveScene().name;
        if(sceneName.Substring(3,1) == "B"){
            num = int.Parse(sceneName.Substring(4));
        }

        string[] temp = new string[]{"",""};

        switch (num)
        {
            case 1: Dialog_texts = new Texts("StoryPhrases1"); temp = Dialog_texts.StoryPhrases1.ReturnDialog(); break;
            case 2: Dialog_texts = new Texts("StoryPhrases2"); temp = Dialog_texts.StoryPhrases2.ReturnDialog(); break;
            case 3: Dialog_texts = new Texts("StoryPhrases3"); temp = Dialog_texts.StoryPhrases3.ReturnDialog(); break;
        }

        if(temp[0].Equals("")){
            SetFalseAll();
            GT.SetActive(true);
            GTText.GetComponent<Text>().text = temp[1];
        }
        else if (temp[1].Equals("")) {
            SetFalseAll();
            ET.SetActive(true);
            ETText.GetComponent<Text>().text = temp[0];
        }
        else {
            SetFalseAll();
            Dialog.SetActive(true);
            bool tmp = temp[1].Substring(0,4).Equals("@SC@");
            if(!tmp){
                StoryPhrasesGT.SetActive(true);
                StoryPhrasesSC.SetActive(false);
                DialogETText.GetComponent<Text>().text = temp[0];
                DialogGTText.GetComponent<Text>().text = temp[1];
                DialogSCText.GetComponent<Text>().text = "";
            }else{
                StoryPhrasesGT.SetActive(false);
                StoryPhrasesSC.SetActive(true);
                DialogETText.GetComponent<Text>().text = temp[0];
                DialogGTText.GetComponent<Text>().text = "";
                DialogSCText.GetComponent<Text>().text = temp[1].Substring(4);
            }
        }
    }

    public void StoryPhrases_field(){

        string[] temp = new string[]{"",""};
        switch (num)
        {
            case 1: temp = Dialog_texts.StoryPhrases1.ReturnDialog(); break;
            case 2: temp = Dialog_texts.StoryPhrases2.ReturnDialog(); break;
            case 3: temp = Dialog_texts.StoryPhrases3.ReturnDialog(); break;
        }

        if (temp[0].Equals("") && temp[1].Equals("")) {
            WinBG.GetComponent<WinMenuMoney>().NewBlvlAchive();
            //Затемнение и финальный ролик добавляем сюда:

            //
            StoryPhrasesObj.SetActive(false);
        }else if(temp[0].Equals("")){
            SetFalseAll();
            GT.SetActive(true);
            GTText.GetComponent<Text>().text = temp[1];
        }
        else if (temp[1].Equals("")) {
            SetFalseAll();
            ET.SetActive(true);
            ETText.GetComponent<Text>().text = temp[0];
        } else{
            SetFalseAll();
            Dialog.SetActive(true);
            bool tmp = temp[1].Substring(0,4).Equals("@SC@");
            if(!tmp){
                StoryPhrasesGT.SetActive(true);
                StoryPhrasesSC.SetActive(false);
                DialogETText.GetComponent<Text>().text = temp[0];
                DialogGTText.GetComponent<Text>().text = temp[1];
                DialogSCText.GetComponent<Text>().text = "";
            }else{
                StoryPhrasesGT.SetActive(false);
                StoryPhrasesSC.SetActive(true);
                DialogETText.GetComponent<Text>().text = temp[0];
                DialogGTText.GetComponent<Text>().text = "";
                DialogSCText.GetComponent<Text>().text = temp[1].Substring(4);
            }
        }
    }

    private void SetFalseAll(){
        Dialog.SetActive(false);
        ET.SetActive(false);
        GT.SetActive(false);
    }
}