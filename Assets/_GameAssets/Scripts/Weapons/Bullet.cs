using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int danyo;
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);//Destruye el objeto en el que está este script
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().RecibirDanyo(danyo);
        }
    }
}
