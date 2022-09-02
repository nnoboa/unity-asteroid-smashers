using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayLives : MonoBehaviour
{
    private GameObject lives1;
    private GameObject lives2;
    private GameObject lives3;

    private int lives;

    void Start()
    {
        lives1 = GameObject.Find("Lives_1");
        lives2 = GameObject.Find("Lives_2");
        lives3 = GameObject.Find("Lives_3");

        lives = 3;
    }

    void Update()
    {
        
    }

    public void setLives(int change)
    {
        lives += change;
        UpdateDisplay();  
    }

    private void UpdateDisplay()
    {
        if (lives < 3) { lives3.gameObject.SetActive(false); }
        if (lives < 2) { lives2.gameObject.SetActive(false); }
        if (lives < 1) { lives1.gameObject.SetActive(false); }
    }
}
