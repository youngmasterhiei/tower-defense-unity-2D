using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class UpgradeEntry
{
    public string upgradeName;
    public float workshopCost = 1f;
    public float workshopCostMultiplier = 1.1f;
    public float workshopEffectPerLevel = 1.05f;
    public float inGameCost = 1f;
    public float inGameCostMultiplier = 1.1f;
    public float inGameEffectPerLevel = 1.05f;
}

[System.Serializable]
public class UpgradeCategoryGroup
{
    public string categoryName;
    public List<UpgradeEntry> upgrades = new List<UpgradeEntry>();
}

[CreateAssetMenu(fileName = "UpgradeData", menuName = "Tower Defense/Upgrade Data")]
public class UpgradeData : ScriptableObject
{
    public List<UpgradeCategoryGroup> categories = new List<UpgradeCategoryGroup>()
    {
        new UpgradeCategoryGroup
        {
            categoryName = "Offense",
            upgrades = new List<UpgradeEntry>()
            {
                new UpgradeEntry { upgradeName = "Damage" },
                new UpgradeEntry { upgradeName = "Attack Speed" },
                new UpgradeEntry { upgradeName = "Crit Chance" },
                new UpgradeEntry { upgradeName = "Crit Multiplier" }
            }
        },
        new UpgradeCategoryGroup
        {
            categoryName = "Defense",
            upgrades = new List<UpgradeEntry>()
            {
                new UpgradeEntry { upgradeName = "Health" },
                new UpgradeEntry { upgradeName = "Health Regen" },
                new UpgradeEntry { upgradeName = "Defense" }
            }
        },
        new UpgradeCategoryGroup
        {
            categoryName = "Utility",
            upgrades = new List<UpgradeEntry>()
            {
                new UpgradeEntry { upgradeName = "Cash" },
                new UpgradeEntry { upgradeName = "Coins" }
            }
        }
    };
}
