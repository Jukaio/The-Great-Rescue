using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupBar : MonoBehaviour
{
    Image powerBar;
    public float maxPower = 100f;
    public static float power; 
    // Start is called before the first frame update
    void Start()
    {
        powerBar = GetComponent<Image>();
        powerBar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //HealthbarScript.health -= "value" makes the bar go down we might want some other way of doing this. But this is how to make it go down for now
        powerBar.fillAmount = power / 100;
        

    }
}
