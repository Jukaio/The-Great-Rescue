using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HigScore : MonoBehaviour
{
    static public int highscore;
    public GameObject spawner;
    public List<GameObject> enemies;
    public Text highscoreText;

    private void Awake()
    {
        enemies = spawner.GetComponent<GameController>().enemies;
    }


    void Update()
    {
        foreach (GameObject enemy in enemies)
            if (enemy.GetComponent<enemyStatus>().healthPoints <= 0)
            {
                highscore += 10;
                PowerupBar.power++;
            }
        highscoreText.text = "" + highscore;
    }
}
