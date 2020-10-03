using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class tutorial_lvl : MonoBehaviour
{
    public GameObject tutorial_3, tutorial_4, tutorial_5, tutorial_6, tutorial_7;
    public GameObject cloud_3, cloud_4;
    public GameObject text_3, text_4, text_6_1, text_7_1;
    public GameObject target_1, target_2;
    public Sprite scared, hello, points, angry, telling, bye;
    private Image tutorial_3_sprite, tutorial_4_sprite;
    private int mode = 0;
    Texts tutorial_lvl_texts;
    void Start()
    {
        tutorial_lvl_texts = new Texts("tutorial_lvl");
        tutorial_3_sprite = tutorial_3.GetComponent<Image>();
        tutorial_4_sprite = tutorial_4.GetComponent<Image>();
        mode = 1;
        text_6_1.GetComponent<Text>().text = tutorial_lvl_texts.tutorial_lvl.ReturnText();
        tutorial_3.SetActive(true);
        tutorial_6.SetActive(true);
    }

    public void Tutorial(){
        switch (mode)
        {
            case 0:
                text_6_1.GetComponent<Text>().text = tutorial_lvl_texts.tutorial_lvl.ReturnText();
                tutorial_3.SetActive(true);
                tutorial_6.SetActive(true);
            break;
            case 1:
                tutorial_4.SetActive(true);
            break;
            case 2:
                tutorial_3_sprite.sprite = hello;
                text_6_1.GetComponent<Text>().text = tutorial_lvl_texts.tutorial_lvl.ReturnText();
                target_1.SetActive(true);
            break;
            case 3:
                target_1.SetActive(false);
                tutorial_3_sprite.sprite = points;
                text_6_1.GetComponent<Text>().text = tutorial_lvl_texts.tutorial_lvl.ReturnText();
            break;
            case 4:
                tutorial_4_sprite.sprite = angry;
                tutorial_6.SetActive(false);
                text_3.GetComponent<Text>().text = tutorial_lvl_texts.tutorial_lvl.ReturnText();
                text_4.GetComponent<Text>().text = tutorial_lvl_texts.tutorial_lvl.ReturnText();
                tutorial_5.SetActive(true);
            break;
            case 5:
                text_7_1.GetComponent<Text>().text = tutorial_lvl_texts.tutorial_lvl.ReturnText();
                tutorial_5.SetActive(false);
                tutorial_7.SetActive(true);
                tutorial_3_sprite.sprite = scared;
            break;
            case 6:
                tutorial_4_sprite.sprite = telling;
                text_7_1.GetComponent<Text>().text = tutorial_lvl_texts.tutorial_lvl.ReturnText();
            break;
            case 7:
                tutorial_4.SetActive(false);
                text_6_1.GetComponent<Text>().text = tutorial_lvl_texts.tutorial_lvl.ReturnText();
                target_2.SetActive(true);
                tutorial_6.SetActive(true);
                tutorial_7.SetActive(false);
                tutorial_3_sprite.sprite = bye;
            break;
            case 8:
                target_2.SetActive(false);
                tutorial_6.SetActive(false);
                tutorial_3.SetActive(false);
            break;
            default: Debug.Log("Tutorial end");
            break;
        }
        mode++;
    }
}
