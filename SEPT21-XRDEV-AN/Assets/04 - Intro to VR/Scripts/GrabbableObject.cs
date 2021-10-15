using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    public Rigidbody objectRigidbody;
    public Color hoverColor;
    public Color nonHoverColor;
    private Material objectMaterial;
    
    void Start()
    {
        objectMaterial = GetComponent<Renderer>().material;
        nonHoverColor = objectMaterial.color;

        objectRigidbody = GetComponent<Rigidbody>();
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

    public void ParentGrab(VRinput controller)
    {
        transform.SetParent(controller.transform);
        objectRigidbody.useGravity = false;
        objectRigidbody.isKinematic = true;
    }
    public void ParentRelease(VRinput controller)
    {
        transform.SetParent(null);
        objectRigidbody.isKinematic = false;
        objectRigidbody.useGravity = true;
    }

    public void JointGrab(VRinput controller)
    {
        FixedJoint fx = controller.gameObject.AddComponent<FixedJoint>();
        fx.connectedBody = objectRigidbody;
    }
    public void JointRelease(VRinput controller)
    {
        FixedJoint fx = controller.GetComponent<FixedJoint>();
        Destroy(fx);
    }
   
}
