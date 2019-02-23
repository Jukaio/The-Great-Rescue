using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public float speed;
    private Movement stoneMovement;


    void Start()
    {
        stoneMovement = gameObject.AddComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        stoneMovement.moveLeft(speed);
  
    }

}
