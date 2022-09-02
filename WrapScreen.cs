using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapScreen : MonoBehaviour
{
    public float xRange;
    public float yRange;
    public float offset;

    void Start()
    {
        
    }

    void Update()
    {
        WrapAround();
    }

    private void WrapAround()
    {
        if (transform.position.x < -xRange) {
            transform.position = new Vector2 (-transform.position.x - offset, transform.position.y);
        }

        else if (transform.position.x > xRange) {
            transform.position = new Vector2 (-transform.position.x + offset, transform.position.y);
        }

        if (transform.position.y < -yRange) {
            transform.position = new Vector2 (transform.position.x, -transform.position.y - offset);
        }

        else if (transform.position.y > yRange) {
            transform.position = new Vector2 (transform.position.x, -transform.position.y + offset);
        }
    }
}
