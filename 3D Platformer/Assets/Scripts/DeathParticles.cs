using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathParticles : MonoBehaviour
{
    public ParticleSystem deathParticles;
    void Start()
    {
        deathParticles.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (deathParticles.isPlaying == false)
        {
            Destroy(gameObject);
        }
    }
}
