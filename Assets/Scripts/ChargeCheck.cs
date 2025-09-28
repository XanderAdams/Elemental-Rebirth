using UnityEngine;

public class ChargeCheck : MonoBehaviour
{
    private BreakableBox breakBox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //breakBox = GetComponent<BreakableBox>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Breakable")){
            breakBox = collision.gameObject.GetComponent<BreakableBox>();
            breakBox.Break();
            Debug.Log("broken");
        }
    }
}
