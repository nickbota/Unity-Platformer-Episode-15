using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    private AudioSource soundSource;
    private AudioSource musicSource;

    private void Awake()
    {
        soundSource = GetComponent<AudioSource>();
        musicSource = transform.GetChild(0).GetComponent<AudioSource>();

        //Keep this object even when we go to new scene
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //Destroy duplicate gameobjects
        else if (instance != null && instance != this)
            Destroy(gameObject);

        //Load volume values
        ChangeSoundVolume(0);
        ChangeMusicVolume(0);
    }
    public void PlaySound(AudioClip _sound)
    {
        soundSource.PlayOneShot(_sound);
    }

    //Volume functions
    public void ChangeSoundVolume(float _change)
    {
        #region Copy pasta
        //Set base value
        float baseVolume = 1;

        //Load saved value
        float currentValue = PlayerPrefs.GetFloat("soundVolume", 100);

        //Change value (make sure it's in 0-100 range)
        currentValue += _change;

        if (currentValue > 100)
            currentValue = 0;
        else if (currentValue < 0)
            currentValue = 100;

        //Save current value
        PlayerPrefs.SetFloat("soundVolume", currentValue);

        //Calculate final value and assign to audio source
        float finalValue = baseVolume * currentValue / 100;
        soundSource.volume = finalValue;
        #endregion

        //ChangeSourceVolume(1, _change, "soundVolume", soundSource);
    }
    public void ChangeMusicVolume(float _change)
    {
        #region Copy pasta
        //Set base value
        float baseVolume = 0.3f;

        //Load saved value
        float currentValue = PlayerPrefs.GetFloat("musicVolume", 100);

        //Change value (make sure it's in 0-100 range)
        currentValue += _change;

        if (currentValue > 100)
            currentValue = 0;
        else if (currentValue < 0)
            currentValue = 100;

        //Save current value
        PlayerPrefs.SetFloat("musicVolume", currentValue);

        //Calculate final value and assign to audio source
        float finalValue = baseVolume * currentValue / 100;
        musicSource.volume = finalValue;
        #endregion

        //ChangeSourceVolume(0.3f, _change, "musicVolume", musicSource);
    }

    //Helper function
    private void ChangeSourceVolume(float _baseValue, float _change, string _volumeName, AudioSource _source)
    {
        //Set base value
        float baseVolume = _baseValue;

        //Load saved value
        float currentValue = PlayerPrefs.GetFloat(_volumeName, 100);

        //Change value (make sure it's in 0-100 range)
        currentValue += _change;

        if (currentValue > 100)
            currentValue = 0;
        else if (currentValue < 0)
            currentValue = 100;

        //Save current value
        PlayerPrefs.SetFloat(_volumeName, currentValue);

        //Calculate final value and assign to audio source
        float finalValue = baseVolume * currentValue / 100;
        _source.volume = finalValue;
    }
}