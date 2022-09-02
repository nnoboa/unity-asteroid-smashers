using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject asteroid;
    public GameObject alien;
    
    private float xRange;
    private float yRange;
    private float timerSpawnAlien;
    private float randomTime;

    void Start()
    {
        xRange = 8;
        yRange = 5;
        randomTime = Random.Range(8.0f, 12.0f);
    }

    void Update()
    {
        timerSpawnAlien += Time.deltaTime;
        if (timerSpawnAlien >= randomTime) {
            SpawnAlien();
            randomTime = Random.Range(8.0f, 12.0f);
            timerSpawnAlien = 0;
        }
    }

    public void SpawnAsteroids(int amount)
    {
        for (int i=0; i < amount; i++) {
            Instantiate(asteroid, GenAsteroidSpawnPos(), asteroid.transform.rotation);
        }
    }

    private void SpawnAlien()
    {
        Instantiate(alien, GenAlienSpawnPos(), alien.transform.rotation);
    }

    private Vector2 GenAsteroidSpawnPos()
    {
        float spawnPosX = Random.Range(-xRange, xRange);
        float spawnPosY = Random.Range(-yRange, yRange);

        // currently bugged
        // GameObject player = GameObject.Find("Player(Clone)");
        // while (Mathf.Abs(spawnPosX - player.transform.position.x) < 2) { spawnPosX = Random.Range(-xRange, xRange); }
        // while (Mathf.Abs(spawnPosY - player.transform.position.y) < 2) { spawnPosY = Random.Range(yRange, yRange); }

        Vector2 spawnPos = new Vector2(spawnPosX, spawnPosY);
        
        return spawnPos;
    }

    private Vector2 GenAlienSpawnPos()
    {
        float spawnPosX = 0;
        float spawnPosY = 0;

        int axis = Random.Range(1, 4);

        switch(axis)
        {
            case 1:
                spawnPosX = xRange + 1;
                break;
            case 2:
                spawnPosX = -xRange - 1;
                break;
            case 3:
                spawnPosY = yRange;
                break;
            case 4:
                spawnPosY = -yRange;
                break;
            default:
                break;
        }

        if (spawnPosX == 0) {
            spawnPosX = Random.Range(-xRange, xRange);
        }
        
        if (spawnPosY == 0) {
            spawnPosY = Random.Range(-yRange, yRange);
        }

        Vector2 spawnPos = new Vector2(spawnPosX, spawnPosY);

        return spawnPos;
    }
}
