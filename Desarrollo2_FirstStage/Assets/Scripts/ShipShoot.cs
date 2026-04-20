using UnityEngine;

public class ShipShoot : MonoBehaviour
{
    /// <summary>
    /// Projectile prefab reference
    /// </summary>
    [Header("References")]
    [SerializeField] private GameObject projectilePrefab;

    /// <summary>
    /// Where the projectile spawns
    /// </summary>
    [SerializeField] private Transform firePoint;

    /// <summary>
    /// Time between shots
    /// </summary>
    [Header("Shooting")]
    [SerializeField] private float fireRate = 0.2f;

    private float lastShootTime;

    private void Update()
    {
        HandleShooting();
    }

    // Get input and shoot if possible
    private void HandleShooting()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Time.time >= lastShootTime + fireRate)
            {
                Shoot();
                lastShootTime = Time.time;
            }
        }
    }

    // Instantiates projectile
    private void Shoot()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }
}
