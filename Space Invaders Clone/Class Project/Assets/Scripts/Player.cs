using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Material mat;
    private Color original;
    public float speed;
    private Rigidbody rb;
    public float jumpforce;

    // Start is called before the first frame update
    void Start()
    {
        	mat = new Material(Shader.Find("Standard"));
		original = GetComponent<Renderer>().material.color;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            mat.color = Color.red;
            GetComponent<Renderer>().material = mat;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            mat.color = Color.green;
            GetComponent<Renderer>().material = mat;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            mat.color = Color.blue;
            GetComponent<Renderer>().material = mat;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mat.color = original;
            GetComponent<Renderer>().material = mat;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back* speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }
    }
}
