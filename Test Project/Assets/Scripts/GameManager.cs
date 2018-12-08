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

    // Use this for initialization
    void Start () {
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
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(); //Closes sprite mover when Q is pressed.
        }
        else if (Input.GetKeyDown(KeyCode.Backspace)) //Q toggles starShip active or inactive.
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
        else if (starShipList.Count < 1)
        {
            if (lives > 0)
            {
                starShip = Instantiate(starShipPref, Vector3.zero, Quaternion.Euler(Vector3.zero)) as GameObject;
            }
            else
            {
                gameOver = true;
                gameOverText.SetActive(true);
            }
        }
        else if (!gameOver)
        {
            if (asteroidList.Count < maxNumberOfAsteroids)
            {
                int randomSpawnPointNumber = Random.Range(0, spawnPoint.Length);
                GameObject newAsteroid = Instantiate(asteroid, spawnPoint[randomSpawnPointNumber], Quaternion.Euler(Vector3.zero)) as GameObject;
                if (newAsteroid != null)
                {

                }
            }
            if (enemyShipList.Count < maxNumberOfEnemyShips)
            {
                int randomSpawnPointNumber = Random.Range(0, spawnPoint.Length);
                if (bossCounter < score / bossSpawnScore)
                {
                    GameObject newEnemyShipBoss = Instantiate(enemyShipBoss, spawnPoint[randomSpawnPointNumber], Quaternion.Euler(Vector3.zero)) as GameObject;
                    bossCounter += 1;
                    if (newEnemyShipBoss != null)
                    {

                    }
                }
                else
                {
                    GameObject newEnemyShip = Instantiate(enemyShip, spawnPoint[randomSpawnPointNumber], Quaternion.Euler(Vector3.zero)) as GameObject;
                    if (newEnemyShip != null)
                    {

                    }
                }
            }
        }
    }
}
