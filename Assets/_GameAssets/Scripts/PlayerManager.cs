using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

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
    [SerializeField]
    private int armaActiva;

    private void Awake()
    {
        salud = saludMaxima;
        ActivarArma(armaActiva);
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
        if (other.gameObject.CompareTag("Cargador"))
        {
            int nc = other.gameObject.GetComponentInParent<CargadorGenerico>().numeroCargadores;
            armas[armaActiva].GetComponent<Weapon>().AgregarCargadores(nc);
            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        //Selección de armas
        for(int i = 1; i <= armas.Length; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                ActivarArma(i-1);
            } 
        }

        //Disparo
        if (Input.GetButtonDown("Fire1"))
        {
            armas[armaActiva].GetComponent<Weapon>().TryShoot();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            armas[armaActiva].GetComponent<Weapon>().Reload();
        }
    }
    public void ActivarArma(int idArma)
    {
        for(int i = 0; i < armas.Length; i++)
        {
            if (i == idArma)
            {
                armas[i].SetActive(true);
                armaActiva = i;
            } else
            {
                armas[i].SetActive(false);
            }
        }
    }
    
}
