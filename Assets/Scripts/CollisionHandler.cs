using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float respawnSeconds = 1.5f;

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Start":
                Debug.Log("Start Point");
                break;
            case "Obstacle":
                CrashSequence();
                break;
            case "Finish":
                SuccessSequence();
                break;
        }
    }

    void LoadNextLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            sceneIndex = 0;
        }
        SceneManager.LoadScene(sceneIndex + 1);
    }

    void Respawn()
    {   
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    void CrashSequence()
    {
        //TODO: Sound effect and particles
        gameObject.GetComponent<Movement>().enabled = false;
        Invoke("Respawn", respawnSeconds);
    }

    void SuccessSequence()
    {
        gameObject.GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", respawnSeconds);
    }


}
