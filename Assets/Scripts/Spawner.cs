using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Spawner : MonoBehaviour

{

public GameObject obstacle;
public float speed = 1.0f; // Speed at which the object will move to the left.


    void Start()
    {
        obstacle = GameObject.Find("Obstacle");
    }

    //spawn Obstacle every ? seconds

    //spawn Fly every ? seconds
}
