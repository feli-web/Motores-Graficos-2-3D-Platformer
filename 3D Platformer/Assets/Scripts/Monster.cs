using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    Rigidbody rb;
    public NavMeshAgent agent;
    Vector3 direction;
    Vector3 pointA;
    Vector3 pointB;
    public float aX;
    public float bX;
    public GameObject deathParticles;

    void Start()
    {
        agent.speed = Random.Range(3.5f, 7);
        direction = pointA;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        pointA = new Vector3(aX, transform.position.y, transform.position.z);
        pointB = new Vector3(bX, transform.position.y, transform.position.z);
        agent.SetDestination(direction);
        ChangeDirection();
    }
    public void ChangeDirection()
    {
        if (Vector3.Distance(transform.position, pointA) < 0.1f)
        {
            agent.speed = Random.Range(3.5f, 7);
            direction = pointB;
        }
        else if (Vector3.Distance(transform.position, pointB) < 0.1f)
        {
            agent.speed = Random.Range(3.5f, 7);
            direction = pointA;
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            if (collision.gameObject.GetComponent<PlayerMovement>().isKilling)
            {
                Instantiate(deathParticles, transform.position, deathParticles.transform.rotation);
                Destroy(this.gameObject, 0.1f);
            }
            else
            {
                collision.gameObject.GetComponent<PlayerScore>().StartDeath();
            }
        }
    }

}
