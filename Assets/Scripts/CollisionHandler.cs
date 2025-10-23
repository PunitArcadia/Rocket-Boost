using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
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
                break;
            default:
                Debug.Log("explode");
                ReloadScene();
                break;
        }
    }

    private void ReloadScene()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex);
    }
}
