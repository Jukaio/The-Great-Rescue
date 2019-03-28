using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRateMin;
    public float fireRateMax;
    private float nextFire;

    void Update()
    {
        if (Time.time > nextFire && gameObject.transform.position.x <= 11)
        {
            if (Random.value <= 0.4)
            {
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            }
            else if(Random.value > 0.4)
            {
                StartCoroutine(shootdouble());
            }
            nextFire = Time.time + Random.Range(fireRateMin, fireRateMax);
        }
    }
    IEnumerator shootdouble()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        yield return new WaitForSeconds(0.4f);
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
    }
}
