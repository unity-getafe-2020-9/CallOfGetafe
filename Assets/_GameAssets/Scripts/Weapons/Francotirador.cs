using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Francotirador : Weapon
{
    public GameObject imagenMirilla;
    public GameObject barraSalud;
    public GameObject arma;
    public FirstPersonController playerController;
    public int danyo;
    public float zoomSpeed;
    private float fov;

    private const float ZOOM_FOV=20;
    private const float NORMAL_FOV=60;
    private const float ZOOM_SENSITIVITY = 0.1f;
    private const float NORMAL_SENSITIVITY = 2f;

    private void Start()
    {
        fov = NORMAL_FOV;
    }

    public void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            HacerZoom();
        }
        else 
        {
            DeshacerZoom();
        }
    }

    private void HacerZoom()
    {
        fov = Mathf.Clamp(fov - Time.deltaTime * zoomSpeed, ZOOM_FOV, NORMAL_FOV);
        Camera.main.fieldOfView = fov;
        imagenMirilla.SetActive(true);
        barraSalud.SetActive(false);
        arma.SetActive(false);
        playerController.m_MouseLook.XSensitivity = ZOOM_SENSITIVITY;
        playerController.m_MouseLook.YSensitivity = ZOOM_SENSITIVITY;
    }

    private void DeshacerZoom()
    {
        if (fov >= NORMAL_FOV) return;

        fov = Mathf.Clamp(fov + Time.deltaTime * zoomSpeed, ZOOM_FOV, NORMAL_FOV);
        Camera.main.fieldOfView = fov;
        imagenMirilla.SetActive(false);
        barraSalud.SetActive(true);
        arma.SetActive(true);
        playerController.m_MouseLook.XSensitivity = NORMAL_SENSITIVITY;
        playerController.m_MouseLook.YSensitivity = NORMAL_SENSITIVITY;
    }

    public override void Shoot()
    {
        base.Shoot();
        RaycastHit hit;
        Vector3 origen = Camera.main.transform.position;
        Vector3 direccion = Camera.main.transform.forward;
        if (Physics.Raycast(origen, direccion, out hit))
        {
            //Entra si "choca" contra algo
            if (hit.transform.gameObject.CompareTag("Enemy")){
                hit.transform.gameObject.GetComponent<Enemy>().RecibirDanyo(danyo, hit.point);
            }
        }
    }
}
