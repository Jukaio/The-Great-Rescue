using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{

    public Rigidbody2D movingWithRb2d(Rigidbody2D rb2d, float moveHorizontal, float moveVertical, float speed)
    {

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);

        return rb2d;
    }



    public void movingWithoutRB(float moveHorizontal, float moveVertical, float speed)
    {
        if(moveHorizontal > 0 && moveVertical > 0)
        {
            
        }
        else if(moveHorizontal < 0 && moveVertical > 0)
        {

        }
        else if(moveHorizontal < 0 && moveVertical < 0)
        {

        }
        else if(moveHorizontal < 0  && moveVertical > 0)
        {

        }


        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        transform.Translate(Time.deltaTime * speed * movement);

    }

    public void moveLeft(float speed)
    {
        Vector2 movement = new Vector2(-1f, 0);
        transform.Translate(Time.deltaTime * speed * movement);
    }




}
