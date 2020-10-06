using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DumbEnemy : Enemy
{
    [SerializeField]
    private float tiempoEntreRotaciones;
    [SerializeField]
    private float gradosRotacionMin;
    [SerializeField]
    private float gradosRotacionMax;

    private void Start()
    {
        InvokeRepeating("Rotar", tiempoEntreRotaciones, tiempoEntreRotaciones);
    }

    public override void Mover()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * velocidad);
    }

    private void Rotar()
    {
        transform.Rotate(0, Random.Range(gradosRotacionMin, gradosRotacionMax), 0);
    }
}
