using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flags : MonoBehaviour
{
    public Material flagColor;
    void Start()
    {
        flagColor.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            flagColor.color = Color.green;
        }
    }
}
