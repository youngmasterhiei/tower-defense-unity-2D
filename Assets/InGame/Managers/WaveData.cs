using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class SpawnEntry
{
    public GameObject prefab;
    [Range(0f, 100f)]
    public float weight;
}

[CreateAssetMenu(fileName = "WaveData", menuName = "Tower Defense/Wave Data")]
public class WaveData : ScriptableObject
{
    [Header("Wave Settings")]
    public int waveNumber;
    public float waveDuration = 12f;
    public int enemyCount;
    public float spawnInterval = 1.5f;

    [Header("Stat Multipliers")]
    public float healthMultiplier = 1f;
    public float speedMultiplier = 1f;
    public float attackMultiplier = 1f;

    [Header("Rewards")]
    public int coinDrop = 5;
    public int cashDrop = 10;

    [Header("Spawn Table")]
    public List<SpawnEntry> spawnEntries;
}