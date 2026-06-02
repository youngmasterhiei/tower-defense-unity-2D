using UnityEngine;

public class UserData : MonoBehaviour
{
    [Header("Currency")]
    public float cash;
    public int coins;
    public int gems;
    public int powerStones;

    [Header("Upgrade Levels")]
    public int damageLevel;
    public int attackSpeedLevel;
    public int critChanceLevel;
    public int critMultLevel;
    public int healthLevel;
    public int healthRegenLevel;
    public int defenseLevel;
    public int cashLevel;
    public int coinsLevel;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    void LoadData()
    {
        cash = PlayerPrefs.GetFloat("cash", 200);
        coins = LoadInt("coins");
        gems = LoadInt("gems");
        powerStones = LoadInt("powerStones");

        damageLevel = LoadInt("damageLevel");
        attackSpeedLevel = LoadInt("attackSpeedLevel");
        critChanceLevel = LoadInt("critChanceLevel");
        critMultLevel = LoadInt("critMultLevel");
        healthLevel = LoadInt("healthLevel");
        healthRegenLevel = LoadInt("healthRegenLevel");
        defenseLevel = LoadInt("defenseLevel");
        cashLevel = LoadInt("cashLevel");
        coinsLevel = LoadInt("coinsLevel");
    }

    public void saveData()
    {
        PlayerPrefs.SetFloat("cash", cash);
        SaveInt("coins", coins);
        SaveInt("gems", gems);
        SaveInt("powerStones", powerStones);

        SaveInt("damageLevel", damageLevel);
        SaveInt("attackSpeedLevel", attackSpeedLevel);
        SaveInt("critChanceLevel", critChanceLevel);
        SaveInt("critMultLevel", critMultLevel);
        SaveInt("healthLevel", healthLevel);
        SaveInt("healthRegenLevel", healthRegenLevel);
        SaveInt("defenseLevel", defenseLevel);
        SaveInt("cashLevel", cashLevel);
        SaveInt("coinsLevel", coinsLevel);

        PlayerPrefs.Save();
    }

    int LoadInt(string key, int defaultValue = 0)
    {
        return PlayerPrefs.GetInt(key, defaultValue);
    }

    void SaveInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    void OnApplicationQuit()
    {
        saveData();
    }
}