using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject grenadePrefab;
    public float throwForce = 10f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ThrowGrenade();
        }
    }

    void ThrowGrenade()
    {
        // Create a new grenade
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);

        // Get the Rigidbody component from the grenade
        Rigidbody rb = grenade.GetComponent<Rigidbody>();

        // Throw the grenade in the direction the player is looking
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
}