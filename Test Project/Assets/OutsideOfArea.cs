using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideOfArea : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other2D)
    {
            Destroy(other2D.gameObject);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
