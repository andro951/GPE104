﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour {
    private Rigidbody2D rb2D;
    private Vector3 vectorToPlayer;
    public float acceleration;
    private Transform tf;

    // Use this for initialization
    void Start ()
    {
        tf = GetComponent<Transform>();
        rb2D = GetComponent<Rigidbody2D>();
        GameManager.instance.asteroidList.Add(this.gameObject);
        vectorToPlayer = GameManager.instance.starShipPref.transform.position - this.gameObject.transform.position;
        tf.right = vectorToPlayer;
    }
	
	// Update is called once per frame
	void Update ()
    {
        rb2D.AddForce(tf.right * acceleration);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        GameManager.instance.asteroidList.Remove(this.gameObject);
        GameManager.instance.score += 10;
    }

}