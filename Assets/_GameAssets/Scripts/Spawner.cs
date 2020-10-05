using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabObjeto;
    public Transform spawnPointTransform;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //Instantiate(prefabObjeto, spawnPointTransform.position, Quaternion.identity);
            GameObject miNuevoObjeto = Instantiate(prefabObjeto, spawnPointTransform.position, Quaternion.identity);
            miNuevoObjeto.GetComponent<Rigidbody>().AddForce(spawnPointTransform.transform.forward, ForceMode.Impulse);
        }
    }
}
