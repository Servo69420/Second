using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtPlayer : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float firingRate = 20f;
   
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    void FireProjectile()
    {
        // Instantiate the projectile at the enemy's position and rotation
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

        // Give the projectile a velocity in the forward direction of the enemy
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * 10f;
    }
    // Update is called once per frame
    void Update()
    {
        float fireTimer = 0f;
        fireTimer += Time.deltaTime;
        if (fireTimer >= firingRate)
        {
            FireProjectile();
            fireTimer = 0f;
        }
    }
}
