using UnityEngine;
using UnityEngine.UI;

public class NoColorDialog : MonoBehaviour
{
    public GameObject NoColorETText, NoColorGTText;
    public GameObject NoColor;
    private Texts NoColorDialog_texts;
    private void OnEnable() {
        NoColorDialog_texts = new Texts("NoColorDialog");
        string[] tmp = NoColorDialog_texts.NoColorDialog.ReturnRandomDialog();
        NoColorGTText.GetComponent<Text>().text = tmp[0];
        NoColorETText.GetComponent<Text>().text = tmp[1];
    }

    public void NoColor_field(){
        NoColor.SetActive(false);
    }
}

