using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerControls inputActions;

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }


}
