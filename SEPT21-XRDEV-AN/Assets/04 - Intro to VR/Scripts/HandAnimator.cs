using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimator : MonoBehaviour
{
    private VRinput controller;
    private Animator handAnimator;

    void Start()
    {
        controller = GetComponent<VRinput>();
        handAnimator = GetComponentInChildren<Animator>();
    }

    
    void Update()
    {
        if(controller && handAnimator)
        {
            handAnimator.Play("Fist Closing", 0, controller.gripValue);
        }
    }
}
