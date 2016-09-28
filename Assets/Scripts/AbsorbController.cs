using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AbsorbController : MonoBehaviour {

    public Slider mineral1;
    public Slider mineral2;
    public Slider mineral3;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Mineral1"))
        {
            mineral1.value++;
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Mineral2"))
        {
            mineral2.value++;
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Mineral3"))
        {
            mineral3.value++;
            other.gameObject.SetActive(false);
        }
    }
}
