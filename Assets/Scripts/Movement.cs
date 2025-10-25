using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [Header("Input Actions")]
    [SerializeField] private InputAction thrust;
    [SerializeField] private InputAction rotation;

    [Header("Component References")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip sfxThrust;
    [SerializeField] private ParticleSystem vfxThrust;
    [SerializeField] private ParticleSystem vfxLeftThrust;
    [SerializeField] private ParticleSystem vfxRightThrust;

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
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        ProcessThrust();
    }

    private void ProcessThrust()
    {
        if (thrust.IsPressed())
        {
            if (!audioSource.isPlaying)
            {
                vfxThrust.Play();
                
                vfxRightThrust.Play();
                audioSource.PlayOneShot(sfxThrust);
            }
            rb.AddRelativeForce(Vector3.up * thrustPower * Time.deltaTime);
        }
        else
        {
            vfxThrust.Stop();
            audioSource.Stop();
        }
    }

    private void Update()
    {
        ProcessRotate();
    }

    private void ProcessRotate()
    {
        float rotationValue = rotation.ReadValue<float>();
        if (rotationValue != 0)
        {
            rb.freezeRotation = true;
            transform.Rotate(rotationValue * Vector3.forward * rotationPower * Time.deltaTime);
            rb.freezeRotation = false;
        }
        else
        {
            vfxLeftThrust.Stop();
            vfxRightThrust.Stop();
        }

        if (rotationValue == 1)
        {
            vfxLeftThrust.Play();
        }

        if (rotationValue == -1)
        {
            vfxRightThrust.Play();
        }
    }
}
