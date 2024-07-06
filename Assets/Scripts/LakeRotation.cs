using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LakeRotation : MonoBehaviour

{
public GameObject lake;
public Vector3 rotationSpeed = new Vector3(0, 100, 0); // Rotation speed in degrees per second.


    void Start()
    {
        lake = this.gameObject;
    }

    void Update()
    {
        // Rotate the object
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
