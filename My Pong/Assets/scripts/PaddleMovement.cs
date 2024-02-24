using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    //variables for the code
    public float speed = 10f;               //control speed
    public float yBorder = 4.5f;            //control the borders
    public Rigidbody2D rb2dRP;              //place to store the rigidbody of Right Paddle
    public Rigidbody2D rb2dLP;              //place to store the rigidbody of Left Paddle

    // Start is called before the first frame update
    void Start()
    {
        // rb2dRP = GetComponent<Rigidbody2D>(); //store the rigidbody from this object
    }

    // Update is called once per frame
    void Update()
    {
        var velocityRP = rb2dRP.velocity;   //create and declare variable for velocity Right Paddle
        var velocityLP = rb2dLP.velocity;   //create and declare variable for velocity Left Paddle


        //Control the Right Paddle
        if (CompareTag("RPaddle"))                                                   //if the object is the right paddle
        {
            if (Input.GetKey(KeyCode.O) && transform.position.y < yBorder)          //while O is held + still inside
            {
                velocityRP.y = speed;                                               //set direction to up
            }

            else if (Input.GetKey(KeyCode.L) && transform.position.y > -yBorder)    //while L is held + still inside
            {
                velocityRP.y = -speed;                                              //set direction to down
            }

            else
            {
                velocityRP.y = 0;                                                   //dont move
            }
        }

        //Control the Left Paddle
        if (CompareTag("LPaddle"))                                                  //if the object is the left paddle
        {
            if (Input.GetKey(KeyCode.W) && transform.position.y < yBorder)          //while W is held + still inside
            {
                velocityLP.y = speed;                                               //set direction to up
            }

            else if (Input.GetKey(KeyCode.S) && transform.position.y > -yBorder)    //while S is held + still inside
            {
                velocityLP.y = -speed;                                              //set direction to down
            }

            else
            {
                velocityLP.y = 0;                                                   //dont move
            }
        }

        rb2dRP.velocity = velocityRP;                                               //move the right padddle
        rb2dLP.velocity = velocityLP;                                               //move the left paddle

    }
}