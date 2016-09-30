using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;             //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

    private Vector2 currentVelocity;
    private Vector2 oppositeForce;

    public GameObject gravBeam;

    public GameObject leftEngine;
    public GameObject rightEngine;
    public GameObject leftThruster;
    public GameObject RightThruster;
    // Use this for initialization
    void Start()
    {
        leftThruster.SetActive(false);
        RightThruster.SetActive(false);
        leftEngine.SetActive(false);
        rightEngine.SetActive(false);
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            gravBeam.SetActive(true);
        }
        else
        {
            gravBeam.GetComponent<Animator>().SetTrigger("EndBeam");
        }
        if (Input.GetKey(KeyCode.A))
        {
            RightThruster.SetActive(true);
            transform.Rotate(new Vector3(0, 0, 8) * speed * Time.fixedDeltaTime);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            RightThruster.SetActive(false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            leftThruster.SetActive(true);
            transform.Rotate(-new Vector3(0, 0, 8) * speed * Time.fixedDeltaTime);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            leftThruster.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            leftThruster.SetActive(true);
            RightThruster.SetActive(true);
            leftEngine.SetActive(true);
            rightEngine.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            leftThruster.SetActive(false);
            RightThruster.SetActive(false);
            leftEngine.SetActive(false);
            rightEngine.SetActive(false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            leftThruster.SetActive(true);
            RightThruster.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            leftThruster.SetActive(false);
            RightThruster.SetActive(false);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            leftEngine.SetActive(true);
            rightEngine.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            leftEngine.SetActive(false);
            rightEngine.SetActive(false);
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
                rb2d.AddForce(-transform.up * speed * Time.fixedDeltaTime * 30);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                rb2d.AddForce(transform.up * speed * Time.fixedDeltaTime * 100);
            }
        }
    }
}