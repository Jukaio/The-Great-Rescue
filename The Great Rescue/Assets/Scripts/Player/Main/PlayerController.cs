using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Experimental.UIElements;
using System;


//public enum myEnum // your custom enumeration
//{
//    Rigidbody,
//    CharacterController,
//};



public class PlayerController : MonoBehaviour


{
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    [SerializeField] private float distanceToMove;
    [SerializeField] private float moveSpeed;
    private bool moveToPoint = false;
    private Vector3 endPosition;





    void Start()
    {

        endPosition = transform.position;
    }

    void FixedUpdate()
    {
        if (moveToPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Update()
    {
        if (endPosition.y <= 3f)
        {
            if (Input.GetKeyDown(KeyCode.W)) //Up
            {
                endPosition = new Vector3(endPosition.x, endPosition.y + distanceToMove, endPosition.z);
                moveToPoint = true;
            }
        }
        if (endPosition.y >= -2f)
        {
            if (Input.GetKeyDown(KeyCode.S)) //Down
            {
                endPosition = new Vector3(endPosition.x, endPosition.y - distanceToMove, endPosition.z);
                moveToPoint = true;
            }
        }

        if (GetComponent<MeleeAttack>().IsEnemyInMelee())
        {
            if (Input.GetKey("space")
            && Time.time > nextFire
            && GetComponent<playerStatus>().getCanShoot())
            {
                //animator.SetBool("isShooting", true);

                nextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            }
        }
        else if (GetComponent<MeleeAttack>().IsEnemyInMelee() == false)
        {
            Debug.Log("LOLOLOLOLO XD OLOLOLOL");
        }
    }

}

