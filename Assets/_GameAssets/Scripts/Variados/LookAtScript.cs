using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LookAtScript : MonoBehaviour
{
    [Tooltip("El Nombre del GameObject al que va a mirar el forward")]
    public string nombre;
    private GameObject target;

    private void Awake()
    {
        target = GameObject.Find(nombre);
    }

    void Update()
    {
        //transform.rotation = Quaternion.LookRotation(target.transform.position-transform.position);
        transform.LookAt(target.transform.position);
    }

    public int CalcularDoble(int numero)
    {
        return numero * 2;
    }
}
