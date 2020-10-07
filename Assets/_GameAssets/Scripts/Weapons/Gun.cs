using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject proyectil;
    public Transform posInicio;
    public float fuerza;
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bala = Instantiate(proyectil, posInicio.position, posInicio.rotation);
            bala.GetComponent<Rigidbody>().AddForce(posInicio.forward * fuerza);
        }
    }
}
