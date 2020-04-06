using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public float spawnRange = 9;
    public int enemyCount;
    public int waveCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        SpawnEnemyWave(waveCount);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;

        if(enemyCount == 0) {
            waveCount++;
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
            SpawnEnemyWave(waveCount);

        }
    }

    private Vector3 GenerateSpawnPosition() {
        var spawnPositionX = Random.Range(-spawnRange, spawnRange);
        var spawnPositionZ = Random.Range(-spawnRange, spawnRange);

        var randomPosition = new Vector3(spawnPositionX, 0, spawnPositionZ);

        return randomPosition;
    }

    private void SpawnEnemyWave(int enemyCount) {
        for(var i = 0; i < enemyCount; i++) {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
}
