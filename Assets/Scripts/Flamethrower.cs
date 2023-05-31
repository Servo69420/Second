using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : MonoBehaviour
{
    public ParticleSystem flameParticles; // Reference to the flame particle system
    public List<ParticleCollisionEvent> collisionEvents; // List to hold collision events
    public float damageAmount = 10.0f; // The amount of damage to apply to NPCs

    void Start()
    {
        flameParticles = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }
    // Reference to the flame particle system

    void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = flameParticles.GetCollisionEvents(other, collisionEvents);

        Target target = other.GetComponent<Target>();

        if (target != null)
        {
            // Apply damage to the target
            target.TakeDamage(damageAmount);
        }
    }

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

