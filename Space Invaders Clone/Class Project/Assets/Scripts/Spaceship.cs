using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public float speed;
    public float turn;
    public float thrust;


    private Rigidbody rb;

    // Start is called before the first frame update
    void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //MovementWithTransformations();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb.AddRelativeForce(Vector3.up * vertical * thrust);
        rb.AddTorque(Vector3.back * horizontal * turn);
    }

    private void MovementWithTransformations()
    {
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * vertical * speed * Time.deltaTime);

        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.back * horizontal * turn * Time.deltaTime);
    }
}
