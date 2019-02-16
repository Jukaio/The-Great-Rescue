using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
        public GameObject[] toSpawn;
        public Vector3 spawnValues;
        public int hazardCount;
        public float spawnWait;
        public float startWait;
        public float waveWait;

        public int arrayLength;

        void Start()
        {
            StartCoroutine(SpawnWaves());
            arrayLength = toSpawn.Length;
        }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = gameObject.transform.position;
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(toSpawn[Random.Range(0, arrayLength)], spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
