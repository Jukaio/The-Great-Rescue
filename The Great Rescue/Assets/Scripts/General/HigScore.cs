using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HigScore : MonoBehaviour
{
    static public int highscore;
    public int highscoreGame;
    public GameObject spawner;
    public List<GameObject> enemies;
    public Text highscoreText;

    private void Awake()
    {

    }


    void Update()
    {
        highscore = highscoreGame;
        //enemies = spawner.GetComponent<GameController>().enemies;
        //foreach (GameObject enemy in enemies)
        //    if (enemy.tag == "Enemy" && enemy.GetComponent<enemyStatus>().healthPoints <= 0)
        //    {
        //        Debug.Log(enemy.name);
        //        highscore += 10;
        //        PowerupBar.power++;
        //    }
        highscoreText.text = "" + highscore;
    }
}
