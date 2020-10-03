using System.Collections.Generic;
using UnityEngine;

public class BugsOnMap : MonoBehaviour
{
    public GameObject[] Bugs;
    private List<int> Choose = new List<int>();
    static public bool AchivePerformed;
    private int count = 0;
    private int n = 0;
    
    void Start()
    {
        n = Random.Range(1,Bugs.Length>2?4:Bugs.Length+1); //Кол-во букашек на локации
        AchivePerformed = false;
        count = 0;
        //Debug.Log("Кол-во букашек на локации: "+n);
        for (int i = 0; i < n; i++){
            int rand = Random.Range(0,Bugs.Length);
            while(Choose.Contains(rand)){
                rand = Random.Range(0,Bugs.Length);
                //Debug.Log("WHILE rand: "+rand);
            }
            //Debug.Log("rand: "+rand);
            Choose.Add(rand);
            //Bugs[rand].transform.localScale = new Vector3(2f, 2f, 2f);
            Bugs[rand].SetActive(true);
        }
    }

    public void Click(){
        count++;
        if(count == n){
            AchivePerformed = true;
            Debug.Log("Собраны все жуки на локации");
        }
    }
}
