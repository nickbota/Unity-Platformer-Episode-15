using UnityEngine;
using UnityEngine.UI;

public class ResolutionText : MonoBehaviour
{
    private Text txt;
    private float updateTimer;

    private void Awake()
    {
        txt = GetComponent<Text>();
    }

    private void Update()
    {
        updateTimer += Time.unscaledTime;
        if (updateTimer > 0.5f)
            UpdateText();
    }
    private void UpdateText()
    {
        txt.text = "RESOLUTION:" + Screen.width + "x" + Screen.height;
    }
}
