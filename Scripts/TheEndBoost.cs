using UnityEngine;

public class TheEndBoost : MonoBehaviour
{
    public GameObject Megillah;
    private float memLength = 0;
    private bool startTouch = false;

    void Update()
    {
        if(Input.touchCount == 2){
            float length = (Input.GetTouch(0).position - Input.GetTouch(1).position).magnitude;
            if(!startTouch){
                memLength = length;
                startTouch = true;
            }
            Megillah.transform.localScale += new Vector3((length - memLength)*0.002f, (length - memLength)*0.002f, 0f);
            memLength = length;
            if(Megillah.transform.localScale.x < 0.5f){
                Megillah.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
            }else if(Megillah.transform.localScale.x > 3f){
                Megillah.transform.localScale = new Vector3(3f, 3f, 1f);
            }
        }
        if(Input.touchCount == 0){
            startTouch = false;
        }
    }
}
