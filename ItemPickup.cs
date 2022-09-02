using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) {
            PlayerController player = other.GetComponent<PlayerController>();
            player.setShieldEnergy(50);
            Destroy(gameObject);
        }
    }
}
