using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    public GameObject[] characters;
    public LivesUI livesUI;

    private int currentIndex = 0;

    private void Start()
    {
        for (int i = 0; i < characters.Length; i++)
            characters[i].SetActive(i == 0);

        UpdateUI();
    }

    public void OnCharacterDeath()
    {
        characters[currentIndex].SetActive(false);
        currentIndex++;

        livesUI.LoseLife(); // UI updates in order

        if (currentIndex < characters.Length)
        {
            characters[currentIndex].SetActive(true);
        }
        else
        {
            Debug.Log("All characters dead. Game Over.");
            GameOver();
        }
    }

    private void UpdateUI()
    {
        int livesRemaining = characters.Length - currentIndex;
        // just to sync UI at start
        while (livesUI.GetLives() > livesRemaining)
            livesUI.LoseLife();
    }

    private void GameOver()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene
        (
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }
}
