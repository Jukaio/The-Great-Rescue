using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObserver : MonoBehaviour
{
    public GameObject[] objects;

    void Start()
    {
        
    }

    void Update()
    {
        objects = GameObject.FindGameObjectsWithTag("Enemy");
        objects = GameObject.FindGameObjectsWithTag("Obstacle");
    }
}
