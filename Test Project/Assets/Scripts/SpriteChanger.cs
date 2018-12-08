using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour {
    //Variables
    private SpriteRenderer theRenderer;
    private Transform tf;
    bool pause = false;
    //up, down, left and rightSpeed allow the developer to alter the speed of starShip through the inspector window of Unity.
    public float turnSpeed;
    public float speed;
    public float ForwardAcceleration;
    public float reverseAcceleration;
    public float sideAcceleration;
    private Rigidbody2D rb2D;

    // Use this for initialization
    void Start () {
        GameManager.instance.starShipList.Add(this.gameObject);
        theRenderer = gameObject.GetComponent<SpriteRenderer>();
        tf = GetComponent<Transform>();
        rb2D = GetComponent<Rigidbody2D>();
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
            if (Input.GetKey(KeyCode.A))
            {
                tf.Rotate(0, 0, turnSpeed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                tf.Rotate(0, 0, -turnSpeed);
            }
            if (Input.GetKey(KeyCode.W))
            {
                rb2D.AddForce(tf.right * ForwardAcceleration);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb2D.AddForce(-tf.right * reverseAcceleration);
            }
            if (Input.GetKey(KeyCode.E))
            {
                rb2D.AddForce(-tf.up * sideAcceleration);
            }
            if (Input.GetKey(KeyCode.Q))
            {
                rb2D.AddForce(tf.up * sideAcceleration);
            }

            if (Input.GetKeyDown(KeyCode.Space)) //If the user presses the space bar, reset starShip's position to the origin.
            {
                tf.position = Vector3.zero;
            }
        }

    }

    private void OnDestroy()
    {
        int lengthOfAsterioidList = GameManager.instance.asteroidList.Count;
        for (int i = 0; i < lengthOfAsterioidList; i++)
        {
            Destroy(GameManager.instance.asteroidList[lengthOfAsterioidList - 1 -i].gameObject);
        }
        int lengthOfEnemyShipList = GameManager.instance.enemyShipList.Count;
        for (int i = 0; i < lengthOfEnemyShipList; i++)
        {
            Destroy(GameManager.instance.enemyShipList[lengthOfEnemyShipList - 1 - i].gameObject);
        }
        GameManager.instance.lives -= 1;
        GameManager.instance.starShipList.Remove(this.gameObject);
    }
}
