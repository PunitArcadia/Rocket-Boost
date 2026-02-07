using UnityEngine;

public class PlayerFeedBack : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip thrustSfx;

    [SerializeField] private ParticleSystem mainThrust;
    [SerializeField] private ParticleSystem leftThrust;
    [SerializeField] private ParticleSystem rightThrust;

    public void PlayThrust()
    {
        Debug.Log("PlayThrust called");
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(thrustSfx);
            mainThrust.Play();
        }
    }

    public void StopThrust()
    {
        mainThrust.Stop();
        audioSource.Stop();
    }

    public void PlayRotation(float direction)
    {
        Debug.Log("PlayRotation: " + direction);
        if (direction > 0) rightThrust.Play();
        if (direction < 0) leftThrust.Play();
    }

    public void StopRotation()
    {
        leftThrust.Stop();
        rightThrust.Stop();
    }

    public void StopAllVfx()
    {
        mainThrust.Stop();
        leftThrust.Stop();
        rightThrust.Stop();
    }
}
