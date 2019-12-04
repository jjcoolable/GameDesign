using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShip : MonoBehaviour
{
    public GameObject missileAlien;
    public float fireRate = 2;

    float nextFire;
    float firstFire;
    // Start is called before the first frame update
    void Start()
    {
        firstFire = Random.Range(10, 70f);
        fireRate = Random.Range(20f, 30f);
        nextFire = Time.time + firstFire;
    }

    void Update()
    {
        //AlienFire(missileAlien);
        
    }

    void AlienRotate()
    {
        transform.Rotate(Vector3.up* 150 * Time.deltaTime, Space.Self);
    }

    void AlienFire(GameObject missileAlien)
    {
        //when the world time is greater than the timer set by the script
        //shoot missile
        if (Time.time > nextFire)
        {
            //create missile
            Instantiate(missileAlien, transform.position, transform.rotation);
            nextFire = Time.time + fireRate;
        }
    }
}
