using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControls : MonoBehaviour
{
    public float thrust;
    public float turningTorque;
    public float dragForce;
    public bool engineON;
    public Light engineLight;
    public Rigidbody laserPrefab;
    public Transform spawnPoint;
    public float shootingForce = 500f;
    private Rigidbody rocketRigidbody;
    

    void Start()
    {
        rocketRigidbody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        engineON = false;

        if (Input.GetKey(KeyCode.W))
        {
            // move forward
            rocketRigidbody.AddForce(transform.forward * Time.deltaTime * thrust);
            engineON = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            // move backwards
            rocketRigidbody.AddForce(transform.forward * Time.deltaTime * -thrust);
            engineON = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            // move left
            rocketRigidbody.AddForce(transform.right * Time.deltaTime * -thrust);
            engineON = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            // move right
            rocketRigidbody.AddForce(transform.right * Time.deltaTime * thrust);
            engineON = true;
        }

        engineLight.enabled = engineON;

        // drag
        rocketRigidbody.AddForce(-rocketRigidbody.velocity * Time.deltaTime * dragForce);

        // get the mouse movement
        float horizontal = Input.GetAxis("Mouse X");
        Debug.Log("the mouse horizontal value is: " + horizontal);
        float vertical = Input.GetAxis("Mouse Y");

        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (horizontal != 0)
            {
                // rotate left and right
                rocketRigidbody.AddRelativeTorque(0, horizontal * Time.deltaTime * turningTorque, 0);
            }
            if (vertical != 0)
            {
                // rotate up and down
                rocketRigidbody.AddRelativeTorque(vertical * Time.deltaTime * turningTorque, 0, 0);
            }
        }

        // shoot laser
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireLaser();
        }
    }

    private void FireLaser()
    {
        Rigidbody laser = Instantiate(laserPrefab, spawnPoint.position, spawnPoint.rotation);
        laser.AddForce(transform.forward * shootingForce);
    }
}
