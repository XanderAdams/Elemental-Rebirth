using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LivesUI : MonoBehaviour
{
    [Header("UI References")]
    public Image[] lifeIcons;          
    public TextMeshProUGUI livesText; 

    private int currentLives;

    public void SetLives(int lives)
    {
        currentLives = lives;

        
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            lifeIcons[i].enabled = i < currentLives;
        }

        
        if (livesText != null)
        {
            livesText.text = "Lives: " + currentLives;
        }
    }
}
