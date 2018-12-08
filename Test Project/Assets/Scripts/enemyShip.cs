using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour {
    private Rigidbody2D rb2D;
    private Vector3 vectorToPlayer;
    public float acceleration;
    private Transform tf;
    public float turnSpeed;

    // Use this for initialization
    void Start()
    {
        tf = GetComponent<Transform>(); //Get the object's transform
        rb2D = GetComponent<Rigidbody2D>(); //Get the rigidbody2d component
        GameManager.instance.enemyShipList.Add(this.gameObject); //Add to enemyShipList to track that this object exists
        vectorToPlayer = GameManager.instance.starShip.transform.position - this.gameObject.transform.position; //Create a vector from this object to the starShip
        tf.right = vectorToPlayer; //Face this object towards starShip
    }

    // Update is called once per frame
    void Update()
    {
        vectorToPlayer = GameManager.instance.starShip.transform.position - this.gameObject.transform.position; //Recalculate a vector to starShip
        vectorToPlayer.Normalize(); //Make the vector a standar size for easier use
        tf.right = tf.right + vectorToPlayer * turnSpeed; //turn towards the vector based on turnspeed
        rb2D.AddForce(tf.right * acceleration); //Add thrust to this object based on acceleration
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject); //If this object collides with starShip, destroy starShip
        }
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        GameManager.instance.enemyShipList.Remove(this.gameObject); //Remove from enemyShipList to track that this object no longer exists
        GameManager.instance.score += 50; //Reward 50 points
    }
}
