using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float thrustPower;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ApplyThrust()
    {
       rb.AddRelativeForce(Vector3.up * thrustPower * Time.deltaTime);
    }
}
