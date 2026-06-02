using UnityEngine;
using UnityEngine.UI;

public class NavManager : MonoBehaviour
{


    // sets buttons and pages in the inspector into an array
    public GameObject[] mainPages;
    public GameObject[] navButtons;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    void Start()
    {

        // is called once in start to save the button number to an index
        for (int i = 0; i < navButtons.Length; i++)
        {
            Button btn = navButtons[i].GetComponent<Button>();
            if (btn != null)
            {
                // Freeze the current loop index and program the button to open that matching page on click
                int indexForLambda = i;
                btn.onClick.AddListener(() => SwitchPage(indexForLambda));
            }

        }
    }

    public void SwitchPage(int panelIndex)
    {
        // Debug.Log(panels[0]);
        // GameObject.Find("StartGameButton");
        // uiPanel.SetActive(true);


        for (int i = 0; i < mainPages.Length; i++)
        {
            // If the loop index matches the requested index, set active. Otherwise, inactive.
            // shorthand if then statmenet
            mainPages[i].SetActive(i == panelIndex);
        }

    }

    public void ShowWorkShop()
    {


        // foreach (UpgradeEntry entry in upgradeData.upgrades) { Debug.Log(entry.upgradeName); }
    }
}





// public class PanelController : MonoBehaviour
// {
//     // Drag your Panel GameObject into this field in the Unity Inspector
//     [SerializeField] private GameObject uiPanel; 

//     // Call this method to show the panel
//     public void ShowPanel()
//     {
//         uiPanel.SetActive(true);
//     }

//     // Call this method to hide the panel
//     public void HidePanel()
//     {
//         uiPanel.SetActive(false);
//     }

//     // Call this method to toggle between showing and hiding
//     public void TogglePanel()
//     {
//         bool isActive = uiPanel.activeSelf;
//         uiPanel.SetActive(!isActive);
//     }
// }
