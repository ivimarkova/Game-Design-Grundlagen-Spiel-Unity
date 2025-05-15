using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public Rigidbody2D playerRb;
    public float speed;
    public float input; //keep track which direction button you are pressing
    public SpriteRenderer spriteRenderer;
    public float jumpForce;

    //Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal"); //pushing left =-1; pushing right=1
        if(input < 0)
        {
            spriteRenderer.flipX = true;
        }//flips back
        else if(input > 0)
        {
            spriteRenderer.flipX=false;
        }

        if (Input.GetButton("Jump"))//velocity - direction and speed where we are moving
        {
            playerRb.linearVelocity = Vector2.up * jumpForce;
        }

    }

    void FixedUpdate()//50 frames per second
    {
        playerRb.linearVelocity = new Vector2 (input * speed, playerRb.linearVelocity.y);
    }
    public void Die()
    {
        Debug.Log("Player died!");
        //add here restart; losing life etc
    }

}
