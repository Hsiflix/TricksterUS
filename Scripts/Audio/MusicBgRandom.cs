using UnityEngine;

public class MusicBgRandom : MonoBehaviour
{
    public AudioClip[] Audios = new AudioClip[3];
    public GameObject Audio_BG_egSup;
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0,Audios.Length); // 0 - jungle, 1 - egyptian, 2 - pirate
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().clip = Audios[rand];
        switch (rand)
        {
            case 1: GetComponent<AudioSource>().volume = 0.133f;
                    GetComponent<AudioSource>().pitch = 0.48f;
                    Audio_BG_egSup.GetComponent<AudioSource>().volume = 0.076f;
                    Audio_BG_egSup.GetComponent<AudioSource>().pitch = 0.45f;
                    Audio_BG_egSup.SetActive(true);
                break;
            case 2: GetComponent<AudioSource>().volume = 0.308f;
                    GetComponent<AudioSource>().pitch = 1f;
                    Audio_BG_egSup.SetActive(false);
                break;
            default: GetComponent<AudioSource>().volume = 0.5f;
                    GetComponent<AudioSource>().pitch = 1f;
                    Audio_BG_egSup.SetActive(false);
                break;
        }
        GetComponent<AudioSource>().Play();
    }
}
