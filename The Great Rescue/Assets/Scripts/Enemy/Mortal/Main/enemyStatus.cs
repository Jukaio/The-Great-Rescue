using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStatus : MonoBehaviour
{
    public float healthPoints;

    // Update is called once per frame
    void Update()
    {
        //Death check
        if (healthPoints <= 0)
            Destroy(gameObject);
        if (gameObject.transform.position.x <= -11)
            Destroy(gameObject);

    }

    //Damage methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
            healthPoints = ApplyDamage(healthPoints, collision.GetComponent<BulletMoverPlayer>().damage);

        else if (collision.gameObject.tag == "PlayerSword")
        {
            Debug.Log("Shot hit!");
            healthPoints = ApplyDamage(healthPoints, collision.GetComponent<SwordAttack>().damage);
        }
    }

    float ApplyDamage(float health, float damage)
    {
        return health - damage;
    }

}
