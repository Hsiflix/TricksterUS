using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBgColorChanger : MonoBehaviour
{
    private void Awake() {
        GetComponent<Camera>().backgroundColor = new Color(Random.Range(0.3f, 0.7f),Random.Range(0.3f, 0.7f),Random.Range(0.3f, 0.7f));
        GetComponent<Camera>().enabled = true;
        info.camColor = GetComponent<Camera>().backgroundColor;
    }
}
