using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletMover : MonoBehaviour
{
    public float speed;
    public GameObject parent;

    void Awake()
    {
        parent = gameObject.transform.parent.gameObject;
    }
    

    void Update()
    {
        Vector2 movement = new Vector2(-1f, 0f);
        transform.Translate(Time.deltaTime * speed * movement);

        if (gameObject.transform.position.x <= -11)
        {
            gameObject.SetActive(false);
            gameObject.transform.position = parent.transform.parent.position;
            gameObject.transform.parent = parent.transform;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            gameObject.transform.position = parent.transform.parent.position;
            gameObject.transform.parent = parent.transform;
        }
    }
}
