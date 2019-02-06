using UnityEngine;
using System.Collections;

public class RepeatingBG : MonoBehaviour
{

    private BoxCollider2D groundCollider;       //This stores a reference to the collider attached to the Ground.
    private float groundHorizontalLength;       //A float to store the x-axis length of the collider2D attached to the Ground GameObject.

    //Awake is called before Start.
    private void Awake()
    {
        //Get and store a reference to the collider2D attached to Ground.
        groundCollider = GetComponent<BoxCollider2D>();
        //Store the size of the collider along the x axis (its length in units).
        groundHorizontalLength = groundCollider.size.x;
    }

    //Update runs once per frame
    private void Update()
    {
        if (transform.position.x < -groundHorizontalLength)
        {
            //if true then the background will run the repeat method.
            RepositionBackground();
        }
    }

    //Moves the object this script is attached to right in order to create our looping background effect.
    private void RepositionBackground()
    {
        //change the *2f value if we want more or less than twice before repeat
        Vector2 groundOffSet = new Vector2(groundHorizontalLength * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffSet;
    }
}