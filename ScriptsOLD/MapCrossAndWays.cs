using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapCrossAndWays : MonoBehaviour {

    int lvl = Infos.viewLvl();//пройдено уровней
    Image m_Image;
    public Sprite m_red;
    public Sprite m_yellow;
    int c; //номер данного уровня

    void Start () {
    m_Image = GetComponent<Image>();
        string a = m_Image.name;    //
        char[] b = a.ToCharArray(); // ПРЕОБРАЗОВАНИЕ STRING -> INT
        c = b[0] - 48;              //
        if (a.Length == 2) { c = c + b[1] - 39; }
        cross_view();
    }
	
	// Update is called once per frame
	void cross_view() {
        if (c < lvl)
        {
            m_Image.sprite = m_yellow;
        }
        else if (c == lvl)
        {
            m_Image.sprite = m_red;
        }
    }
}
