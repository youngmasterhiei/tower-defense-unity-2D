using UnityEngine;

public class UserData : MonoBehaviour
{
    public float cash;
    public int coins;
    public int gems;
    public int powerStones;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        cash = PlayerPrefs.GetFloat("cash", 200);
        coins = PlayerPrefs.GetInt("coins", 0);
        gems = PlayerPrefs.GetInt("gems", 0);
        powerStones = PlayerPrefs.GetInt("powerStones", 0);


    }

    public void saveData()
    {
        PlayerPrefs.SetFloat("cash", cash);
        PlayerPrefs.SetInt("coins", coins);
        PlayerPrefs.SetInt("gems", gems);
        PlayerPrefs.SetInt("powerStones", powerStones);
        PlayerPrefs.Save();

    }

    void OnApplicationQuit()
    {
        saveData();
    }
}
