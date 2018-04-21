﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootForward : MonoBehaviour
{
    public Rigidbody bullet;
    public float velocity = 10.0f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody newBullet = Instantiate(bullet, transform.position, bullet.rotation) as Rigidbody;
            newBullet.AddForce(transform.forward * velocity, ForceMode.VelocityChange);
        }
	}
}
