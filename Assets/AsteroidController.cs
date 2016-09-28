using UnityEngine;
using System.Collections;

public class AsteroidController : MonoBehaviour {

    public Rigidbody2D mediumAsteroid;
    public Rigidbody2D smallAsteroid;
    public Rigidbody2D mineral;

    public int rotation;
	// Use this for initialization
	void Start () {
        rotation = Random.Range(-20, 20);

    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(new Vector3(0, 0, rotation) * Time.deltaTime);
    }

    public float maxSpeed = 5f;//Replace with your max speed
    void FixedUpdate()
    {
        if (GetComponent<Rigidbody2D>().velocity.magnitude > maxSpeed)
        {
            GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * maxSpeed;
        }
    }

    public void Destruct()
    {
        int medCount = 0, smallCount = 0, minCount = 0;
        if(mediumAsteroid != null)
        {
            medCount = Random.Range(1, 3);
        }
        if (smallAsteroid != null)
        {
            smallCount = Random.Range(1, 3);
        }
        if (mineral != null)
        {
            minCount = Random.Range(1, 4);
        }
        GenerateSmallerBodies(medCount, smallCount, minCount);
        gameObject.SetActive(false);
    }
    void GenerateSmallerBodies(int medium, int small, int mineral1)
    {
        GenerateType(medium, mediumAsteroid, 10f);
        GenerateType(small, smallAsteroid, 5f);
        GenerateType(mineral1, mineral, 0.1f);
    }

    void GenerateType(int count, Rigidbody2D type, float force)
    {
        for (int i = 0; i < count; i++)
        {
            Rigidbody2D asteroid = (Rigidbody2D)Instantiate(type, transform.position + new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0), transform.rotation);
            //laserClone.velocity = transform.parent.GetComponent<Rigidbody2D>().velocity;
            asteroid.AddForce(new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5)) * 10f * Time.deltaTime * force, ForceMode2D.Impulse);
        }
    }
}
