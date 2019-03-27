using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    GameObject EnemyCheckArea;
    public bool isInMeleeRange;
    public List<GameObject> enemies;
    public float range;
    public GameObject spawner;

    public GameObject Boss;

    public int theCheck;


    void Start()
    {
        EnemyCheckArea = new GameObject("AreaCheck");

    }

    void Update()
    {
        EnemyCheckArea.transform.position = new Vector3(gameObject.transform.position.x + (range / 2) , 
                                                        gameObject.transform.position.y, 
                                                        gameObject.transform.position.z);

        enemies = spawner.GetComponent<GameController>().enemies;

        theCheck = 0;

        foreach(GameObject enemy in enemies)
        {
            if (enemy == null)
                continue;
            else if (enemy.tag == "Enemy" && 
                enemy.transform.position.y >= gameObject.transform.position.y - 1f &&
                enemy.transform.position.y <= gameObject.transform.position.y - 0.3f)
            {
                if (enemy.transform.position.x < EnemyCheckArea.transform.position.x + (range / 2)) //works woohoo
                {
                    theCheck++;
                    isInMeleeRange = true;
                    Debug.Log(enemy.name);
                }
                else
                    continue;
            }
        }
        if (Boss == null)
        {
            
        }
        else if (Boss.transform.position.x < EnemyCheckArea.transform.position.x + (range / 2)) //works woohoo
        {
            theCheck++;
            isInMeleeRange = true;
        }


        if (theCheck == 0)
            isInMeleeRange = false;

        if (Input.GetKey(KeyCode.X)) //Clear boarda
        {
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
        }
    }

    public bool IsEnemyInMelee()
    {
        return !isInMeleeRange;
    }



}
