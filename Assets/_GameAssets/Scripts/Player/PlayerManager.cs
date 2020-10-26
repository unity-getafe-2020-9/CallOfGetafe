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
    private GameObject[] iconosArmas;
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
    [SerializeField]
    protected Text textAmmo;
    [SerializeField]
    protected Text textChargers;
    [SerializeField]
    private Image bloodImage;

    private static PlayerManager _instance;
    private void Awake()
    {
        //Patrón Singleton
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        salud = saludMaxima;
        ActivarArma(armaActiva);
    }

    
    private void Update()
    {
        ElegirArma();
        Disparar();
        Recargar();
    }
    public void ElegirArma()
    {
        //Selección de armas
        for (int i = 1; i <= armas.Length; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                ActivarArma(i - 1);
            }
        }
    }
    public void Disparar()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            armas[armaActiva].GetComponent<Weapon>().TryShoot();
        }
    }
    public void Recargar()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            armas[armaActiva].GetComponent<Weapon>().Reload();
        }
    }
    public void RecibirDanyo(int danyo)
    {
        salud = salud - danyo;
        PintarSalud();
        if (salud <= 0)
        {
            Morir();
        }
    }
    private void PintarSalud()
    {
        healthBar.GetComponent<Image>().fillAmount = salud / ((float)saludMaxima);
        //Cambio en el color de la sangre
        Color colorSangre = bloodImage.color;//Hacemos una copia del color
        colorSangre.a = 1 - (salud / (float)saludMaxima);//Modificamos el alpha
        bloodImage.color = colorSangre;//Hacemos el set del nuevo color modificado
    }
    public void Morir()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().HacerGameOver();
    }
    public void AbrirPuertas()
    {

    }
    public void RecuperarSalud(int incSalud)
    {
        salud += incSalud;
        salud = Mathf.Min(salud, saludMaxima);
        PintarSalud();
    }
    public void CogerEscudo()
    {

    }
    public void PerderEscudo()
    {
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
            GameManager.hasKey = true;
        }
        if (other.gameObject.CompareTag("Cargador"))
        {
            int nc = other.gameObject.GetComponentInParent<CargadorGenerico>().numeroCargadores;
            armas[armaActiva].GetComponent<Weapon>().AgregarCargadores(nc);
            Destroy(other.gameObject);
        }
    }
    public void ActivarArma(int idArma)
    {
        for(int i = 0; i < armas.Length; i++)
        {
            if (i == idArma)
            {
                armas[i].SetActive(true);
                iconosArmas[i].SetActive(true);
                armaActiva = i;

                int chargers = armas[i].GetComponent<Weapon>().chargers;
                int ammos = armas[i].GetComponent<Weapon>().ammos;

                textAmmo.text = ammos.ToString();
                textChargers.text = "x"+chargers.ToString();


            } else
            {
                armas[i].SetActive(false);
                iconosArmas[i].SetActive(false);
            }
        }
    }
    public bool TieneLaSaludATope()
    {
        if (salud>=saludMaxima)
        {
            return true;
        } else
        {
            return false;
        }

    }
}
