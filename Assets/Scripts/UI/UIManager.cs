using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private AudioClip gameOverSound;

    private void Awake()
    {
        PauseGame(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseUI.activeInHierarchy)
                PauseGame(false);
            else
                PauseGame(true);
        }
    }

    //Game over function
    public void GameOver()
    {
        gameOverUI.SetActive(true);
        SoundManager.instance.PlaySound(gameOverSound);
    }

    //Restart
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Return to menu
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //Quit game/exit play mode
    public void Quit()
    {
        Application.Quit(); //Quit game(only works in build)

        //Exit play mode (only works in editor)
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    //Pause menu functions
    public void PauseGame(bool _status)
    {
        pauseUI.SetActive(_status);
        Time.timeScale = System.Convert.ToInt32(!_status);
    }

    //Change sound/music volume
    public void ChangeSoundVolume()
    {
        SoundManager.instance.ChangeSoundVolume(20);
    }
    public void ChangeMusicVolume()
    {
        SoundManager.instance.ChangeMusicVolume(20);
    }
}