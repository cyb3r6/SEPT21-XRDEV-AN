using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float moveSpeed;
    public float moveAmount;
    public SpawnArea game;

    private float startingXPosition;


    void Awake()
    {
        startingXPosition = transform.position.x;
    }

    void Update()
    {
        var newPosition = transform.position;
        newPosition.x = startingXPosition + Mathf.Sin(Time.time * moveSpeed) *  moveAmount;
        transform.position = newPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var foodStuff = collision.gameObject.GetComponent<Food>();
        if(foodStuff != null)
        {
            Debug.Log("Hit!");
            Destroy(foodStuff.gameObject);
            Destroy(gameObject);
            game.SpawnTarget();

        }
    }
}
