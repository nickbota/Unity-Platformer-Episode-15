using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuScreen;
    [SerializeField] private GameObject settingsScreen;
    [SerializeField] private GameObject creditsScreen;

    //Resolution Sizes
    private int[] horizontalResolutions = new int[] { 640, 854, 1280, 1920 };
    private int[] verticalResolutions = new int[] { 360, 480, 720, 1280};
    private int currentResolution;

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

    //Open Menu
    public void OpenMenu()
    {
        ActivateScreen(menuScreen);
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

    #region Settings Functions
    public void ChangeSoundVolume()
    {
        SoundManager.instance.ChangeSoundVolume(20);
    }
    public void ChangeMusicVolume()
    {
        SoundManager.instance.ChangeMusicVolume(20);
    }
    public void ChangeResolution()
    {
        currentResolution++;
        if (currentResolution >= horizontalResolutions.Length)
            currentResolution = 0;

        Screen.SetResolution(horizontalResolutions[currentResolution], 
            verticalResolutions[currentResolution], true);
    }
    #endregion

    #region Credits Functions
    public void OpenYoutube()
    {
        OpenLink("https://www.youtube.com/c/PandemoniumGameDev");
    }
    public void OpenDragon()
    {
        OpenLink("https://assetstore.unity.com/packages/2d/characters/dragon-warrior-free-93896");
    }
    public void OpenPixelAdventure()
    {
        OpenLink("https://assetstore.unity.com/packages/2d/characters/pixel-adventure-1-155360");
    }
    public void OpenKnight()
    {
        OpenLink("https://assetstore.unity.com/packages/2d/characters/knight-sprite-sheet-free-93897");
    }
    public void OpenMusic()
    {
        OpenLink("https://patrickdearteaga.com/");
    }
    private void OpenLink(string _url)
    {
        Application.OpenURL(_url);
    }
    #endregion
}