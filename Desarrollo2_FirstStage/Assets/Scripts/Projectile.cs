using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent (typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 150f;

    // Time before the projectile is destroyed
    [Header("Lifetime")]
    [SerializeField] private float lifetime = 5f;

    [Header("VFX")]
    [SerializeField] private GameObject hitVFX;

    [Header("Audio")]
    [SerializeField] private AudioClip hitSound;

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.TakeDamage();
        }

        // VFX
        if (hitVFX != null)
        {
            Instantiate(hitVFX, transform.position, Quaternion.identity);
        }

        // Audio
        if (hitSound != null)
        {
            AudioSource.PlayClipAtPoint(hitSound, transform.position);
        }

        Destroy(gameObject);
    }
}
