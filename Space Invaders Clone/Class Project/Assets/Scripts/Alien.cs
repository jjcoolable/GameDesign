using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public int hitPoints = 3;
    public GameObject explosion;
    public float fireRate = 0.5f;
    [Range(0f, 1f)]
    public float fireProb = 0.1f;
    public float timeForFirstShot = 2f;
    public GameObject alienBullet;
    public Vector3 bulletOffset;

    private float timeBetweenShots;
    private float timeForNextShot;

    private void Start()
    {
        timeBetweenShots = 1 / fireRate;
        timeForNextShot = timeForFirstShot;
    }
    void Update()
    {
        timeForNextShot -= Time.deltaTime;
        if(timeForNextShot <=0)
        {
            float prob = Random.Range(0f, 1f);
            if (prob <=fireProb)
            {
                Fire();
                timeForNextShot = timeBetweenShots;
            }
        }
    }

    void Fire()
    {
        Instantiate(alienBullet, transform.position, transform.rotation);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            hitPoints--;
            Destroy(collision.gameObject);
            if (hitPoints <= 0)
            {
                Destroy(this.gameObject);
                Instantiate(explosion, transform.position, transform.rotation);
            }
        }
           
    }
}
