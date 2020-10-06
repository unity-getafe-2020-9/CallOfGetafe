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
        salud=salud-danyo;
        sliderSalud.value = sliderSalud.maxValue - salud;
    }
    public void Morir()
    {

    }
}
