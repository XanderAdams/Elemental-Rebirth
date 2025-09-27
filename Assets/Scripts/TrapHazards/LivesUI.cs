using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LivesUI : MonoBehaviour
{
    [Header("UI References")]
    public Image[] lifeIcons;          // Drag your 4 UI Images here in order
    public TextMeshProUGUI livesText;  // Optional text, e.g. "Lives:"

    private int currentLives;

    public void SetLives(int lives)
    {
        currentLives = lives;

        // Update life icons
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            lifeIcons[i].enabled = i < currentLives;
        }

        // Update TMP text
        if (livesText != null)
        {
            livesText.text = "Lives: " + currentLives;
        }
    }
}
