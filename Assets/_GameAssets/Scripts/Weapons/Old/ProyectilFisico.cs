using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ProyectilFisico : MonoBehaviour
{
    [SerializeField]
    public int danyo;
    [SerializeField]
    private float timeToDestroy;

    private int vida;
    private void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy de = collision.gameObject.GetComponent<Enemy>();
            de.RecibirDanyo(danyo, transform.position);
            Destroy(gameObject);
        }
    }
}
