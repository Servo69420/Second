using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : MonoBehaviour
{
    public ParticleSystem flameParticles; // Reference to the flame particle system

    void Update()
    {
        // If the player is holding down the fire button...
        if (Input.GetButton("Fire1"))
        {
            // ...start the flamethrower.
            if (!flameParticles.isPlaying)
            {
                flameParticles.Play();
            }
        }
        else
        {
            // Otherwise, stop the flamethrower.
            if (flameParticles.isPlaying)
            {
                flameParticles.Stop();
            }
        }
    }
}

