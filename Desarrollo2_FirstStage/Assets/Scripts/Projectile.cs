using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 150f;

    // Time before the projectile is destroyed
    [Header("Lifetime")]
    [SerializeField] private float lifetime = 5f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
