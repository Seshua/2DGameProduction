using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float distanceFromPlayer = 5f;
    [SerializeField]
    private float heightOffset = 5f;
    [SerializeField]
    private float zRotationAngle = 45f;
    [SerializeField]
    private float yRotationAngle = -90f;

    [SerializeField]
    private float smoothingTime = 0.1f;

    private void Awake()
    {
        // Find the player if not set
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void Update()
    {
        if (target == null) return;
        Vector3 targetPosition = new Vector3(target.position.x + distanceFromPlayer, target.position.y + heightOffset, target.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothingTime * Time.deltaTime);
        transform.rotation = Quaternion.Euler(zRotationAngle, yRotationAngle, 0f);
    }
}
