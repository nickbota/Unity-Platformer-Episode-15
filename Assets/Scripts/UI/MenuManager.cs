using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private RectTransform arrow;
    [SerializeField] private RectTransform[] buttons;
    [SerializeField] private AudioClip changeSound;
    [SerializeField] private AudioClip interactSound;
    private int currentPosition;

    private void Awake()
    {
        ChangePosition(0);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            ChangePosition(-1);
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            ChangePosition(1);

        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetButtonDown("Submit"))
            Interact();
    }

    public void ChangePosition(int _change)
    {
        currentPosition += _change;

        if (_change != 0)
            SoundManager.instance.PlaySound(changeSound);

        if (currentPosition < 0)
            currentPosition = buttons.Length - 1;
        else if (currentPosition > buttons.Length - 1)
            currentPosition = 0;

        AssignPosition();
    }
    private void AssignPosition()
    {
        arrow.position = new Vector3(arrow.position.x, buttons[currentPosition].position.y);
    }
    private void Interact()
    {
        SoundManager.instance.PlaySound(interactSound);

        if (currentPosition == 0)
        {
            //Start game
            SceneManager.LoadScene(PlayerPrefs.GetInt("level", 1));
        }
        else if (currentPosition == 1)
        {
            //Open Settings
        }
        else if (currentPosition == 2)
        {
            //Open Credits
        }
        else if (currentPosition == 3)
            Application.Quit();
    }
}