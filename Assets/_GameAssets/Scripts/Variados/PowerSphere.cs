using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSphere : MonoBehaviour
{
    public int aportacionSalud;
    public float delayAcumulacion;
    private GameObject player;
    private PlayerManager pm;
    private void Start()
    {
        player = GameObject.Find("Player");
        pm = player.GetComponent<PlayerManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="Player")
        {
            //Comienza la carga
            StartCoroutine("CargarSalud");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            //Detiene la carga
            StopAllCoroutines();
        }
    }

    IEnumerator CargarSalud()
    {
        //while(true)
        while (!pm.TieneLaSaludATope())
        {
            pm.RecuperarSalud(aportacionSalud);
            yield return new WaitForSeconds(delayAcumulacion);
            //yield return null;//Sin demora
        }
    }
}
