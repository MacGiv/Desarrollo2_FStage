using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RocketLauncher : MonoBehaviour
{
    private Rigidbody rb;
    
    [SerializeField] private float launchForce;
    [SerializeField] private float torqueForce;
    [SerializeField] private ForceMode jumpForceMode;
    [SerializeField] private ForceMode torqueForceMode;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(transform.up * launchForce, jumpForceMode);
        
        if (Input.GetKeyDown(KeyCode.D))
            rb.AddTorque(transform.right * torqueForce, torqueForceMode);
        if (Input.GetKeyDown(KeyCode.A))
            rb.AddTorque(-transform.right * torqueForce, torqueForceMode);

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision started with {collision.gameObject.name} at {collision.transform.position}");
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log($"´{gameObject.name} is colliding with {collision.gameObject.name} at {collision.transform.position}");
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log($"´{gameObject.name} stopped colliding with {collision.gameObject.name} at {collision.transform.position}");
    }
}
