using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    /// <summary>
    /// Asteroid prefab reference
    /// </summary>
    [Header("References")]
    [SerializeField] private GameObject asteroidPrefab;

    [SerializeField] private Transform player;

    /// <summary>
    /// Spawn settings
    /// </summary>
    [Header("Spawn Settings")]
    [SerializeField] private float spawnInterval = 5f;

    [SerializeField] private float spawnDistance = 100f;

    private float timer;

    private void Awake()
    {
        if (player == null)
        {
            GameObject playerGO = GameObject.FindGameObjectWithTag("Player");

            if (playerGO != null)
            {
                player = playerGO.transform;
            }
            else
            {
                Debug.LogError("Player not found in scene!");
            }
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnAsteroid();
            timer = 0f;
        }
    }

    private void SpawnAsteroid()
    {
        Vector3 randomDirection = Random.onUnitSphere;  // Returns a random point on the surface of a sphere with radius = 1
        Vector3 spawnPosition = player.position + randomDirection * spawnDistance;

        GameObject asteroidGO = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

        Asteroid asteroid = asteroidGO.GetComponent<Asteroid>();

        asteroid.Initialize(player);
    }
}