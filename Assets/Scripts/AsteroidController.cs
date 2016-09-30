using UnityEngine;
using System.Collections;

public class AsteroidController : MonoBehaviour {

    public Rigidbody2D mediumAsteroid;
    public Rigidbody2D smallAsteroid;
    public Rigidbody2D mineral1;
    public Rigidbody2D mineral2;
    public Rigidbody2D mineral3;

    public int rotation;

    public Animator anim;
	// Use this for initialization
	void Start () {
        rotation = Random.Range(-20, 20);
        anim = GetComponent<Animator>();
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
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Collider2D>().enabled = false;
        int medCount = 0, smallCount = 0, minCount1 = 0, minCount2 = 0, minCount3 = 0;
        if(mediumAsteroid != null)
        {
            medCount = Random.Range(0, 3);
        }
        if (smallAsteroid != null)
        {
            smallCount = Random.Range(0, 3);
        }
        if (mineral1 != null)
        {
            minCount1 = Random.Range(0, 4);
        }
        if (mineral2 != null)
        {
            minCount2 = Random.Range(0, 3);
        }
        if (mineral3 != null)
        {
            minCount3 = Random.Range(0, 2);
        }
        GenerateSmallerBodies(medCount, smallCount, minCount1, minCount2, minCount3);
        
    }
    public void DeleteAsteroid()
    {
        Destroy(gameObject);
    }
    void GenerateSmallerBodies(int medium, int small, int mineralCnt1, int mineralCnt2, int mineralCnt3)
    {
        GenerateType(medium, mediumAsteroid, 20f);
        GenerateType(small, smallAsteroid, 10f);
        GenerateType(mineralCnt1, mineral1, 0.5f);
        GenerateType(mineralCnt2, mineral2, 0.5f);
        GenerateType(mineralCnt3, mineral3, 0.5f);
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
