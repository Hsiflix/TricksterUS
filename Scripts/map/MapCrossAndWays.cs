using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MapCrossAndWays : MonoBehaviour {

    Image m_Image;
    public Sprite m_red;
    public Sprite m_yellow;

    void Start () {
        m_Image = GetComponent<Image>();
        cross_view(int.Parse(GetComponent<Image>().name));
    }
	
	void cross_view(int name) {
        if (name < info.lvl)
        {
            m_Image.sprite = m_yellow;
        }
        else if (name == info.lvl)
        {
            m_Image.sprite = m_red;
        }
    }
}
