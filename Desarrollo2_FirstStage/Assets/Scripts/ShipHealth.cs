using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipHealth : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Die();
    }

    // Handles player death
    private void Die()
    {
        // Reinicia la escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}