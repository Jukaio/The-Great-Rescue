using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
        public GameObject[] toSpawn;

        public float startWait;
        public float waveWait;
        private float nextWave;
    private int currentWave;

    public List<GameObject> waves = new List<GameObject>();
    public List<GameObject> enemies = new List<GameObject>();


    void Start()
        {
            StartCoroutine(SpawnWaves());
        }

    private void Update()
    {
        if(Time.time > nextWave)
        {
            nextWave = Time.time + waveWait;

            Vector3 spawnPosition = gameObject.transform.position;
            Quaternion spawnRotation = Quaternion.identity;

            waves.Add(Instantiate(toSpawn[currentWave], spawnPosition, spawnRotation));
            currentWave++;
            for (int j = 0; j < waves[waves.Count - 1].transform.childCount; j++)
            {
                enemies.Add(waves[waves.Count - 1].transform.GetChild(j).gameObject);
            }

        }

        for (int i = 0; i < waves.Count; i++)
        {
            if (waves[i].transform.childCount == 0)
            {
                waves.Remove(waves[i]);
            }

        }

        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] == null)
            {
                enemies.Remove(enemies[i]);
            }

        }

    }


    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);


        //Vector3 spawnPosition = gameObject.transform.position;
        //Quaternion spawnRotation = Quaternion.identity;

        //waves.Add(Instantiate(toSpawn[Random.Range(0, toSpawn.Length)], spawnPosition, spawnRotation));

        //for (int j = 0; j < waves[waves.Count - 1].transform.childCount; j++)
        //{
        //    enemies.Add(waves[waves.Count - 1].transform.GetChild(j).gameObject);
        //}

        yield return new WaitForSeconds(waveWait);
        
    }
}
