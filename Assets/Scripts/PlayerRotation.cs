using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float rotationPower;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Rotate(float direction)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * direction * rotationPower * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
