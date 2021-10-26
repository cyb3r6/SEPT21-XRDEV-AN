using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRSmoothMotion : MonoBehaviour
{
    public Transform xrRig;
    public Transform director;

    private VRinput controller;
    private Vector3 playerForward;
    private Vector3 playerRight;

    
    void Start()
    {
        controller = GetComponent<VRinput>();
    }

    
    void Update()
    {
        playerForward = director.forward;
        playerForward.y = 0f;
        playerForward.Normalize();

        playerRight = director.right;
        playerRight.y = 0;
        playerRight.Normalize();

        // move forwards and backwards
        xrRig.position += playerForward * controller.thumbstick.y * Time.deltaTime;
        // move right and left
        xrRig.position += playerRight * controller.thumbstick.x * Time.deltaTime;
    }
}
