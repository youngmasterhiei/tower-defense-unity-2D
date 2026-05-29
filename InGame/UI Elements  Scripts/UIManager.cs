using UnityEngine;
using TMPro; // required for TextMeshPro text elements
using UnityEngine.UI; // required for Slider

public class UIManager : MonoBehaviour
{
    [Header("References")]
    public WaveManager waveManager; // pulls wave data and state from WaveManager

    [Header("Top Panel")]
    public TextMeshProUGUI waveNumberText; // displays current wave number
    public Slider waveTimerBar; // fills left to right as wave progresses
    public TextMeshProUGUI coinsText; // displays current coin count

    [Header("Bottom Panel")]
    public TextMeshProUGUI enemyHPText; // displays current wave enemy HP
    public TextMeshProUGUI enemyATKText; // displays current wave enemy ATK

    void Update()
    {
        UpdateWaveUI(); // called every frame to keep UI in sync with game state
    }

    void UpdateWaveUI()
    {
        // sets wave label to current wave number
        waveNumberText.text = "Wave " + waveManager.GetCurrentWaveIndex();
        // Debug.Log("waveNumberText   " + waveManager.GetCurrentWaveIndex());

        // fills bar from 0 to 1 based on how much of the wave duration has passed

        if (waveManager.isInWave)
        {
            waveTimerBar.value = waveManager.GetWaveTimer() / waveManager.GetCurrentWave().waveDuration;

        }
        else
        {
            waveTimerBar.value = waveManager.GetPauseTimer() / waveManager.timeBetweenWaves;
        }
    }
}