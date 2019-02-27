using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    //Vector3 thingToCheck;

    //Vector3 start;
    //Vector3 end;

    GameObject isCloseArea;
    public bool check;
    public GameObject[] enemies;

    public int theCheck;


    void Start()
    {
        //start = gameObject.transform.position;
        //end = gameObject.transform.position;
        //end.x = gameObject.transform.position.x + 3;

        

        isCloseArea = new GameObject("AreaCheck");
        isCloseArea.AddComponent<BoxCollider2D>();
        isCloseArea.GetComponent<BoxCollider2D>().size = new Vector2(5f, 1f);
        isCloseArea.GetComponent<BoxCollider2D>().isTrigger = true;

    }

    void Update()
    {
        isCloseArea.transform.position = new Vector3(gameObject.transform.position.x + 2, 
                                                        gameObject.transform.position.y, 
                                                        gameObject.transform.position.z);

        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        theCheck = 0;

        //for(int i = 0; i <= enemies.Length; i++)
        foreach(GameObject enemy in enemies)
        {
            if(enemy.transform.position.x < isCloseArea.transform.position.x + (isCloseArea.GetComponent<BoxCollider2D>().size.x/2)) //works woohoo
            {
                theCheck++;
                check = true;
            }
        }

        if (theCheck == 0)
            check = false;
        
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    var test = isCloseArea.GetComponent<BoxCollider2D>();
    //    if(test.IsTouching(collision))
    //    {

    //    }
    //}



    bool whatIsArea()
    {
        //if(thingToCheck.x <= end.x && thingToCheck.x >= start.x
        //    && thingToCheck.y <= end.y && thingToCheck.y >= start.y
        //    && thingToCheck.z <= end.z && thingToCheck.z >= start.z
        //    )
        //{

        //}
        return false;
    }
}
