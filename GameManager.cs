using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    private SpawnManager spawnManager;
    private GameObject intermissionText;
    private DisplayLives displayLives;
    private DisplayEnergy displayEnergy;

    private int playerLives;
    private int asteroidsDestroyed;
    private int highestLevel;
    private bool newLife;
    private float timerReset;
    private bool intermission;
    private float timerIntermission;
    private bool gameOver;

    void Start()
    {
        Instantiate(player, new Vector2(0, 0), player.transform.rotation);
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        intermissionText = GameObject.Find("Intermission Text");
        intermissionText.gameObject.SetActive(false);
        displayLives = GameObject.Find("Lives Counter").GetComponent<DisplayLives>();
        playerLives = 3;
        displayEnergy = GameObject.Find("Energy Counter").GetComponent<DisplayEnergy>();
        displayEnergy.SetReference();

        asteroidsDestroyed = 0;
        highestLevel = 0;
        spawnManager.SpawnAsteroids(2);
    }

    void Update()
    {
        if (newLife) {
            timerReset += Time.deltaTime;
            if (timerReset >= 3.0f) {
                intermissionText.gameObject.SetActive(false);
                Instantiate(player, new Vector2(0, 0), player.transform.rotation);
                displayEnergy.SetReference();
                newLife = false;
                timerReset = 0;
            }
        }

        if (intermission) {
            timerIntermission += Time.deltaTime;
            if (timerIntermission >= 3.0f) {
                intermissionText.gameObject.SetActive(false);
                spawnManager.SpawnAsteroids(3); // can scale this with a difficulty setting if I so choose
                intermission = false;
                timerIntermission = 0;
            }
        }

        if (gameOver) {
            timerReset += Time.deltaTime;
            if (timerReset >= 3.0f) {
                SceneManager.LoadScene("Title");
            }
        }

        if (intermission == false && FindObjectsOfType<AsteroidMovement>().Length == 0) {
            DisplayIntermission(true);
        }
    }

    private void DisplayIntermission(bool newLevel)
    {
        if (newLevel) {
            highestLevel++;
            intermission = true;
        }
        intermissionText.gameObject.SetActive(true);
        intermissionText.GetComponent<DisplayScores>().UpdateSprites(asteroidsDestroyed, highestLevel);
    }

    public void PlayerDied()
    {
        playerLives--;
        displayLives.setLives(-1);
        DisplayIntermission(false);
        
        if (playerLives > 0) {
            newLife = true;
        }
        
        else {
            gameOver = true;
        }
    }

    public void SetAsteroidsDestroyed(int change)
    {
        asteroidsDestroyed += change;
    }
}
