using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class UpgradeEntry
{
    public string upgradeName;
    public float statValue = 1f;
    public float workshopCost = 1f;
    public float workshopCostMultiplier = 1.1f;
    public float workshopEffectPerLevel = 1.05f;
    public float inGameCost = 1f;
    public float inGameCostMultiplier = 1.1f;
    public float inGameEffectPerLevel = 1.05f;
    public int unLockCost;
    public bool isUnlocked = false;
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
                new UpgradeEntry { upgradeName = "Damage", statValue = 25f, inGameCost = 1f, isUnlocked = true },
                new UpgradeEntry { upgradeName = "Attack Speed", statValue = 2.3f, inGameCost = 1f, isUnlocked = true },
                new UpgradeEntry { upgradeName = "Range", statValue = 4f, isUnlocked = true },
                new UpgradeEntry { upgradeName = "Crit Chance", statValue = 2f },
                new UpgradeEntry { upgradeName = "Crit Multiplier" },
                new UpgradeEntry { upgradeName = "Multi-Shot Chance"},
                new UpgradeEntry { upgradeName = "Multi-Shot Quantity"},
                new UpgradeEntry { upgradeName = "Rapid-Fire Duration"},
                new UpgradeEntry { upgradeName = "Rapid-Fire Chance"},
                new UpgradeEntry { upgradeName = "Bounce-Shot Chance"},
                new UpgradeEntry { upgradeName = "Bounce-Shot Quantity"},
                new UpgradeEntry { upgradeName = "Rend-Armor Chance"},
                new UpgradeEntry { upgradeName = "Rend-Armor Multiplier"},
                new UpgradeEntry { upgradeName = "Poison-Shot Duration" },
                new UpgradeEntry { upgradeName = "Poison-Shot Chance" },
                new UpgradeEntry { upgradeName = "Slow-Shot Chance" },
                new UpgradeEntry { upgradeName = "Slow-Shot Duration" }


            }
        },
        new UpgradeCategoryGroup
        {
            categoryName = "Defense",
            upgrades = new List<UpgradeEntry>()
            {
                new UpgradeEntry { upgradeName = "Health", isUnlocked = true },
                new UpgradeEntry { upgradeName = "Health Regen", isUnlocked = true },
                new UpgradeEntry { upgradeName = "Defense" },
                new UpgradeEntry { upgradeName = "Knockback Chance"},
                new UpgradeEntry { upgradeName = "Knockback Strength"},
                new UpgradeEntry { upgradeName = "Shield Amount"},
                new UpgradeEntry { upgradeName = "Shield Regen"},
                new UpgradeEntry { upgradeName = "Lifesteal Percent"}


            }
        },
        new UpgradeCategoryGroup
        {
            categoryName = "Utility",
            upgrades = new List<UpgradeEntry>()
            {
                new UpgradeEntry { upgradeName = "Cash", isUnlocked = true },
                new UpgradeEntry { upgradeName = "Coins", isUnlocked = true },
                new UpgradeEntry { upgradeName = "Mana Amount"},
                new UpgradeEntry { upgradeName = "Mana Regen"},
                new UpgradeEntry { upgradeName = "Free Upgrade Offense"},
                new UpgradeEntry { upgradeName = "Free Upgrade Defense"},
                new UpgradeEntry { upgradeName = "Free Upgrade Utility"},
                new UpgradeEntry { upgradeName = "Wave Skip Chance"}


            }
        }
    };
}
