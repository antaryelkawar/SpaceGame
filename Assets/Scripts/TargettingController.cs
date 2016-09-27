using UnityEngine;
using System.Collections;

public class TargettingController : MonoBehaviour
{
    public Rigidbody2D laser;
    public float speed = 10f;

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + 90);
    }
    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FireLaser();
        }
    }
    void FireLaser()
    {
        Rigidbody2D laserClone = (Rigidbody2D)Instantiate(laser, transform.position, transform.rotation);
        laserClone.AddForce(transform.right * speed * Time.deltaTime * 100);
    }
}
