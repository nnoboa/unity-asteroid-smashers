using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject projectile;
    public Sprite shieldsOn;
    public Sprite shieldsOff;

    private float vertical;
    private float horizontal;
    private float speed;
    private float shieldEnergy;
    //private float timerMovement;
    private float timerShield;
    private float timerShoot;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        speed = 0;
        shieldEnergy = 100;
    }

    void Update()
    {
        //timerMovement += Time.deltaTime;
        timerShield += Time.deltaTime;
        timerShoot += Time.deltaTime;

        if (Input.GetButton("Jump") && (timerShoot > 0.4f)) {
            Instantiate(projectile, transform.position, transform.rotation);
            timerShoot = 0;
        }
    }

    void FixedUpdate()
    {
        transform.position += transform.up * speed;

        ManageSpeed();
        ManageEnergy();

        horizontal = -1 * Input.GetAxisRaw("Horizontal");
        if (Input.GetButton("Horizontal")) {
            transform.Rotate(0, 0, horizontal * 5.0f);
        }
    }

    private void ManageSpeed()
    {
        vertical = Input.GetAxisRaw("Vertical");

        if (speed >= 0 && speed <= 0.2f) {
            if (vertical == 0) { speed -= 0.0005f; }
            else { speed = speed + vertical * 0.001f; }
        }

        if (speed > 0.2f) { speed = 0.2f; }
        else if (speed < 0) { speed = 0; }
    }

    private void ManageEnergy()
    {
        if (timerShield >= 1.5f && shieldEnergy > 0) {
            shieldEnergy--;
            timerShield = 0;
        }

        if (shieldEnergy == 0) {
            this.GetComponent<SpriteRenderer>().sprite = shieldsOff;
        } else { this.GetComponent<SpriteRenderer>().sprite = shieldsOn; }
    }

    public float getShieldEnergy()
    {
        return shieldEnergy;
    }

    public void setShieldEnergy(float amount)
    {
        shieldEnergy += amount;

        if (shieldEnergy < 0) { shieldEnergy = 0; }
        else if (shieldEnergy >= 199) { shieldEnergy = 199; }
    }

    public void KillPlayer()
    {
        gameManager.PlayerDied();
        Destroy(gameObject);
    }
}
