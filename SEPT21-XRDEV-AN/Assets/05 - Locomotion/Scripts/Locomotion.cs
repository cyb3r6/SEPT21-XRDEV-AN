using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotion : MonoBehaviour
{
    private VRinput controller;
    public Transform xrRig;
    public float playerSpeed;

    private LineRenderer line;

    // curve line
    public float height = 1f;
    public float smoothAmount = 5f;

    [Range(5, 40)]
    public int lineResolution = 10;

    void Start()
    {
        controller = GetComponent<VRinput>();
        line = GetComponent<LineRenderer>();
        line.enabled = false;
    }

    
    void Update()
    {
        HandleRotation();
        HandleMovement();

    }

    /// <summary>
    /// Snap turns
    /// </summary>
    void HandleRotation()
    {
        // detect if the thumstick is pressed
        if (Input.GetButtonDown($"XRI_{controller.hand}_Primary2DAxisClick"))
        {
            float direction = Input.GetAxis($"XRI_{controller.hand}_Primary2DAxis_Horizontal");

            if(direction > 0)
            {
                // rotate right
                xrRig.Rotate(0, 30, 0);
            }
            else
            {
                // rotate left
                xrRig.Rotate(0,-30,0);
            }

            // turnary operator

            //Detect the direction 
            float rotation = Input.GetAxis($"XRI_{controller.hand}_Primary2DAxis_Horizontal") > 0 ? 30 : -30;

            //apply the rotation to the xrrig
            xrRig.Rotate(0, rotation, 0);
        }
    }

    /// <summary>
    /// Smooth motion
    /// </summary>
    void HandleMovement()
    {
        Vector3 forwardDirection = new Vector3(xrRig.forward.x, 0, xrRig.forward.z);
        Vector3 rightDirection  = new Vector3(xrRig.right.x, 0, xrRig.right.z);

        forwardDirection.Normalize();
        rightDirection.Normalize();

        float horizontalValue = Input.GetAxis($"XRI_{controller.hand}_Primary2DAxis_Horizontal");
        float verticalValue = Input.GetAxis($"XRI_{controller.hand}_Primary2DAxis_Vertical");

        //forward and backwards
        xrRig.position = xrRig.position + (verticalValue * playerSpeed * -forwardDirection * Time.deltaTime);

        //right and left
        xrRig.position = xrRig.position + (horizontalValue * playerSpeed * rightDirection * Time.deltaTime);

    }

    /// <summary>
    /// Straight line teleportation
    /// </summary>
    void HandleRaycast()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        // if ray hits something
        if (Physics.Raycast(ray, out hitInfo, 10))
        {
            line.enabled = true;
            line.SetPosition(0, transform.position);
            line.SetPosition(1, hitInfo.point);

            // if i've hit something valid, true if valid
            bool validTarget = hitInfo.collider.CompareTag("Teleportation");

            Color color = validTarget ? Color.blue : Color.red;
            
            line.material.color = color;

            if (validTarget && Input.GetButtonDown($"XRI_{controller.hand}_TriggerButton"))
            {
                xrRig.position = hitInfo.point;
            }
        }
        else // we havent' hit something
        {
            line.enabled = false;
        }
    }

    private void CurveLine(Vector3 hitPoint)
    {
        Vector3 A = controller.transform.position;
        Vector3 C = hitPoint;
        Vector3 B = (C - A) / 2 + A;

        B.y += height;

        for (int i = 0; i <= lineResolution; i++)
        {
            float t = (float)i / (float)lineResolution;
            Vector3 AtoB = Vector3.Lerp(A, B, t);
            Vector3 BtoC = Vector3.Lerp(B, C, t);
            Vector3 curvePosition = Vector3.Lerp(AtoB, BtoC, t);

            line.SetPosition(i, curvePosition);
        }
    }
}
