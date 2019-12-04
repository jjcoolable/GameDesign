using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float torqueForce;

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody rb = GetComponent<Rigidbody>();
        //rb.AddTorque(Vector3.up * torqueForce);
        
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * torqueForce * Time.deltaTime, Space.Self);
    }

}