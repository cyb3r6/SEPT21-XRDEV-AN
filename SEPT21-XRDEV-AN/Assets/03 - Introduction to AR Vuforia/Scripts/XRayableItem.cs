using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script will be attached to a gameobject in the
/// heiarchy that we want to xray.
/// </summary>

public class XRayableItem : MonoBehaviour
{
    List<MeshRenderer> childRend = new List<MeshRenderer>();
    int startRenderQueue;

    private void Start()
    {
        XRay();
    }
    public void DoXray()
    {
        // make sure the gameobject has a renderer
        if (GetComponentInChildren<MeshRenderer>())
        {
            Material[] materials;

            for (int i = 0; i < this.transform.childCount; i++)
            {
                childRend.Add(GetComponentInChildren<MeshRenderer>());
                Debug.Log(childRend[i]);
                
                materials = childRend[i].materials;
                foreach (Material mat in materials)
                {
                    mat.renderQueue = 2999;
                }
            }
        }
    }

    // Background (1000): rendered before any others
    // Geometry (2000): opaque geometry
    // AlphaTest (2450): Alpha tested geometry
    // Geometrylast: last render queue considered "opaque"
    // Transparent (3000): rendered after Geometry and AlphaTest
    // Overlay (4000): meant for overlay effects.
    public void XRay()
    {
        startRenderQueue = GetComponent<Renderer>().material.renderQueue;

        if (GetComponent<Renderer>())
        {
            GetComponent<Renderer>().material.renderQueue = 3002;
        }
    }

    public void DeXRay()
    {
        if (GetComponent<Renderer>())
        {
            GetComponent<Renderer>().material.renderQueue = startRenderQueue;
        }
    }
}
