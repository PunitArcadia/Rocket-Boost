using UnityEngine;

public class Spinner : MonoBehaviour
{
    public Vector3 rotateAngles;

    private void Update()
    {
        transform.Rotate(rotateAngles);
    }
}
