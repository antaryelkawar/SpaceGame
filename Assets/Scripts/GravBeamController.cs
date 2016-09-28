using UnityEngine;
using System.Collections;

public class GravBeamController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Asteroids") || other.gameObject.CompareTag("Minerals"))
        {
            Vector3 awayVelocity = CalculateTangentialVelocity(other);
            Rigidbody2D rb2d = other.GetComponentInParent<Rigidbody2D>();
            rb2d.AddForce(awayVelocity * 2, ForceMode2D.Force);
            rb2d.AddForce((transform.position - other.transform.position) * 10f * Time.smoothDeltaTime);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Asteroids") || other.gameObject.CompareTag("Minerals"))
        {
            Vector3 awayVelocity = CalculateTangentialVelocity(other);           
            Rigidbody2D rb2d = other.GetComponentInParent<Rigidbody2D>();
            rb2d.AddForce(-awayVelocity * 2, ForceMode2D.Force);
            rb2d.AddForce((transform.position - other.transform.position) * 10f * Time.smoothDeltaTime);
        }
    }

    Vector3 CalculateTangentialVelocity(Collider2D other)
    {
        Vector3 velocity = other.GetComponent<Rigidbody2D>().velocity;
        Vector3 stationaryPoint = transform.position;
        Vector3 movingPoint = other.GetComponent<Rigidbody2D>().position;
        Vector3 diffBetPoint = movingPoint - stationaryPoint;
        //return Vector3.Cross(diffBetPoint, velocity) / diffBetPoint.magnitude;
        return velocity - (Vector3.Dot(velocity, diffBetPoint) / Vector3.Dot(diffBetPoint, diffBetPoint) * diffBetPoint);
    }
}
