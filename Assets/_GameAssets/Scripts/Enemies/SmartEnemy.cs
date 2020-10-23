using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartEnemy : Enemy
{
    [SerializeField]
    private float tiempoEntreRotaciones;
    [SerializeField]
    private float gradosRotacionMin;
    [SerializeField]
    private float gradosRotacionMax;
    [SerializeField]
    protected float distanciaSeguimiento;
    [SerializeField]
    private float incrementoVelocidadAtaque;

    private float velocidadActual;

    protected void Start()
    {
        base.Start();
        InvokeRepeating("Rotar", tiempoEntreRotaciones, tiempoEntreRotaciones);
    }

    public override void Mover()
    {
        //La posición del player pero la Y del enemigo
        Vector3 target = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        if (CalcularDistanciaAlPlayer() <= distanciaSeguimiento)
        {
            transform.LookAt(target);
            velocidadActual = velocidad * incrementoVelocidadAtaque;
        } else
        {
            velocidadActual = velocidad;
        }
        transform.Translate(Vector3.forward * Time.deltaTime * velocidadActual);
    }

    private void Rotar()
    {
        if (CalcularDistanciaAlPlayer() > distanciaSeguimiento)
        {
            transform.Rotate(0, Random.Range(gradosRotacionMin, gradosRotacionMax), 0);
        }
    }

    public override void Atacar()
    {
        player.GetComponent<PlayerManager>().RecibirDanyo(danyoInfringido);
        Morir(true);
    }
}
