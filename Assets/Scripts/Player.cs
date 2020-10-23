using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float movementSpeed = 10f;
    Rigidbody2D rb;
    float movement = 0f;
    BoxCollider2D myFeet;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        myFeet = GetComponent<BoxCollider2D>();
    }

    void Update(){
        movement = Input.GetAxis("Horizontal") * movementSpeed;
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
        FlipSprite();
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(myFeet.IsTouchingLayers(LayerMask.GetMask("Platform Breaker"))){
            Destroy(collision.gameObject);
        }
    }

    private void FlipSprite(){
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if(playerHasHorizontalSpeed){
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
    }
}
