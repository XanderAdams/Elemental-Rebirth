using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrapHazard : MonoBehaviour
{
    [Header("Trap Settings")]
    [Tooltip("Tag used to identify the player object.")]
    public string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.Kill();
            }
            else
            {
                Debug.LogWarning("Player collided with trap but has no PlayerHealth script attached!");
            }
        }
    }
}
