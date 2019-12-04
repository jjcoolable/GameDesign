using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool useForces = false;
    public float speed=5f;
    public float thrust = 5.25f;

    private Rigidbody rb;

    // Update is called once per frame
    void Update()
    {
        float xdirection = Input.GetAxis("Horizontal");
        if (useForces)
        {
            if (rb == null)
            {
                CreateRigidBody();
            }
            MoveUsingForces(xdirection);
        }
        else
        {
            Destroy(rb);
            MoveTranslational(xdirection);
        }
    }

    void CreateRigidBody()
    {
        rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
    }

    void MoveTranslational(float amount)
    {
        transform.Translate(Vector3.right * amount * speed * Time.deltaTime);
    }

    void MoveUsingForces(float amount)
    {
        rb.AddRelativeForce(Vector3.right * amount * thrust);
    }
}
