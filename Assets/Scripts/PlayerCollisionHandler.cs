using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionHandler : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioClip crashSfx;
    [SerializeField] private AudioClip successSfx;

    [Header("VFX")]
    [SerializeField] private ParticleSystem crashVfx;
    [SerializeField] private ParticleSystem successVfx;

    private AudioSource audioSource;
    private PlayerMovement movement;
    private PlayerFeedBack feedBack;

    private PlayerState currentState = PlayerState.Alive;

    private PlayerInputHandler inputHandler;
    private Collider playerCollider;
    private Rigidbody rb;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        movement = GetComponent<PlayerMovement>();
        inputHandler = GetComponent<PlayerInputHandler>();
        feedBack = GetComponent<PlayerFeedBack>();
        playerCollider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (currentState != PlayerState.Alive)
            return;

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                HandleSuccess();
                break;
            default:
                HandleCrash();
                break;
        }
    }

    private void HandleSuccess()
    {
        currentState = PlayerState.Transitioning;
        feedBack.StopAllVfx();
        DisablePlayerForSuccess();
        successVfx.Play();
        PlaySound(successSfx);
        StartCoroutine(LoadNextSceneAfterDelay());
    }

    private void HandleCrash()
    {
        currentState = PlayerState.Dead;
        feedBack.StopAllVfx();
        DisablePlayerForCrash();
        crashVfx.Play();
        PlaySound(crashSfx);
        StartCoroutine(ReloadSceneAfterDelay());
    }

    private void PlaySound(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.PlayOneShot(clip);
    }

    private IEnumerator ReloadSceneAfterDelay()
    {
        yield return new WaitForSeconds(crashSfx.length);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator LoadNextSceneAfterDelay()
    {
        yield return new WaitForSeconds(successSfx.length);
        int nextIndex = (SceneManager.GetActiveScene().buildIndex + 1)
                        % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextIndex);
    }

    private void DisablePlayerForCrash()
    {
        if (movement) movement.enabled = false;
        if (inputHandler) inputHandler.enabled = false;
        //if (playerCollider) playerCollider.enabled = false;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = false;
        rb.useGravity = true;
    }

    private void DisablePlayerForSuccess()
    {
        if (movement) movement.enabled = false;
        if (inputHandler) inputHandler.enabled = false;
        if (playerCollider) playerCollider.enabled = false;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;
    }


}
