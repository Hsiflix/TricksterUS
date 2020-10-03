using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandCloudAnim : MonoBehaviour
{
    private int speedKoef = 1;
    private int number = 1;
    void Start()
    {
        speedKoef = int.Parse(transform.name.Substring(2,1));
        number = int.Parse(transform.name.Substring(4,1));
        //transform.position = new Vector3(-1200f+Random.Range(-2000f, 2500f), 1020f+Random.Range(0f, 200f), 0f);

        transform.position = number==1?new Vector3(-1200f+Random.Range(-2000f, 0f), 970f+Random.Range(0f, 200f), 0f):
                                new Vector3(-1200f+Random.Range(0f, 2500f), 1020f+Random.Range(0f, 200f), 0f);

        transform.rotation = Quaternion.Euler(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        //Debug.Log(int.Parse(transform.name.Substring(2,1)));
    }

    void Update()
    {
        //transform.position = new Vector3(transform.position.x+Random.Range(0.1f, 1f), transform.position.y+Random.Range(-1f, 1.1f), 0f);
        transform.position = new Vector3(transform.position.x+Random.Range(0.1f*speedKoef, 1f*speedKoef), transform.position.y+Random.Range(-0.5f, 0.5f), 0f);
        //Debug.Log(transform.position);
        if(transform.position.x > 2500f){
            number = number==1?2:1;
            transform.position = number==1?new Vector3(-1200f+Random.Range(-2000f, 0f), 970f+Random.Range(0f, 200f), 0f):
                                new Vector3(-1200f+Random.Range(0f, 1000f), 1020f+Random.Range(0f, 200f), 0f);
            transform.rotation = Quaternion.Euler(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        }
    }
}
