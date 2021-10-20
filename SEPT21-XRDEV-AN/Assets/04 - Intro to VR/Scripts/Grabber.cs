using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    public VRinput controller;
    public float throwForce;
    public GrabbableObject collidingObject;
    public GrabbableObject heldObject;

    private void OnTriggerEnter(Collider other)
    {
        var grab = other.GetComponent<GrabbableObject>();
        if (grab)
        {
            grab.OnHoverStart();
            collidingObject = grab;
            Debug.Log($"colliding object is {collidingObject}, grabbed is {grab}");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var grab = other.GetComponent<GrabbableObject>();
        if(grab == collidingObject)
        {
            grab.OnHoverEnd();
            collidingObject = null;
        }
    }

    
    void Awake()
    {
        controller = GetComponent<VRinput>();

        controller.OnGripDown.AddListener(Grab);
        controller.OnGripUp.AddListener(Release);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Grab()
    {
        if(collidingObject != null)
        {
            heldObject = collidingObject;
            heldObject.JointGrab(controller);
        }
    }

    public void Release()
    {
        if (heldObject)
        {
            heldObject.JointRelease(controller);

            // throw
            heldObject.objectRigidbody.velocity = controller.velocity * throwForce;
            heldObject.objectRigidbody.angularVelocity = controller.angularVelocity * throwForce;

            heldObject = null;
        }
    }
}
