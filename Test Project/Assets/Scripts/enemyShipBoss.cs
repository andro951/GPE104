using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipBoss : MonoBehaviour {
    private Rigidbody2D rb2D;
    private Vector3 vectorToPlayer;
    public float acceleration;
    private Transform tf;
    public float turnSpeed;
    private Vector3 starShipPositionOld;
    private Vector3 starShipPosition;
    private Vector3 targetVector;
    private Vector3 starShipVector;

    void Start()
    {
        tf = GetComponent<Transform>(); //Get the object's transform
        rb2D = GetComponent<Rigidbody2D>(); //Get the rigidbody2d component
        GameManager.instance.enemyShipList.Add(this.gameObject); //Add to enemyShipList to track that this object exists
        starShipPosition = GameManager.instance.starShip.transform.position; //Used to store the starShip's position
        vectorToPlayer = starShipPosition - this.gameObject.transform.position; //Create a vector from this object to the starShip
        tf.right = vectorToPlayer; //Face this object towards starShip

        //In progress.  Does not currently Work.
        //starShipPositionOld = starShipPosition;
    }

    void Update()
    {
        

        vectorToPlayer = GameManager.instance.starShip.transform.position - this.gameObject.transform.position; //Recalculate a vector to starShip
        vectorToPlayer.Normalize(); //Make the vector a standar size for easier use
        tf.right = tf.right + vectorToPlayer * turnSpeed; //turn towards the vector based on turnspeed
        rb2D.AddForce(tf.right * acceleration); //Add thrust to this object based on acceleration

        //In progress.  Does not currently Work.
        //vectorToPlayer = GameManager.instance.starShip.transform.position - this.gameObject.transform.position;
        //vectorToPlayer.Normalize();
        //starShipVector = starShipPosition - starShipPositionOld;
        //targetVector = vectorToPlayer - Mathf.Asin(Mathf.Sin(Vector3.Angle(vectorToPlayer, starShipVector)));
        //tf.right = tf.right + targetVector * turnSpeed;
        //rb2D.AddForce(tf.right * acceleration);
        //starShipPositionOld = starShipPosition;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject); //If this object collides with starShip, destroy starShip
        }
        Destroy(gameObject); //If this object collides, destroy it
    }

    void OnDestroy()
    {
        GameManager.instance.enemyShipList.Remove(this.gameObject); //Remove from enemyShipList to track that this object no longer exists
        GameManager.instance.score += 100; //Reward 100 points
    }
}
