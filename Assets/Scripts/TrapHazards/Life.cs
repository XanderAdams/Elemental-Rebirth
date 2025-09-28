using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public Character character;
    //use this on the next life

    [Header("UI Images")]
    public Image leafImage;
    public Image stoneImage;
    public Image airImage;

    public void UpdateLifeIcon() //not sure which works better, they jsut gonna both stay ig
    {
        //life slots from lifeui work with this 
        leafImage.gameObject.SetActive(true);
        stoneImage.gameObject.SetActive(true);
        airImage.gameObject.SetActive(true);

        if (character == Character.Plant)
        {
            leafImage.gameObject.SetActive(true);
            Debug.Log("Character is now Leaf");
        }
        else if (character == Character.Stone)
        {
            stoneImage.gameObject.SetActive(true);
            Debug.Log("Character is now Stone");
        }
        else if (character == Character.Air)
        {
            airImage.gameObject.SetActive(true);
            Debug.Log("Character is now Air");
        }
        else
        {
            Die();
            Debug.Log("Game Over?");
        }

        void Die() //die after characters lives are up
        {
            Debug.Log("Player has died.");
            //SceneManager.LoadScene("Dead");  //the dead scene or main menu etc
        }


    }
}