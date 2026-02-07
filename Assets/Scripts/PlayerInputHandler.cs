using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private InputAction thrust;
    [SerializeField] private InputAction rotation;

    [SerializeField] private PlayerMovement movement;
    [SerializeField] private PlayerRotation rotationController;
    [SerializeField] private PlayerFeedBack feedback;

    private void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    private void Update()
    {
        if (thrust.IsPressed())
        {
            movement.ApplyThrust();
            feedback.PlayThrust();
        }
        else
        {
            feedback.StopThrust();
        }

        float rotateValue = rotation.ReadValue<float>();
        if (rotateValue != 0)
        {
            rotationController.Rotate(rotateValue);
            feedback.PlayRotation(rotateValue);
        }
        else
        {
            feedback.StopRotation();
        }
    }

}
