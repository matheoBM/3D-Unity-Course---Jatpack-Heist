using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatKeys : MonoBehaviour
{
    Collider playerCollider;

    void Start()
    {
        playerCollider = GetComponent<Collider>();    
    }

    void Update()
    {
        ProcessKeyInput();
    }

    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            //Load Next Level
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            //Control collision
            ControlCollision();
        }
    }

    private static void LoadNextLevel()
    {
        int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevelIndex == SceneManager.sceneCount - 1)
        {
            nextLevelIndex = 0;
        }
        SceneManager.LoadScene(nextLevelIndex);
    }

    private void ControlCollision()
    {
        CollisionHandler colHandler = GetComponent<CollisionHandler>();
        colHandler.collisionDisabled = !colHandler.collisionDisabled;

    }
}
