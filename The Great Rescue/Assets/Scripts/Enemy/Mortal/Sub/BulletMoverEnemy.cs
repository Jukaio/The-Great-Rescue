using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoverEnemy : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tag == "PlayerBullet")
        {
            if (collision.gameObject.tag == "Enemy" && collision.gameObject.layer != 8)
                Destroy(gameObject);
        }
    }
}
