using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : GrabbableObject
{
    private Light flashLight;
    void Start()
    {
        flashLight = GetComponentInChildren<Light>();
    }

    public override void OnInteraction()
    {
        flashLight.enabled = !flashLight.enabled;
    }
}
