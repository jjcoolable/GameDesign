using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public float speed;
    public float turn;
    public float vThrust;
    public float hThrust;
    public float hoverAmplitude;
    public float deltaAngle;
    public float frequency;
    public float xPos;
    public GameObject missile;
    public float fireRate;
    
    private float timeBetweenShots;
    private Rigidbody rb;
    private float angle = 0;

    float nextFire;
    
    // Start is called before the first frame update
    void Start() 
    {
        rb = GetComponent<Rigidbody>();
        timeBetweenShots = 1 / fireRate;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //MovementWithTransformations();
        Hover();
        if (Input.GetKey(KeyCode.Space))
        {
            Fire(missile);
        }
    }

    private void Fire(GameObject missile)
    {
        if (Time.time > nextFire)
        {
            Instantiate(missile, transform.position, transform.rotation);
            nextFire = Time.time + timeBetweenShots;
        }
    }

    private void Hover()
    {
        transform.Translate(0, hoverAmplitude * Mathf.Sin(frequency * angle) * Time.deltaTime, 0);
        angle += deltaAngle;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb.AddRelativeForce(Vector3.up * vertical * vThrust);
        rb.AddRelativeForce(Vector3.right * horizontal * hThrust);
      //rb.AddTorque(Vector3.back * horizontal * turn);
    }

    private void MovementWithTransformations()
    {
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * vertical * speed * Time.deltaTime);

        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.back * horizontal * turn * Time.deltaTime);
    }
}
