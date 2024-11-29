using UnityEngine;

public class Rigidbody3DGravityController : MonoBehaviour
{
    [Header("[<color=green>Gravity Config</color>]")]
    [SerializeField]
    private float gravityStep = 9.81f;
    [SerializeField]
    private float maxGravityToApply = 50f;
    [SerializeField]
    private float sphereCastRadius = 0.2f;
    [SerializeField]
    private float sphereCastLength = 0.75f;

    private Rigidbody rBody3D;
    private float currentGravity = 0f;

    private void Awake()
    {
        rBody3D = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // If were in the air apply gravity to the player else set gravity to 0
        if (!IsGrounded())
        {
            ApplyGravity();
        }
        else
        {
            currentGravity = Mathf.Clamp(currentGravity, 0f, maxGravityToApply);
        }
    }

    private void ApplyGravity()
    {
        // Increase gravity over time
        currentGravity += (gravityStep * 100) * Time.deltaTime;
        // Apply downward force
        rBody3D.AddForce(Vector3.down * currentGravity, ForceMode.Acceleration);
    }

    private bool IsGrounded()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        return Physics.SphereCast(ray, sphereCastRadius, sphereCastLength, LayerMask.GetMask("Ground"));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + Vector3.down * sphereCastLength, sphereCastRadius);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * sphereCastLength);
    }
}
