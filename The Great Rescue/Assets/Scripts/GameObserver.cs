using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObserver : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject[] enemies;
    public GameObject[] enemyBullets;
    public GameObject[] playerBullets;
    void Start()
    {
        
    }

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        enemyBullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
        playerBullets = GameObject.FindGameObjectsWithTag("PlayerBullet");

        foreach(GameObject entity in enemies)
        {
            entity.transform.localScale = new Vector3(1f - (entity.transform.position.y / 16f), 1f - (entity.transform.position.y / 16f), 1f);
        }
        foreach (GameObject entity in obstacles)
        {
            entity.transform.localScale = new Vector3(1.1f - (entity.transform.position.y / 16f), 1.1f - (entity.transform.position.y / 16f), 1f);
        }
        foreach (GameObject entity in enemyBullets)
        {
            entity.transform.localScale = new Vector3(1.1f - (entity.transform.position.y / 16f), 1.1f - (entity.transform.position.y / 16f), 1f);
        }
        foreach (GameObject entity in playerBullets)
        {
            entity.transform.localScale = new Vector3(1.1f - (entity.transform.position.y / 16f), 1.1f - (entity.transform.position.y / 16f), 1f);
        }
    }
}
