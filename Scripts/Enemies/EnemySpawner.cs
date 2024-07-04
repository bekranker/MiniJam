using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    
    [Header("Spawn Points")]
    [SerializeField] private Transform spawnPoint1;
    [SerializeField] private Transform spawnPoint2;

    [Header("Enemy Prefab")]
    [SerializeField] private GameObject enemyPrefab;

    public void SpawnEnemies()
    {
        Instantiate(enemyPrefab, spawnPoint1.position, spawnPoint1.rotation);
        Instantiate(enemyPrefab, spawnPoint2.position, spawnPoint2.rotation);
    }
}
