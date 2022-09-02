using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject nextAsteroid;

    public float maxSpeed;
    public float minSpeed;
    public float shieldDamage;
    public bool isSmall;

    private float xMoving;
    private float yMoving;
    private float angle;
    private float timerDamage;
    private bool canDamage;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // 50-50 chance +/-, ensures min speed is abided by is either direction
        if (Random.Range(0, 2) == 1) {
            xMoving = Random.Range(minSpeed, maxSpeed);
        }
        else {
            xMoving = Random.Range(-minSpeed, -maxSpeed);
        }

        if (Random.Range(0, 2) == 1) {
            yMoving = Random.Range(minSpeed, maxSpeed);
        }
        else {
            yMoving = Random.Range(-minSpeed, -maxSpeed);
        }

        angle = Random.Range(-0.5f, 0.5f);
        
        canDamage = false;
    }

    void Update()
    {
        if (!canDamage) {
            CheckCanDamage();
        }
    }

    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x + xMoving, transform.position.y + yMoving);
        transform.Rotate(0, 0, angle);
    }

    private void CheckCanDamage()
    {
        timerDamage += Time.deltaTime;
        if (timerDamage >= 1.0f) {
            canDamage = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canDamage) {
            if (other.gameObject.CompareTag("Player")) {
                PlayerController player = other.GetComponent<PlayerController>();
                if (player.getShieldEnergy() > 0) {
                    player.setShieldEnergy(shieldDamage);
                    if (isSmall == false){
                        Instantiate(nextAsteroid, transform.position, nextAsteroid.transform.rotation);
                        Instantiate(nextAsteroid, transform.position, nextAsteroid.transform.rotation);
                    }
                    gameManager.SetAsteroidsDestroyed(1);
                    Destroy(gameObject);
                }
                else { 
                    player.KillPlayer();
                }
            }
        }
    }
}
