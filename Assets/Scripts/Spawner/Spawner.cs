using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public Transform[] SpawnerPoint;
    public GameObject[] enemyPrefabs;

    
    public float marshInterval = 5f;

    
    public Transform spawnTransform;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    // Update is called once per frame
    private IEnumerator spawnEnemy()
    {
        int randomSpawn = Random.Range(0, SpawnerPoint.Length);
        int randomEnemy = Random.Range(0, enemyPrefabs.Length);

        yield return new WaitForSeconds(marshInterval);
        GameObject newEnemy = Instantiate(enemyPrefabs[randomEnemy], SpawnerPoint[randomSpawn].position, Quaternion.identity);
        StartCoroutine(spawnEnemy());
    }
}
