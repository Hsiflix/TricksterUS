using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassAnimation : MonoBehaviour
{

    Material m_Material;

    void Start()
    {
        m_Material = GetComponent<Renderer>().sharedMaterial;
    }

    void Update()
    {
        m_Material.mainTextureOffset = new Vector2(m_Material.mainTextureOffset.x+0.0001f, 
                                    m_Material.mainTextureOffset.y+0.0001f);
    }
}
