using UnityEngine;
using System.Collections;

public class TargettingController : MonoBehaviour
{
    public Rigidbody2D laser;
    public float speed = 20f;

    void Update()
    {

    }
    void LateUpdate()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        //transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + 90);
        if (Input.GetMouseButtonDown(0))
        {            
            FireLaser();
        }
    }
    void FireLaser()
    {
        Rigidbody2D laserClone = (Rigidbody2D)Instantiate(laser, transform.position + transform.up.normalized, transform.rotation);
        //laserClone.velocity = transform.parent.GetComponent<Rigidbody2D>().velocity;
        laserClone.AddForce(transform.up * speed * Time.deltaTime * 100);
    }
}
