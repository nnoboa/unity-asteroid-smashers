using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    // public Sprite title;
    // public Sprite info;
    // private int sprite;
    //private bool cooldown;
    // private float timerCooldown;

    void Start()
    {
        // sprite = 0;
    }

    void Update()
    {
        if (Input.GetButton("Jump")) { // space bar
            SceneManager.LoadScene("Game");
        }

        
        // not needed at the moment - can be used to display info or other text on screen
        /**
        if (cooldown) {
            timerCooldown += Time.deltaTime;
            if (timerCooldown >= 0.5f) {
                cooldown = false;
                timerCooldown = 0;
            }
        }

        if (Input.GetButton("Submit") && cooldown == false) { // enter/return key
            if (sprite == 0) {
                this.GetComponent<SpriteRenderer>().sprite = info;
                sprite++;
            }
            else {
                this.GetComponent<SpriteRenderer>().sprite = title;
                sprite--;
            }
            cooldown = true;
        }
        */
    }
}
