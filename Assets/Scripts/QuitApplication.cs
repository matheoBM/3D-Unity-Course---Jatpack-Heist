using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    void Update()
    {
        ProcessQuitKey();
    }

    void ProcessQuitKey()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quiting Aplication");
            Application.Quit();
        }
    }
}
