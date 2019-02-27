using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public float speed;


    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(-1f, 0);
        transform.Translate(Time.deltaTime * speed * movement);

        if (gameObject.transform.position.x <= -11)
            Destroy(gameObject);
    }

}
