using System;
using UnityEngine;
using UnityEngine.Advertisements;
public class BeginMonetization : MonoBehaviour
{
    static public bool testMode = false;
    static public string AndroidGameId = "3553943";

    void Start () {
        AndroidGameId = "3553943";
        if(!Advertisement.isInitialized) {
            Advertisement.Initialize (AndroidGameId, testMode);
        }
    }
}
 