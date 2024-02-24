using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    //variables for the game

    //variables for the movement speed
    public float xSpeed = 0.05f;         //variable for horizontal speed
    public float ySpeed = 0.05f;         //variable for vertical speed

    //variables for the direction movement
    private bool xMove = true;          //variable for horizontal direction
    private bool yMove = true;          //variable for vertical direction

    //variables for the border  
    float xBorder = 7.5f;               //variable for horizontal borders
    float yBorder = 4.5f;               //variable for vertival borders

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal movement
        if (xMove == true)                                                                              //if direction is right
        {
            transform.position = new Vector2(transform.position.x + xSpeed, transform.position.y);     //move to right
        }
        else                                                                                            //if direction is left
        {
            transform.position = new Vector2(transform.position.x + xSpeed, transform.position.y);     //move to left
        }

        if (transform.position.x >= xBorder)                                                             //if ball gets to right edge
        {
            xMove = false;                                                                              //make direction left
            xSpeed *= -1;                                                                               //make the ball go left
        }

        else if (transform.position.x <= -xBorder)                                                      //if  ball gets to left edge 
        {
            xMove = true;                                                                               //make direction right
            xSpeed *= -1;                                                                               //make the ball go right
        }

        //Vertical movement
        if (yMove == true)                                                                              //if direction is up
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + ySpeed);     //make the ball go up
        }

        else                                                                                            //if direction is down
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + ySpeed);     //make the ball go down
        }

        if (transform.position.y >= yBorder)                                                            //if the ball gets to the top
        {
            yMove = false;                                                                              //make direction down
            ySpeed *= -1;                                                                               //make the ball go down

        }

        else if (transform.position.y <= -yBorder)                                                      //if the ball gets to the bottom
        {
            yMove = true;                                                                               //make direction up
            ySpeed *= -1;                                                                               //make the ball go up
        }
    }

    // OnCollisionEnter is called when this collider or rigidbody has begun touching another rigidbody/collider.
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("RPaddle"))        //if the object collides with something containing the tag RPaddle
        {
            Debug.Log("hit");                          //send a message to the console informing the hit

            if (xMove == true)                          //if the ball is going to the right  
            {
                xMove = false;                          //change it's direction to left
                xSpeed *= -1;                           //make it go left
            }
        }

        if (coll.collider.CompareTag("LPaddle"))
        {
            if (xMove == false)                         //if the ball is going to left
            {
                xMove = true;                           //change direction to right
                xSpeed *= -1;                           //make it go right
            }
        }
    }
}