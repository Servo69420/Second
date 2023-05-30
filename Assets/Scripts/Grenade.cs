using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;  // Delay before the grenade explodes
    public float blastRadius = 5f;  // Radius of the explosion
    public float explosionForce = 700f;  // Force of the explosion

    private bool hasExploded = false;  // Check if the grenade has exploded
    public GameObject explosionEffect;

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        if (delay <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        // Find all the colliders within the blast radius
        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);
        Instantiate(explosionEffect, transform.position, transform.rotation);

        GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);

        // Get the ParticleSystem component
        ParticleSystem particles = explosion.GetComponent<ParticleSystem>();

        // Destroy the explosion effect once it's finished playing
        Destroy(explosion, particles.main.duration + particles.main.startLifetime.constantMax);

        foreach (Collider nearbyObject in colliders)
        {
            // Check if the nearby object is a zombie
            if (nearbyObject.gameObject.CompareTag("Enemy"))
            {
                Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    // Apply a force to the object
                    Vector3 direction = rb.transform.position - transform.position;
                    rb.AddExplosionForce(explosionForce, transform.position, blastRadius);

                    // Apply damage to the zombie
                    ZombieHealth zombieHealth = nearbyObject.GetComponent<ZombieHealth>();
                    if (zombieHealth != null)
                    {
                        // Calculate the damage based on the distance from the explosion center
                        float damage = explosionForce * (1.0f - (nearbyObject.transform.position - transform.position).magnitude / blastRadius);
                        zombieHealth.TakeDamage(damage);
                    }
                }
            }
        }

        // Destroy the grenade object
        Destroy(gameObject);
    }
}
