using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    private int salud;
    [SerializeField]
    private float danyoInfringido;
    [SerializeField]
    protected float velocidad;
    [SerializeField]
    private float distanciaAtaque;
    [SerializeField]
    private Slider sliderSalud;
    [SerializeField]
    private GameObject prefabExplossion;
    [SerializeField]
    private AudioClip explossionSound;
    [SerializeField]
    private AudioClip painSound;
    [SerializeField]
    private int points;

    void Start()
    {
        
    }

    void Update()
    {
        Mover();
    }

    public void Atacar()
    {

    }
    public abstract void Mover();//Sólo está declarado, NO está implementado
    
    public void Detectar()
    {

    }
    public void RecibirDanyo(int danyo)
    {
        GetComponent<AudioSource>().PlayOneShot(painSound);//PlayOneShot no para la reproducción anterior
        salud =salud-danyo;
        sliderSalud.value = sliderSalud.maxValue - salud;
        if (salud <= 0)
        {
            Morir();
        }
    }
    protected void Morir()
    {
        GameObject explosion = Instantiate(prefabExplossion, transform.position, transform.rotation);
        explosion.GetComponent<AudioSource>().clip = explossionSound;
        explosion.GetComponent<AudioSource>().Play();
        Destroy(gameObject);
    }
}
