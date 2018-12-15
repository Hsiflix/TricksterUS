using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempBool : MonoBehaviour {

	public GameObject bomb;
	public GameObject bomb1;
	public GameObject bomb2;
	static public bool start = false;
	private IEnumerator[] coroutine = new IEnumerator[3];
	static public int[] spawns = {0,0,0};

	void Update(){
		if(start){
			start = false;
			tap();
		}
	}
	public void tap(){
		coroutine[0] = Late(bomb, 0f);
		StartCoroutine(coroutine[0]);
		coroutine[1] = Late(bomb1, 0.5f);
		StartCoroutine(coroutine[1]);
		coroutine[2] = Late(bomb2, 1f);
		StartCoroutine(coroutine[2]);
	}

	IEnumerator Late(GameObject _obj, float time = 1)
    {
        yield return new WaitForSeconds(time);
		_obj.SetActive(true);
        
    }
}
