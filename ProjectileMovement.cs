using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private float xRange;
    private float yRange;
    public bool isAlien;

    void Start()
    {
        xRange = 9;
        yRange = 6;
    }

    
    void Update()
    {
        CheckOutOfBounds();
    }

    void FixedUpdate()
    {
        transform.position += transform.up * 0.25f;
    }
    
    private void CheckOutOfBounds()
    {
        if ( (Mathf.Abs(transform.position.x) > xRange) || (Mathf.Abs(transform.position.y) > yRange) ) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Asteroid")) {
            Destroy(gameObject);
        }
        else if (isAlien && other.gameObject.CompareTag("Player")) {
            PlayerController player = other.GetComponent<PlayerController>();
            player.setShieldEnergy(-5);
            Destroy(gameObject);
        }
    }
}
