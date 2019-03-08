using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckUpAndDown : MonoBehaviour
{
    GameObject CheckUp;
    GameObject CheckDown;
    public GameObject[] obstacles;

    public bool deactivateUp;
    public bool deactivateDown;

    private int downCounter;
    private int upCounter;


    void Start()
    {
        CheckUp = new GameObject("CheckUp");
        CheckDown = new GameObject("CheckDown");
        CheckUp.AddComponent<BoxCollider2D>().isTrigger = true;
        CheckDown.AddComponent<BoxCollider2D>().isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        CheckUp.transform.position = gameObject.transform.position;
        CheckDown.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 2.635f);

        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        downCounter = 0;
        upCounter = 0;

        foreach(GameObject obstacle in obstacles)
        {
            if (obstacle.transform.position.x <= gameObject.transform.position.x)
            {
                if (obstacle.transform.position.y < gameObject.transform.position.y - 1.55f &&
                    obstacle.transform.position.y > gameObject.transform.position.y - (1.55f * 2))
                {
                    deactivateDown = true;
                    downCounter++;
                }
                else if(obstacle.transform.position.y > gameObject.transform.position.y &&
                    obstacle.transform.position.y < gameObject.transform.position.y + 1.55f)
                {
                    deactivateUp = true;
                    upCounter++;
                }
            }
        }
        if (downCounter <= 0)
            deactivateDown = false;
        if (upCounter <= 0)
            deactivateUp = false;
    }

    public bool isUpBlocked()
    {
        return !deactivateUp;
    }

    public bool isDownBlocked()
    {
        return !deactivateDown;
    }
}
