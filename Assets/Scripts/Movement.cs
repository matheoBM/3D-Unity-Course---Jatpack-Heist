using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Exemplo de extrutura 
    //PARAMETERS - for tuning , typically set in editor
    //CACHE - e.g. references for redability speed
    //STATE - private instace (member) variables. ex. isAlive

    [SerializeField] float thrustSpeed = 1000f;
    [SerializeField] float rotationSpeed = 100f;
    [SerializeField] AudioClip thrustAudio;

    Rigidbody rb;
    AudioSource audioSource;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * Time.deltaTime * thrustSpeed);
            if (!audioSource.isPlaying)
            {
                Debug.Log("Audio Playing");
                audioSource.PlayOneShot(thrustAudio);
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationSpeed);
        }
    }

    private void ApplyRotation(float rotationThrust)
    {
        //Freeze the rotation before control
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThrust);
        rb.freezeRotation = false;
    }
}
