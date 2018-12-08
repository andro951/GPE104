using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour {
    public Text scoreText;

    void Update()
    {
        scoreText.text = "Lives: " + GameManager.instance.lives; //Display the number of lives.
    }
}
