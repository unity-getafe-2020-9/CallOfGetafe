using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilFisico : MonoBehaviour
{
    [SerializeField]
    public int danyo;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DumbEnemy de = collision.gameObject.GetComponent<DumbEnemy>();
            de.RecibirDanyo(danyo);
            Destroy(gameObject);
        }
    }
}
