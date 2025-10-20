using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [Header("Input Actions")]
    [SerializeField] private InputAction thrust;
    [SerializeField] private InputAction rotation;

    [Header("Component References")]
    [SerializeField] private Rigidbody rb;

    [Header("Power Values")]
    [SerializeField] private float thrustPower;
    [SerializeField] private float rotationPower;

    private void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ProcessThrust();
    }

    private void ProcessThrust()
    {
        if (thrust.IsPressed())
        {
            Debug.Log("Space is pressed");
            rb.AddRelativeForce(Vector3.up * thrustPower * Time.deltaTime);
        }
    }

    private void Update()
    {
        float rotationValue = rotation.ReadValue<float>();
        Debug.Log("The rotation value" +  rotationValue);
    }
}
