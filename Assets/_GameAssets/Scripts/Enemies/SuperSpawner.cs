using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabEnemy;
    [SerializeField]
    private float tiempoEntreInstancias;
    [SerializeField]
    Transform[] posiciones;

    private int posicion = 0;

    void Start()
    {
        InvokeRepeating("SpawnearEnemigo", 0, tiempoEntreInstancias);
    }

    void SpawnearEnemigo()
    {
        /*
        //Secuencial
        Instantiate(prefabEnemy, posiciones[posicion].position, transform.rotation);
        posicion++;
        if (posicion == posiciones.Length)
        {
            posicion = 0;
        }
        */
        //Aleatorio
        Instantiate(prefabEnemy, posiciones[Random.Range(0,posiciones.Length)].position, transform.rotation);
    }
}
