using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour {
    //Variables
    public GameObject starShip;
    private SpriteRenderer theRenderer;
    private Transform tf;
    bool pause = false;

	// Use this for initialization
	void Start () {
        theRenderer = gameObject.GetComponent<SpriteRenderer>();
        tf = GetComponent<Transform>();
        if (theRenderer != null)
        {
            theRenderer.color = Color.green;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            starShip.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.P)) //Check if the player wants to pause or unpause the game.
        {
            if (pause)
            {
                pause = false;
            }
            else
            {
                pause = true;
            }
        }

        if (!pause) //If the game is not paused, take the user's input.
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    tf.position = tf.position + Vector3.left;
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    tf.position = tf.position + Vector3.right;
                }
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    tf.position = tf.position + Vector3.up;
                }
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    tf.position = tf.position + Vector3.down;
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    tf.position = tf.position + Vector3.left;
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    tf.position = tf.position + Vector3.right;
                }
                else if (Input.GetKey(KeyCode.UpArrow))
                {
                    tf.position = tf.position + Vector3.up;
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    tf.position = tf.position + Vector3.down;
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                tf.position = Vector3.zero;
            }
        }
    }
}
