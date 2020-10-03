using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class ButLoadLvl : MonoBehaviour {

    public Animation _anim;
    public GameObject _map;
    static public string _namelvl = "lvl";
    private bool active = true;
    
	void Start () {
        _anim = gameObject.GetComponent<Animation>();
        _map = GameObject.Find("Canvas");
    }
	
    public void PushButton()
    {
        if(active){
            active = false;
            if(info.AudioOn)   GameObject.Find("Chest_sound").GetComponent<AudioSource>().Play();
            _map.SetActive(false);
            _anim.Play();
            info.isCoop = false;
            info.isEndless = false;
            StartCoroutine(Animat());
        }
    }

    IEnumerator Animat()
    {
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene(_namelvl, LoadSceneMode.Single);
    }
}
