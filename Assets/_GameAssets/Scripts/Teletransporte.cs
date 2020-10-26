using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teletransporte : MonoBehaviour
{
    [SerializeField]
    private string sceneName;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Condición que evalue que tenemos la llave
            if (GameManager.hasKey == true)
            {
                GameManager.CargarEscena(sceneName);
            } else
            {
                //Avisa al usuario de que no tiene llave
            }
        }
    }
}