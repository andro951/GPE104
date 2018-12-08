using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShipBoss : MonoBehaviour {
    private Rigidbody2D rb2D;
    private Vector3 vectorToPlayer;
    public float acceleration;
    private Transform tf;
    public float turnSpeed;
    private Vector3 starShipPositionOld;
    private Vector3 starShipPosition;
    private Vector3 targetVector;
    private Vector3 starShipVector;


    // Use this for initialization
    void Start()
    {
        tf = GetComponent<Transform>();
        rb2D = GetComponent<Rigidbody2D>();
        GameManager.instance.enemyShipList.Add(this.gameObject);
        starShipPosition = GameManager.instance.starShip.transform.position;
        vectorToPlayer = starShipPosition - this.gameObject.transform.position;
        tf.right = vectorToPlayer;
        //In progress.  Does not currently Work.
        //starShipPositionOld = starShipPosition;
    }

    // Update is called once per frame
    void Update()
    {
        

        vectorToPlayer = GameManager.instance.starShip.transform.position - this.gameObject.transform.position;
        vectorToPlayer.Normalize();
        tf.right = tf.right + vectorToPlayer * turnSpeed;
        rb2D.AddForce(tf.right * acceleration);

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
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        GameManager.instance.enemyShipList.Remove(this.gameObject);
        GameManager.instance.score += 100;
    }
}
