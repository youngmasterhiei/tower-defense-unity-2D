using UnityEngine;
using UnityEngine.UIElements; // Make sure this is at the top!

public class WorkShopController : MonoBehaviour
{
    [Header("Data Source")]
    [SerializeField] private UpgradeData upgradeData;

    // Changed from OnEnable() to Start() to guarantee everything is loaded in memory!
    private void Start()
    {
        // 1. Grab the component safely
        UIDocument uiDoc = GetComponent<UIDocument>();

        // 2. The Safety Check: If the inspector component is missing, stop instead of crashing!
        if (uiDoc == null)
        {
            Debug.LogError($"[WorkShopController] Missing a UIDocument component on {gameObject.name}! Please add one in the Inspector.", this);
            return;
        }

        // 3. Extract the root element safely
        VisualElement root = uiDoc.rootVisualElement;
        if (root == null)
        {
            Debug.LogError("[WorkShopController] UI Toolkit root element is null. Double check your Panel Settings assignment!", this);
            return;
        }

        root.Clear();

        // 4. Build the ScrollView container
        ScrollView container = new ScrollView(ScrollViewMode.Vertical);
        container.style.flexGrow = 1f;
        root.Add(container);

        // 5. Safety checks for data source
        if (upgradeData == null || upgradeData.upgrades == null)
        {
            Debug.LogWarning("Please drag your UpgradeData asset file into the script slot in the Inspector!");
            return;
        }

        // 6. The Dynamic Loop
        foreach (UpgradeEntry upgrade in upgradeData.upgrades)
        {
            container.Add(new Button(() => OnUpgradeClicked(upgrade.upgradeName))
            {
                text = $"{upgrade.upgradeName}\nCost: {upgrade.workshopCost}"
            });
        }
    }

    private void OnUpgradeClicked(string name)
    {
        Debug.Log($"[UI Toolkit] Tapped to purchase: {name}");
    }
}
