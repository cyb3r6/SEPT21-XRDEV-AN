using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRinput : MonoBehaviour
{
    public Hand hand = Hand.Left;
    public float gripValue;
    public Vector3 velocity;
    public Vector3 angularVelocity;

    public UnityEvent OnGripDown;
    public UnityEvent OnGripUpdated;
    public UnityEvent OnGripUp;
    public UnityEvent OnThumbstickDown;
    public UnityEvent OnThumbstickUpdated;
    public UnityEvent OnThumbstickUp;

    private string gripAxis;
    private string gripButton;
    private string thumbstickButton;
    private Vector3 previousPosition;
    private Vector3 previousAngularRotation;

    void Start()
    {
        gripAxis = $"XRI_{hand}_Grip";
        gripButton = $"XRI_{hand}_GripButton";
        thumbstickButton = $"XRI_{hand}_Primary2DAxisClick";
    }

    
    void Update()
    {
        gripValue = Input.GetAxis(gripAxis);

        if (Input.GetButtonDown(gripButton))
        {
            OnGripDown?.Invoke();
        }
        if (Input.GetButton(gripButton))
        {
            OnGripUpdated?.Invoke();
        }
        if (Input.GetButtonUp(gripButton))
        {
            OnGripUp?.Invoke();
        }
        if (Input.GetButtonDown(thumbstickButton))
        {
            OnThumbstickDown?.Invoke();
        }
        if (Input.GetButton(thumbstickButton))
        {
            OnThumbstickUpdated?.Invoke();
        }
        if (Input.GetButtonUp(thumbstickButton))
        {
            OnThumbstickUp?.Invoke();
        }

        velocity = (this.transform.position - previousPosition) / Time.deltaTime;
        previousPosition = this.transform.position;

        angularVelocity = (this.transform.eulerAngles - previousAngularRotation) / Time.deltaTime;
        previousAngularRotation = this.transform.eulerAngles;

    }
}

[System.Serializable]
public enum Hand
{
    Left,
    Right
}
