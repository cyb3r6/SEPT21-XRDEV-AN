using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{

    public GrabbableObject collidingObject;
    public GrabbableObject heldObject;

    private void OnTriggerEnter(Collider other)
    {
        var grab = other.GetComponent<GrabbableObject>();
        if (grab)
        {
            grab.OnHoverStart();
            collidingObject = grab;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
