using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{
    public void Kill()
    {
        Debug.Log(name + " was killed by a trap!");

        // Notify CharacterManager
        FindObjectOfType<CharacterManager>().OnCharacterDeath();
    }

   /* private void Die() //die after characters lives are up
    {
        // Replace this with death logic (respawn, game over, animation, etc.)
        Debug.Log("Player has died.");
        Destroy(gameObject); 
    }*/
}
