using UnityEngine;
using System.Collections;

public class LaserController : MonoBehaviour {

    public float lifetime = 1.0f;
	void Update () {
        Destroy(this.gameObject, lifetime);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Asteroids"))
        {
            other.gameObject.GetComponent<AsteroidController>().Destruct();
            Destroy(this.gameObject);
        }
    }
}
