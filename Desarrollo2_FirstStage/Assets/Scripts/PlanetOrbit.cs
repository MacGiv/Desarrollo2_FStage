using UnityEngine;

public class PlanetOrbit : MonoBehaviour
{
    /// <summary>
    /// Center of the orbit (Sun)
    /// </summary>
    [Header("Orbit")]
    [SerializeField] private Transform center;

    /// <summary>
    /// Orbit shape (ellipse)
    /// </summary>
    [SerializeField] private float semiMajorAxis = 20f;
    [SerializeField] private float semiMinorAxis = 15f;

    /// <summary>
    /// Orbit speed
    /// </summary>
    [SerializeField] private float speed = 1f;

    private float angle;

    private void Update()
    {
        angle += speed * Time.deltaTime;

        float x = Mathf.Cos(angle) * semiMajorAxis;
        float z = Mathf.Sin(angle) * semiMinorAxis;

        transform.position = center.position + new Vector3(x, 0f, z);
    }
}
