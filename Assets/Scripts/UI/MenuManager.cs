using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuScreen;
    [SerializeField] private GameObject settingsScreen;
    [SerializeField] private GameObject creditsScreen;

    private void Awake()
    {
        //Activate main menu on start
        ActivateScreen(menuScreen);
    }

    #region Main Menu Functions
    //Load game
    public void LoadGame()
    {
        int currentLevel = PlayerPrefs.GetInt("currentLevel", 1);
        SceneManager.LoadScene(currentLevel);
    }

    //Open Settings
    public void OpenSettings()
    {
        ActivateScreen(settingsScreen);
    }

    //Open Credits
    public void OpenCredits()
    {
        ActivateScreen(creditsScreen);
    }

    //Quit game
    public void Quit()
    {
        Application.Quit(); //Quit game(only works in build)

        //Exit play mode (only works in editor)
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    #endregion

    //Helper function
    private void ActivateScreen(GameObject _screen)
    {
        menuScreen.SetActive(false);
        settingsScreen.SetActive(false);
        creditsScreen.SetActive(false);

        _screen.SetActive(true);
    }
}