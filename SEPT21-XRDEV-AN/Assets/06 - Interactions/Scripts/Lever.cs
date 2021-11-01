using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : GrabbableObject
{
    public Vector3 centerOfMass = new Vector3(0,0,0);
    public HingeJoint leverJoint;
    private Rigidbody leverRigidbody;


    void Start()
    {
        leverRigidbody = GetComponent<Rigidbody>();
        leverRigidbody.centerOfMass = centerOfMass;
        leverJoint = GetComponent<HingeJoint>();
    }

    public float NormalizedJointAngle()
    {
        float normalizedAngle = leverJoint.angle / leverJoint.limits.max;
        return normalizedAngle;
    }
}
