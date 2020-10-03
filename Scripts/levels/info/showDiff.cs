using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class showDiff : MonoBehaviour
{
    private Text timerText, stepsText;

    private void Start() {
        timerText = GameObject.Find("Timer").GetComponent<Text>();
        stepsText = GameObject.Find("Steps").GetComponent<Text>();
    }
    public void SetDefault(){
        timerText.color = Color.white;
        timerText.text = ""+info.timersecond;
        stepsText.color = Color.white;
        if(info.steps < 1000) stepsText.text = ""+info.steps;
        else stepsText.text = "999+";
    }
    public void ShowDif(int valueS, int modeS){ //modeS = {1=UpTime, 2=UpStep, 3=DwTime, 4=DwStep}
        StartCoroutine(ShowDifIE(valueS, modeS));
    }

    IEnumerator ShowDifIE(int valueS, int modeS){
        switch (modeS){ //modeS = {1=UpTime, 2=UpStep, 3=DwTime, 4=DwStep}
            case 1: timerText.color = Color.green;
                    timerText.text = "+"+valueS;
                    yield return new WaitForSeconds(1.5f);
                    timerText.color = Color.white;
                    timerText.text = ""+info.timersecond;
                break;
            case 2: stepsText.color = Color.green;
                    stepsText.text = "+"+valueS;
                    yield return new WaitForSeconds(1.5f);
                    stepsText.color = Color.white;
                    if(info.steps < 1000) stepsText.text = ""+info.steps;
                    else stepsText.text = "999+";
                break;
            case 3: timerText.color = Color.red;
                    timerText.text = ""+info.timersecond;
                    yield return new WaitForSeconds(1.5f);
                    timerText.color = Color.white;
                break;
            case 4: stepsText.color = Color.red;
                    if(info.steps < 1000) stepsText.text = ""+info.steps;
                    else stepsText.text = "999+";
                    yield return new WaitForSeconds(1.5f);
                    stepsText.color = Color.white;
                break;
        }
    }
}
