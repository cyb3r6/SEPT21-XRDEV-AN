using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRTeleportation : MonoBehaviour
{
    private VRinput controller;
    private LineRenderer line;
    private Vector3 hitPosition;
    public bool shouldTeleport;
    public Transform xrRig;
    public GameObject reticle;

    void Start()
    {
        controller = GetComponent<VRinput>();
        line = GetComponent<LineRenderer>();

        // turning off the line
        line.enabled = false;
        reticle.SetActive(false);

        // start listening to thumbstick updated and up
        controller.OnThumbstickUpdated.AddListener(RaycastTeleport);
        controller.OnThumbstickUp.AddListener(Teleport);
    }

    /// <summary>
    /// When the thumbstick is held down,
    /// show the raycast line
    /// </summary>
    public void RaycastTeleport()
    {
        RaycastHit hit;
        if (Physics.Raycast(controller.transform.position, controller.transform.forward, out hit))
        {
            hitPosition = hit.point;

            // line visuals
            line.SetPosition(0, controller.transform.position);
            line.SetPosition(1, hitPosition);
            line.enabled = true;

            reticle.SetActive(true);
            reticle.transform.position = hitPosition;

            shouldTeleport = true;
        }
    }

    /// <summary>
    /// moving the xrrig transform to the hit postion of the raycast
    /// </summary>
    public void Teleport()
    {
        if (shouldTeleport == true)
        {
            xrRig.position = hitPosition;
            shouldTeleport = false;
            line.enabled = false;
        }
    }
}
