using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathMenu : MonoBehaviour
{
    public GameObject deathPanel;

    public void RestartGame()
    {
        // Reload the currently active scene
        Time.timeScale = 1f; // unpause before reload
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitToMainMenu()
    {
        // Load the main menu scene by name
        Time.timeScale = 1f; // unpause before switching
        SceneManager.LoadScene("MainMenu");
    }

    public void ShowDeathMenu()
    {
        deathPanel.SetActive(true);
        Time.timeScale = 0f; // pause game
    }
}
