using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour {
    //Variables
    private SpriteRenderer theRenderer;
    private Transform tf;
    bool pause = false;
    //up, down, left and rightSpeed allow the developer to alter the speed of starShip through the inspector window of Unity.
    public float upSpeed = 1;
    public float downSpeed = 1;
    public float leftSpeed = 1;
    public float rightSpeed = 1;

    // Use this for initialization
    void Start () {
        theRenderer = gameObject.GetComponent<SpriteRenderer>();
        tf = GetComponent<Transform>();
        if (theRenderer != null)
        {
            theRenderer.color = Color.green; //Change the color of starShip to green.
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P)) //Check if the player wants to pause or unpause the game.
        {
            if (pause) //If the game is paused, unpause it.
            {
                pause = false;
            }
            else //If the game is not paused, pause it.
            {
                pause = true;
            }
        }



        if (!pause) //If the game is not paused, take the user's input.
        {
            if (Input.GetKey(KeyCode.LeftShift)) //If shift is pressed, the arrow keys will cause starShip to move 1 increment at at time for each time the arrow key is pressed and released.
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    tf.position = tf.position + Vector3.left * leftSpeed;
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    tf.position = tf.position + Vector3.right * rightSpeed;
                }
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    tf.position = tf.position + Vector3.up * upSpeed;
                }
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    tf.position = tf.position + Vector3.down * downSpeed;
                }
            }
            else //If shift is not pressed, the arrow keys will continuously move starShip.
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    tf.position = tf.position + Vector3.left * leftSpeed;
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    tf.position = tf.position + Vector3.right * rightSpeed;
                }
                else if (Input.GetKey(KeyCode.UpArrow))
                {
                    tf.position = tf.position + Vector3.up * upSpeed;
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    tf.position = tf.position + Vector3.down * downSpeed;
                }
            }



            if (Input.GetKeyDown(KeyCode.Space)) //If the user presses the space bar, reset starShip's position to the origin.
            {
                tf.position = Vector3.zero;
            }
        }
    }
}
