using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HigScore : MonoBehaviour
{
    public float highscore;
    public GameObject[] enemies;
    public Text highscoreText;


    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
            if (enemy.GetComponent<enemyStatus>().healthPoints <= 0)
                highscore += 10;
        highscoreText.text = "Score: " + highscore;
    }
}
