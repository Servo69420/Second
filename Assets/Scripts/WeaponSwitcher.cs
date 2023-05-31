using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject weapon1;  // Reference to the first weapon
    public GameObject weapon2;  // Reference to the second weapon

    // Use this for initialization
    void Start()
    {
        // Initially, weapon1 is active and weapon2 is inactive
        weapon1.SetActive(true);
        weapon2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player has pressed the key to switch weapons
        if (Input.GetKeyDown(KeyCode.Q))  // Change this to whatever key you want
        {
            SwitchWeapon();
        }
    }

    // Switch the active weapon
    void SwitchWeapon()
    {
        // If weapon1 is active, deactivate it and activate weapon2
        if (weapon1.activeInHierarchy)
        {
            weapon1.SetActive(false);
            weapon2.SetActive(true);
        }
        // If weapon2 is active, deactivate it and activate weapon1
        else
        {
            weapon2.SetActive(false);
            weapon1.SetActive(true);
        }
    }
}
