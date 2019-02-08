using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    public float speed;
    private Movement bulletMovement;

    void Start()
    {
        bulletMovement = gameObject.AddComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletMovement.moveRight(speed);

        if (gameObject.transform.position.x >= 11)
            Destroy(gameObject);
    }
}
