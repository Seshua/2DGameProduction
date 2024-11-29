using UnityEngine;

public class CheckObjectYPosition : MonoBehaviour
{
    [SerializeField]
    private float deathThresholdYPosition = -25f;

    private void Update()
    {
        if (transform.position.y < deathThresholdYPosition) Destroy(gameObject);
    }
}
