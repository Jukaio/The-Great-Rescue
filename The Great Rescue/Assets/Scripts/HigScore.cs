using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HigScore : MonoBehaviour
{
    public float highscore;
    public GameObject[] enemies;



    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
            if (enemy.GetComponent<enemyStatus>().healthPoints <= 0)
                highscore += 10;
    }
}
