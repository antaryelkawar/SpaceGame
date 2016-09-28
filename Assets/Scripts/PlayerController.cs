using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;             //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

    private Vector2 currentVelocity;
    private Vector2 oppositeForce;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, 0, 8) * speed * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-new Vector3(0, 0, 8) * speed * Time.fixedDeltaTime);
        }
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        if (rb2d.velocity.magnitude < 20)
        {
            Vector2 currentVelocity = rb2d.velocity;
            Vector2 oppositeForce = -currentVelocity;
            if (Input.GetKey(KeyCode.Space))
            {
                rb2d.AddForce(oppositeForce * 2, ForceMode2D.Force);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                rb2d.AddForce(-transform.up * speed * Time.fixedDeltaTime * 50);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                rb2d.AddForce(transform.up * speed * Time.fixedDeltaTime * 100);
            }
        }


        //if(currentVelocity.x != 0 && currentVelocity.y != 0)
        //{
        //    rb2d.AddForce(oppositeForce / 2);
        //}

        ////Store the current horizontal input in the float moveHorizontal.
        //float moveHorizontal = Input.GetAxis("Horizontal");

        ////Store the current vertical input in the float moveVertical.
        //float moveVertical = Input.GetAxis("Vertical");

        ////Use the two store floats to create a new Vector2 variable movement.
        //Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        ////Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        //rb2d.AddForce(movement * speed);
        //transform.up = rb2d.velocity.normalized;
    }
}