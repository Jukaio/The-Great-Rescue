using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{
    public Image cooldown;
    public float waitTime = 10;
    public bool coolingDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(coolingDown == true)
        {
            cooldown.fillAmount -= 1.0f / waitTime * Time.deltaTime;
        }
    }
}
