using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    
    void OnEnable()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Planet")
        {
            Destroy(collision.gameObject);
        }
    }
}
