using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletForce = 2f;
    public float timeToLive = 2f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToLive);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        rb.AddForce(Vector3.up * bulletForce, ForceMode.Impulse);
    }
}
