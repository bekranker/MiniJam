using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] DayNightCycle _dayNightCycle;
    [Header("Waves")]
    [SerializeField] private WaveType[] _waves;

    private int _enemyCount {get; set;}
    private float _spawnRate {get; set;}


    public void InitWave()
    {
        _enemyCount = _waves[_dayNightCycle.DayCount].EnemyCount;
        _spawnRate = _waves[_dayNightCycle.DayCount].SpawnRate;
    }
    public void StartWave() => StartCoroutine(SpawnEnemiesIE());
    public IEnumerator SpawnEnemiesIE()
    {
        for (int i = 0; i < _enemyCount; i++)
        {
            _enemySpawner.SpawnEnemies();
            yield return new WaitForSeconds(_spawnRate);
        }
    }

}