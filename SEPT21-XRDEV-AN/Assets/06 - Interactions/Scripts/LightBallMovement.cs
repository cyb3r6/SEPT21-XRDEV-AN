using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBallMovement : MonoBehaviour
{
    public Lever forwardBackwardLever;
    public float speed;


    
    void Update()
    {
        transform.position = transform.position + transform.forward * Time.deltaTime * speed * forwardBackwardLever.NormalizedJointAngle();
    }
}
