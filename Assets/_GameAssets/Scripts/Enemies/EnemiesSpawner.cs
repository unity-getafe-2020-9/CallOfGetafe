using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabEnemy;
    [SerializeField]
    private float tiempoEntreInstancias;
    [SerializeField]
    private int numeroMaximoEnemigos;

    private int numeroEnemigosCreados = 0;
    private const float MIN_ANGLE = -180;
    private const float MAX_ANGLE = 180;

    void Start()
    {
        InvokeRepeating("SpawnearEnemigo", 0, tiempoEntreInstancias);
    }

    void SpawnearEnemigo()
    {
        Vector3 rotacion = new Vector3(0, Random.Range(MIN_ANGLE, MAX_ANGLE), 0);
        Instantiate(prefabEnemy, transform.position, Quaternion.Euler(rotacion));
        numeroEnemigosCreados++;
        if (numeroEnemigosCreados == numeroMaximoEnemigos)
        {
            CancelInvoke();
        }
    }
}
