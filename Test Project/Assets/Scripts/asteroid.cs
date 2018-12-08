using System.Collections;
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
        tf = GetComponent<Transform>(); //Get the object's transform
        rb2D = GetComponent<Rigidbody2D>(); //Get the rigidbody2d component
        GameManager.instance.asteroidList.Add(this.gameObject); //Add to asteroidList to track that this object exists
        vectorToPlayer = GameManager.instance.starShip.transform.position - this.gameObject.transform.position; //Create a vector from this object to the starShip
        tf.right = vectorToPlayer; //Face this object towards starShip
    }
	
	// Update is called once per frame
	void Update ()
    {
        rb2D.AddForce(tf.right * acceleration); //Add thrust to this object based on acceleration
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject); //If this object collides with starShip, destroy starShip
        }
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        GameManager.instance.asteroidList.Remove(this.gameObject); //Remove from asteroidList to track that this object no longer exists
        GameManager.instance.score += 10; //Reward 10 points
    }

}
