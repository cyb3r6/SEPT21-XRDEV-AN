using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 axis;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame. 90FPS, this will run at
    // 90 times per second.
    void Update()
    {
        transform.Rotate(axis * speed * Time.deltaTime);
    }
}
