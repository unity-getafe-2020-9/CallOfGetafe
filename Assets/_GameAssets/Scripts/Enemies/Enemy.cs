﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(AudioSource))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    private int salud;
    [SerializeField]
    protected int danyoInfringido;
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
    [SerializeField]
    private GameObject prefabBlood;

    protected GameObject player;

    protected void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Mover();
        float distancia = CalcularDistanciaAlPlayer();
        if (distancia <= distanciaAtaque)
        {
            Atacar();
        }
    }

    public abstract void Atacar();
    public abstract void Mover();//Sólo está declarado, NO está implementado
   
    public void Detectar()
    {

    }
    public void RecibirDanyo(int danyo, Vector3 position)
    {
        GetComponent<AudioSource>().PlayOneShot(painSound);//PlayOneShot no para la reproducción anterior

        salud =salud-danyo;
        sliderSalud.value = sliderSalud.maxValue - salud;
        if (salud <= 0)
        {
            Morir();
        } else
        {
            Sangrar(position);
        }
    }
    protected void Morir()
    {
        GameObject explosion = Instantiate(prefabExplossion, transform.position, transform.rotation);
        explosion.GetComponent<AudioSource>().clip = explossionSound;
        explosion.GetComponent<AudioSource>().Play();
        Destroy(gameObject);
    }
    protected void Sangrar(Vector3 bloodPosition)
    {
        GameObject sangre = Instantiate(prefabBlood, bloodPosition, transform.rotation);
    }

    protected float CalcularDistanciaAlPlayer()
    {
        /*
        Vector3 vDistancia = player.transform.position - transform.position;
        float distancia = vDistancia.magnitude;
        */
        float distancia = Vector3.Distance(player.transform.position, transform.position);
        return distancia;
    }
}
