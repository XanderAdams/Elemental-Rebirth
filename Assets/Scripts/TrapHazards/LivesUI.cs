using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LivesUI : MonoBehaviour
{
    [Header("UI References")]
    [Tooltip("Life slots (each should have a Life script).")]
    public Life[] lifeSlots;         // each slot = one icon with a Life script
    public TextMeshProUGUI livesText;

    private int currentLives;

    private void Start()
    {
        currentLives = lifeSlots.Length;
        UpdateUI();
    }

    public void LoseLife()
    {
        if (currentLives > 0)
        {
            currentLives--;
            UpdateUI();
        }
    }

    public void GainLife()
    {
        if (currentLives < lifeSlots.Length)
        {
            currentLives++;
            UpdateUI();
        }
    }

    private void UpdateUI() //calls from life script
    {
        for (int i = 0; i < lifeSlots.Length; i++)
        {
            // only show active lives
            lifeSlots[i].gameObject.SetActive(i < currentLives);

            // also refresh the icon type
            if (i < currentLives)
                lifeSlots[i].UpdateLifeIcon();
        }

        if (livesText != null)
            livesText.text = "Lives: " + currentLives;
    }

    public int GetLives()
    {
        return currentLives;
    }
}
