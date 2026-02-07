using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector;
    [SerializeField] float speed;

    private Vector3 startPosition;
    private float movementFactor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        movementFactor = Mathf.PingPong(Time.time * speed, 1);
        transform.position = startPosition + movementVector * movementFactor;
    }
}
