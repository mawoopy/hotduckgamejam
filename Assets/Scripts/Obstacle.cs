using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Obstacle : MonoBehaviour

{

public GameObject obstacle;
public float speed = 1.0f; // Speed at which the object will move to the left.


    void Start()
    {
        obstacle = this.gameObject;
    }

    void Update()
    {
        // Move the object to the left
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
