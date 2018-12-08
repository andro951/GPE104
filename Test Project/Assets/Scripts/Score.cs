using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public Text scoreText;
	
	void Start ()
    {
		
	}
	
	void Update ()
    {
        scoreText.text = "Score: " + GameManager.instance.score; //Display the Player's score
    }
}
