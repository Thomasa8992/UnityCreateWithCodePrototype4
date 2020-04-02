using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRange = 9;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemy", 5, 5);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private Vector3 GenerateSpawnPosition() {
        var spawnPositionX = Random.Range(-spawnRange, spawnRange);
        var spawnPositionZ = Random.Range(-spawnRange, spawnRange);

        var randomPosition = new Vector3(spawnPositionX, 0, spawnPositionZ);

        return randomPosition;
    }

    private void CreateEnemy() {
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }
}
