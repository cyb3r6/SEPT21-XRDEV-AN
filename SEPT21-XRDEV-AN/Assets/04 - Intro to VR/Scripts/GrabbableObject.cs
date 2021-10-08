using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    public Color hoverColor;
    public Color nonHoverColor;
    private Material objectMaterial;
    
    void Start()
    {
        objectMaterial = GetComponent<Renderer>().material;
        nonHoverColor = objectMaterial.color;
    }

    public void OnHoverStart()
    {
        if (objectMaterial)
        {
            objectMaterial.color = hoverColor;
        }
    }

    public void OnHoverEnd()
    {
        if (objectMaterial)
        {
            objectMaterial.color = nonHoverColor;
        }
    }
   
}
