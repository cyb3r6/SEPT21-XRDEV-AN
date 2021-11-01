using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchButton : MonoBehaviour
{
    public Transform button;
    public Transform downPosition;
    public AudioClip clip;
    public UnityEvent OnButtonPressed;

    private Vector3 originalPosition;
    private AudioSource audioSource;

    void Start()
    {
        originalPosition = button.position;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            button.position = downPosition.position;

            // do something here
            audioSource.PlayOneShot(clip);
            OnButtonPressed?.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            button.position = originalPosition;
        }
    }
}
