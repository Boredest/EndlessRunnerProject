using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2D;
    [Range(3,8)]
    public float jumpVelocity;
    private float bufferCheck = 0.1f; //slightly above zero

    public LayerMask groundLayer;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }//Awake

    void Start()
    {
      
    }//Start

    void Update()
    {
        
        if (isGrounded() && Input.GetKeyDown(KeyCode.Space))
        {

            rb.velocity = Vector2.up * jumpVelocity;
        }
    }//Update

    private bool isGrounded()
    {

        return Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, bufferCheck, groundLayer);

}//isGrounded
  

}
