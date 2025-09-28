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

    
}
