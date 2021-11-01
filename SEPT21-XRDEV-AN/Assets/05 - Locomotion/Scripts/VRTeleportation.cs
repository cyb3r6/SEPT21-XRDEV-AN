using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRTeleportation : MonoBehaviour
{
    private VRinput controller;
    private LineRenderer line;
    private Vector3 hitPosition;
    private Vector3 lastHitPosition;
    private Vector3 smoothedEndPosition;

    public Renderer screen;
    public bool shouldTeleport;
    public Transform xrRig;
    public GameObject reticle;
    public float height = 1f;
    public float smoothAmount = 5f;

    [Range(5, 40)]
    public int lineResolution = 10;

    void Start()
    {
        controller = GetComponent<VRinput>();
        line = GetComponent<LineRenderer>();

        // turning off the line
        line.enabled = false;
        reticle.SetActive(false);
        line.positionCount = lineResolution+1;

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

            // smooth out the endpoint
            Vector3 directionToHitPosition = (hitPosition - lastHitPosition) / smoothAmount;
            smoothedEndPosition = lastHitPosition + directionToHitPosition;
            lastHitPosition = smoothedEndPosition;


            // line visuals
            CurveLine(smoothedEndPosition);
            line.enabled = true;

            reticle.SetActive(true);
            reticle.transform.position = smoothedEndPosition;
            reticle.transform.LookAt(hit.normal + hitPosition);

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
            StartCoroutine(FadeTeleport());
            shouldTeleport = false;
            line.enabled = false;
            reticle.SetActive(false);
        }
    }

    private IEnumerator FadeTeleport()
    {
        float currentTime = 0f;
        while (currentTime < 1)
        {
            currentTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
            screen.material.color = Color.Lerp(Color.clear, Color.black, currentTime);
        }
        xrRig.position = smoothedEndPosition;

        yield return new WaitForSeconds(0.5f);

        while(currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
            screen.material.color = Color.Lerp(Color.clear, Color.black, currentTime);
        }
    }

    private void CurveLine(Vector3 hitPoint)
    {
        Vector3 A = controller.transform.position;
        Vector3 C = hitPoint;
        Vector3 B = (C - A) / 2 + A;

        B.y += height;

        for(int i = 0; i <= lineResolution; i++)
        {
            float t = (float)i / (float)lineResolution;
            Vector3 AtoB = Vector3.Lerp(A, B, t);
            Vector3 BtoC = Vector3.Lerp(B, C, t);
            Vector3 curvePosition = Vector3.Lerp(AtoB, BtoC, t);

            line.SetPosition(i, curvePosition);
        }
    }
}
