using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Gun : MonoBehaviour
{
    public GameObject proyectil;
    public Transform posInicio;
    public float fuerza;

    public GameObject imagenMirilla;
    public GameObject barraSalud;
    public GameObject arma;
    public FirstPersonController playerController;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bala = Instantiate(proyectil, posInicio.position, posInicio.rotation);
            bala.GetComponent<Rigidbody>().AddForce(posInicio.forward * fuerza);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Camera.main.fieldOfView = 20;//HARDCODE = HATERS
            imagenMirilla.SetActive(true);
            barraSalud.SetActive(false);
            arma.SetActive(false);
            playerController.m_MouseLook.XSensitivity = 0.1f;
            playerController.m_MouseLook.YSensitivity = 0.1f;
        }
        if (Input.GetButtonUp("Fire2"))
        {
            Camera.main.fieldOfView = 60;//HARCODE = HATERS
            imagenMirilla.SetActive(false);
            barraSalud.SetActive(true);
            arma.SetActive(true);
            playerController.m_MouseLook.XSensitivity = 2f;
            playerController.m_MouseLook.YSensitivity = 2f;
        }
    }
}
