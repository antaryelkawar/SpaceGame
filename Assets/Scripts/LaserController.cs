using UnityEngine;
using System.Collections;

public class LaserController : MonoBehaviour {

    public float lifetime = 1.0f;
	void Update () {
        Destroy(this.gameObject, lifetime);
	}
}
