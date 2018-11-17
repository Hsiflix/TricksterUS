using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class ButLoadLvl : MonoBehaviour {

    public Animation _anim;
    public GameObject _map;
    //public GameObject _this;
    bool flajok;
    static public string _namelvl = "lvl";
	// Use this for initialization
	void Start () {
        _anim = gameObject.GetComponent<Animation>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PushButton()
    {
        _map.SetActive(false);
        _anim.Play();
        StartCoroutine(Animat());
    }

    IEnumerator Animat()
    {
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(_namelvl);
    }
}
