using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    //Add this script to the player
    public Vector3 check;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Flag"))
        {
            check = other.gameObject.transform.position;
        }
        if (other.gameObject.CompareTag("Death"))
        {
            Revive();
        }
    }
    public void Revive()
    {
        this.transform.position = check;
    }
}
