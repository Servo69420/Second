using UnityEngine;
using UnityEngine.UI;  // Required for UI elements

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Transform barrelEnd;

    public Camera fpsCam;

    public LineRenderer laserBeam;
    public float laserDisplayTime = 0.1f;

    public int maxAmmo = 10;  // Maximum amount of ammo per magazine
    private int currentAmmo;  // Current ammo count
    public float reloadTime = 2f;  // Time it takes to reload
    private bool isReloading = false;  // Check if we're currently reloading

    public Image reloadIcon;  // The reload icon

    void Start()
    {
        laserBeam.enabled = false;
        currentAmmo = maxAmmo;  // Start with a full magazine
        reloadIcon.enabled = false;  // Start with the reload icon hidden
    }

    void Update()
    {
        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            reloadIcon.enabled = true;  // Show the reload icon
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    System.Collections.IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
        reloadIcon.enabled = false;  // Hide the reload icon after reloading
        Debug.Log("Reloaded");
    }

    System.Collections.IEnumerator ShowLaser()
    {
        laserBeam.enabled = true;
        yield return new WaitForSeconds(laserDisplayTime);
        laserBeam.enabled = false;
    }

    void Shoot()
    {
        if (currentAmmo <= 0)
            return;

        currentAmmo--;

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            laserBeam.SetPosition(0, barrelEnd.position);
            laserBeam.SetPosition(1, hit.point);
            StartCoroutine(ShowLaser());
        }
    }
}
