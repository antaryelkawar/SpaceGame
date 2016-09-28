using UnityEngine;
using System.Collections;

public class AbsorbController : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Asteroids"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
