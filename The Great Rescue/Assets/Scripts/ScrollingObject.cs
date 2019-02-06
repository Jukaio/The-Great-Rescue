using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        //make the object move in set speed
        rb2d.velocity = new Vector2(speed, 0);
    }

    void Update()
    {
        // If the game is over, stop scrolling.
        //if (-GAMEOVER-)
        //{
        //    rb2d.velocity = Vector2.zero;
        //}
    }
}