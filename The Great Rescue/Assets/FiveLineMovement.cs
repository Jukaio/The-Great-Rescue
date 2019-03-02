using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiveLineMovement : MonoBehaviour
{
    public float distance;
    public Vector3 travelVector;
    public float originY;
    public float moveSpeed;

    void Start()
    {
        originY = transform.position.y;
    }


    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W))
        {
            travelVector = new Vector3(transform.position.x, originY + (distance * 2), transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, travelVector, Time.deltaTime * moveSpeed);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            travelVector = new Vector3(transform.position.x, originY - (distance * 2), transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, travelVector, Time.deltaTime * moveSpeed);
        }

        if (Input.GetKey(KeyCode.S) == false && Input.GetKey(KeyCode.W) == false)
        {
            adjustPosition();
        }
    }

    private void adjustPosition()
    {
        if (transform.position.y >= originY + ((distance * 2) - (distance / 2)) &&
            transform.position.y != originY + (distance * 2))
        {
            travelVector = new Vector3(transform.position.x, originY + (distance * 2), transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, travelVector, Time.deltaTime * moveSpeed);
        }
        else if (transform.position.y >= originY + ((distance) - (distance / 2)) &&
                transform.position.y < originY + ((distance * 2) - (distance / 2)) &&
                transform.position.y != originY + distance)
        {
            travelVector = new Vector3(transform.position.x, originY + (distance), transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, travelVector, Time.deltaTime * moveSpeed);
        }
        else if (transform.position.y < originY + (distance / 2) &&
                   transform.position.y >= originY - (distance / 2) &&
                   transform.position.y != originY)
        {
            travelVector = new Vector3(transform.position.x, originY, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, travelVector, Time.deltaTime * moveSpeed);
        }
        else if (transform.position.y < originY - ((distance) - (distance / 2)) &&
                transform.position.y >= originY - ((distance * 2) - (distance / 2)) &&
                transform.position.y != originY - distance)
        {
            travelVector = new Vector3(transform.position.x, originY - (distance), transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, travelVector, Time.deltaTime * moveSpeed);
        }
        else if (transform.position.y < originY - ((distance * 2) - (distance / 2)) &&
            transform.position.y != originY - (distance * 2))
        {
            travelVector = new Vector3(transform.position.x, originY - (distance * 2), transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, travelVector, Time.deltaTime * moveSpeed);
        }
    }
}
