using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipHealth : MonoBehaviour
{
    [SerializeField] private GameObject deathVFX;
    [SerializeField] private AudioClip deathSound;

    private void OnCollisionEnter(Collision collision)
    {
        Die();
    }

    // Handles player death
    private void Die()
    {
        if (deathVFX != null)
        {
            Instantiate(deathVFX, transform.position, Quaternion.identity);
        }

        if (deathSound != null)
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
        }

        Invoke(nameof(ReloadScene), 0.5f);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}