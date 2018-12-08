using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarShip : MonoBehaviour {
    private SpriteRenderer theRenderer;
    private Transform tf;
    public float turnSpeed;
    public float speed;
    public float ForwardAcceleration;
    public float reverseAcceleration;
    public float sideAcceleration;
    private Rigidbody2D rb2D;

    void Start ()
    {
        GameManager.instance.starShipList.Add(this.gameObject); //Add this instance of starShip to starShipList to track that it exists.
        theRenderer = gameObject.GetComponent<SpriteRenderer>(); 
        tf = GetComponent<Transform>();
        rb2D = GetComponent<Rigidbody2D>();
        if (theRenderer != null)
        {
            theRenderer.color = Color.green; //Change the color of starShip to green.
        }
	}
	
	void Update ()
    {

        //Player Constrls:
        if (Input.GetKey(KeyCode.A))
        {
            tf.Rotate(0, 0, turnSpeed); //A: Rotatie left
        }
        if (Input.GetKey(KeyCode.D))
        {
            tf.Rotate(0, 0, -turnSpeed); //D: Rotate Right
        }
        if (Input.GetKey(KeyCode.W))//W: Move Forward
        {
            rb2D.AddForce(tf.right * ForwardAcceleration);
        }
        if (Input.GetKey(KeyCode.S))//S: Move Backward
        {
            rb2D.AddForce(-tf.right * reverseAcceleration);
        }
        if (Input.GetKey(KeyCode.E))//E: Straif Right
        {
            rb2D.AddForce(-tf.up * sideAcceleration);
        }
        if (Input.GetKey(KeyCode.Q))//Q: Straif Left
        {
            rb2D.AddForce(tf.up * sideAcceleration);
        }
    }

    private void OnDestroy()// When spaceShip is destroyed
    {
        //Destroy all asteroids
        int lengthOfAsterioidList = GameManager.instance.asteroidList.Count;
        for (int i = 0; i < lengthOfAsterioidList; i++)
        {
            Destroy(GameManager.instance.asteroidList[lengthOfAsterioidList - 1 -i].gameObject);
        }
        //Destroy all enemyShips
        int lengthOfEnemyShipList = GameManager.instance.enemyShipList.Count;
        for (int i = 0; i < lengthOfEnemyShipList; i++)
        {
            Destroy(GameManager.instance.enemyShipList[lengthOfEnemyShipList - 1 - i].gameObject);
        }
        //Reduce lives by 1
        GameManager.instance.lives -= 1;
        //Remove the object from starShipList so the GameManager knows it no longer exists.
        GameManager.instance.starShipList.Remove(this.gameObject);
    }
}
