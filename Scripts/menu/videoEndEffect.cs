using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System.Collections;

public class videoEndEffect : MonoBehaviour
{
    VideoPlayer _videoPlayer;
    public string nameScene = "";
    public bool asyncB = false;
    private AsyncOperation async;

    void Start()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _videoPlayer.Prepare();

        _videoPlayer.loopPointReached += _videoPlayer_loopPointReached;

        Invoke("play", 0);

        if(asyncB){
            StartCoroutine(StartLoad());
        }
    }

    private void _videoPlayer_loopPointReached(VideoPlayer source)
    {
        if(asyncB){
            async.allowSceneActivation = true;
        }else{
            SceneManager.LoadScene(nameScene);
        }
        Debug.Log("end of video");
    }

    private void play()
    {
        _videoPlayer.Play();
    }

    IEnumerator StartLoad(){
        yield return new WaitForSeconds(1f);
        async = SceneManager.LoadSceneAsync(nameScene);
		async.allowSceneActivation = false;
    }
}
