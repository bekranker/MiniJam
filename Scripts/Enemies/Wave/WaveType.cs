using System.Collections;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "WaveType", menuName = "ScriptableObjects/WaveType", order = 1)]
public class WaveType : ScriptableObject
{
    public int EnemyCount;
    public float SpawnRate;

}