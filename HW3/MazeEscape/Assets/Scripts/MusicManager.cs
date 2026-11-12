using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    public Text buttonText;

    // static so the choice is remembered after restarting the scene
    static bool musicOn = true;

    void Start()
    {
        UpdateMusic();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMusic();
        }
    }

    public void ToggleMusic()
    {
        musicOn = !musicOn;
        UpdateMusic();
    }

    void UpdateMusic()
    {
        if (musicOn)
        {
            audioSource.UnPause();
            buttonText.text = "Music: ON";
        }
        else
        {
            audioSource.Pause();
            buttonText.text = "Music: OFF";
        }
    }
}
