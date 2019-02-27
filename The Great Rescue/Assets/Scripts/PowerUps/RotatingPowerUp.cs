using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPowerUp : MonoBehaviour
{
    float x;
    // Start is called before the first frame update
    void Start()
    {
        x = 0.5f;  //velocity
    }

    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0, x, 0)); //applying rotation
    }
}
