using UnityEngine;

public class PlayerGunPickup : MonoBehaviour
{
    public GameObject gun; // The gun that the player starts with

    void Start()
    {
        // Initially, the gun is not active
        gun.SetActive(false);
    }

    // This function gets called when the player picks up a gun
    public void PickUpGun(GameObject newGun)
    {
        // Deactivate the current gun
        if (gun != null)
            gun.SetActive(false);

        // Set the new gun as the active gun
        gun = newGun;

        // Activate the new gun
        gun.SetActive(true);
    }
}
