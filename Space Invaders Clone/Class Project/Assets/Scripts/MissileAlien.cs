using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileAlien : MonoBehaviour
{
    public float missileSpeed;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.down * missileSpeed);
    }
}
