using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootPoint;
    public float speed;
    public float shootTime;
    void Start()
    {
        InvokeRepeating("Shoot", 0, shootTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shoot()
    {
        var b = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        b.GetComponent<Rigidbody>().velocity = shootPoint.right * -speed * Time.deltaTime;
        Kill(b);
    }
    public void Kill(GameObject bullet)
    {
        Destroy(bullet, 1f);
    }
}
