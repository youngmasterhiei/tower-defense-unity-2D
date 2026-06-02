using UnityEngine;
using UnityEngine.UI;

public class WorkShopController : MonoBehaviour
{


    // sets buttons and pages in the inspector into an array
    public GameObject[] upgradePages;
    public GameObject[] upgradeNavButtons;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    void Start()
    {

        // is called once in start to save the button number to an index
        for (int i = 0; i < upgradeNavButtons.Length; i++)
        {
            Button btn = upgradeNavButtons[i].GetComponent<Button>();
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


        for (int i = 0; i < upgradePages.Length; i++)
        {
            // If the loop index matches the requested index, set active. Otherwise, inactive.
            // shorthand if then statmenet
            upgradePages[i].SetActive(i == panelIndex);
        }

    }

    public void ShowWorkShop()
    {


        // foreach (UpgradeEntry entry in upgradeData.upgrades) { Debug.Log(entry.upgradeName); }
    }
}


