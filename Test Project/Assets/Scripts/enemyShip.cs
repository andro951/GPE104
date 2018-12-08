using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShip : MonoBehaviour {
    private Rigidbody2D rb2D;
    private Vector3 vectorToPlayer;
    public float acceleration;
    private Transform tf;
    public float turnSpeed;

    // Use this for initialization
    void Start()
    {
        tf = GetComponent<Transform>();
        rb2D = GetComponent<Rigidbody2D>();
        GameManager.instance.enemyShipList.Add(this.gameObject);
        vectorToPlayer = GameManager.instance.starShip.transform.position - this.gameObject.transform.position;
        tf.right = vectorToPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        vectorToPlayer = GameManager.instance.starShip.transform.position - this.gameObject.transform.position;
        vectorToPlayer.Normalize();
        tf.right = tf.right + vectorToPlayer * turnSpeed;
        rb2D.AddForce(tf.right * acceleration);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        GameManager.instance.enemyShipList.Remove(this.gameObject);
        GameManager.instance.score += 50;
    }
}
