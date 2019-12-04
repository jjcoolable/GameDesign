using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public float speed = 5f;
  //public float turn;
  //public float vThrust;
    public float hThrust = 10f;
    public float hoverAmplitude = 1f;
    public float frequency = 0.1f;
    public float deltaAngle = 0.796f;
    public float maxXOffset = 14f;
    public GameObject missile;
    public float fireRate = 2f;
    public bool useforces = false;
    
    private float timeBetweenShots;
    private Rigidbody rb;
    private float angle = 0;
    

    float nextFire;
    
    // Start is called before the first frame update
    void Start() 
    {
        //angle = 0;
        //basey = tansform.position.y;
        rb = GetComponent<Rigidbody>();
        timeBetweenShots = 1 / fireRate;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Hover();
        //deltaAngle = 360 * hoverFrequency * Time.deltaTime;
        //angle = (angle + deltaAngle) % 360;
        //Vector3 pos = transform.position;
        //float deltaY = deltaA
        //transform.position = new Vector3(pos.x, basey + deltaY, pos.z);

        float horizontal = Input.GetAxis("Horizontal");
        //if (useforces)
        //{
           // MoveWithForces(horizontal);
       // }
        //else
        //{
            MovementWithTransformations(horizontal);
       // }
        
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

    void MoveWithForces(float amount)
    {
        
      //float vertical = Input.GetAxis("Vertical");

      //rb.AddRelativeForce(Vector3.up * vertical * vThrust);
        rb.AddRelativeForce(Vector3.right * amount * hThrust);
        
        //rb.AddTorque(Vector3.back * horizontal * turn);
    }

    private void MovementWithTransformations(float amount)
    {
        //float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * amount * speed * Time.deltaTime);
        Vector3 pos = transform.position;
        if (pos.x < -maxXOffset)
        {
            transform.position = new Vector3(-maxXOffset, pos.y, pos.z);
        }
        if (pos.x > maxXOffset)
        {
            transform.position = new Vector3(maxXOffset, pos.y, pos.z);
        }
        //transform.Rotate(Vector3.back * horizontal * turn * Time.deltaTime);
    }
}
