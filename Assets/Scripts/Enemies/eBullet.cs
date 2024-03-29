﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eBullet : MonoBehaviour
{
    //Just some variable naming
    public float ebulletSpeed;
    private Rigidbody ebulletRB;
    public float eDespawnTime;

    void Start()
    {
        //This part assigns the bullet's Rigidbody value to the bulletRB variable...
        ebulletRB = GetComponent<Rigidbody>();

        //...which allows us to manipulate the velocity of the bullet, propelling it forward with the bullet speed
        ebulletRB.velocity = transform.forward * ebulletSpeed;

        //This coroutine begins when the bullets spawn
        StartCoroutine(DPBulletDespawn());
    }

    //This is the coroutine started earlier
    IEnumerator DPBulletDespawn()
    {
        //It waits for a set number of seconds (despawnTime) and then destroys the game object
        //This can help set the range of a bullet or debug it incase it goes through a wall
        yield return new WaitForSeconds(eDespawnTime);
        Destroy(gameObject);
    }


    //This section determines what happens when a bullet collide with objects
    private void OnCollisionEnter(Collision col)
    {
        //If it collides with a wall, it destroys itself in confusion
        if (col.transform.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}