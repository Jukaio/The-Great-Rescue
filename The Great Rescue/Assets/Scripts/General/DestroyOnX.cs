using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnX : MonoBehaviour
{
    public GameObject gO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gO.transform.position.x <= -11)
            Destroy(gO);
    }
}
