using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscilator : MonoBehaviour
{
    [SerializeField] Vector3 movementPosition;
    [SerializeField] float period;
    
    Vector3 startingPosition;

    float movementFactor;
    void Start()
    {
        startingPosition = transform.position;        
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) return;//Dont devide by zero

        float cycles = Time.time / period; //growing overtime
        const float tau = Mathf.PI * 2; //constant value of 6.283

        float rawSinWave = Mathf.Sin(tau * cycles); //Sin function: -1 to 1

        movementFactor = (rawSinWave + 1) / 2; //Scale factor between 0 and 1

        Vector3 offset = movementPosition * movementFactor;
        transform.position = startingPosition + offset;
        
    }
}
