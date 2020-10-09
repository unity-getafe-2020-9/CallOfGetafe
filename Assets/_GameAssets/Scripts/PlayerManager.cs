using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private string nombre;
    [SerializeField]
    private int saludMaxima;
    [SerializeField]
    private int salud;
    [SerializeField]
    private GameObject[] armas;
    [SerializeField]
    private int puntuacion;
    [SerializeField]
    private bool escudo;
    [SerializeField]
    private bool llave;

    [SerializeField]
    GameObject healthBar;


    private void Awake()
    {
        salud = saludMaxima;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Camera.main.fieldOfView = 20;//HARDCODE = HATERS
        } 
        if (Input.GetButtonUp("Fire2"))
        {
            Camera.main.fieldOfView = 60;//HARCODE = HATERS
        }
    }

    public void Disparar()
    {

    }
    public void Morir()
    {

    }
    public void AbrirPuertas()
    {

    }
    public void RecuperarSalud()
    {

    }
    public void CogerEscudo()
    {

    }
    public void PerderEscudo()
    {
    }
    
    public void RecibirDanyo(int danyo)
    {
        salud = salud - danyo;
        healthBar.GetComponent<Image>().fillAmount = salud / ((float)saludMaxima);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Llave"))
        {
            Destroy(other.gameObject);
            /*
            GameObject objetoLlave = GameObject.Find("ImageKey");
            //Modificar el canal alpha
            Image imagenLlave = objetoLlave.GetComponent<Image>();
            Color nuevoColor = imagenLlave.color;
            nuevoColor.a = 255;
            imagenLlave.color = nuevoColor;
            */
            //Asignando un nuevo color
            GameObject.Find("ImageKey").GetComponent<Image>().color = Color.yellow;
        }
    }

}
