using UnityEngine;
using UnityEngine.UI;

public class BugsSpriteChanger : MonoBehaviour
{
    public Sprite[] BugSprites;
    void Start()
    {
        GetComponent<Image>().sprite = BugSprites[Random.Range(0,BugSprites.Length)];
    }
}
