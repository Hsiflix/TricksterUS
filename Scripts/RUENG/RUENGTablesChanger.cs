using System;
using UnityEngine;
using UnityEngine.UI;

public class RUENGTablesChanger : MonoBehaviour
{
    private const int N = 10;
    public Sprite[] sprites = new Sprite[2*N];
    public GameObject[] tables = new GameObject[N];
    public GameObject[] ContinueAnim = new GameObject[N];
    public GameObject[] NewGameAnim = new GameObject[N];
    public GameObject[] EndlessAnim = new GameObject[N];
    public GameObject[] OptionsAnim = new GameObject[N];

    public void Start()
    {
        try{
            for (int i = 0; i < N; i++){
                if(info.lang == 1){ //RUS
                    tables[i].GetComponent<SpriteRenderer>().sprite = sprites[i*2];
                    ContinueAnim[i].GetComponent<SpriteRenderer>().sprite = sprites[i*2];
                    NewGameAnim[i].GetComponent<SpriteRenderer>().sprite = sprites[i*2];
                    EndlessAnim[i].GetComponent<SpriteRenderer>().sprite = sprites[i*2];
                    OptionsAnim[i].GetComponent<SpriteRenderer>().sprite = sprites[i*2];
                }else{ //ENG
                    tables[i].GetComponent<SpriteRenderer>().sprite = sprites[i*2+1];
                    ContinueAnim[i].GetComponent<SpriteRenderer>().sprite = sprites[i*2+1];
                    NewGameAnim[i].GetComponent<SpriteRenderer>().sprite = sprites[i*2+1];
                    EndlessAnim[i].GetComponent<SpriteRenderer>().sprite = sprites[i*2+1];
                    OptionsAnim[i].GetComponent<SpriteRenderer>().sprite = sprites[i*2+1];
                }
            }
        }catch(Exception e){
            Debug.Log("RUENGTablesChanger: " + e);
        }
    }
}
