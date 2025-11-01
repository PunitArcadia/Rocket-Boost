using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private AudioClip sfxCrash;
    [SerializeField] private AudioClip sfxSuccess;

    [SerializeField] private ParticleSystem vfxCrash;
    [SerializeField] private ParticleSystem vfxSuccess;

    [SerializeField] private AudioSource audioSource;

    [SerializeField] float delayTime = 2f;

    bool isTouched = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            LoadNextScene();
        }

        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            isTouched = !isTouched;
        }

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Application.Quit();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isTouched)
        {
            return;
        } 

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("It's Friendly object");
                break;
            case "Fuel":
                Debug.Log("It's Fuel object");
                break;
            case "Finish":
                Debug.Log("It's Finish object");
                StartNextSequence();
                break;
            default:
                Debug.Log("explode");
                StartCrashSequence();
                break;
        }
    }

    private void StartNextSequence()
    {
        isTouched = true;
        vfxSuccess.Play();
        audioSource.Stop();
        audioSource.PlayOneShot(sfxSuccess);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextScene", delayTime);
    }

    private void StartCrashSequence()
    {
        isTouched = true;
        vfxCrash.Play();
        audioSource.Stop();
        audioSource.PlayOneShot(sfxCrash);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadScene", delayTime);
    }

    private void LoadNextScene() 
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int NextIndex = CurrentSceneIndex + 1;
        if (CurrentSceneIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            NextIndex = 0;
        }
        SceneManager.LoadScene(NextIndex);
    }

    private void ReloadScene()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex);
    }
}
