using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float respawnSeconds = 1.5f;
    [SerializeField] AudioClip explosionClip;
    [SerializeField] AudioClip sucessClip;

    [SerializeField] ParticleSystem explosionParticles;
    [SerializeField] ParticleSystem sucessParticles;

    AudioSource audioSource;

    bool isTransitioning = false;
    public bool collisionDisabled = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning || collisionDisabled) return;

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
        if (sceneIndex == SceneManager.sceneCountInBuildSettings-1)
        {
            sceneIndex = 0;
        }
        else
        {
            sceneIndex += 1;
        }
        Debug.Log($"Loading Scene {sceneIndex}");
        SceneManager.LoadScene(sceneIndex);
    }

    void Respawn()
    {   
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    void CrashSequence()
    {
        //TODO: Sound effect and particles
        explosionParticles.Play();
        audioSource.Stop();
        audioSource.PlayOneShot(explosionClip);
        gameObject.GetComponent<Movement>().enabled = false;
        isTransitioning = true;
        Invoke("Respawn", respawnSeconds);
    }

    void SuccessSequence()
    {
        sucessParticles.Play();
        audioSource.Stop();
        audioSource.PlayOneShot(sucessClip);
        gameObject.GetComponent<Movement>().enabled = false;
        isTransitioning=true;
        Invoke("LoadNextLevel", respawnSeconds);
    }


}
