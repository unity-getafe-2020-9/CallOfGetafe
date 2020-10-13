using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public AudioClip acShoot;
    public AudioClip acReload;
    public AudioClip acStuck;
    public float cadency;//Tiempo entre disparos
    public int maxAmmoByCharger;//Número de balas por cargador
    public int maxCharger;//Número de cargadores posibles
    public int ammos;//Número de balas en el cargador "activo"
    public int chargers;//Número de cargadores

    public void TryShoot()
    {
        if (CanShoot())
        {
            Shoot();
        }
    }

    public void Reload()
    {
        if (chargers > 0)
        {
            PlayReloadSound();
            ammos = maxAmmoByCharger;
            chargers--;
        }
    }

    public virtual void Shoot() {
        PlayShootSound();
        ammos--;
    }
    public bool CanShoot()
    {
        /*
        * ammos > 0 && cadencia (1 segundo entre disparos)
        */
        if (ammos > 0)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public void PlayShootSound()
    {
        //reproducir el sonido del disparo
    }
    public void PlayReloadSound()
    {

    }
}
