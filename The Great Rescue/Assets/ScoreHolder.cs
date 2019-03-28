using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHolder : MonoBehaviour
{
    public GameObject world;
    public int scoreHolder = 0;
    public HigScore highScore01;

    // Start is called before the first frame update
    void Start()
    {
        world = GameObject.FindGameObjectWithTag("World");
        highScore01 = GameObject.FindGameObjectWithTag("SpawnerLevel01").GetComponent<HigScore>();

        if (world.name != "World1")
        {
            scoreHolder = highScore01.highscoreGame;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
