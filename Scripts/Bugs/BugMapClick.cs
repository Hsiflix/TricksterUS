using UnityEngine;
using UnityEngine.UI;

public class BugMapClick : MonoBehaviour
{
    public void Click(){
        Destroy(GetComponent<Image>());
        Destroy(GetComponent<Animation>());
        Destroy(GetComponent<Button>());
        GameObject.Find("audio_bug_click").GetComponent<AudioSource>().Stop();
        GameObject.Find("audio_bug_click").GetComponent<AudioSource>().Play();
    }
}
