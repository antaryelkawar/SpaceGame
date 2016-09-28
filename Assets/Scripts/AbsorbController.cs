using UnityEngine;
using System.Collections;

public class AbsorbController : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Minerals"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
