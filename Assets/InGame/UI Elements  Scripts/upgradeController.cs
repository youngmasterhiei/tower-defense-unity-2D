using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic; // Required namespace to utilize generic types like List<>

/// <summary>
/// Controls the Main Menu Workshop UI. Handles switching between category pages (Offense, Defense, Utility)
/// and dynamically populates placeholder grid buttons using values defined in a central UpgradeData ScriptableObject.
/// </summary>
public class upgradeController : MonoBehaviour
{
    [Header("UI Element Arrays")]
    public GameObject[] upgradePages;

    public GameObject[] upgradeNavButtons;

    [Header("UI Prefab Link")]
    public UpgradeButtonUI buttonTemplate;

    [Header("Data Architecture")]
    public UpgradeData upgradeData;

    void Start()
    {
        // Loop through all assigned navigation buttons to dynamically configure their behaviors
        for (int i = 0; i < upgradeNavButtons.Length; i++)
        {
            // Extract the standard UI Button component from the current navigation GameObject
            Button btn = upgradeNavButtons[i].GetComponent<Button>();

            // Safety check: only proceed if a Button component actually exists on the object
            if (btn != null)
            {
                int indexForLambda = i;
                btn.onClick.AddListener(() => SwitchPage(indexForLambda));
            }
        }

        PopulateAllPages();
    }


    public void SwitchPage(int panelIndex)
    {
        for (int i = 0; i < upgradePages.Length; i++)
        {
            upgradePages[i].SetActive(i == panelIndex);
            if (i == panelIndex && upgradePages[i].TryGetComponent(out ScrollRect scroll))
            {
                scroll.verticalNormalizedPosition = 1f;
            }
        }
    }


    public void PopulateAllPages()
    {
        if (upgradeData == null || upgradeData.categories == null) return;

        for (int p = 0; p < upgradePages.Length; p++)
        {
            if (p >= upgradeData.categories.Count) break;

            List<UpgradeEntry> categoryUpgrades = upgradeData.categories[p].upgrades;
            Button[] buttons = upgradePages[p].GetComponentsInChildren<Button>(true);

            for (int i = 0; i < buttons.Length; i++)
            {
                if (i >= categoryUpgrades.Count)
                {
                    buttons[i].gameObject.SetActive(false);
                    continue;
                }

                UpgradeEntry entry = categoryUpgrades[i];

                if (!entry.isUnlocked)
                {
                    buttons[i].gameObject.SetActive(false);
                    continue;
                }

                UpgradeButtonUI btnUI = buttons[i].GetComponent<UpgradeButtonUI>();

                if (btnUI != null)
                {
                    if (btnUI.nameText != null) btnUI.nameText.text = entry.upgradeName;
                    if (btnUI.levelText != null) btnUI.levelText.text = "Lvl 0";
                    if (btnUI.costText != null) btnUI.costText.text = $"${entry.workshopCost:F0}";
                }

                buttons[i].gameObject.SetActive(true);
            }
        }
    }

}
