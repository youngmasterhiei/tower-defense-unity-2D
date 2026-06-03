using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic; // Required namespace to utilize generic types like List<>

/// <summary>
/// Controls the Main Menu Workshop UI. Handles switching between category pages (Offense, Defense, Utility)
/// and dynamically populates placeholder grid buttons using values defined in a central UpgradeData ScriptableObject.
/// </summary>
public class WorkShopController : MonoBehaviour
{
    [Header("UI Element Arrays")]
    // References to the UI panel containers for each page (e.g., Index 0 = Offense Scroll View, Index 1 = Defense, etc.)
    public GameObject[] upgradePages;

    // References to the navigation bar buttons used to toggle between the different upgrade pages
    public GameObject[] upgradeNavButtons;

    [Header("UI Prefab Link")]
    // Reference slot for your Master UI Button Prefab template component. 
    // This explicitly tells this controller to recognize the custom UpgradeButtonUI data type.
    public UpgradeButtonUI buttonTemplate;

    [Header("Data Architecture")]
    // Reference slot for your custom UpgradeData ScriptableObject containing the nested category and upgrade entries
    public UpgradeData upgradeData;

    /// <summary>
    /// Unity built-in lifecycle method called automatically once before the very first frame update.
    /// Used here to initialize button events and trigger the initial UI setup.
    /// </summary>
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
                // Freeze the current loop index into a local variable. This is critical for the lambda expression 
                // below, preventing it from incorrectly utilizing the final value of 'i' when the loop finishes.
                int indexForLambda = i;

                // Add a runtime click event listener. When this nav button is clicked, it calls SwitchPage 
                // passing its specific index number (0 for Offense, 1 for Defense, etc.)
                btn.onClick.AddListener(() => SwitchPage(indexForLambda));
            }
        }

        // Run the dynamic populator once at game startup to sync layout text blocks with scriptable data
        PopulateAllPages();
    }

    /// <summary>
    /// Changes which upgrade sub-menu panel is visible to the player.
    /// </summary>
    /// <param name="panelIndex">The index number of the category page that should be shown.</param>
    public void SwitchPage(int panelIndex)
    {
        // Loop through every page registered in our UI panel array
        for (int i = 0; i < upgradePages.Length; i++)
        {
            // If the current index matches the requested page index, set active to true; otherwise, set false.
            // This turns on the requested category screen and cleanly shuts down all other ones.
            upgradePages[i].SetActive(i == panelIndex);

            // Efficiency Check: If this is the newly activated page, attempt to grab a ScrollRect component.
            // Using TryGetComponent is highly optimized because it avoids memory allocation errors if missing.
            if (i == panelIndex && upgradePages[i].TryGetComponent(out ScrollRect scroll))
            {
                // Forcefully snap the scroll box back up to the absolute top (1.0f represents 100% top value).
                // This guarantees that opening a new tab doesn't start midway scrolled down from a previous page.
                scroll.verticalNormalizedPosition = 1f;
            }
        }
    }

    /// <summary>
    /// Iterates through all upgrade page elements and maps names from your custom data structures directly onto the UI layout.
    /// </summary>
    public void PopulateAllPages()
    {
        // Guard Rail Safety Check: If the ScriptableObject reference is null, or if its inner category list 
        // hasn't been instantiated yet, exit immediately. This avoids a NullReferenceException crash.
        if (upgradeData == null || upgradeData.categories == null) return;

        // Outer Loop: Step through every UI page configured in the Canvas inspector
        for (int p = 0; p < upgradePages.Length; p++)
        {
            // Array Bounds Check: If your UI has more pages assigned than there are categories structured 
            // inside the ScriptableObject asset, break out to prevent pulling invalid structural parameters.
            if (p >= upgradeData.categories.Count) break;

            // Extract the direct List of upgrade entries belonging to this specific category group matching the page index
            List<UpgradeEntry> categoryUpgrades = upgradeData.categories[p].upgrades;

            // Scan the current sub-menu page layout and compile an array of every single UI Button component hidden inside.
            // Passing 'true' guarantees Unity finds buttons even if the page or gameobject is currently deactivated/invisible.
            Button[] buttons = upgradePages[p].GetComponentsInChildren<Button>(true);

            // Inner Loop: Step through every UI placeholder button detected inside this specific page
            for (int i = 0; i < buttons.Length; i++)
            {
                // 1. Extract your new custom script component right off the current button object.
                UpgradeButtonUI btnUI = buttons[i].GetComponent<UpgradeButtonUI>();

                // Logical Branch: Determine if we have real scriptable asset data ready for this button slot index
                if (i < categoryUpgrades.Count)
                {
                    // Pull the structural data parameters corresponding to this exact index number out of our Scriptable list
                    UpgradeEntry entry = categoryUpgrades[i];

                    // 2. Direct, lightning-fast assignment using your new drag-and-drop reference slots!
                    if (btnUI != null)
                    {
                        // Safely apply text to your Name, Level, and Cost fields if they have been assigned
                        if (btnUI.nameText != null) btnUI.nameText.text = entry.upgradeName;
                        if (btnUI.levelText != null) btnUI.levelText.text = "Lvl 0";
                        if (btnUI.costText != null) btnUI.costText.text = $"${entry.workshopCost:F0}";
                    }

                    // Ensure the button is fully active, visible, and interactive for the user
                    buttons[i].gameObject.SetActive(true);
                }
                else
                {
                    // If the slot number 'i' is larger than our actual upgrade count, we have run out of data.
                    // This line hides the remaining empty layout placeholder grids cleanly from the UI framework view.
                    buttons[i].gameObject.SetActive(false);
                }
            }
        }
    }
}
