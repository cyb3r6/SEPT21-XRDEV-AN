using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float maxMoveSpeed = 3;
    public float moveAmount;
    public SpawnArea game;

    private float startingXPosition;
    public float speed;

    void Awake()
    {
        startingXPosition = transform.position.x;

        speed = Random.Range(0, maxMoveSpeed);
    }

    void Update()
    {
        var newPosition = transform.position;
        newPosition.x = startingXPosition + Mathf.Sin(Time.time * speed) *  moveAmount;
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
            game.AddToScore(speed);
        }
    }
}
