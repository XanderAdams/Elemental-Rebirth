using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{
    public Character newCharacter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AirController player = collision.GetComponent<AirController>();
            if (player != null)
            {
                player.SetCharacter(newCharacter);
            }
        }
    }
}
