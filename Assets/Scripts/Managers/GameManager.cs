using UnityEngine;
// System is required for Math.Cos and Math.Sin used in spawn position calculation
using System;

public class GameManager : MonoBehaviour
{
    // reference to WaveManager — keeps wave timing and data separate from spawn logic
    public WaveManager waveManager;
    float timer = 0f; // tracks time between individual enemy spawns
    public ObjectPooling NormalEnemyPool;
    public ObjectPooling TankEnemyPool;
    GameObject enemyToBeSpawned;
    void Update()
    {
        // only run spawn logic during an active wave
        if (waveManager.isInWave)
        {
            timer += Time.deltaTime;

            // spawn an enemy once enough time has passed based on current wave's spawn interval
            if (timer >= waveManager.GetCurrentWave().spawnInterval)
            {
                SpawnEnemies(PickEnemy());
                timer -= waveManager.GetCurrentWave().spawnInterval; // subtract instead of reset to stay accurate
            }
        }
        else
        {
            timer = 0f; // reset spawn timer during the cooldown between waves
        }
    }

    void SpawnEnemies(GameObject enemy)
    {
        float fixedDistance = 5f; // how far from center enemies spawn
        Vector2 center = new Vector2(transform.position.x, transform.position.y);
        float angle = UnityEngine.Random.Range(0f, Mathf.PI * 2f); // random angle around full circle
        float x = center.x + (float)Math.Cos(angle) * fixedDistance; // x position on spawn ring
        float y = center.y + (float)Math.Sin(angle) * fixedDistance; // y position on spawn ring
        Vector3 spawnPosition = new Vector3(x, y, 0);


        if (enemy == NormalEnemyPool.objectToPool)
        {
            enemyToBeSpawned = NormalEnemyPool.GetPooledObject();
            enemyToBeSpawned.transform.position = spawnPosition;
            enemyToBeSpawned.GetComponent<BaseEnemyScript>().health = 80;
            enemyToBeSpawned.SetActive(true);
        }
        else if (enemy == TankEnemyPool.objectToPool)
        {
            enemyToBeSpawned = TankEnemyPool.GetPooledObject();
            enemyToBeSpawned.transform.position = spawnPosition;
            enemyToBeSpawned.GetComponent<BaseEnemyScript>().health = 80;
            enemyToBeSpawned.SetActive(true);
        }

    }

    GameObject PickEnemy()
    {
        float roll = UnityEngine.Random.Range(0f, 100f); // random number 0-100
        float cumulative = 0f; // running total used to find which weight slice the roll landed in

        // loop through each entry in the wave's spawn table
        foreach (SpawnEntry entry in waveManager.GetCurrentWave().spawnEntries)
        {
            cumulative += entry.weight;
            if (roll < cumulative) return entry.prefab; // roll landed in this entry's slice
        }

        return waveManager.GetCurrentWave().spawnEntries[0].prefab; // fallback if weights don't add to 100
    }
}