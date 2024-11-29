using UnityEngine;

namespace Game.Utilities
{
    public static class Utilities
    {
        public static bool IsWithinDistance(Vector3 objectPosition, Vector3 targetPosition, float maxDistance)
        {
            return Vector3.Distance(objectPosition, targetPosition) <= maxDistance;
        }

        public static bool IsTargetPositionOnGround(Vector3 position)
        {
            // Define the layer mask for the ground layer
            int groundLayerMask = LayerMask.GetMask("Ground");

            // Perform a raycast from above the target position, shooting downwards
            Ray ray = new Ray(position + Vector3.up * 2f, Vector3.down); // Raycast starts 2 units above the target
            RaycastHit hit;

            // Check if the ray hits the ground
            if (Physics.Raycast(ray, out hit, 5f, groundLayerMask))
            {
                return true; // Valid ground found
            }

            return false; // Not on ground
        }

    }
}
