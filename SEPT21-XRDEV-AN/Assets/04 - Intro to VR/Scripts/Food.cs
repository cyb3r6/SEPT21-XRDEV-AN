using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : GrabbableObject
{
    public AudioSource foodAudioSource;
    public List<AudioClip> foodSmashSounds = new List<AudioClip>();



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude > 1f)
        {
            if(foodSmashSounds != null)
            {
                int randomIndex = Random.Range(0, foodSmashSounds.Count);

                foodAudioSource.PlayOneShot(foodSmashSounds[randomIndex]);
            }
            

            Destroy(this.gameObject);
        }
    }
}
