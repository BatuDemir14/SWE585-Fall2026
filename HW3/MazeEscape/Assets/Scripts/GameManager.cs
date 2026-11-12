using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject endPanel;
    public Text endText;

    bool gameEnded = false;

    void Start()
    {
        Time.timeScale = 1f;
        endPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayAgain();
        }
    }

    public void WinGame()
    {
        EndGame("You escaped the maze!");
    }

    public void LoseGame(string reason)
    {
        EndGame(reason);
    }

    void EndGame(string message)
    {
        if (gameEnded)
        {
            return;
        }

        gameEnded = true;
        endText.text = message + "\nDo you want to play another round?";
        endPanel.SetActive(true);
        Time.timeScale = 0f; // stop the game
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Debug.Log("quit game");
        Application.Quit();
    }
}
