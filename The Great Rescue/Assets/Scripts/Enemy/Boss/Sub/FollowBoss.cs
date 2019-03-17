using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBoss : MonoBehaviour
{
    public GameObject Boss;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Boss.transform.position;
    }
}
