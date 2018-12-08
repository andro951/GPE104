using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public GameObject starShipPref;
    public GameObject asteroid;
    public GameObject enemyShip;
    public GameObject enemyShipBoss;
    public GameObject playSpace;
    public GameObject starShip;
    public GameObject gameOverText;
    bool starShipActive = true;
    public int maxNumberOfAsteroids;
    public int maxNumberOfEnemyShips;
    public int score = 0;
    public List<GameObject> asteroidList;
    public List<GameObject> enemyShipList;
    public List<GameObject> starShipList;
    public Vector3[] spawnPoint;
    private int bossCounter = 0;
    public int bossSpawnScore;
    private bool gameOver;
    public int lives;
    public int respawnTimer;

    void Start () {
        //Prevents a second GameManager from being created
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            Debug.Log("A second game manager already exists.  The new game manager was destroyed.");
        }

        //Create spawn points for asteroids and enemyShips
        spawnPoint = new Vector3[16];
        spawnPoint[0].Set (12, 0, 0);
        spawnPoint[1].Set(12, 3, 0);
        spawnPoint[2].Set(12, 6, 0);
        spawnPoint[3].Set(12, -3, 0);
        spawnPoint[4].Set(12, -6, 0);
        spawnPoint[5].Set(-12, 0, 0);
        spawnPoint[6].Set(-12, 3, 0);
        spawnPoint[7].Set(-12, 6, 0);
        spawnPoint[8].Set(-12, -3, 0);
        spawnPoint[9].Set(-12, -6, 0);
        spawnPoint[10].Set(0, 7, 0);
        spawnPoint[11].Set(6, 7, 0);
        spawnPoint[12].Set(-6, 7, 0);
        spawnPoint[13].Set(0, -7, 0);
        spawnPoint[14].Set(6, -7, 0);
        spawnPoint[15].Set(-6, -7, 0);
	}

	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(); //Closes the game when escape is pressed.
        }
        else if (Input.GetKeyDown(KeyCode.Backspace)) //Backspace toggles starShip active or inactive.
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
        else if (starShipList.Count < 1) //If starShip does not exist
        {
            if (lives > 0) //And if there are lives left
            {
                starShip = Instantiate(starShipPref, Vector3.zero, Quaternion.Euler(Vector3.zero)) as GameObject; //Create a new object for starShip. (spawn/respawn)
            }
            else
            {
                gameOver = true; //If there are 0 lives left, the game is over.
                gameOverText.SetActive(true); //Display game over.
            }
        }
        else if (!gameOver) //If the game is NOT over
        {
            if (asteroidList.Count < maxNumberOfAsteroids) //If there are less than the maximum number of allowed asterioids, create a new asteroid
            {
                int randomSpawnPointNumber = Random.Range(0, spawnPoint.Length); //Select the number for a random spawn point
                GameObject newAsteroid = Instantiate(asteroid, spawnPoint[randomSpawnPointNumber], Quaternion.Euler(Vector3.zero)) as GameObject; //Create asteriod
                if (newAsteroid != null) //Currently not used
                {

                }
            }
            if (enemyShipList.Count < maxNumberOfEnemyShips) //If there are less than the maximum number of allowed enemyShips, create a new enemyShip
            {
                int randomSpawnPointNumber = Random.Range(0, spawnPoint.Length); //Select the number for a random spawn point
                if (bossCounter < score / bossSpawnScore) //If the player's score has reached the threshold for spawning a boss, bossSpawnScore, spawn an enemyShipBoss
                {
                    GameObject newEnemyShipBoss = Instantiate(enemyShipBoss, spawnPoint[randomSpawnPointNumber], Quaternion.Euler(Vector3.zero)) as GameObject;
                    bossCounter += 1; //Prevent an enemyShipBoss from spawning until the score threshold is reached again
                    if (newEnemyShipBoss != null) //Currently not used
                    {

                    }
                }
                else //Otherwise, spawn a normal enemyShip
                {
                    GameObject newEnemyShip = Instantiate(enemyShip, spawnPoint[randomSpawnPointNumber], Quaternion.Euler(Vector3.zero)) as GameObject;
                    if (newEnemyShip != null) //Currently not used
                    {

                    }
                }
            }
        }
    }
}
