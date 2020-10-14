using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketExplosion : MonoBehaviour
{
    public int danyo;
    public float radioExplosion;
    public GameObject prefabExplosion;
    private void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radioExplosion);
        foreach(Collider c in colliders)
        {
            if (c.gameObject.CompareTag("Enemy"))
            {
                c.gameObject.GetComponentInParent<Enemy>().RecibirDanyo(danyo);
            }

            if (c.gameObject.CompareTag("Player"))
            {
                c.gameObject.GetComponentInParent<PlayerManager>().RecibirDanyo(danyo);
            }
        }

        Instantiate(prefabExplosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
