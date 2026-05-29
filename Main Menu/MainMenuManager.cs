// SceneA.
// SceneA is given the sceneName which will
// load SceneB from the Build Settings

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    void Start()
    {
        // Debug.Log("Starting game");

    }

    public void StartGame()
    {
        Debug.Log("sceneName to load:  game");
        SceneManager.LoadScene("game");
    }
}