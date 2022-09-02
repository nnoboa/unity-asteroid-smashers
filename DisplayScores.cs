using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayScores : MonoBehaviour
{
    private GameObject asteroidsHundreds;
    private GameObject asteroidsTens;
    private GameObject asteroidsOnes;

    private GameObject levelsTens;
    private GameObject levelsOnes;

    public List<Sprite> numbers;

    void Start()
    {
        asteroidsHundreds = GameObject.Find("Destroyed_Hundreds");
        asteroidsTens = GameObject.Find("Destroyed_Tens");
        asteroidsOnes = GameObject.Find("Destroyed_Ones");

        levelsTens = GameObject.Find("Levels_Tens");
        levelsOnes = GameObject.Find("Levels_Ones");
    }

    void Update()
    {
        
    }

    public void UpdateSprites(int asteroidsDestroyed, int highestLevel)
    {
        int hundredsPlace = (int)(asteroidsDestroyed / 100);
        int tensPlace = (int)(asteroidsDestroyed / 10 ) % 10;
        int onesPlace = asteroidsDestroyed % 10;

        asteroidsHundreds.GetComponent<SpriteRenderer>().sprite = numbers[hundredsPlace];
        asteroidsTens.GetComponent<SpriteRenderer>().sprite = numbers[tensPlace];
        asteroidsOnes.GetComponent<SpriteRenderer>().sprite = numbers[onesPlace];

        tensPlace = (highestLevel / 10 ) % 10;
        onesPlace = highestLevel % 10;

        levelsTens.GetComponent<SpriteRenderer>().sprite = numbers[tensPlace];
        levelsOnes.GetComponent<SpriteRenderer>().sprite = numbers[onesPlace];
    }
}
