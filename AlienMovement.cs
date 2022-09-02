using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMovement : MonoBehaviour
{
    public GameObject energy;
    public GameObject projectile;

    private float xRange;
    private float yRange;
    private float xMoving;
    private float yMoving;
    private float speed;
    private float timerShoot;
    private float shootCooldown;

    void Start()
    {
        xRange = 8;
        yRange = 5;
        speed = 0.08f;

        shootCooldown = Random.Range(1.0f, 2.5f);

        if (transform.position.x >= xRange) {
            xMoving = -1;
        }
        else if (transform.position.x <= -xRange) {
            xMoving = 1;
        }
        else {
            xMoving = 0;
        }

        if (transform.position.y >= yRange) {
            yMoving = -1;
        }
        else if (transform.position.y <= -yRange) {
            yMoving = 1;
        }
        else {
            yMoving = 0;
        }
    }

    void Update()
    {
        timerShoot += Time.deltaTime;
        if (timerShoot >= shootCooldown) {
            ShootAtPlayer();
            timerShoot = 0;
        }

        CheckOutOfBounds();
    }

    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x + xMoving * speed, transform.position.y + yMoving * speed);
    }

    private void CheckOutOfBounds()
    {
        if ( (Mathf.Abs(transform.position.x) > xRange + 3) || (Mathf.Abs(transform.position.y) > yRange + 1) ) {
            Destroy(gameObject);
        }
    }

    private void ShootAtPlayer()
    {
        // find the angle between the alien ship and the player
        if (GameObject.Find("Player(Clone)")) {
            PlayerController player = GameObject.Find("Player(Clone)").GetComponent<PlayerController>();
            float x = player.transform.position.x - transform.position.x;
            float y = player.transform.position.y - transform.position.y;
            float angle = Mathf.Atan2(x, y) * Mathf.Rad2Deg * -1;
            Instantiate(projectile, transform.position, Quaternion.Euler(new Vector3(0, 0, angle)));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player_Projectile")) {
            Instantiate(energy, transform.position, energy.transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
