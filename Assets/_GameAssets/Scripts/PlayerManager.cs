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
}
