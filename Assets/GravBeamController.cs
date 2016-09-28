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
        Rigidbody2D rb2d = other.GetComponentInParent<Rigidbody2D>();
        rb2d.AddForce((transform.position - other.transform.position) * 10f * Time.smoothDeltaTime);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Rigidbody2D rb2d = other.GetComponentInParent<Rigidbody2D>();
        rb2d.AddForce((transform.position - other.transform.position) * 10f * Time.smoothDeltaTime);
    }

}
