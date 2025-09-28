using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterManager : MonoBehaviour
{
    public LivesUI livesUI;
    public AirController airController;   
    public Transform respawnLocation;
    public GameObject playerObject;
    public DeathMenu deathPanel;

    private int currentIndex = 0;
    private Character[] characterOrder = { Character.Plant, Character.Stone, Character.Air };  
    private void Start()
    {
        // removed extra here
        airController.SetCharacter(characterOrder[0]);
        UpdateUI();
    }

    public void OnCharacterDeath()
    {
        currentIndex++;
        livesUI.LoseLife();

        if (currentIndex < characterOrder.Length)
        {
            // move player to respawn
            if (respawnLocation != null)
                airController.transform.position = respawnLocation.position;

            // should switch the players form without multiple gameobjects being needed
            airController.SetCharacter(characterOrder[currentIndex]);

            Debug.Log($"Respawned as {characterOrder[currentIndex]} at {respawnLocation.position}"); //the creature at which you switch to regarding the order above
        }
        else
        {
            Debug.Log("All characters dead. Game Over.");
            //playerObject.SetActive(false);
            deathPanel.ShowDeathMenu();
        }
    }

    private void UpdateUI()
    {
        int livesRemaining = characterOrder.Length - currentIndex;
        while (livesUI.GetLives() > livesRemaining)
            livesUI.LoseLife();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
