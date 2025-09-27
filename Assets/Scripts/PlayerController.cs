using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
        private Rigidbody2D body;
        public float speed = 10f;
        public float jump = 50f;
        public bool isJumping;
        public Vector2 boxsize;
        public float castDistinace;
        public LayerMask groundLayer;
        Vector2 movement;
        public int facing = 1;
 
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
 
    private void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        body.linearVelocity = new Vector2(movement.x * speed, body.linearVelocity.y);
        
        if(movement.x>0.2f||movement.x<-0.2f){
            gameObject.GetComponent<Animator>().SetBool("Moving", true);
        }
        else{
            gameObject.GetComponent<Animator>().SetBool("Moving", false);
        }
 
        if (Input.GetKey(KeyCode.Space) && isGrounded()){
            body.AddForce(new Vector2(body.linearVelocity.x,jump));
            
            StartCoroutine(JumpCooldown());
        }
        if(isGrounded()){
            gameObject.GetComponent<Animator>().SetBool("Jumping", false);
        }
        if(isGrounded() == false){
            gameObject.GetComponent<Animator>().SetBool("Jumping", true);
        }
        if(movement.x<0 )
        {
            facing = -1;
            gameObject.GetComponent<SpriteRenderer>().flipX=true;
        }
        else if (movement.x>0 )
        {
            facing = 1;
             gameObject.GetComponent<SpriteRenderer>().flipX=false;
        }
    }


    public bool isGrounded(){
        if(Physics2D.BoxCast(transform.position,boxsize,0, -transform.up,castDistinace, groundLayer )) {
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
        yield return new WaitForSeconds(0.4f);
        isJumping = false;
        Debug.Log("done");
    }
}