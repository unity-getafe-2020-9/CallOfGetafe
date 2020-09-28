using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotador : MonoBehaviour
{
    [Range(-200,200)]
    public float angularSpeed;
    
    void Update()
    {
        transform.Rotate(0, angularSpeed * Time.deltaTime, 0);
    }
}
