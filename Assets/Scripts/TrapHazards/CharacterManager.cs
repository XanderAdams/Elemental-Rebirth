using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    [Header("Characters")]
    public GameObject[] characters;

    [Header("UI")]
    public LivesUI livesUI;

    private int currentIndex = 0;

    private void Start()
    {
        // Activate first, disable others
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(i == 0);
        }

        UpdateUI();
    }

    public void OnCharacterDeath()
    {
        characters[currentIndex].SetActive(false);
        currentIndex++;

        if (currentIndex < characters.Length)
        {
            characters[currentIndex].SetActive(true);
        }
        else
        {
            Debug.Log("All characters dead. Game Over.");
            GameOver();
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        int livesRemaining = characters.Length - currentIndex;
        livesUI.SetLives(livesRemaining);
    }

    private void GameOver()
    {
        // Reload for now
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
