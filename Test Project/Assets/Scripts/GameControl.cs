using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameManager instance;
    public GameObject starShip;
    bool starShipActive = true;

	// Use this for initialization
	void Start () {
		if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            Debug.Log("A second game manager already exists.  The new game manager was destroyed.");
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(); //Closes sprite mover when Q is pressed.
        }
        if (Input.GetKeyDown(KeyCode.Q)) //Q toggles starShip active or inactive.
        {
            if (starShipActive) //If starShip is active, set it to inactive.
            {
                starShip.SetActive(false);
                starShipActive = false;
            }
            else //If starShip is inactive, set it to active.
            {
                starShip.SetActive(true);
                starShipActive = true;
            }
        }
    }
}
