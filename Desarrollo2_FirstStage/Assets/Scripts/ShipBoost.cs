using UnityEngine;

public class ShipBoost : MonoBehaviour
{
    /// <summary>
    /// Boost multiplier applied to movement
    /// </summary>
    [Header("Boost Settings")]
    [SerializeField] private float boostMultiplier = 2f;
    [SerializeField] private float boostDuration = 2f;
    [SerializeField] private float boostCooldown = 1f;

    [SerializeField] private GameObject particles;

    private bool isBoosting;
    private float boostTimer;
    private float cooldownTimer;

    public float CurrentMultiplier => isBoosting ? boostMultiplier : 1f;

    private void Update()
    {
        HandleInput();
        UpdateTimers();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && cooldownTimer <= 0f)
        {
            isBoosting = true;
            particles.SetActive(true);
            boostTimer = boostDuration;
        }
    }

    private void UpdateTimers()
    {
        if (cooldownTimer > 0f)
            cooldownTimer -= Time.deltaTime;

        if (!isBoosting) return;

        boostTimer -= Time.deltaTime;

        if (boostTimer <= 0f)
        {
            isBoosting = false;
            particles.SetActive(false);
            cooldownTimer = boostCooldown;
        }
    }
}