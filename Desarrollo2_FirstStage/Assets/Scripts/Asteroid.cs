using UnityEngine;

public class Asteroid : MonoBehaviour, IDamageable
{
    /// <summary>
    /// Movement speed towards the player
    /// </summary>
    [Header("Movement")]
    [SerializeField] private float speed = 10f;

    private Transform target;

    public void Initialize(Transform target)
    {
        this.target = target;
    }

    private void Update()
    {
        if (target == null) return;

        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    public void TakeDamage()
    {
        Destroy(gameObject);
    }
}