using UnityEngine;

public class AllAchivements : MonoBehaviour
{
    public DialogView DialogGO;
    
    private void OnEnable(){
        if(!info.AllAciveDone){
            bool allAchive = true;
            for (int i = 0; i < info.maxAchive; i++){
                allAchive &= AchivementMap.achivements[i,3];
                //Debug.Log(AchivementMap.achivements[i,3]);
            }
            if(allAchive){
                info.AllAciveDone = true;
                Debug.LogWarning("AllAchiveOnEnable");
                DialogGO.DialogName = "AllAchivements";
                DialogGO.StartDialogView();
                info.money += 500000;
                info.Save();
            }
        }
    }
}
