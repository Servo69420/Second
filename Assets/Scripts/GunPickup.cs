using UnityEngine;

public class GunPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SendMessage("PickUpGun", gameObject);
            gameObject.SetActive(false);
        }
    }
}
