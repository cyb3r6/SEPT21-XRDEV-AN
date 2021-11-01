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
    public Vector2 thumbstick;

    public UnityEvent OnGripDown;
    public UnityEvent OnGripUpdated;
    public UnityEvent OnGripUp;
    public UnityEvent OnThumbstickDown;
    public UnityEvent OnThumbstickUpdated;
    public UnityEvent OnThumbstickUp;
    public UnityEvent OnTriggerDown;
    public UnityEvent OnTriggerUpdated;
    public UnityEvent OnTriggerUp;
    public UnityEvent OnAButtonDown;

    private string gripAxis;
    private string gripButton;
    private string thumbstickButton;
    private string thumbstickX;
    private string thumbstickY;
    private string triggerButton;
    private string AButton;

    private Vector3 previousPosition;
    private Vector3 previousAngularRotation;
    
    void Start()
    {
        gripAxis = $"XRI_{hand}_Grip";
        gripButton = $"XRI_{hand}_GripButton";
        thumbstickButton = $"XRI_{hand}_Primary2DAxisClick";
        thumbstickX = $"XRI_{hand}_Primary2DAxis_Horizontal";
        thumbstickY = $"XRI_{hand}_Primary2DAxis_Vertical";
        triggerButton = $"XRI_{hand}_TriggerButton";
        AButton = $"XRI_{hand}_PrimaryButton";
    }

    
    void Update()
    {
        gripValue = Input.GetAxis(gripAxis);

        thumbstick = new Vector2(Input.GetAxis(thumbstickX), Input.GetAxis(thumbstickY));

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
        if (Input.GetButtonDown(triggerButton))
        {
            OnTriggerDown?.Invoke();
        }
        if (Input.GetButton(triggerButton))
        {
            OnTriggerUpdated?.Invoke();
        }
        if (Input.GetButtonUp(triggerButton))
        {
            OnTriggerUp?.Invoke();
        }
        if (Input.GetButtonDown(AButton))
        {
            OnAButtonDown?.Invoke();
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
