using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2D;
    public GameManager gameManager;
    [Range(3,8)]
    public float jumpVelocity;
    private float bufferCheck = 0.1f; //slightly above zero
    public float fallMultiplier = 2.5f;

    public LayerMask groundLayer;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }//Awake

    private void Start()
    {
      
    }//Start

    private void Update()
    {
        
        if (isGrounded() && Input.GetKeyDown(KeyCode.Space) || isGrounded() && Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = Vector2.up * jumpVelocity;
        }

        if(rb.velocity.y < -3)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 2) * Time.deltaTime;
        }
     
 
    }//Update

    private bool isGrounded()
    {

        return Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, bufferCheck, groundLayer);

}//isGrounded

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            this.gameObject.SetActive(false);
            gameManager.GameOver();
        }
    }//OnCol

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Obstacle")
        {
            gameManager.Score();
        }
    }


}
