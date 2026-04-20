using UnityEngine;

public class Planet : MonoBehaviour, IDamageable
{
    // Called when hit
    public void TakeDamage()
    {
        Destroy(gameObject);
    }
}