using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Player.transform.position;
    }
}
