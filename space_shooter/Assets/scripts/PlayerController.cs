using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Boundary
{
    public float xmin,xmax,zmin,zmax;
}
public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;
    public GameObject shot;
    public Transform shotspawn;
    public float fireRate;
    private float nextFire;
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time>nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotspawn.position, shotspawn.rotation);
        }
    }
    void FixedUpdate()
    {
        float movehorizontal = Input.GetAxis("Horizontal");
        float movevertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(movehorizontal, 0.0f, movevertical);
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = movement * speed;
        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x,boundary.xmin,boundary.xmax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zmin, boundary.zmax)
        );
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x*-tilt);
    }
}
