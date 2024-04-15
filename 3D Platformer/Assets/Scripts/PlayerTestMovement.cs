using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestMovement : MonoBehaviour
{
    float x;
    float z;
    public float speed;

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(x * speed, 0, z * speed);
    }
}
