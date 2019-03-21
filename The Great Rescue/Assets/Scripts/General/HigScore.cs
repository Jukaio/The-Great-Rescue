using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HigScore : MonoBehaviour
{
    static public int highscore;
    public GameObject[] enemies;
    public Text highscoreText;


    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
            if (enemy.GetComponent<enemyStatus>().healthPoints <= 0)
            {
                highscore += 10;
                PowerupBar.power++;
            }
        highscoreText.text = "" + highscore;
    }
}
