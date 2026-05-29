using UnityEngine;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour
{
    public List<WaveData> waves;
    public float timeBetweenWaves = 5f;

    private int currentWaveIndex = 1;
    private float waveTimer = 0f;
    private float pauseTimer = 0f;
    public bool isInWave = true;
    private WaveData currentWave;


    void Start()
    {
        currentWave = waves[0];
    }

    void Update()
    {

        if (isInWave)
        {
            waveTimer += Time.deltaTime;


            if (waveTimer >= currentWave.waveDuration)
            {
                waveTimer = 0f;
                isInWave = false;

            }
        }
        else
        {
            pauseTimer += Time.deltaTime;

            if (pauseTimer >= timeBetweenWaves)
            {
                pauseTimer = 0f;
                isInWave = true;
                NextWave();
            }
        }
    }

    void NextWave()
    {
        currentWaveIndex++;

    }

    public WaveData GetCurrentWave()
    {
        return currentWave;
    }

    public bool IsInWave()
    {
        return isInWave;
    }

    public float GetWaveTimer()
    {
        return waveTimer;
    }

    public float GetPauseTimer()
    {
        return pauseTimer;
    }

    public int GetCurrentWaveIndex()
    {
        return currentWaveIndex;
    }
}