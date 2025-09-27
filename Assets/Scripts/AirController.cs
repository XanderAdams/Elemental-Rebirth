using System.Collections;
using UnityEngine;

public class AirController : MonoBehaviour
{
    public Character character = Character.Human;
    private Rigidbody2D body;
    public float speed = 10f;
    public float chargeSpeed = 100f;
    public float jump = 50f;
    public float doubleJump = 100f;
    public bool isJumping;
    public Vector2 boxsize;
    public float castDistinace;
    public LayerMask groundLayer;
    Vector2 movement;
    public int facing = 1;
    public int maxJumps = 2;
    public int jumpAmount = 0;
    public GameObject chargeCheck;
    public bool isCharging;
    public bool isAirGuy = false;
    public bool isEarthGuy = false;
 
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    public void Start()
    {
        if(isAirGuy == false){
            maxJumps = 0;
        }
        else{
            maxJumps = 1;
        }
        jumpAmount = maxJumps;

    }

    private void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        body.linearVelocity = new Vector2(movement.x * speed, body.linearVelocity.y);

        if (movement.x > 0.1f || movement.x < -0.1f)
        {
            gameObject.GetComponent<Animator>().SetBool("Moving", true);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("Moving", false);
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            StartCoroutine(JumpCooldown());

            body.linearVelocity = new Vector2(body.linearVelocity.x, jump);
            jumpAmount--;
            
        }
        if (Input.GetKey(KeyCode.Space) && jumpAmount > 0 && isJumping == false)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, doubleJump);

            StartCoroutine(JumpCooldown());
            jumpAmount--;
        }
        if (isGrounded())
        {
            jumpAmount = maxJumps;
        }
        if (isGrounded())
        {
            gameObject.GetComponent<Animator>().SetBool("jumping", false);
        }
        if (isGrounded() == false)
        {
            gameObject.GetComponent<Animator>().SetBool("jumping", true);
        }
        if (movement.x < 0)
        {
            if(isCharging == false)
            {
                facing = -1;
                transform.rotation = Quaternion.Euler(transform.eulerAngles.x, 180, transform.eulerAngles.z);
            }
        }
        else if (movement.x > 0)
        {
            if(isCharging == false)
            {
                facing = 1;
                transform.rotation = Quaternion.Euler(transform.eulerAngles.x, 0, transform.eulerAngles.z);
            }
        }
        if (Input.GetKey(KeyCode.F) )
        {
            if (isEarthGuy)
            {
                chargeCheck.SetActive(true);
                //body.linearVelocity = new Vector2(movement.x * chargeSpeed, body.linearVelocity.y);
                body.AddForce(new Vector2((facing * chargeSpeed * 10), body.linearVelocity.y));
                isCharging = true;
                gameObject.GetComponent<Animator>().SetBool("Skill", true);
            }
            else
            {
                chargeCheck.SetActive(false);
                isCharging = false;
                gameObject.GetComponent<Animator>().SetBool("Skill", false);
            }
        }
            
    }


    public bool isGrounded(){
        if(Physics2D.BoxCast(transform.position,boxsize,0, -transform.up,castDistinace, groundLayer ) ) {
            return true;
            
            
        }
        else{
            return false;
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up * castDistinace, boxsize );
    }

    private IEnumerator JumpCooldown()
    {
        
        isJumping = true;
        yield return new WaitForSeconds(0.5f);
        isJumping = false;
        Debug.Log("done");
    }
}

public enum Character
{
    Human,
    Plant,
    Stone,
    Air
}