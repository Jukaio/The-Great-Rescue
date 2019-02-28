using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        //other.name should equal the root of your Player object
        if (other.name == "Player")
        {
            //The scene number to load (in File->Build Settings)
            SceneManager.LoadScene(2);
        }
    }
}

