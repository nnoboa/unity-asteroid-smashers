using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayEnergy : MonoBehaviour
{
    private PlayerController player;
    private GameObject hundreds;
    private GameObject tens;
    private GameObject ones;

    public List<Sprite> numbers;

    void Start()
    {
        hundreds = GameObject.Find("Energy_Hundreds");
        tens = GameObject.Find("Energy_Tens");
        ones = GameObject.Find("Energy_Ones");
    }

    void Update()
    {
        ManageSprites();
    }

    private void ManageSprites()
    {
        
        int tensPlace = ( (int)player.getShieldEnergy() / 10 ) % 10;
        int onesPlace = (int)player.getShieldEnergy() % 10;

        if (player.getShieldEnergy() >= 100) {
            hundreds.GetComponent<SpriteRenderer>().sprite = numbers[1];
        } 
        else {
            hundreds.GetComponent<SpriteRenderer>().sprite = numbers[0];
        }

        tens.GetComponent<SpriteRenderer>().sprite = numbers[tensPlace];
        ones.GetComponent<SpriteRenderer>().sprite = numbers[onesPlace];
    }

    public void SetReference()
    {
        player = GameObject.Find("Player(Clone)").GetComponent<PlayerController>();
    }
}
