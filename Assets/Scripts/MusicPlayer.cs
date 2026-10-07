using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource audioSource;

    bool isPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (isPaused)
            {
                audioSource.UnPause();
            }
            else
            {
                audioSource.Pause();
            }
            isPaused = !isPaused;
        }
    }
}
