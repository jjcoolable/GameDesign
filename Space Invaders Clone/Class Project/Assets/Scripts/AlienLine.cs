using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienLine : MonoBehaviour
{
    public int numOfAliens = 5;
    public GameObject Alien;
    public float speedAlien = 4f;

    // Start is called before the first frame update
    void Start()
    {
        CreateAliens(Alien);
    }
    void CreateAliens(GameObject Alien)
    {
        for (int i = 1; i <= numOfAliens; i++)
        {
            GameObject alien = Instantiate(Alien,
            new Vector3(i * 2f, 0, 0) + gameObject.transform.position,
            gameObject.transform.rotation) as GameObject;
            alien.transform.parent = gameObject.transform;
        }
    }
}