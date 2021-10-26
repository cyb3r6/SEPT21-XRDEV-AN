using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerGun : GrabbableObject
{
    public List<GameObject> shootingPrefabs = new List<GameObject>();
    public Transform spawnPoint;
    public float shootingForce = 1500f;
    private int index = 0;

    public override void OnInteraction()
    {
        index = Random.Range(0, shootingPrefabs.Count);
        GameObject burger = Instantiate(shootingPrefabs[index], spawnPoint.position, spawnPoint.rotation);
        burger.GetComponent<Rigidbody>().AddForce(burger.transform.forward * shootingForce);
        //index++;

        //if(index == shootingPrefabs.Count)
        //{
        //    index = 0;
        //}

        Destroy(burger, 3);
    }

    
}
