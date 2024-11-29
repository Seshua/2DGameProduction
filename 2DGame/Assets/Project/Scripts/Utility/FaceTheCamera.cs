using UnityEngine;

public class FaceTheCamera : MonoBehaviour
{
    private Camera customCamera;

    private void Start()
    {
        customCamera = Camera.main;  // Use your custom camera here if it's not the main camera
    }

    private void Update()
    {
        if (customCamera != null)
        {
            // Get direction from object to camera
            Vector3 directionToCamera = customCamera.transform.position - transform.position;
            directionToCamera.y = 0; // Ignore the y-axis to keep the object upright

            // Rotate the object to face the camera based on its custom angles
            Quaternion targetRotation = Quaternion.LookRotation(-directionToCamera);
            transform.rotation = targetRotation;
        }
    }
}
