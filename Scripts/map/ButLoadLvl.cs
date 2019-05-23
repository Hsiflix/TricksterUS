using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class ButLoadLvl : MonoBehaviour {

    public Animation _anim;
    public GameObject _map;
    static public string _namelvl = "lvl";
    
	void Start () {
        _anim = gameObject.GetComponent<Animation>();
    }
	
    public void PushButton()
    {
        _map.SetActive(false);
        _anim.Play();
        StartCoroutine(Animat());
    }

    IEnumerator Animat()
    {
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene(_namelvl, LoadSceneMode.Single);
    }
}
